namespace Floating_Desktop
{
    partial class DesktopItem
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
            Label_Name = new Label();
            label_folder = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            Label_Name.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label_Name.Location = new Point(12, 92);
            Label_Name.Name = "label1";
            Label_Name.Size = new Size(96, 19);
            Label_Name.TabIndex = 0;
            Label_Name.Text = "???";
            Label_Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_folder
            // 
            label_folder.AutoSize = true;
            label_folder.Location = new Point(-1, -1);
            label_folder.Name = "label_folder";
            label_folder.Size = new Size(24, 19);
            label_folder.TabIndex = 0;
            label_folder.Text = "📁";
            label_folder.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.OneDrive_Folder_Icon_svg;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // DesktopItem
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(120, 120);
            Controls.Add(label_folder);
            Controls.Add(Label_Name);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DesktopItem";
            Text = "DesktopItem";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_Name;
        private PictureBox pictureBox1;
        private Label label_folder;
    }
}