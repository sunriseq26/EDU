namespace Digest
{
    partial class About
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAboutName = new System.Windows.Forms.Label();
            this.lblAboutVersion = new System.Windows.Forms.Label();
            this.lblAboutOrg = new System.Windows.Forms.Label();
            this.lblAboutRights = new System.Windows.Forms.Label();
            this.lblAboutDitail = new System.Windows.Forms.Label();
            this.tbAbout = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.tbAbout);
            this.groupBox1.Controls.Add(this.lblAboutDitail);
            this.groupBox1.Controls.Add(this.lblAboutRights);
            this.groupBox1.Controls.Add(this.lblAboutOrg);
            this.groupBox1.Controls.Add(this.lblAboutVersion);
            this.groupBox1.Controls.Add(this.lblAboutName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblAboutName
            // 
            this.lblAboutName.AutoSize = true;
            this.lblAboutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAboutName.Location = new System.Drawing.Point(6, 24);
            this.lblAboutName.Name = "lblAboutName";
            this.lblAboutName.Size = new System.Drawing.Size(102, 16);
            this.lblAboutName.TabIndex = 0;
            this.lblAboutName.Text = "Справочник ";
            // 
            // lblAboutVersion
            // 
            this.lblAboutVersion.AutoSize = true;
            this.lblAboutVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAboutVersion.Location = new System.Drawing.Point(6, 40);
            this.lblAboutVersion.Name = "lblAboutVersion";
            this.lblAboutVersion.Size = new System.Drawing.Size(75, 16);
            this.lblAboutVersion.TabIndex = 1;
            this.lblAboutVersion.Text = "Версия 1.1";
            // 
            // lblAboutOrg
            // 
            this.lblAboutOrg.AutoSize = true;
            this.lblAboutOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAboutOrg.Location = new System.Drawing.Point(6, 56);
            this.lblAboutOrg.Name = "lblAboutOrg";
            this.lblAboutOrg.Size = new System.Drawing.Size(172, 16);
            this.lblAboutOrg.TabIndex = 2;
            this.lblAboutOrg.Text = "© 2020 Кустарников Иван";
            // 
            // lblAboutRights
            // 
            this.lblAboutRights.AutoSize = true;
            this.lblAboutRights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAboutRights.Location = new System.Drawing.Point(6, 72);
            this.lblAboutRights.Name = "lblAboutRights";
            this.lblAboutRights.Size = new System.Drawing.Size(148, 16);
            this.lblAboutRights.TabIndex = 3;
            this.lblAboutRights.Text = "Все права защищены.";
            // 
            // lblAboutDitail
            // 
            this.lblAboutDitail.AutoSize = true;
            this.lblAboutDitail.Location = new System.Drawing.Point(10, 116);
            this.lblAboutDitail.Name = "lblAboutDitail";
            this.lblAboutDitail.Size = new System.Drawing.Size(131, 13);
            this.lblAboutDitail.TabIndex = 4;
            this.lblAboutDitail.Text = "Информация о продукте";
            // 
            // tbAbout
            // 
            this.tbAbout.Location = new System.Drawing.Point(13, 133);
            this.tbAbout.Multiline = true;
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.Size = new System.Drawing.Size(405, 168);
            this.tbAbout.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(342, 318);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 371);
            this.Controls.Add(this.groupBox1);
            this.Name = "About";
            this.Text = "About";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAboutName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbAbout;
        private System.Windows.Forms.Label lblAboutDitail;
        private System.Windows.Forms.Label lblAboutRights;
        private System.Windows.Forms.Label lblAboutOrg;
        private System.Windows.Forms.Label lblAboutVersion;
    }
}