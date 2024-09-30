namespace GetCompanyPublicIP
{
    partial class Form_GetIp
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_IpShow = new System.Windows.Forms.TextBox();
            this.btn_GetIp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ServerIp = new System.Windows.Forms.TextBox();
            this.btn_SaveServerIp = new System.Windows.Forms.Button();
            this.btn_demoip = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_IpShow
            // 
            this.textBox_IpShow.Location = new System.Drawing.Point(108, 78);
            this.textBox_IpShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_IpShow.Name = "textBox_IpShow";
            this.textBox_IpShow.Size = new System.Drawing.Size(206, 28);
            this.textBox_IpShow.TabIndex = 0;
            // 
            // btn_GetIp
            // 
            this.btn_GetIp.Location = new System.Drawing.Point(747, 81);
            this.btn_GetIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_GetIp.Name = "btn_GetIp";
            this.btn_GetIp.Size = new System.Drawing.Size(112, 34);
            this.btn_GetIp.TabIndex = 1;
            this.btn_GetIp.Text = "取得Ip";
            this.btn_GetIp.UseVisualStyleBackColor = true;
            this.btn_GetIp.Click += new System.EventHandler(this.btn_GetIp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "公司公网IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "服务器IP";
            // 
            // textBox_ServerIp
            // 
            this.textBox_ServerIp.Location = new System.Drawing.Point(108, 18);
            this.textBox_ServerIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_ServerIp.Name = "textBox_ServerIp";
            this.textBox_ServerIp.Size = new System.Drawing.Size(206, 28);
            this.textBox_ServerIp.TabIndex = 3;
            // 
            // btn_SaveServerIp
            // 
            this.btn_SaveServerIp.Location = new System.Drawing.Point(747, 14);
            this.btn_SaveServerIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SaveServerIp.Name = "btn_SaveServerIp";
            this.btn_SaveServerIp.Size = new System.Drawing.Size(112, 34);
            this.btn_SaveServerIp.TabIndex = 5;
            this.btn_SaveServerIp.Text = "保存服务器Ip";
            this.btn_SaveServerIp.UseVisualStyleBackColor = true;
            this.btn_SaveServerIp.Click += new System.EventHandler(this.btn_SaveServerIp_Click);
            // 
            // btn_demoip
            // 
            this.btn_demoip.Location = new System.Drawing.Point(603, 12);
            this.btn_demoip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_demoip.Name = "btn_demoip";
            this.btn_demoip.Size = new System.Drawing.Size(112, 34);
            this.btn_demoip.TabIndex = 6;
            this.btn_demoip.Text = "示例Ip";
            this.btn_demoip.UseVisualStyleBackColor = true;
            this.btn_demoip.Click += new System.EventHandler(this.btn_demoip_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(333, 17);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(206, 28);
            this.textBox_Port.TabIndex = 7;
            this.textBox_Port.Text = "9528";
            // 
            // Form_GetIp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 180);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.btn_demoip);
            this.Controls.Add(this.btn_SaveServerIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ServerIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_GetIp);
            this.Controls.Add(this.textBox_IpShow);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_GetIp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取得公司公网Ip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IpShow;
        private System.Windows.Forms.Button btn_GetIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ServerIp;
        private System.Windows.Forms.Button btn_SaveServerIp;
        private System.Windows.Forms.Button btn_demoip;
        private System.Windows.Forms.TextBox textBox_Port;
    }
}

