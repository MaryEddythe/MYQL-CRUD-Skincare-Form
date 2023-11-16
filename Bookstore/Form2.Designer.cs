
namespace Bookstore
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btn_continue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_continue
            // 
            this.btn_continue.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_continue.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_continue.Location = new System.Drawing.Point(64, 474);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(167, 42);
            this.btn_continue.TabIndex = 0;
            this.btn_continue.Text = "Shop Now";
            this.btn_continue.UseVisualStyleBackColor = false;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1246, 688);
            this.Controls.Add(this.btn_continue);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Luminique";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_continue;
    }
}