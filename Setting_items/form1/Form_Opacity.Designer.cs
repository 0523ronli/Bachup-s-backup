namespace Bachup_s_backup.Setting_items.form1
{
    partial class Form_Opacity
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
            SuspendLayout();
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(37, 109);
            hScrollBar1.Minimum = 20;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(338, 24);
            hScrollBar1.TabIndex = 0;
            hScrollBar1.Value = 20;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // label1
            // 
            label1.Location = new Point(130, 56);
            label1.Name = "label1";
            label1.Size = new Size(179, 32);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // submit
            // 
            submit.Location = new Point(430, 158);
            submit.Name = "submit";
            submit.Size = new Size(94, 29);
            submit.TabIndex = 2;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = true;
            submit.Click += onSubmit;
            // 
            // cancel
            // 
            cancel.Location = new Point(330, 158);
            cancel.Name = "cancel";
            cancel.Size = new Size(94, 29);
            cancel.TabIndex = 3;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += onCancel;
            // 
            // Form_Opacity
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 199);
            Controls.Add(cancel);
            Controls.Add(submit);
            Controls.Add(label1);
            Controls.Add(hScrollBar1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Opacity";
            Text = "Form_Opacity";
            ResumeLayout(false);
        }

        #endregion

        private HScrollBar hScrollBar1;
        private Label label1;
        private Button submit;
        private Button cancel;
    }
}