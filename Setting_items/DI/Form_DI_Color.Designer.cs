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
            cancel = new Button();
            submit = new Button();
            DI_BackColor = new Label();
            colorDialog1 = new ColorDialog();
            DI_Defult = new Label();
            SuspendLayout();
            // 
            // cancel
            // 
            cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancel.Location = new Point(581, 406);
            cancel.Name = "cancel";
            cancel.Size = new Size(99, 32);
            cancel.TabIndex = 0;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // submit
            // 
            submit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            submit.Location = new Point(689, 406);
            submit.Name = "submit";
            submit.Size = new Size(99, 32);
            submit.TabIndex = 1;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = true;
            submit.Click += submit_Click;
            // 
            // DI_BackColor
            // 
            DI_BackColor.BackColor = SystemColors.AppWorkspace;
            DI_BackColor.ForeColor = SystemColors.ControlText;
            DI_BackColor.Location = new Point(73, 54);
            DI_BackColor.Name = "DI_BackColor";
            DI_BackColor.Size = new Size(240, 50);
            DI_BackColor.TabIndex = 2;
            DI_BackColor.Text = "Click to change DI_BackColor";
            DI_BackColor.TextAlign = ContentAlignment.MiddleCenter;
            DI_BackColor.DoubleClick += DI_BackColor_onDoubleClick;
            // 
            // DI_Defult
            // 
            DI_Defult.BackColor = SystemColors.AppWorkspace;
            DI_Defult.ForeColor = SystemColors.ControlText;
            DI_Defult.Location = new Point(73, 135);
            DI_Defult.Name = "DI_Defult";
            DI_Defult.Size = new Size(240, 50);
            DI_Defult.TabIndex = 3;
            DI_Defult.Text = "Click to change DI_Size";
            DI_Defult.TextAlign = ContentAlignment.MiddleCenter;
            DI_BackColor.DoubleClick += DI_Size_onDoubleClick;
            // 
            // Global
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(DI_Defult);
            Controls.Add(DI_BackColor);
            Controls.Add(submit);
            Controls.Add(cancel);
            Name = "Global";
            Text = "global";
            ResumeLayout(false);
        }

        #endregion

        private Button cancel;
        private Button submit;
        private Label DI_BackColor;
        private ColorDialog colorDialog1;
        private Label DI_Defult;
    }
}