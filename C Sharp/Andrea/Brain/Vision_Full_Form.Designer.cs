namespace Brain
{
    partial class Vision_Full_Form
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
            this.imageBox_Current_Frame = new Emgu.CV.UI.ImageBox();
            this.imageBox_face_1 = new Emgu.CV.UI.ImageBox();
            this.imageBox_face_2 = new Emgu.CV.UI.ImageBox();
            this.imageBox_face_3 = new Emgu.CV.UI.ImageBox();
            this.imageBox_face_4 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_Current_Frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_4)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox_Current_Frame
            // 
            this.imageBox_Current_Frame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.imageBox_Current_Frame.Location = new System.Drawing.Point(0, 120);
            this.imageBox_Current_Frame.Name = "imageBox_Current_Frame";
            this.imageBox_Current_Frame.Size = new System.Drawing.Size(474, 360);
            this.imageBox_Current_Frame.TabIndex = 2;
            this.imageBox_Current_Frame.TabStop = false;
            // 
            // imageBox_face_1
            // 
            this.imageBox_face_1.Location = new System.Drawing.Point(0, 12);
            this.imageBox_face_1.Name = "imageBox_face_1";
            this.imageBox_face_1.Size = new System.Drawing.Size(102, 102);
            this.imageBox_face_1.TabIndex = 2;
            this.imageBox_face_1.TabStop = false;
            // 
            // imageBox_face_2
            // 
            this.imageBox_face_2.Location = new System.Drawing.Point(108, 12);
            this.imageBox_face_2.Name = "imageBox_face_2";
            this.imageBox_face_2.Size = new System.Drawing.Size(102, 102);
            this.imageBox_face_2.TabIndex = 2;
            this.imageBox_face_2.TabStop = false;
            // 
            // imageBox_face_3
            // 
            this.imageBox_face_3.Location = new System.Drawing.Point(216, 12);
            this.imageBox_face_3.Name = "imageBox_face_3";
            this.imageBox_face_3.Size = new System.Drawing.Size(102, 102);
            this.imageBox_face_3.TabIndex = 2;
            this.imageBox_face_3.TabStop = false;
            // 
            // imageBox_face_4
            // 
            this.imageBox_face_4.Location = new System.Drawing.Point(324, 12);
            this.imageBox_face_4.Name = "imageBox_face_4";
            this.imageBox_face_4.Size = new System.Drawing.Size(102, 102);
            this.imageBox_face_4.TabIndex = 2;
            this.imageBox_face_4.TabStop = false;
            // 
            // Vision_Full_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 480);
            this.Controls.Add(this.imageBox_face_4);
            this.Controls.Add(this.imageBox_face_3);
            this.Controls.Add(this.imageBox_face_2);
            this.Controls.Add(this.imageBox_face_1);
            this.Controls.Add(this.imageBox_Current_Frame);
            this.Name = "Vision_Full_Form";
            this.Text = "Vision_Full_Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Vision_Full_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_Current_Frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_face_4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox_Current_Frame;
        private Emgu.CV.UI.ImageBox imageBox_face_1;
        private Emgu.CV.UI.ImageBox imageBox_face_2;
        private Emgu.CV.UI.ImageBox imageBox_face_3;
        private Emgu.CV.UI.ImageBox imageBox_face_4;
    }
}