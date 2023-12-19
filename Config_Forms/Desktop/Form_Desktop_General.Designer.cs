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
            groupBox2 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            colorDialog1 = new ColorDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(884, 54);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.AppWorkspace;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(208, 17);
            label4.Name = "label4";
            label4.Size = new Size(141, 30);
            label4.TabIndex = 9;
            label4.Text = "Click to change";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 23);
            label3.Name = "label3";
            label3.Size = new Size(186, 19);
            label3.TabIndex = 8;
            label3.Text = "Desktop Defult BackColor";
            // 
            // Form_Desktop_General
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 448);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Desktop_General";
            Text = "Form_Opacity";
            Load += Form_Desktop_General_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private HScrollBar hScrollBar1;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private ColorDialog colorDialog1;
    }
}