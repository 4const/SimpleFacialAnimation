namespace SimpleFacialAnimation
{
    partial class SimpleFacialAnimationForm
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
            this.xmlTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.compileBtn = new System.Windows.Forms.ToolStripButton();
            this.playBtn = new System.Windows.Forms.ToolStripButton();
            this.resetBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xmlTextBox
            // 
            this.xmlTextBox.Location = new System.Drawing.Point(0, 28);
            this.xmlTextBox.Name = "xmlTextBox";
            this.xmlTextBox.Size = new System.Drawing.Size(402, 474);
            this.xmlTextBox.TabIndex = 0;
            this.xmlTextBox.TabStop = false;
            this.xmlTextBox.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBtn,
            this.saveBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(440, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // loadBtn
            // 
            this.loadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadBtn.Image = global::SimpleFacialAnimation.Properties.Resources.load_2;
            this.loadBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.loadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(24, 24);
            this.loadBtn.ToolTipText = "Загрузить";
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBtn.Image = global::SimpleFacialAnimation.Properties.Resources.save;
            this.saveBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(24, 24);
            this.saveBtn.ToolTipText = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileBtn,
            this.playBtn,
            this.resetBtn});
            this.toolStrip2.Location = new System.Drawing.Point(404, 27);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(36, 476);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // compileBtn
            // 
            this.compileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compileBtn.Image = global::SimpleFacialAnimation.Properties.Resources.reload;
            this.compileBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.compileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compileBtn.Name = "compileBtn";
            this.compileBtn.Size = new System.Drawing.Size(34, 24);
            this.compileBtn.ToolTipText = "Обработать скрипт";
            this.compileBtn.Click += new System.EventHandler(this.compileBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playBtn.Image = global::SimpleFacialAnimation.Properties.Resources.play;
            this.playBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.playBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(34, 24);
            this.playBtn.ToolTipText = "Проиграть анимацию";
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetBtn.Image = global::SimpleFacialAnimation.Properties.Resources.reset;
            this.resetBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.resetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(34, 24);
            this.resetBtn.ToolTipText = "Сбросить ";
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // SimpleFacialAnimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(440, 503);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.xmlTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleFacialAnimationForm";
            this.Text = "Simple Facial Animation";
            this.Load += new System.EventHandler(this.SimpleFacialAnimationForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox xmlTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveBtn;
        private System.Windows.Forms.ToolStripButton loadBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton compileBtn;
        private System.Windows.Forms.ToolStripButton resetBtn;
        private System.Windows.Forms.ToolStripButton playBtn;
    }
}