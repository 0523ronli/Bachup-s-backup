namespace Floating_Desktop
{
    partial class Form_Temps
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
            button2 = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(6, 61);
            button2.Name = "button2";
            button2.Size = new Size(185, 29);
            button2.TabIndex = 1;
            button2.Text = "Sync Files With Desktop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(6, 26);
            button1.Name = "button1";
            button1.Size = new Size(149, 29);
            button1.TabIndex = 2;
            button1.Text = "Open Temp Folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(726, 101);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Temp Folder";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 119);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(149, 23);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "double buffering";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form_Temps
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 450);
            Controls.Add(checkBox1);
            Controls.Add(groupBox1);
            Name = "Form_Temps";
            Text = "Form_Temps";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
    }
}