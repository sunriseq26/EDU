namespace RMI_Stavropol
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnTry = new System.Windows.Forms.Button();
            this.txtBoxEnter = new System.Windows.Forms.TextBox();
            this.btnPlayRestart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTask = new System.Windows.Forms.Label();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.lblHelp);
            this.grpBox.Controls.Add(this.lblCount);
            this.grpBox.Controls.Add(this.btnTry);
            this.grpBox.Controls.Add(this.txtBoxEnter);
            this.grpBox.Controls.Add(this.btnPlayRestart);
            this.grpBox.Controls.Add(this.btnExit);
            this.grpBox.Controls.Add(this.lblTask);
            this.grpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBox.Location = new System.Drawing.Point(2, 2);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(375, 222);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHelp.Location = new System.Drawing.Point(223, 66);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(79, 16);
            this.lblHelp.TabIndex = 13;
            this.lblHelp.Text = "Подсказка";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Enabled = false;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(31, 101);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(172, 18);
            this.lblCount.TabIndex = 12;
            this.lblCount.Text = "Количество попыток: 0";
            // 
            // btnTry
            // 
            this.btnTry.Enabled = false;
            this.btnTry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTry.Location = new System.Drawing.Point(128, 60);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(89, 26);
            this.btnTry.TabIndex = 11;
            this.btnTry.Text = "Проверить";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // txtBoxEnter
            // 
            this.txtBoxEnter.Enabled = false;
            this.txtBoxEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxEnter.Location = new System.Drawing.Point(30, 60);
            this.txtBoxEnter.MaxLength = 10;
            this.txtBoxEnter.Name = "txtBoxEnter";
            this.txtBoxEnter.Size = new System.Drawing.Size(92, 26);
            this.txtBoxEnter.TabIndex = 10;
            this.txtBoxEnter.TextChanged += new System.EventHandler(this.txtBoxEnter_TextChanged);
            this.txtBoxEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxEnter_KeyPress);
            // 
            // btnPlayRestart
            // 
            this.btnPlayRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlayRestart.Location = new System.Drawing.Point(214, 134);
            this.btnPlayRestart.Name = "btnPlayRestart";
            this.btnPlayRestart.Size = new System.Drawing.Size(131, 28);
            this.btnPlayRestart.TabIndex = 9;
            this.btnPlayRestart.Text = "Играть";
            this.btnPlayRestart.UseVisualStyleBackColor = true;
            this.btnPlayRestart.Click += new System.EventHandler(this.btnPlayRestart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(30, 134);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(131, 28);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTask.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTask.Location = new System.Drawing.Point(6, 16);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(341, 16);
            this.lblTask.TabIndex = 1;
            this.lblTask.Text = "Угадай число от 0 до 100. Я уже знаю его! =D";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 226);
            this.Controls.Add(this.grpBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnTry;
        private System.Windows.Forms.TextBox txtBoxEnter;
        private System.Windows.Forms.Button btnPlayRestart;
        private System.Windows.Forms.Button btnExit;
    }
}

