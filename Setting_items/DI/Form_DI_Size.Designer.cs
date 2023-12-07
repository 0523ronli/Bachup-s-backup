namespace Bachup_s_backup.Setting_items
{
    partial class Form_DI_Size
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
            submit = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // submit
            // 
            submit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            submit.Location = new Point(191, 109);
            submit.Name = "submit";
            submit.Size = new Size(94, 29);
            submit.TabIndex = 0;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = true;
            submit.Click += onSubmit;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Small (80 * 80)", "Medium (140 * 140)", "Large (200 * 200)" });
            comboBox1.Location = new Point(42, 45);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(169, 27);
            comboBox1.TabIndex = 1;
            // 
            // Form_DI_Size
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 174);
            Controls.Add(comboBox1);
            Controls.Add(submit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_DI_Size";
            Text = "Form_DI_Size";
            Load += Form_DI_Size_Load;
            ResumeLayout(false);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button submit;
        private ComboBox comboBox1;
    }
}