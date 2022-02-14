
namespace MatrixTransform
{
    partial class Scene
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.xTrackBar = new System.Windows.Forms.TrackBar();
            this.yTrackBar = new System.Windows.Forms.TrackBar();
            this.zTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(256, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 512);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // xTrackBar
            // 
            this.xTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xTrackBar.LargeChange = 30;
            this.xTrackBar.Location = new System.Drawing.Point(13, 536);
            this.xTrackBar.Maximum = 360;
            this.xTrackBar.Name = "xTrackBar";
            this.xTrackBar.Size = new System.Drawing.Size(1024, 45);
            this.xTrackBar.SmallChange = 5;
            this.xTrackBar.TabIndex = 17;
            this.xTrackBar.TickFrequency = 15;
            this.xTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.xTrackBar.Scroll += new System.EventHandler(this.xTrackBar_Scroll);
            // 
            // yTrackBar
            // 
            this.yTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yTrackBar.LargeChange = 30;
            this.yTrackBar.Location = new System.Drawing.Point(13, 587);
            this.yTrackBar.Maximum = 360;
            this.yTrackBar.Name = "yTrackBar";
            this.yTrackBar.Size = new System.Drawing.Size(1024, 45);
            this.yTrackBar.SmallChange = 5;
            this.yTrackBar.TabIndex = 18;
            this.yTrackBar.TickFrequency = 15;
            this.yTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.yTrackBar.Scroll += new System.EventHandler(this.yTrackBar_Scroll);
            // 
            // zTrackBar
            // 
            this.zTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zTrackBar.LargeChange = 30;
            this.zTrackBar.Location = new System.Drawing.Point(13, 638);
            this.zTrackBar.Maximum = 360;
            this.zTrackBar.Name = "zTrackBar";
            this.zTrackBar.Size = new System.Drawing.Size(1024, 45);
            this.zTrackBar.SmallChange = 5;
            this.zTrackBar.TabIndex = 19;
            this.zTrackBar.TickFrequency = 15;
            this.zTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.zTrackBar.Scroll += new System.EventHandler(this.zTrackBar_Scroll);
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 710);
            this.Controls.Add(this.zTrackBar);
            this.Controls.Add(this.yTrackBar);
            this.Controls.Add(this.xTrackBar);
            this.Controls.Add(this.panel1);
            this.Name = "Scene";
            this.Text = "Scene";
            this.Load += new System.EventHandler(this.Scene_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar xTrackBar;
        private System.Windows.Forms.TrackBar yTrackBar;
        private System.Windows.Forms.TrackBar zTrackBar;
    }
}