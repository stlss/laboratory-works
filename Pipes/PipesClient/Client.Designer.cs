namespace Pipes
{
    partial class frmMain
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
            this._btnSend = new System.Windows.Forms.Button();
            this._lblPipe = new System.Windows.Forms.Label();
            this._tbPipe = new System.Windows.Forms.TextBox();
            this._lblMessage = new System.Windows.Forms.Label();
            this._tbMessage = new System.Windows.Forms.TextBox();
            this._lbLogin = new System.Windows.Forms.Label();
            this._tbLogin = new System.Windows.Forms.TextBox();
            this._rtbMessages = new System.Windows.Forms.RichTextBox();
            this._btLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnSend
            // 
            this._btnSend.Enabled = false;
            this._btnSend.Location = new System.Drawing.Point(379, 114);
            this._btnSend.Margin = new System.Windows.Forms.Padding(4);
            this._btnSend.Name = "_btnSend";
            this._btnSend.Size = new System.Drawing.Size(135, 28);
            this._btnSend.TabIndex = 2;
            this._btnSend.Text = "Отправить";
            this._btnSend.UseVisualStyleBackColor = true;
            this._btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // _lblPipe
            // 
            this._lblPipe.AutoSize = true;
            this._lblPipe.Location = new System.Drawing.Point(16, 11);
            this._lblPipe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblPipe.Name = "_lblPipe";
            this._lblPipe.Size = new System.Drawing.Size(90, 32);
            this._lblPipe.TabIndex = 1;
            this._lblPipe.Text = "Введите имя\r\nканала";
            // 
            // _tbPipe
            // 
            this._tbPipe.Location = new System.Drawing.Point(120, 18);
            this._tbPipe.Margin = new System.Windows.Forms.Padding(4);
            this._tbPipe.Name = "_tbPipe";
            this._tbPipe.Size = new System.Drawing.Size(249, 22);
            this._tbPipe.TabIndex = 0;
            this._tbPipe.Text = "\\\\.\\pipe\\ServerPipe";
            // 
            // _lblMessage
            // 
            this._lblMessage.AutoSize = true;
            this._lblMessage.Location = new System.Drawing.Point(16, 120);
            this._lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(81, 16);
            this._lblMessage.TabIndex = 1;
            this._lblMessage.Text = "Сообщение";
            // 
            // _tbMessage
            // 
            this._tbMessage.Enabled = false;
            this._tbMessage.Location = new System.Drawing.Point(120, 117);
            this._tbMessage.Margin = new System.Windows.Forms.Padding(4);
            this._tbMessage.Name = "_tbMessage";
            this._tbMessage.Size = new System.Drawing.Size(249, 22);
            this._tbMessage.TabIndex = 1;
            this._tbMessage.TextChanged += new System.EventHandler(this.TbMessage_TextChanged);
            // 
            // _lbLogin
            // 
            this._lbLogin.AutoSize = true;
            this._lbLogin.Location = new System.Drawing.Point(16, 71);
            this._lbLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lbLogin.Name = "_lbLogin";
            this._lbLogin.Size = new System.Drawing.Size(46, 16);
            this._lbLogin.TabIndex = 3;
            this._lbLogin.Text = "Логин";
            // 
            // _tbLogin
            // 
            this._tbLogin.Location = new System.Drawing.Point(120, 68);
            this._tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this._tbLogin.Name = "_tbLogin";
            this._tbLogin.Size = new System.Drawing.Size(249, 22);
            this._tbLogin.TabIndex = 4;
            this._tbLogin.TextChanged += new System.EventHandler(this.TbLogin_TextChanged);
            // 
            // _rtbMessages
            // 
            this._rtbMessages.Location = new System.Drawing.Point(19, 158);
            this._rtbMessages.Name = "_rtbMessages";
            this._rtbMessages.ReadOnly = true;
            this._rtbMessages.Size = new System.Drawing.Size(495, 208);
            this._rtbMessages.TabIndex = 5;
            this._rtbMessages.Text = "";
            // 
            // _btLogin
            // 
            this._btLogin.Location = new System.Drawing.Point(379, 65);
            this._btLogin.Margin = new System.Windows.Forms.Padding(4);
            this._btLogin.Name = "_btLogin";
            this._btLogin.Size = new System.Drawing.Size(135, 28);
            this._btLogin.TabIndex = 6;
            this._btLogin.Text = "Авторизоваться";
            this._btLogin.UseVisualStyleBackColor = true;
            this._btLogin.Click += new System.EventHandler(this.BtLogin_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 378);
            this.Controls.Add(this._btLogin);
            this.Controls.Add(this._rtbMessages);
            this.Controls.Add(this._tbLogin);
            this.Controls.Add(this._lbLogin);
            this.Controls.Add(this._tbMessage);
            this.Controls.Add(this._lblMessage);
            this.Controls.Add(this._tbPipe);
            this.Controls.Add(this._lblPipe);
            this.Controls.Add(this._btnSend);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnSend;
        private System.Windows.Forms.Label _lblPipe;
        private System.Windows.Forms.TextBox _tbPipe;
        private System.Windows.Forms.Label _lblMessage;
        private System.Windows.Forms.TextBox _tbMessage;
        private System.Windows.Forms.Label _lbLogin;
        private System.Windows.Forms.TextBox _tbLogin;
        private System.Windows.Forms.RichTextBox _rtbMessages;
        private System.Windows.Forms.Button _btLogin;
    }
}