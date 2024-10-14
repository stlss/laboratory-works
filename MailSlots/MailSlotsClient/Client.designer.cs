namespace MailSlots
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnSend = new System.Windows.Forms.Button();
            this._tbMessage = new System.Windows.Forms.TextBox();
            this._lblMailSlot = new System.Windows.Forms.Label();
            this._btnConnect = new System.Windows.Forms.Button();
            this._lblMessage = new System.Windows.Forms.Label();
            this._tbMailSlot = new System.Windows.Forms.TextBox();
            this._lbLogin = new System.Windows.Forms.Label();
            this._tbLogin = new System.Windows.Forms.TextBox();
            this._rtbMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _btnSend
            // 
            this._btnSend.Enabled = false;
            this._btnSend.Location = new System.Drawing.Point(365, 94);
            this._btnSend.Margin = new System.Windows.Forms.Padding(4);
            this._btnSend.Name = "_btnSend";
            this._btnSend.Size = new System.Drawing.Size(121, 32);
            this._btnSend.TabIndex = 3;
            this._btnSend.Text = "Отправить";
            this._btnSend.UseVisualStyleBackColor = true;
            this._btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // _tbMessage
            // 
            this._tbMessage.Enabled = false;
            this._tbMessage.Location = new System.Drawing.Point(115, 99);
            this._tbMessage.Margin = new System.Windows.Forms.Padding(4);
            this._tbMessage.Name = "_tbMessage";
            this._tbMessage.Size = new System.Drawing.Size(240, 22);
            this._tbMessage.TabIndex = 1;
            this._tbMessage.TextChanged += new System.EventHandler(this.TbMessage_TextChanged);
            // 
            // _lblMailSlot
            // 
            this._lblMailSlot.AutoSize = true;
            this._lblMailSlot.Location = new System.Drawing.Point(9, 12);
            this._lblMailSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblMailSlot.Name = "_lblMailSlot";
            this._lblMailSlot.Size = new System.Drawing.Size(93, 32);
            this._lblMailSlot.TabIndex = 2;
            this._lblMailSlot.Text = "Введите имя \r\nмейлслота";
            // 
            // _btnConnect
            // 
            this._btnConnect.Location = new System.Drawing.Point(365, 50);
            this._btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this._btnConnect.Name = "_btnConnect";
            this._btnConnect.Size = new System.Drawing.Size(121, 32);
            this._btnConnect.TabIndex = 2;
            this._btnConnect.Text = "Подключиться";
            this._btnConnect.UseVisualStyleBackColor = true;
            this._btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // _lblMessage
            // 
            this._lblMessage.AutoSize = true;
            this._lblMessage.Location = new System.Drawing.Point(9, 102);
            this._lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(81, 16);
            this._lblMessage.TabIndex = 2;
            this._lblMessage.Text = "Сообщение";
            // 
            // _tbMailSlot
            // 
            this._tbMailSlot.Location = new System.Drawing.Point(115, 12);
            this._tbMailSlot.Margin = new System.Windows.Forms.Padding(4);
            this._tbMailSlot.Name = "_tbMailSlot";
            this._tbMailSlot.Size = new System.Drawing.Size(240, 22);
            this._tbMailSlot.TabIndex = 0;
            this._tbMailSlot.Text = "\\\\.\\mailslot\\ServerMailslot";
            this._tbMailSlot.TextChanged += new System.EventHandler(this.TbMailSlot_TextChanged);
            // 
            // _lbLogin
            // 
            this._lbLogin.AutoSize = true;
            this._lbLogin.Location = new System.Drawing.Point(9, 58);
            this._lbLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lbLogin.Name = "_lbLogin";
            this._lbLogin.Size = new System.Drawing.Size(46, 16);
            this._lbLogin.TabIndex = 5;
            this._lbLogin.Text = "Логин";
            // 
            // _tbLogin
            // 
            this._tbLogin.Location = new System.Drawing.Point(115, 55);
            this._tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this._tbLogin.Name = "_tbLogin";
            this._tbLogin.Size = new System.Drawing.Size(240, 22);
            this._tbLogin.TabIndex = 4;
            this._tbLogin.TextChanged += new System.EventHandler(this.TbLogin_TextChanged);
            // 
            // _rtbMessages
            // 
            this._rtbMessages.Location = new System.Drawing.Point(12, 141);
            this._rtbMessages.Name = "_rtbMessages";
            this._rtbMessages.ReadOnly = true;
            this._rtbMessages.Size = new System.Drawing.Size(474, 208);
            this._rtbMessages.TabIndex = 6;
            this._rtbMessages.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 359);
            this.Controls.Add(this._rtbMessages);
            this.Controls.Add(this._lbLogin);
            this.Controls.Add(this._tbLogin);
            this.Controls.Add(this._tbMailSlot);
            this.Controls.Add(this._lblMessage);
            this.Controls.Add(this._lblMailSlot);
            this.Controls.Add(this._tbMessage);
            this.Controls.Add(this._btnConnect);
            this.Controls.Add(this._btnSend);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnSend;
        private System.Windows.Forms.TextBox _tbMessage;
        private System.Windows.Forms.Label _lblMailSlot;
        private System.Windows.Forms.Button _btnConnect;
        private System.Windows.Forms.Label _lblMessage;
        private System.Windows.Forms.TextBox _tbMailSlot;
        private System.Windows.Forms.Label _lbLogin;
        private System.Windows.Forms.TextBox _tbLogin;
        private System.Windows.Forms.RichTextBox _rtbMessages;
    }
}

