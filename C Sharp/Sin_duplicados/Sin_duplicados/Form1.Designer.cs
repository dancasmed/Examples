namespace Sin_duplicados
{
    partial class Form1
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
            this.textBox_Lista_Original = new System.Windows.Forms.TextBox();
            this.textBox_Lista_Resultados = new System.Windows.Forms.TextBox();
            this.button_buscar_sin_duplicados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Lista_Original
            // 
            this.textBox_Lista_Original.Location = new System.Drawing.Point(13, 32);
            this.textBox_Lista_Original.Multiline = true;
            this.textBox_Lista_Original.Name = "textBox_Lista_Original";
            this.textBox_Lista_Original.Size = new System.Drawing.Size(131, 229);
            this.textBox_Lista_Original.TabIndex = 0;
            this.textBox_Lista_Original.Text = "Azucena\r\nRocio\r\nBugambilia\r\nTulipan";
            // 
            // textBox_Lista_Resultados
            // 
            this.textBox_Lista_Resultados.Location = new System.Drawing.Point(150, 32);
            this.textBox_Lista_Resultados.Multiline = true;
            this.textBox_Lista_Resultados.Name = "textBox_Lista_Resultados";
            this.textBox_Lista_Resultados.Size = new System.Drawing.Size(131, 229);
            this.textBox_Lista_Resultados.TabIndex = 1;
            // 
            // button_buscar_sin_duplicados
            // 
            this.button_buscar_sin_duplicados.Location = new System.Drawing.Point(13, 267);
            this.button_buscar_sin_duplicados.Name = "button_buscar_sin_duplicados";
            this.button_buscar_sin_duplicados.Size = new System.Drawing.Size(268, 23);
            this.button_buscar_sin_duplicados.TabIndex = 2;
            this.button_buscar_sin_duplicados.Text = "Buscar sin duplicados";
            this.button_buscar_sin_duplicados.UseVisualStyleBackColor = true;
            this.button_buscar_sin_duplicados.Click += new System.EventHandler(this.button_buscar_sin_duplicados_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 296);
            this.Controls.Add(this.button_buscar_sin_duplicados);
            this.Controls.Add(this.textBox_Lista_Resultados);
            this.Controls.Add(this.textBox_Lista_Original);
            this.Name = "Form1";
            this.Text = "Sin duplicados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Lista_Original;
        private System.Windows.Forms.TextBox textBox_Lista_Resultados;
        private System.Windows.Forms.Button button_buscar_sin_duplicados;
    }
}

