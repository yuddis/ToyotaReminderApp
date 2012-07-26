namespace Toyota_Reminder
{
    partial class ForgetPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxNPass = new System.Windows.Forms.TextBox();
            this.textBoxCNPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelNoteConPass = new System.Windows.Forms.Label();
            this.labelNotePass = new System.Windows.Forms.Label();
            this.labelNoteUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Toyota_Reminder.Properties.Resources.footer;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 62);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Confirm New Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Enabled = false;
            this.textBoxUsername.Location = new System.Drawing.Point(184, 81);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(181, 20);
            this.textBoxUsername.TabIndex = 8;
            // 
            // textBoxNPass
            // 
            this.textBoxNPass.Location = new System.Drawing.Point(184, 142);
            this.textBoxNPass.Name = "textBoxNPass";
            this.textBoxNPass.PasswordChar = '*';
            this.textBoxNPass.Size = new System.Drawing.Size(181, 20);
            this.textBoxNPass.TabIndex = 9;
            this.textBoxNPass.TextChanged += new System.EventHandler(this.textBoxNPass_TextChanged);
            this.textBoxNPass.Leave += new System.EventHandler(this.textBoxNPass_Leave);
            this.textBoxNPass.Enter += new System.EventHandler(this.textBoxNPass_Enter);
            // 
            // textBoxCNPass
            // 
            this.textBoxCNPass.Location = new System.Drawing.Point(184, 201);
            this.textBoxCNPass.Name = "textBoxCNPass";
            this.textBoxCNPass.PasswordChar = '*';
            this.textBoxCNPass.Size = new System.Drawing.Size(181, 20);
            this.textBoxCNPass.TabIndex = 10;
            this.textBoxCNPass.TextChanged += new System.EventHandler(this.textBoxCNPass_TextChanged_1);
            this.textBoxCNPass.Leave += new System.EventHandler(this.textBoxCNPass_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = ":";
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(80, 292);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 13;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(236, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelNoteConPass
            // 
            this.labelNoteConPass.AutoSize = true;
            this.labelNoteConPass.ForeColor = System.Drawing.Color.Blue;
            this.labelNoteConPass.Location = new System.Drawing.Point(185, 225);
            this.labelNoteConPass.Name = "labelNoteConPass";
            this.labelNoteConPass.Size = new System.Drawing.Size(0, 13);
            this.labelNoteConPass.TabIndex = 20;
            // 
            // labelNotePass
            // 
            this.labelNotePass.AutoSize = true;
            this.labelNotePass.ForeColor = System.Drawing.Color.Blue;
            this.labelNotePass.Location = new System.Drawing.Point(185, 171);
            this.labelNotePass.Name = "labelNotePass";
            this.labelNotePass.Size = new System.Drawing.Size(0, 13);
            this.labelNotePass.TabIndex = 19;
            // 
            // labelNoteUsername
            // 
            this.labelNoteUsername.AutoSize = true;
            this.labelNoteUsername.ForeColor = System.Drawing.Color.Blue;
            this.labelNoteUsername.Location = new System.Drawing.Point(187, 110);
            this.labelNoteUsername.Name = "labelNoteUsername";
            this.labelNoteUsername.Size = new System.Drawing.Size(0, 13);
            this.labelNoteUsername.TabIndex = 18;
            // 
            // ForgetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 343);
            this.Controls.Add(this.labelNoteConPass);
            this.Controls.Add(this.labelNotePass);
            this.Controls.Add(this.labelNoteUsername);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCNPass);
            this.Controls.Add(this.textBoxNPass);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ForgetPass";
            this.Text = "Form Forget Password";
            this.Load += new System.EventHandler(this.ForgetPass_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxNPass;
        private System.Windows.Forms.TextBox textBoxCNPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelNoteConPass;
        private System.Windows.Forms.Label labelNotePass;
        private System.Windows.Forms.Label labelNoteUsername;
    }
}