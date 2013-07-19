namespace InitDataBase_fzd
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDBname = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ckMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtDBname
            // 
            this.txtDBname.Location = new System.Drawing.Point(12, 12);
            this.txtDBname.Name = "txtDBname";
            this.txtDBname.Size = new System.Drawing.Size(536, 21);
            this.txtDBname.TabIndex = 3;
            this.txtDBname.Text = "DataBaseName";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(288, 73);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清空数据";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(182, 73);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(75, 23);
            this.btnName.TabIndex = 6;
            this.btnName.Text = "删除表";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRun.ForeColor = System.Drawing.Color.Maroon;
            this.btnRun.Location = new System.Drawing.Point(399, 43);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(52, 47);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Go";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(10, 78);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(137, 12);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click on me for tips !";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ckMode
            // 
            this.ckMode.AutoSize = true;
            this.ckMode.Checked = true;
            this.ckMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMode.Location = new System.Drawing.Point(12, 43);
            this.ckMode.Name = "ckMode";
            this.ckMode.Size = new System.Drawing.Size(138, 16);
            this.ckMode.TabIndex = 9;
            this.ckMode.Text = "数据库名/连接字符串";
            this.ckMode.UseVisualStyleBackColor = true;
            this.ckMode.CheckedChanged += new System.EventHandler(this.ckMode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 104);
            this.Controls.Add(this.ckMode);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDBname);
            this.Location = new System.Drawing.Point(300, 600);
            this.Name = "Form1";
            this.Text = "数据库初始化工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDBname;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox ckMode;
    }
}

