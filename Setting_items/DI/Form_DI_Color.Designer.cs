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
            DI_ForeColor = new Label();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
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
            DI_BackColor.Location = new Point(448, 90);
            DI_BackColor.Name = "DI_BackColor";
            DI_BackColor.Size = new Size(240, 50);
            DI_BackColor.TabIndex = 2;
            DI_BackColor.Text = "Click to change DI_BackColor";
            DI_BackColor.TextAlign = ContentAlignment.MiddleCenter;
            DI_BackColor.DoubleClick += DI_BackColor_onDoubleClick;
            // 
            // DI_ForeColor
            // 
            DI_ForeColor.BackColor = SystemColors.AppWorkspace;
            DI_ForeColor.ForeColor = SystemColors.ControlText;
            DI_ForeColor.Location = new Point(448, 23);
            DI_ForeColor.Name = "DI_ForeColor";
            DI_ForeColor.Size = new Size(240, 50);
            DI_ForeColor.TabIndex = 3;
            DI_ForeColor.Text = "Click to change DI_ForeColor";
            DI_ForeColor.TextAlign = ContentAlignment.MiddleCenter;
            DI_ForeColor.DoubleClick += DI_ForeColor_onDoubleClick;
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
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(DI_ForeColor);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(DI_BackColor);
            groupBox1.Controls.Add(label1);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 211);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Desktop Item";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(175, 19);
            label3.TabIndex = 6;
            label3.Text = "Desktop Item BackColor";
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
            // 
            // Form_DI_Color
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(submit);
            Controls.Add(cancel);
            Name = "Form_DI_Color";
            Text = "global";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button cancel;
        private Button submit;
        private Label DI_BackColor;
        private ColorDialog colorDialog1;
        private Label DI_ForeColor;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
    }
}