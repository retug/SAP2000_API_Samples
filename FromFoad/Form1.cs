using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SAP2000v1;

namespace MyFirstSap2000Plugin
{
    public partial class Form1 : Form
    {
        private cSapModel _SapModel = null;
        private cPluginCallback _Plugin = null;

        //initiate lists
        List<LoadCombination> LoadCombinationList;
        List<JointReaction> JointReactionList;
        List<FrameForce> FrameForceStartList;
        List<FrameForceEnd> FrameForceEndList;
        List<SelectedObjects> SelectedFrameObjectsList;
        List<FrameObj_GetNameList> FrameObj_GetNameList_List;
        //the unique label of the starting point in SAP


        public Form1(ref cSapModel SapModel, ref cPluginCallback Plugin)
        {
            this._SapModel = SapModel;
            this._Plugin = Plugin;
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(255, 140, 105), 1);
            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            System.Drawing.Drawing2D.LinearGradientBrush lGB2 = new System.Drawing.Drawing2D.LinearGradientBrush(area, Color.FromArgb(255, 255, 255), Color.FromArgb(159, 159, 159), LinearGradientMode.Vertical);
            mgraphics.FillRectangle(lGB2, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCombination_LstBox.SelectionMode = SelectionMode.MultiSimple;
            // do setup things here
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // must include a call to finish()
            _Plugin.Finish(0);
        }
        private void ShowLoadCommbinationsBtn_Click(object sender, EventArgs e)
        {
            int NumberNames = 1;
            string[] MyName = null;

            _SapModel.RespCombo.GetNameList(ref NumberNames, ref MyName);

            LoadCombinationList = new List<LoadCombination>();

            if (MyName!=null)
            {
                for (int i = 0; i < MyName.Length; i++)
                {
                    LoadCombination Lcomb = new LoadCombination();
                    Lcomb.NumberNames = NumberNames;
                    Lcomb.MyName = MyName[i];
                    LoadCombinationComBox.Items.Add(MyName[i]);
                    LoadCombinationList.Add(Lcomb);
                    LoadCombination_LstBox.Items.Add(MyName[i]);
                }
            }
            else
            {
                MessageBox.Show("Insure The Load Combination is exist.");
            }

        }
        private void ShowJointReactionForcesBtn_Click(object sender, EventArgs e)
        {
            string Name = "";
            //eItemTypeElm ItemTypeElm;
            int NumberResults = 1;
            string[] Obj=null;
            string[] Elm = null;
            string[] LoadCase = null;
            string[] StepType = null;
            double[] StepNum = null;
            double[] F1 = null;
            double[] F2 = null;
            double[] F3 = null;
            double[] M1 = null;
            double[] M2 = null;
            double[] M3 = null;

            bool isModelRunning = _SapModel.GetModelIsLocked();
            if (isModelRunning)
            {
                //clear all case and combo output selections
                _SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
                //set case and combo output selections
                _SapModel.Results.Setup.SetComboSelectedForOutput(LoadCombination_LstBox.SelectedItem.ToString());
                //get joint reactions
                _SapModel.Results.JointReact("1", eItemTypeElm.Element, ref NumberResults, ref Obj,ref Elm, ref LoadCase, ref StepType, ref StepNum,
                    ref F1, ref F2, ref F3,
                    ref M1, ref M2, ref M3);

                JointReactionList = new List<JointReaction>();
                JointReaction jReact = new JointReaction();

                jReact.Name = Name;
                jReact.LoadCase = LoadCase[0];
                jReact.F1 = F1[0];
                jReact.F2 = F2[0];
                jReact.F3 = F3[0];
                jReact.M1 = M1[0];
                jReact.M2 = M2[0];
                jReact.M3 = M3[0];

                JointReactionList.Add(jReact);

                dataGridView1.DataSource = JointReactionList;
            }
            else
            {
                DialogResult result = MessageBox.Show("the model is not run, Do you want Run the model ?", "Run Analysis", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result==DialogResult.Yes)
                {
                    _SapModel.Analyze.RunAnalysis();
                }
            }

        }

