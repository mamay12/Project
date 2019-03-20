namespace Project
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.reg_button = new System.Windows.Forms.Button();
            this.del_change_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.del_change_button);
            this.panel1.Controls.Add(this.reg_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 624);
            this.panel1.TabIndex = 7;
            // 
            // reg_button
            // 
            this.reg_button.Location = new System.Drawing.Point(12, 583);
            this.reg_button.Name = "reg_button";
            this.reg_button.Size = new System.Drawing.Size(206, 29);
            this.reg_button.TabIndex = 8;
            this.reg_button.Text = "Регистрация нового пользователя";
            this.reg_button.UseVisualStyleBackColor = true;
            this.reg_button.Click += new System.EventHandler(this.reg_button_Click);
            // 
            // del_change_button
            // 
            this.del_change_button.Location = new System.Drawing.Point(12, 533);
            this.del_change_button.Name = "del_change_button";
            this.del_change_button.Size = new System.Drawing.Size(206, 44);
            this.del_change_button.TabIndex = 8;
            this.del_change_button.Text = "Удалить пользователя/изменить данные для входа";
            this.del_change_button.UseVisualStyleBackColor = true;
            this.del_change_button.Click += new System.EventHandler(this.del_change_button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 624);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
//            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button reg_button;
        public System.Windows.Forms.Button del_change_button;
    }
}