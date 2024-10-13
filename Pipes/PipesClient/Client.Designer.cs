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
            this.SuspendLayout();
            // 
            // _btnSend
            // 
            this._btnSend.Enabled = false;
            this._btnSend.Location = new System.Drawing.Point(379, 65);
            this._btnSend.Margin = new System.Windows.Forms.Padding(4);
            this._btnSend.Name = "_btnSend";
            this._btnSend.Size = new System.Drawing.Size(100, 28);
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
            this._lblMessage.Location = new System.Drawing.Point(16, 71);
            this._lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(81, 16);
            this._lblMessage.TabIndex = 1;
            this._lblMessage.Text = "Сообщение";
            // 
            // _tbMessage
            // 
            this._tbMessage.Location = new System.Drawing.Point(120, 68);
            this._tbMessage.Margin = new System.Windows.Forms.Padding(4);
            this._tbMessage.Name = "_tbMessage";
            this._tbMessage.Size = new System.Drawing.Size(249, 22);
            this._tbMessage.TabIndex = 1;
            this._tbMessage.TextChanged += new System.EventHandler(this.TbMessage_TextChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 111);
            this.Controls.Add(this._tbMessage);
            this.Controls.Add(this._lblMessage);
            this.Controls.Add(this._tbPipe);
            this.Controls.Add(this._lblPipe);
            this.Controls.Add(this._btnSend);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnSend;
        private System.Windows.Forms.Label _lblPipe;
        private System.Windows.Forms.TextBox _tbPipe;
        private System.Windows.Forms.Label _lblMessage;
        private System.Windows.Forms.TextBox _tbMessage;
    }
}