        private void ShowFrameReactionForcesBtn_Click(object sender, EventArgs e)
        {
            //clear all case and combo output selections
            _SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
            //set case and combo output selections
            _SapModel.Results.Setup.SetComboSelectedForOutput(LoadCombination_LstBox.SelectedItem.ToString());

            string Name = "1";
            eItemTypeElm ItemTypeElm;
            int NumberResults = 1;
            string[] Obj = null;
            double[] ObjSta = null;
            string[] Elm = null;
            double[] ElmSta = null;
            string[] LoadCase = null;
            string[] StepType = null;
            double[] StepNum = null;
            double[] P = null;
            double[] V2 = null;
            double[] V3 = null;
            double[] T = null;
            double[] M2 = null;
            double[] M3 = null;

            bool isModelRunning = _SapModel.GetModelIsLocked();
            if (isModelRunning)
            {

                //get Frame Force
                _SapModel.Results.FrameForce("1", eItemTypeElm.ObjectElm, ref NumberResults, ref Obj, ref ObjSta, ref Elm, ref ElmSta, ref LoadCase, ref StepType, ref StepNum,
                    ref P, ref V2, ref V3,
                    ref T, ref M2, ref M3);

                FrameForceStartList = new List<FrameForce>();
                FrameForceEndList = new List<FrameForceEnd>();

                if (LoadCase != null && P != null && V2 != null && V3 != null && T != null && M2 != null && M3 != null)
                {
 
                    FrameForce FrameReact = new FrameForce();

                    FrameReact.Name = Name;
                    FrameReact.LoadCase = LoadCase[0];
                    FrameReact.P = P[0];
                    FrameReact.V2 = V2[0];
                    FrameReact.V3 = V3[0];
                    FrameReact.T = T[0];
                    FrameReact.M2 = M2[0];
                    FrameReact.M3 = M3[0];

                    FrameForceStartList.Add(FrameReact);
                    FrameLoadDataGrid.DataSource = FrameForceStartList;


                    FrameForceEnd FrameReactEnd = new FrameForceEnd();

                    FrameReactEnd.LoadCase = LoadCase[0];
                    FrameReactEnd.P = P[NumberResults-1];
                    FrameReactEnd.V2 = V2[NumberResults-1];
                    FrameReactEnd.V3 = V3[NumberResults-1];
                    FrameReactEnd.T = T[NumberResults - 1];
                    FrameReactEnd.M2 = M2[NumberResults - 1];
                    FrameReactEnd.M3 = M3[NumberResults - 1];

                    FrameForceEndList.Add(FrameReactEnd);
                    dataGridView1.DataSource = FrameForceEndList;


                    //    for (int i = 0; i < NumberResults; i++)
                    //    {
                    //        FrameForce FrameReact = new FrameForce();
                    //        FrameReact.Name = "1";
                    //        FrameReact.LoadCase= LoadCase[i];
                    //        FrameReact.P= P[i];
                    //        FrameReact.V2= V2[i];
                    //        FrameReact.V3= V3[i];
                    //        FrameReact.T= T[i];
                    //        FrameReact.M2= M2[i];
                    //        FrameReact.M3= M3[i];

                    //        FrameForceList.Add(FrameReact);

                    //    }
                    //FrameLoadDataGrid.DataSource = FrameForceList;
                }
                else
                {
                    MessageBox.Show("داده‌های مورد نیاز برای این کاربر معتبر نیست.");
                }

            }
            else
            {
                DialogResult result_2 = MessageBox.Show("the model is not run, Do you want Run the model ?", "Run Analysis", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result_2 == DialogResult.Yes)
                {
                    _SapModel.Analyze.RunAnalysis();
                }
            }
        }

        private void GetFrameListBtn_Click(object sender, EventArgs e)
        {
            int NumberItems = 0;
            int[] ObjectType = null;
            string[] ObjectName = null;
            _SapModel.SelectObj.GetSelected(ref NumberItems, ref ObjectType, ref ObjectName);
            SelectedFrameObjectsList = new List<SelectedObjects>();
            FrameObj_GetNameList_List = new List<FrameObj_GetNameList>();

            // ensures users select an object first
            if (ObjectType == null)
            {
                MessageBox.Show("Select frame(s) first, then click the button");
            }
            else
            {
                for (int i = 0; i < ObjectType.Length; i++)
                {
                    SelectedObjects SelectedObject = new SelectedObjects();
                    SelectedObject.ObjectType = ObjectType[i];
                    SelectedObject.ObjectName = ObjectName[i];

                    int NumberFrame = 0;
                    string[] ObjectNameFrm = null;

                    //if the object type is 5, this is a Frame
                    if (ObjectType[i] == 2)
                    {

                        SelectedFrameObjectsList.Add(SelectedObject);
                        _SapModel.FrameObj.GetNameList(ref NumberFrame, ref ObjectNameFrm);

                        for (int j = 0; j < ObjectNameFrm.Length; j++)
                        {
                            FrameObj_GetNameList FrameObject = new FrameObj_GetNameList();
                            FrameObject.NumberNames = NumberFrame;
                            FrameObject.MyName = ObjectNameFrm[j];
                            FrameObj_GetNameList_List.Add(FrameObject);
                        }
                    }

                    else
                    {
                        ;
                    }
                    //writes data to data
                    //FrameListGrid.DataSource = SelectedFrameObjectsList;
                }
            }

            FrameListGrid.DataSource = SelectedFrameObjectsList;
        }

    }
}
