namespace Bachup_s_backup.Setting_items.form1
{
    partial class Form_Desktop_General
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
            hScrollBar1 = new HScrollBar();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(132, 23);
            hScrollBar1.Minimum = 20;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(286, 24);
            hScrollBar1.TabIndex = 0;
            hScrollBar1.Value = 20;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // label1
            // 
            label1.Location = new Point(421, 18);
            label1.Name = "label1";
            label1.Size = new Size(179, 32);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(123, 19);
            label2.TabIndex = 5;
            label2.Text = "Desktop Opacity";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(hScrollBar1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(884, 54);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // Form_Desktop_General
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 448);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Desktop_General";
            Text = "Form_Opacity";
            Load += Form_Desktop_General_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private HScrollBar hScrollBar1;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
    }
}