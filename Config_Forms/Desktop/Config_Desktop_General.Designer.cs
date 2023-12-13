namespace Bachup_s_backup.Setting_items.form1
{
    partial class Config_Desktop_General
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
            submit = new Button();
            cancel = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(138, 7);
            hScrollBar1.Minimum = 20;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(286, 24);
            hScrollBar1.TabIndex = 0;
            hScrollBar1.Value = 20;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // label1
            // 
            label1.Location = new Point(427, 2);
            label1.Name = "label1";
            label1.Size = new Size(179, 32);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // submit
            // 
            submit.Location = new Point(620, 158);
            submit.Name = "submit";
            submit.Size = new Size(94, 29);
            submit.TabIndex = 2;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = true;
            submit.Visible = false;
            submit.Click += onSubmit;
            // 
            // cancel
            // 
            cancel.Location = new Point(520, 158);
            cancel.Name = "cancel";
            cancel.Size = new Size(94, 29);
            cancel.TabIndex = 3;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Visible = false;
            cancel.Click += onCancel;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(123, 19);
            label2.TabIndex = 5;
            label2.Text = "Desktop Opacity";
            // 
            // Form_Opacity
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 199);
            Controls.Add(label2);
            Controls.Add(cancel);
            Controls.Add(submit);
            Controls.Add(label1);
            Controls.Add(hScrollBar1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Opacity";
            Text = "Form_Opacity";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HScrollBar hScrollBar1;
        private Label label1;
        private Button submit;
        private Button cancel;
        private Label label2;
    }
}