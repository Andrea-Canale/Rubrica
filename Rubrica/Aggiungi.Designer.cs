using System;
using System.Windows.Forms;

namespace Rubrica
{
    partial class Aggiungi
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
            this.userControl11 = new UserForms.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(0, 1);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(800, 450);
            this.userControl11.TabIndex = 0;
            this.userControl11.Disposed += new EventHandler((sender, e) => this.Dispose());
            // 
            // Aggiungi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControl11);
            this.Name = "Aggiungi";
            this.Text = "Aggiungi";
            this.ResumeLayout(false);

        }

        #endregion

        private UserForms.UserControl1 userControl11;
       
    }
}