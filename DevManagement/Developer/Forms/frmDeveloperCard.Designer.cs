namespace DevManagement.Developer.Forms
{
    partial class frmDeveloperCard
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
            this.lblTitle = new Guna.UI.WinForms.GunaLabel();
            this.ctrlDeveloperCard1 = new DevManagement.Developer.Controls.ctrlDeveloperCard();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(776, 72);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Add New Developer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDeveloperCard1
            // 
            this.ctrlDeveloperCard1.Location = new System.Drawing.Point(124, 119);
            this.ctrlDeveloperCard1.Name = "ctrlDeveloperCard1";
            this.ctrlDeveloperCard1.Size = new System.Drawing.Size(559, 267);
            this.ctrlDeveloperCard1.TabIndex = 11;
            // 
            // frmDeveloperCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.ctrlDeveloperCard1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmDeveloperCard";
            this.Text = "frmDeveloperCard";
            this.Load += new System.EventHandler(this.frmDeveloperCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel lblTitle;
        private Controls.ctrlDeveloperCard ctrlDeveloperCard1;
    }
}