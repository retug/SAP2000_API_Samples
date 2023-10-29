namespace MyFirstSap2000Plugin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoadCombinationComBox = new System.Windows.Forms.ComboBox();
            this.ShowLoadCommbinationsBtn = new System.Windows.Forms.Button();
            this.LoadCombination_LstBox = new System.Windows.Forms.ListBox();
            this.FrameLoadDataGrid = new System.Windows.Forms.DataGridView();
            this.ShowFrameReactionForcesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowJointReactionForcesBtn = new System.Windows.Forms.Button();
            this.GetFrameListBtn = new System.Windows.Forms.Button();
            this.FrameListGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameLoadDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(337, 257);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(974, 165);
            this.dataGridView1.TabIndex = 1;
            // 
            // LoadCombinationComBox
            // 
            this.LoadCombinationComBox.FormattingEnabled = true;
            this.LoadCombinationComBox.Location = new System.Drawing.Point(1209, 425);
            this.LoadCombinationComBox.Margin = new System.Windows.Forms.Padding(1);
            this.LoadCombinationComBox.Name = "LoadCombinationComBox";
            this.LoadCombinationComBox.Size = new System.Drawing.Size(102, 21);
            this.LoadCombinationComBox.TabIndex = 2;
            // 
            // ShowLoadCommbinationsBtn
            // 
            this.ShowLoadCommbinationsBtn.Location = new System.Drawing.Point(13, 16);
            this.ShowLoadCommbinationsBtn.Margin = new System.Windows.Forms.Padding(1);
            this.ShowLoadCommbinationsBtn.Name = "ShowLoadCommbinationsBtn";
            this.ShowLoadCommbinationsBtn.Size = new System.Drawing.Size(160, 21);
            this.ShowLoadCommbinationsBtn.TabIndex = 0;
            this.ShowLoadCommbinationsBtn.Text = "Get Load Commbinations";
            this.ShowLoadCommbinationsBtn.UseVisualStyleBackColor = true;
            this.ShowLoadCommbinationsBtn.Click += new System.EventHandler(this.ShowLoadCommbinationsBtn_Click);
            // 
            // LoadCombination_LstBox
            // 
            this.LoadCombination_LstBox.FormattingEnabled = true;
            this.LoadCombination_LstBox.Location = new System.Drawing.Point(13, 47);
            this.LoadCombination_LstBox.Margin = new System.Windows.Forms.Padding(1);
            this.LoadCombination_LstBox.Name = "LoadCombination_LstBox";
            this.LoadCombination_LstBox.Size = new System.Drawing.Size(311, 160);
            this.LoadCombination_LstBox.TabIndex = 3;
            // 
            // FrameLoadDataGrid
            // 
            this.FrameLoadDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FrameLoadDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.FrameLoadDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FrameLoadDataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.FrameLoadDataGrid.Location = new System.Drawing.Point(337, 38);
            this.FrameLoadDataGrid.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.FrameLoadDataGrid.Name = "FrameLoadDataGrid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FrameLoadDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.FrameLoadDataGrid.RowHeadersWidth = 102;
            this.FrameLoadDataGrid.RowTemplate.Height = 40;
            this.FrameLoadDataGrid.Size = new System.Drawing.Size(974, 179);
            this.FrameLoadDataGrid.TabIndex = 1;
            // 
            // ShowFrameReactionForcesBtn
            // 
            this.ShowFrameReactionForcesBtn.Location = new System.Drawing.Point(334, 424);
            this.ShowFrameReactionForcesBtn.Margin = new System.Windows.Forms.Padding(1);
            this.ShowFrameReactionForcesBtn.Name = "ShowFrameReactionForcesBtn";
            this.ShowFrameReactionForcesBtn.Size = new System.Drawing.Size(156, 21);
            this.ShowFrameReactionForcesBtn.TabIndex = 4;
            this.ShowFrameReactionForcesBtn.Text = "Show Frame Reaction Forces";
            this.ShowFrameReactionForcesBtn.UseVisualStyleBackColor = true;
            this.ShowFrameReactionForcesBtn.Click += new System.EventHandler(this.ShowFrameReactionForcesBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End";
            // 
            // ShowJointReactionForcesBtn
            // 
            this.ShowJointReactionForcesBtn.Location = new System.Drawing.Point(1051, 425);
            this.ShowJointReactionForcesBtn.Margin = new System.Windows.Forms.Padding(1);
            this.ShowJointReactionForcesBtn.Name = "ShowJointReactionForcesBtn";
            this.ShowJointReactionForcesBtn.Size = new System.Drawing.Size(156, 21);
            this.ShowJointReactionForcesBtn.TabIndex = 0;
            this.ShowJointReactionForcesBtn.Text = "Show Joint Reaction Forces";
            this.ShowJointReactionForcesBtn.UseVisualStyleBackColor = true;
            this.ShowJointReactionForcesBtn.Click += new System.EventHandler(this.ShowJointReactionForcesBtn_Click);
            // 
            // GetFrameListBtn
            // 
            this.GetFrameListBtn.Location = new System.Drawing.Point(13, 224);
            this.GetFrameListBtn.Margin = new System.Windows.Forms.Padding(1);
            this.GetFrameListBtn.Name = "GetFrameListBtn";
            this.GetFrameListBtn.Size = new System.Drawing.Size(160, 21);
            this.GetFrameListBtn.TabIndex = 6;
            this.GetFrameListBtn.Text = "Get Frame List";
            this.GetFrameListBtn.UseVisualStyleBackColor = true;
            this.GetFrameListBtn.Click += new System.EventHandler(this.GetFrameListBtn_Click);
            // 
            // FrameListGrid
            // 
            this.FrameListGrid.AllowUserToDeleteRows = false;
            this.FrameListGrid.AllowUserToOrderColumns = true;
            this.FrameListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FrameListGrid.Location = new System.Drawing.Point(10, 257);
            this.FrameListGrid.Margin = new System.Windows.Forms.Padding(1);
            this.FrameListGrid.Name = "FrameListGrid";
            this.FrameListGrid.RowHeadersWidth = 102;
            this.FrameListGrid.RowTemplate.Height = 40;
            this.FrameListGrid.Size = new System.Drawing.Size(314, 471);
            this.FrameListGrid.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1751, 846);
            this.Controls.Add(this.FrameListGrid);
            this.Controls.Add(this.GetFrameListBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowFrameReactionForcesBtn);
            this.Controls.Add(this.LoadCombination_LstBox);
            this.Controls.Add(this.LoadCombinationComBox);
            this.Controls.Add(this.FrameLoadDataGrid);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ShowLoadCommbinationsBtn);
            this.Controls.Add(this.ShowJointReactionForcesBtn);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameLoadDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameListGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox LoadCombinationComBox;
        private System.Windows.Forms.Button ShowLoadCommbinationsBtn;
        private System.Windows.Forms.ListBox LoadCombination_LstBox;
        private System.Windows.Forms.DataGridView FrameLoadDataGrid;
        private System.Windows.Forms.Button ShowFrameReactionForcesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ShowJointReactionForcesBtn;
        private System.Windows.Forms.Button GetFrameListBtn;
        private System.Windows.Forms.DataGridView FrameListGrid;
    }
}