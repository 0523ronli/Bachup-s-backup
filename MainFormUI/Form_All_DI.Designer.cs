namespace Bachup_s_backup
{
    partial class Form_All_DI
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
            Grid1 = new DataGridView();
            Column_name = new DataGridViewTextBoxColumn();
            Column_path = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column_x = new DataGridViewTextBoxColumn();
            Column_y = new DataGridViewTextBoxColumn();
            Column_src = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
            SuspendLayout();
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid1.Columns.AddRange(new DataGridViewColumn[] { Column_name, Column_path, Column1, Column_x, Column_y, Column_src });
            Grid1.Location = new Point(12, 12);
            Grid1.Name = "Grid1";
            Grid1.RowHeadersWidth = 51;
            Grid1.RowTemplate.Height = 29;
            Grid1.Size = new Size(776, 426);
            Grid1.TabIndex = 0;
            // 
            // Column_name
            // 
            Column_name.HeaderText = "FileName";
            Column_name.MinimumWidth = 6;
            Column_name.Name = "Column_name";
            Column_name.ReadOnly = true;
            Column_name.Width = 104;
            // 
            // Column_path
            // 
            Column_path.HeaderText = "FilePath";
            Column_path.MinimumWidth = 6;
            Column_path.Name = "Column_path";
            Column_path.ReadOnly = true;
            Column_path.Width = 93;
            // 
            // Column1
            // 
            Column1.HeaderText = "NickName";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 111;
            // 
            // Column_x
            // 
            Column_x.HeaderText = "X";
            Column_x.MinimumWidth = 6;
            Column_x.Name = "Column_x";
            Column_x.Width = 48;
            // 
            // Column_y
            // 
            Column_y.HeaderText = "Y";
            Column_y.MinimumWidth = 6;
            Column_y.Name = "Column_y";
            Column_y.Width = 47;
            // 
            // Column_src
            // 
            Column_src.HeaderText = "src";
            Column_src.MinimumWidth = 6;
            Column_src.Name = "Column_src";
            Column_src.Visible = false;
            Column_src.Width = 58;
            // 
            // Form_All_DI
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Grid1);
            Name = "Form_All_DI";
            Text = "Form_All_DI";
            ((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Grid1;
        private DataGridViewTextBoxColumn Column_name;
        private DataGridViewTextBoxColumn Column_path;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column_x;
        private DataGridViewTextBoxColumn Column_y;
        private DataGridViewTextBoxColumn Column_src;
    }
}