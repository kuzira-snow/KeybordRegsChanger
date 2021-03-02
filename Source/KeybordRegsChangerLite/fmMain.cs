using KeybordRegsChangerCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeybordRegsChanger
{
    public partial class fmMain : Form
    {
        // キーボード Type Subtype
        // US 101/104 4 0
        // JIS 106/109 7 2

        private List<DgvKeybordModel> KeybordList = new List<DgvKeybordModel>();

        /// <summary>コンストラクタ.</summary>
        public fmMain()
        {
            InitializeComponent();
        }
        
        /// <summary>画面表示.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmMain_Load(object sender, EventArgs e)
        {
            dgvKeybord.AutoGenerateColumns = false;
            UpdateKeybordInfo();

            txtMsg.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMsg.ForeColor = System.Drawing.Color.Black;
            txtMsg.BackColor = Color.White;
            txtMsg.Text = "キーボードの日本語(106)/英語(101)を再起動しないで切替を行う為に" + Environment.NewLine
                        + "各キーボードのレジストリへ設定をする。" + Environment.NewLine
                        + "Lite版は現在の設定が取れないので初期表示の値は現在の設定と異なります。";
        }

        /// <summary>端末の設定情報を取得.</summary>
        private void UpdateKeybordInfo()
        {
            KeybordList.Clear();
            string rKeyName;

            var deviceList = Device.GetKeybordDevices();
            foreach (var deviceInfo in deviceList)
            {
                DgvKeybordModel addItem = new DgvKeybordModel();
                addItem.InstanceID = deviceInfo.DeviceID;
                KeybordList.Add(addItem);
            }

            dgvKeybord.DataSource = null;
            var bindingList = new BindingList<DgvKeybordModel>(KeybordList);
            var source = new BindingSource(bindingList, null);
            dgvKeybord.DataSource = source;
        }
        
        /// <summary>レジストリへ書き込み.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName;
            StringBuilder commands = new StringBuilder();

            // ファイル保存ダイアログ
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "ファイルを保存する";
                sfd.InitialDirectory = System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                sfd.FileName = @"KeybordRegsChanger.bat";
                sfd.Filter = "バッチファイル(*.bat)|*.bat|すべてのファイル(*.*)|*.*";
                sfd.FilterIndex = 1;

                //オープンファイルダイアログを表示する
                DialogResult sfdResult = sfd.ShowDialog();

                if (sfdResult != DialogResult.OK)
                {
                    return;
                }
                fileName = sfd.FileName;
            }
                       
            string rKeyName;

            // 韓国語の設定
            commands.AppendLine(":: 韓国語の設定");
            rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
            if (cmbKorSetting.Text == "無し")
            {
                commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "LayerDriver KOR"));
            }
            else
            {
                commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "LayerDriver KOR", "kbd101a.dll"));
            }

            commands.AppendLine("");
            commands.AppendLine(":: 全体統一の設定");
            if (!chkAllSetting.Checked)
            {
                rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
                // 統一設定しない
                commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "OverrideKeyboardType"));
                commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "OverrideKeyboardSubtype"));
            }
            else
            {
                // 全て統一
                rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
                if (cmbAllSetting.Text == "JIS")
                {
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "LayerDriver JPN", "kbd106.dll"));
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "OverrideKeyboardIdentifier", "PCAT_106KEY"));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardType", 7));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardSubtype", 2));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "KeyboardTypeOverride", 7));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "KeyboardSubtypeOverride", 2));
                }
                else if (cmbAllSetting.Text == "US")
                {
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "LayerDriver JPN", "kbd101.dll"));
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "OverrideKeyboardIdentifier", "PCAT_101KEY"));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardType", 4));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardSubtype", 0));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "KeyboardTypeOverride", 4));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "KeyboardSubtypeOverride", 0));
                }
                else
                {
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "KeyboardTypeOverride", 7));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "KeyboardSubtypeOverride", 2));
                }
            }

            commands.AppendLine("");
            commands.AppendLine(":: 各キーボードへの設定");
            // 各キーボードへの設定
            foreach (var keybord in KeybordList)
            {
                if (keybord.Enable == false)
                {
                    continue;
                }

                rKeyName = string.Format(@"SYSTEM\CurrentControlSet\Enum\{0}\Device Parameters", keybord.InstanceID);

                if (keybord.Type == "JIS")
                {
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "LayerDriver JPN", "kbd106.dll"));
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "OverrideKeyboardIdentifier", "PCAT_106KEY"));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardType", 7));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardSubtype", 2));
                }
                else if (keybord.Type == "US")
                {
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "LayerDriver JPN", "kbd101.dll"));
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "OverrideKeyboardIdentifier", "PCAT_101KEY"));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardType", 4));
                    commands.AppendLine(Registy.SetRegistyValueDWORDLite(rKeyName, "OverrideKeyboardSubtype", 0));
                }
                else
                {
                    commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "LayerDriver JPN"));
                    commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "OverrideKeyboardIdentifier"));
                    commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "OverrideKeyboardType"));
                    commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "OverrideKeyboardSubtype"));
                }

                if (string.IsNullOrWhiteSpace(keybord.KeybordName))
                {
                    commands.AppendLine(Registy.DeleteRegistyValueLite(rKeyName, "KeybordName"));
                }
                else
                {
                    commands.AppendLine(Registy.SetRegistyValueSTRINGLite(rKeyName, "KeybordName", keybord.KeybordName));
                }
            }

            commands.AppendLine("");
            commands.AppendLine("レジストリの設定が完了しました。再起動を行って下さい。");
            commands.AppendLine("pause");

            // ファイル出力
            System.IO.File.WriteAllText(fileName, commands.ToString());
        }

        /// <summary>キーボード情報データクラス.</summary>
        public class DgvKeybordModel
        {
            public bool Enable { get; set; } = true;
            public string InstanceID { get; set; }
            public string Type { get; set; } = "(なし)";
            public string KeybordName { get; set; } = "";
        }
    }
}

