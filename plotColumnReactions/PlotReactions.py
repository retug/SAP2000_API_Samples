import comtypes.client
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.colors import LinearSegmentedColormap

#SAP2000 v26 model.


# Initialize SAP2000 API
def initialize_sap2000():
    try:
        sap_object = comtypes.client.GetActiveObject("CSI.SAP2000.API.SapObject")
    except (OSError, comtypes.COMError):
        # Create a new instance if one isn't open
        sap_object = comtypes.client.CreateObject("CSI.SAP2000.API.SapObject")
        sap_object.ApplicationStart()

    sap_model = sap_object.SapModel
    return sap_model

#extract a singular joint reeaction
def extract_joint_reaction(sap_model, joint):

    # Example for setting all joints -1 means all joints

    elementType = 0 #If this item is ObjectElm, the result request is for the point element corresponding to the point object specified by the Name item.
    NumberResults = 1;
    Obj = []
    Elm = []
    LoadCase = []
    StepType = []
    StepNum = []
    F1 = []
    F2 = []
    F3 = []
    M1 = []
    M2 = []
    M3 = []

    x = sap_model.Results.JointReact(joint, elementType, NumberResults, Obj, Elm, LoadCase, StepType, StepNum, F1, F2, F3, M1, M2, M3) #x[8] = F3 reactions (axial)

    X = 0
    Y = 0
    Z = 0
    coordinates = sap_model.PointObj.GetCoordCartesian(joint, X, Y, Z)

    joint_coords = [coordinates[0], coordinates[1]]

    #Return the X and Y Data of the point

    return x[8], joint_coords


sap_model = initialize_sap2000()

# Specify load case or combination for which to extract envelope reactions
load_case_name = "ASD ENVELOPE"  # Example load case, modify as needed

# Set results to be in local coordinates
sap_model.Results.Setup.DeselectAllCasesAndCombosForOutput()
sap_model.Results.Setup.SetComboSelectedForOutput(load_case_name)

group_name = "BRACE REACTIONS"
y = sap_model.GroupDef.GetAssignments(group_name)

joints = y[2]
plotting_data = []

for joint in joints:
    joint_reaction = extract_joint_reaction(sap_model, joint)
    plotting_data.append(joint_reaction)


XY_data = []
min_data = []
max_data = []
for data in plotting_data:
    XY_loc = data[1]
    XY_data.append(XY_loc)
    min_rxn = data[0][1]
    min_data.append(min_rxn)
    max_rxn = data[0][0]
    max_data.append(max_rxn)


# Separate the x and y coordinates
x = [loc[0] for loc in XY_data]
y = [loc[1] for loc in XY_data]

# Assuming you want to use max_data for the heatmap, but you can switch it with min_data if necessary
z = max_data  # This can be changed to min_data if needed

# Create a custom colormap that transitions from green (low) to red (high)
colors = [(0, 1, 0), (1, 0, 0)]  # Green to Red
n_bins = 100  # Define the number of color bins
cmap_name = 'green_red_map'
cm = LinearSegmentedColormap.from_list(cmap_name, colors, N=n_bins)

# Create heatmap
plt.figure(figsize=(8, 6))
plt.scatter(x, y, c=z, cmap=cm, s=100)  # Apply the custom colormap
plt.colorbar(label='Max Reaction')  # Label the color bar based on the z value


# Add text labels to show the max reaction values with an offset
offset_x = 0.05  # Adjust this value to control the horizontal offset
offset_y = 0.05  # Adjust this value to control the vertical offset

for i in range(len(x)):
    plt.text(x[i] + offset_x, y[i] + offset_y, f'{z[i]:.2f}', fontsize=9, ha='left', va='bottom', color='black')


plt.title('ASD Max Reactions (kip)')
plt.xlabel('X (ft)')
plt.ylabel('Y (ft)')

plt.show()
########################################################################################################################
# Plot 2: Min Reaction Heatmap
####################################################################################################################
# Use min_data for this plot
z_min = min_data

# Create color list based on the condition (red for negative, green for positive or zero)
colors = ['red' if value < 0 else 'green' for value in z_min]

# Plot 2: Min Reactions Scatter Plot (red for values < 0, green for >= 0)
plt.figure(figsize=(8, 6))

# Use the colors list to color the points in the scatter plot
plt.scatter(x, y, c=colors, s=100)

# Add text labels to show the min reaction values with an offset
offset_x = 0.10  # Adjust this value to control the horizontal offset
offset_y = 0.05  # Adjust this value to control the vertical offset

for i in range(len(x)):
    plt.text(x[i] + offset_x, y[i] + offset_y, f'{z_min[i]:.2f}', fontsize=12, ha='left', va='bottom', color='black')

plt.title('ASD Minimum Reactions (kip, - = uplift)')
plt.xlabel('X (ft)')
plt.ylabel('Y (ft)')

plt.show()

