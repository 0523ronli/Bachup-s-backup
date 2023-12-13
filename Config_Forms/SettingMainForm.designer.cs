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
            foldablePanel.BackColor = Color.FromArgb(85, 85, 85);
            foldablePanel.Dock = DockStyle.Left;
            foldablePanel.Location = new Point(0, 0);
            foldablePanel.Margin = new Padding(0);
            foldablePanel.Name = "foldablePanel";
            foldablePanel.Size = new Size(200, 711);
            foldablePanel.TabIndex = 0;
            // 
            // centerPenal
            // 
            centerPenal.BackColor = SystemColors.ControlDarkDark;
            centerPenal.Dock = DockStyle.Fill;
            centerPenal.Location = new Point(200, 0);
            centerPenal.Margin = new Padding(0);
            centerPenal.Name = "centerPenal";
            centerPenal.Size = new Size(937, 711);
            centerPenal.TabIndex = 2;
            // 
            // SettingMainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1137, 711);
            Controls.Add(centerPenal);
            Controls.Add(foldablePanel);
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "SettingMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Setting";
            TopMost = true;
            Load += Mainform_Load;
            ResumeLayout(false);
        }

        #endregion

        public Panel foldablePanel;
        public Panel centerPenal;
    }
}