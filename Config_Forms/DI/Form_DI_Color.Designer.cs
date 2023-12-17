namespace Bachup_s_backup
{
    partial class Form_DI_Color
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
            colorDialog = new ColorDialog();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 39);
            label1.Name = "label1";
            label1.Size = new Size(175, 19);
            label1.TabIndex = 4;
            label1.Text = "Desktop Item BackColor";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.AppWorkspace;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(187, 33);
            label2.Name = "label2";
            label2.Size = new Size(141, 30);
            label2.TabIndex = 5;
            label2.Text = "Click to change";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 159);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Desktop Item";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.AppWorkspace;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(187, 70);
            label4.Name = "label4";
            label4.Size = new Size(141, 30);
            label4.TabIndex = 7;
            label4.Text = "Click to change";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(174, 19);
            label3.TabIndex = 6;
            label3.Text = "Desktop Item ForeColor";
            // 
            // Form_DI_Color
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "Form_DI_Color";
            Text = "global";
            Load += Form_DI_Color_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ColorDialog colorDialog;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
    }
}