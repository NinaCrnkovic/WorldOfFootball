﻿namespace WorldOfFootball
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pbSettings = new WorldOfFootball.CustomDesign.OvalPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(117)))));
            this.pnlHeader.Controls.Add(this.pbSettings);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Name = "pnlHeader";
            // 
            // pbSettings
            // 
            resources.ApplyResources(this.pbSettings, "pbSettings");
            this.pbSettings.BackColor = System.Drawing.Color.DarkGray;
            this.pbSettings.Image = global::WorldOfFootball.Properties.Resources.settings;
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::WorldOfFootball.Properties.Resources.Logo2;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pnlContainer
            // 
            resources.ApplyResources(this.pnlContainer, "pnlContainer");
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Click += new System.EventHandler(this.PnlContainer_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlHeader;
        private PictureBox pictureBox1;
        private Panel pnlContainer;
        private CustomDesign.OvalPictureBox pbSettings;
    }
}