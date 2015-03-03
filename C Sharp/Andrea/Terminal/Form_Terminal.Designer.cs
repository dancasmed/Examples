namespace Terminal
{
    partial class Form_Terminal
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
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.textBox_Output = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Main.Controls.Add(this.textBox_Input, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.textBox_Output, 0, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 2;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.17073F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.829268F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(828, 367);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // textBox_Input
            // 
            this.textBox_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Input.Location = new System.Drawing.Point(3, 344);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(822, 20);
            this.textBox_Input.TabIndex = 1;
            this.textBox_Input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Input_KeyPress);
            // 
            // textBox_Output
            // 
            this.textBox_Output.BackColor = System.Drawing.Color.Black;
            this.textBox_Output.CausesValidation = false;
            this.textBox_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Output.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox_Output.Location = new System.Drawing.Point(3, 3);
            this.textBox_Output.Multiline = true;
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.ReadOnly = true;
            this.textBox_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Output.Size = new System.Drawing.Size(822, 335);
            this.textBox_Output.TabIndex = 0;
            this.textBox_Output.TabStop = false;
            // 
            // Form_Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 367);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "Form_Terminal";
            this.Text = "Artificial Neural Network Dynamicly Redesigned (Entidad Artificial)";
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.TextBox textBox_Output;
    }
}

