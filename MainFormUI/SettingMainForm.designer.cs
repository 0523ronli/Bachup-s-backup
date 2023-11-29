using System.Drawing;
using System.Windows.Forms;

namespace UItestv2
{
    partial class SettingMainForm
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
            foldablePanel = new Panel();
            centerPenal = new Panel();
            SuspendLayout();
            // 
            // foldablePanel
            // 
            foldablePanel.AutoScroll = true;
            foldablePanel.BackColor = Color.FromArgb(75, 75, 75);
            foldablePanel.Dock = DockStyle.Left;
            foldablePanel.Location = new Point(0, 0);
            foldablePanel.Margin = new Padding(0);
            foldablePanel.Name = "foldablePanel";
            foldablePanel.Size = new Size(178, 561);
            foldablePanel.TabIndex = 0;
            // 
            // centerPenal
            // 
            centerPenal.BackColor = SystemColors.ActiveCaption;
            centerPenal.Dock = DockStyle.Fill;
            centerPenal.Location = new Point(178, 0);
            centerPenal.Margin = new Padding(0);
            centerPenal.Name = "centerPenal";
            centerPenal.Size = new Size(833, 561);
            centerPenal.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 561);
            Controls.Add(centerPenal);
            Controls.Add(foldablePanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "主視窗";
            Load += Mainform_Load;
            ResumeLayout(false);
        }

        #endregion

        public Panel foldablePanel;
        public Panel centerPenal;
    }
}