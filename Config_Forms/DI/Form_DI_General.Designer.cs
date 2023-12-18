namespace Bachup_s_backup.Setting_items
{
    partial class Form_DI_General
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
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 111);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Icon Size";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 84);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(103, 23);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "Large Icon";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 55);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(122, 23);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "Medium Icon";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(102, 23);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Smail Icon";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(18, 129);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(185, 23);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Transparent Backcolor";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form_DI_General
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 320);
            Controls.Add(checkBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_DI_General";
            Text = "Form_DI_Size";
            Load += Form_DI_Size_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private CheckBox checkBox1;
    }
}