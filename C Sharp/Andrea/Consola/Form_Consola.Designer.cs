namespace Consola
{
    partial class Form_Consola
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
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_output
            // 
            this.textBox_output.BackColor = System.Drawing.Color.Black;
            this.textBox_output.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_output.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_output.Location = new System.Drawing.Point(0, 0);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.ReadOnly = true;
            this.textBox_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_output.Size = new System.Drawing.Size(729, 376);
            this.textBox_output.TabIndex = 0;
            this.textBox_output.TabStop = false;
            // 
            // textBox_input
            // 
            this.textBox_input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_input.Location = new System.Drawing.Point(0, 382);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(729, 20);
            this.textBox_input.TabIndex = 1;
            this.textBox_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_input_KeyPress);
            // 
            // Form_Consola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 402);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.textBox_output);
            this.Name = "Form_Consola";
            this.Text = "Artificial Network Dynamicly Redisigned  EA";
            this.Load += new System.EventHandler(this.Form_Consola_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.TextBox textBox_input;
    }
}

