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
            this.comileBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xmlTextBox
            // 
            this.xmlTextBox.Location = new System.Drawing.Point(12, 12);
            this.xmlTextBox.Name = "xmlTextBox";
            this.xmlTextBox.Size = new System.Drawing.Size(402, 503);
            this.xmlTextBox.TabIndex = 0;
            this.xmlTextBox.Text = "";
            // 
            // comileBtn
            // 
            this.comileBtn.Location = new System.Drawing.Point(420, 12);
            this.comileBtn.Name = "comileBtn";
            this.comileBtn.Size = new System.Drawing.Size(75, 23);
            this.comileBtn.TabIndex = 1;
            this.comileBtn.Text = "Запустить";
            this.comileBtn.UseVisualStyleBackColor = true;
            this.comileBtn.Click += new System.EventHandler(this.comileBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(420, 41);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 2;
            this.runBtn.Text = "Play";
            this.runBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(420, 70);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SimpleFacialAnimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 527);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.comileBtn);
            this.Controls.Add(this.xmlTextBox);
            this.Name = "SimpleFacialAnimationForm";
            this.Text = "Simple Facial Animation";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox xmlTextBox;
        private System.Windows.Forms.Button comileBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button button1;
    }
}