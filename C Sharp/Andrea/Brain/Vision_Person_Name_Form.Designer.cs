namespace Brain
{
    partial class Vision_Person_Name_Form
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
            this.components = new System.ComponentModel.Container();
            this.imageBox_Picture = new Emgu.CV.UI.ImageBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox_Picture
            // 
            this.imageBox_Picture.Location = new System.Drawing.Point(12, 12);
            this.imageBox_Picture.Name = "imageBox_Picture";
            this.imageBox_Picture.Size = new System.Drawing.Size(195, 193);
            this.imageBox_Picture.TabIndex = 2;
            this.imageBox_Picture.TabStop = false;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(53, 215);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(96, 20);
            this.textBox_Name.TabIndex = 3;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(12, 218);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(35, 13);
            this.label_Name.TabIndex = 4;
            this.label_Name.Text = "Name";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(156, 215);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(51, 23);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // Vision_Person_Name_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 238);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.imageBox_Picture);
            this.Name = "Vision_Person_Name_Form";
            this.Text = "Set person name";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox_Picture;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Button button_Save;
    }
}