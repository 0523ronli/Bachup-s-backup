using System.Drawing;
using System.Windows.Forms;

namespace UItestv2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.foldablePanel = new System.Windows.Forms.Panel();
            this.centerPenal = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // foldablePanel
            // 
            this.foldablePanel.AutoScroll = true;
            this.foldablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.foldablePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.foldablePanel.Location = new System.Drawing.Point(0, 0);
            this.foldablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.foldablePanel.Name = "foldablePanel";
            this.foldablePanel.Size = new System.Drawing.Size(178, 561);
            this.foldablePanel.TabIndex = 0;
            // 
            // centerPenal
            // 
            this.centerPenal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.centerPenal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPenal.Location = new System.Drawing.Point(178, 0);
            this.centerPenal.Margin = new System.Windows.Forms.Padding(0);
            this.centerPenal.Name = "centerPenal";
            this.centerPenal.Size = new System.Drawing.Size(833, 561);
            this.centerPenal.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 561);
            this.Controls.Add(this.centerPenal);
            this.Controls.Add(this.foldablePanel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "主視窗";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel foldablePanel;
        public Panel centerPenal;
    }
}