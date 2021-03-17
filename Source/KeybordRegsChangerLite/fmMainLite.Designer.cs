namespace KeybordRegsChanger
{
    partial class fmMainLite
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvKeybord = new System.Windows.Forms.DataGridView();
            this.cmbAllSetting = new System.Windows.Forms.ComboBox();
            this.chkAllSetting = new System.Windows.Forms.CheckBox();
            this.cmbKorSetting = new System.Windows.Forms.ComboBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KeybordName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeybord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(12, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(238, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "バッチの書き出し";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvKeybord
            // 
            this.dgvKeybord.AllowUserToAddRows = false;
            this.dgvKeybord.AllowUserToDeleteRows = false;
            this.dgvKeybord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKeybord.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKeybord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKeybord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeybord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Type,
            this.KeybordName,
            this.InstanceID});
            this.dgvKeybord.Location = new System.Drawing.Point(15, 214);
            this.dgvKeybord.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKeybord.MultiSelect = false;
            this.dgvKeybord.Name = "dgvKeybord";
            this.dgvKeybord.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Snow;
            this.dgvKeybord.RowTemplate.Height = 30;
            this.dgvKeybord.Size = new System.Drawing.Size(851, 266);
            this.dgvKeybord.TabIndex = 9;
            // 
            // cmbAllSetting
            // 
            this.cmbAllSetting.FormattingEnabled = true;
            this.cmbAllSetting.Items.AddRange(new object[] {
            "JIS",
            "US"});
            this.cmbAllSetting.Location = new System.Drawing.Point(478, 132);
            this.cmbAllSetting.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAllSetting.Name = "cmbAllSetting";
            this.cmbAllSetting.Size = new System.Drawing.Size(150, 27);
            this.cmbAllSetting.TabIndex = 5;
            this.cmbAllSetting.Text = "JIS";
            // 
            // chkAllSetting
            // 
            this.chkAllSetting.AutoSize = true;
            this.chkAllSetting.Checked = true;
            this.chkAllSetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllSetting.Location = new System.Drawing.Point(15, 169);
            this.chkAllSetting.Name = "chkAllSetting";
            this.chkAllSetting.Size = new System.Drawing.Size(212, 23);
            this.chkAllSetting.TabIndex = 6;
            this.chkAllSetting.Text = "システム全体で設定する";
            this.chkAllSetting.UseVisualStyleBackColor = true;
            // 
            // cmbKorSetting
            // 
            this.cmbKorSetting.FormattingEnabled = true;
            this.cmbKorSetting.Items.AddRange(new object[] {
            "無し",
            "有り"});
            this.cmbKorSetting.Location = new System.Drawing.Point(512, 168);
            this.cmbKorSetting.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKorSetting.Name = "cmbKorSetting";
            this.cmbKorSetting.Size = new System.Drawing.Size(150, 27);
            this.cmbKorSetting.TabIndex = 8;
            this.cmbKorSetting.Text = "無し";
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.LightYellow;
            this.txtMsg.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMsg.ForeColor = System.Drawing.Color.Red;
            this.txtMsg.Location = new System.Drawing.Point(12, 53);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(854, 69);
            this.txtMsg.TabIndex = 3;
            this.txtMsg.Text = "aaa\r\naaa\r\nbbb\r\nccc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "全体設定時の一括 or 個別設定時の未設定のキーボード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "韓国語の有無";
            // 
            // Enable
            // 
            this.Enable.DataPropertyName = "Enable";
            this.Enable.FalseValue = "false";
            this.Enable.HeaderText = "Enable";
            this.Enable.IndeterminateValue = "true";
            this.Enable.MinimumWidth = 100;
            this.Enable.Name = "Enable";
            this.Enable.TrueValue = "true";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "(なし)",
            "JIS",
            "US"});
            this.Type.MinimumWidth = 100;
            this.Type.Name = "Type";
            // 
            // KeybordName
            // 
            this.KeybordName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.KeybordName.DataPropertyName = "KeybordName";
            this.KeybordName.HeaderText = "KeybordName";
            this.KeybordName.MinimumWidth = 100;
            this.KeybordName.Name = "KeybordName";
            this.KeybordName.Width = 144;
            // 
            // InstanceID
            // 
            this.InstanceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.InstanceID.DataPropertyName = "InstanceID";
            this.InstanceID.HeaderText = "InctanceID";
            this.InstanceID.MinimumWidth = 100;
            this.InstanceID.Name = "InstanceID";
            this.InstanceID.Width = 122;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(879, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.cmbKorSetting);
            this.Controls.Add(this.chkAllSetting);
            this.Controls.Add(this.cmbAllSetting);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvKeybord);
            this.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.Text = "KeybordRegs";
            this.Load += new System.EventHandler(this.fmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeybord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvKeybord;
        private System.Windows.Forms.ComboBox cmbAllSetting;
        private System.Windows.Forms.CheckBox chkAllSetting;
        private System.Windows.Forms.ComboBox cmbKorSetting;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeybordName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstanceID;
    }
}

