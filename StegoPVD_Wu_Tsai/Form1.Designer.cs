namespace StegoPVD_Wu_Tsai
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ImagePathTextBox = new System.Windows.Forms.RichTextBox();
            this.EncryptMsgTextBox = new System.Windows.Forms.RichTextBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DecryptMsgTextBox = new System.Windows.Forms.RichTextBox();
            this.DecryptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagePathTextBox
            // 
            this.ImagePathTextBox.Location = new System.Drawing.Point(241, 28);
            this.ImagePathTextBox.Name = "ImagePathTextBox";
            this.ImagePathTextBox.Size = new System.Drawing.Size(206, 29);
            this.ImagePathTextBox.TabIndex = 0;
            this.ImagePathTextBox.Text = "";
            // 
            // EncryptMsgTextBox
            // 
            this.EncryptMsgTextBox.Location = new System.Drawing.Point(73, 85);
            this.EncryptMsgTextBox.Name = "EncryptMsgTextBox";
            this.EncryptMsgTextBox.Size = new System.Drawing.Size(292, 105);
            this.EncryptMsgTextBox.TabIndex = 1;
            this.EncryptMsgTextBox.Text = "";
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(73, 206);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(107, 32);
            this.EncryptButton.TabIndex = 2;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(462, 28);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(110, 29);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(73, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 215);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(496, 260);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(292, 215);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // DecryptMsgTextBox
            // 
            this.DecryptMsgTextBox.Location = new System.Drawing.Point(496, 85);
            this.DecryptMsgTextBox.Name = "DecryptMsgTextBox";
            this.DecryptMsgTextBox.Size = new System.Drawing.Size(292, 105);
            this.DecryptMsgTextBox.TabIndex = 6;
            this.DecryptMsgTextBox.Text = "";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(496, 206);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(107, 32);
            this.DecryptButton.TabIndex = 7;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 607);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.DecryptMsgTextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.EncryptMsgTextBox);
            this.Controls.Add(this.ImagePathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ImagePathTextBox;
        private System.Windows.Forms.RichTextBox EncryptMsgTextBox;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox DecryptMsgTextBox;
        private System.Windows.Forms.Button DecryptButton;
    }
}

