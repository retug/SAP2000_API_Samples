import comtypes.client
import math
import matplotlib.pyplot as plt
import numpy as np
import matplotlib.colors as mcolors

import pandas as pd

#Using Comtypes 1.1.14
#boiler plate code to attach to the SAP model
SapObject=comtypes.client.GetActiveObject("CSI.SAP2000.API.SapObject")
SapModel = SapObject.SapModel

objects = SapModel.SelectObj.GetSelected()
point_obj = []
#From our selected objects, we need to filter out just the nodes
for type_obj , point_num in zip(objects[1],objects[2]) :
    if type_obj == 1 : #1 = points
        point_obj.append(point_num)
    else :
        pass
    
NumberTables = 1
TableKey = []
TableName = []
ImportType = []


PointData = []
#pull x and y data
for pnt in point_obj:
    PointData.append(SapModel.PointObj.GetCoordCartesian(pnt)[0:2])
    
# Convert to numpy array for easier manipulation
PointData = np.array(PointData)
x_coords = PointData[:, 0]
y_coords = PointData[:, 1]
     

# this shows all the available tabes that can be accessed
x = SapModel.DatabaseTables.GetAvailableTables(NumberTables,TableKey, TableName, ImportType)
    
TableKey = 'Joint Accelerations - Relative'
FieldKeyList = []

SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
loadCase = 'Steady State - #1 Loc'
SapModel.Results.Setup.SetCaseSelectedForOutput(loadCase)


TableKey = 'Joint Accelerations - Relative'

# set the group you want the results for, you can pick either 'All', 'Left Nodes', 'Right Nodes'
GroupName = 'nodesOfInterest'

TableVersion = 1
FieldsKeysIncluded = []
NumberRecords = 1
TableData = []

##This is a very large set of data, unorganized. Let's break it down. Every 226 items it repeats, 226 items to one node
JointAccelerations = SapModel.DatabaseTables.GetTableforDisplayArray(TableKey, FieldKeyList, GroupName, TableVersion, FieldsKeysIncluded, NumberRecords, TableData)

joint_size = 226*12 #226 entries and 11 data points per entry
#BE VERY CAREFUL NONE TYPE OBJECT IN JOINT ACCELERATIONS THAT DOES NOT APPEAR IN TABLE on JOINT ACCELERATIONS. Had 11, but needs to be 12. 
#Tables often do not match returned response.
jointAcceleration = []


for i in range(0, len(JointAccelerations[4]), joint_size):
    jointAcceleration.append(JointAccelerations[4][i:i + joint_size])
    

joint_fequency = []
joint_accel = []


for joint in jointAcceleration:
    table_feq = []
    table_accel = []
    for i in range(0, int(len(joint) / 12)):
        table_feq.append(joint[i*12 + 4])  # 5th element
        table_accel.append(joint[i*12 + 8]) # 8th element
    joint_fequency.append(table_feq)
    joint_accel.append(table_accel)
    
max_accel_node = []
freq_at_max_accel  = []

for freq, accel in zip(joint_fequency, joint_accel):
    max_accel = max(accel)
    max_index = accel.index(max_accel)
    corresponding_freq = freq[max_index]
    
    max_accel_node.append(float(max_accel))  # Convert to float
    freq_at_max_accel.append(corresponding_freq)
    

# Normalize the acceleration values
norm = mcolors.Normalize(vmin=min(max_accel_node), vmax=max(max_accel_node))

# Create the heat map
plt.figure(figsize=(10, 8))
scatter = plt.scatter(x_coords, y_coords, c=max_accel_node, cmap='viridis', norm=norm, marker='o')
plt.colorbar(scatter, label='Max Acceleration')
plt.xlabel('X Coordinate')
plt.ylabel('Y Coordinate')
plt.title('Heat Map of Max Acceleration at Coordinates')

# Add labels to each point
# Add labels to each point
for i in range(len(x_coords)):
    plt.text(x_coords[i], y_coords[i], f'({int(x_coords[i])}, {int(y_coords[i])})', fontsize=8, ha='right')
plt.show()









