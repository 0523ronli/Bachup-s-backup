using System.Windows.Forms;

namespace UItestv2
{
    partial class setting
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
            this.objectselector = new System.Windows.Forms.ComboBox();
            this.CLRinput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.changeCLRbrtn = new System.Windows.Forms.Button();
            this.debug1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // objectselector
            // 
            this.objectselector.FormattingEnabled = true;
            this.objectselector.Items.AddRange(new object[] {
            "主要填滿",
            "主要文字",
            "次要填滿",
            "次要文字",
            "選取顏色"});
            this.objectselector.Location = new System.Drawing.Point(125, 20);
            this.objectselector.Name = "objectselector";
            this.objectselector.Size = new System.Drawing.Size(138, 23);
            this.objectselector.TabIndex = 0;
            this.objectselector.SelectedIndexChanged += new System.EventHandler(this.objectselector_SelectedIndexChanged);
            // 
            // CLRinput
            // 
            this.CLRinput.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.CLRinput.Location = new System.Drawing.Point(275, 21);
            this.CLRinput.Name = "CLRinput";
            this.CLRinput.Size = new System.Drawing.Size(114, 25);
            this.CLRinput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "更變顏色";
            // 
            // changeCLRbrtn
            // 
            this.changeCLRbrtn.Location = new System.Drawing.Point(397, 21);
            this.changeCLRbrtn.Name = "changeCLRbrtn";
            this.changeCLRbrtn.Size = new System.Drawing.Size(86, 23);
            this.changeCLRbrtn.TabIndex = 3;
            this.changeCLRbrtn.Text = "確認";
            this.changeCLRbrtn.UseVisualStyleBackColor = true;
            this.changeCLRbrtn.Click += new System.EventHandler(this.changeCLRbrn_Click);
            // 
            // debug1
            // 
            this.debug1.AutoSize = true;
            this.debug1.Location = new System.Drawing.Point(27, 65);
            this.debug1.Name = "debug1";
            this.debug1.Size = new System.Drawing.Size(171, 25);
            this.debug1.TabIndex = 0;
            this.debug1.Text = "除錯:顯示左面板控制項";
            this.debug1.UseVisualStyleBackColor = true;
            this.debug1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 136);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "表單預設最大化";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(27, 170);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 19);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "無邊框表單";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.debug1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeCLRbrtn);
            this.Controls.Add(this.objectselector);
            this.Controls.Add(this.CLRinput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "setting";
            this.Text = "setting";
            this.Load += new System.EventHandler(this.setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox objectselector;
        private TextBox CLRinput;
        private Label label1;
        private Button changeCLRbrtn;
        private Button debug1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}