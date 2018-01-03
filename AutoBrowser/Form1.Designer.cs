namespace AutoBrowser
{
    partial class FormAutoBrowser
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
            this.buttonSelectScript = new System.Windows.Forms.Button();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSelectScript
            // 
            this.buttonSelectScript.Location = new System.Drawing.Point(53, 12);
            this.buttonSelectScript.Name = "buttonSelectScript";
            this.buttonSelectScript.Size = new System.Drawing.Size(92, 23);
            this.buttonSelectScript.TabIndex = 0;
            this.buttonSelectScript.Text = "Select Script";
            this.buttonSelectScript.UseVisualStyleBackColor = true;
            this.buttonSelectScript.Click += new System.EventHandler(this.buttonSelectScript_Click);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(53, 41);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(92, 23);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // FormAutoBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 78);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.buttonSelectScript);
            this.Name = "FormAutoBrowser";
            this.Text = "AutoBrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectScript;
        private System.Windows.Forms.Button buttonExecute;
    }
}

