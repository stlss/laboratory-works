namespace Pipes
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
            this.SuspendLayout();
            // 
            // _rtbMessages
            // 
            this._rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbMessages.Location = new System.Drawing.Point(0, 0);
            this._rtbMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._rtbMessages.Name = "_rtbMessages";
            this._rtbMessages.ReadOnly = true;
            this._rtbMessages.Size = new System.Drawing.Size(519, 252);
            this._rtbMessages.TabIndex = 0;
            this._rtbMessages.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 252);
            this.Controls.Add(this._rtbMessages);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _rtbMessages;
    }
}

