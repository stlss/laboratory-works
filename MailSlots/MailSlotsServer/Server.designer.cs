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
            this._rtbMessages = new System.Windows.Forms.RichTextBox();
            this._lblMailSlot = new System.Windows.Forms.Label();
            this._tbMailSlot = new System.Windows.Forms.TextBox();
            this._btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _rtbMessages
            // 
            this._rtbMessages.Location = new System.Drawing.Point(18, 62);
            this._rtbMessages.Margin = new System.Windows.Forms.Padding(4);
            this._rtbMessages.Name = "_rtbMessages";
            this._rtbMessages.ReadOnly = true;
            this._rtbMessages.Size = new System.Drawing.Size(493, 223);
            this._rtbMessages.TabIndex = 0;
            this._rtbMessages.Text = "";
            // 
            // _lblMailSlot
            // 
            this._lblMailSlot.AutoSize = true;
            this._lblMailSlot.Location = new System.Drawing.Point(18, 25);
            this._lblMailSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblMailSlot.Name = "_lblMailSlot";
            this._lblMailSlot.Size = new System.Drawing.Size(107, 16);
            this._lblMailSlot.TabIndex = 3;
            this._lblMailSlot.Text = "Имя мейлслота";
            // 
            // _tbMailSlot
            // 
            this._tbMailSlot.Location = new System.Drawing.Point(162, 22);
            this._tbMailSlot.Margin = new System.Windows.Forms.Padding(4);
            this._tbMailSlot.Name = "_tbMailSlot";
            this._tbMailSlot.Size = new System.Drawing.Size(200, 22);
            this._tbMailSlot.TabIndex = 4;
            this._tbMailSlot.Text = "ServerMailslot";
            // 
            // _btnConnect
            // 
            this._btnConnect.Location = new System.Drawing.Point(390, 18);
            this._btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this._btnConnect.Name = "_btnConnect";
            this._btnConnect.Size = new System.Drawing.Size(121, 32);
            this._btnConnect.TabIndex = 5;
            this._btnConnect.Text = "Изменить имя";
            this._btnConnect.UseVisualStyleBackColor = true;
            this._btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 304);
            this.Controls.Add(this._btnConnect);
            this.Controls.Add(this._tbMailSlot);
            this.Controls.Add(this._lblMailSlot);
            this.Controls.Add(this._rtbMessages);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox _rtbMessages;
        private System.Windows.Forms.Label _lblMailSlot;
        private System.Windows.Forms.TextBox _tbMailSlot;
        private System.Windows.Forms.Button _btnConnect;
    }
}

