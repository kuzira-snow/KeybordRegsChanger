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

            if (IsAdministrator())
            {
                btnAdmin.Visible = false;
                txtMsg.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtMsg.ForeColor = System.Drawing.Color.Black;
                txtMsg.BackColor = Color.White;
                txtMsg.Text = "キーボードの日本語(106)/英語(101)を再起動しないで切替を行う為に" + Environment.NewLine
                            + "各キーボードのレジストリへ設定をする。";
            }
            else
            {
                btnAdmin.Visible = true;
                txtMsg.Font = new Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtMsg.ForeColor = Color.Red;
                txtMsg.BackColor = Color.LightYellow;
                txtMsg.Text = "レジストリへの書き込みは管理者権限が必要です。" + Environment.NewLine
                            + "管理者権限で実行する場合は『管理者権限で再実行』をクリックして下さい。";
            }
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

            // 韓国語の設定有無を取得（デフォルト入っている事がある）
            rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
            string langKOR;
            if (Registy.GetRegistyValueSTRING(rKeyName, "LayerDriver KOR", out langKOR))
            {
                cmbKorSetting.Text = "無し";
            }
            else
            {
                cmbKorSetting.Text = "有り";
            }

            // 制御方法を取得
            rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
            long valOverrideKeyboardType, valOverrideKeyboardSubtype;
            if (Registy.GetRegistyValueDWORD(rKeyName, "KeyboardTypeOverride", out valOverrideKeyboardType)
                && Registy.GetRegistyValueDWORD(rKeyName, "KeyboardSubtypeOverride", out valOverrideKeyboardSubtype))
            {
                if (valOverrideKeyboardType == 7)
                {
                    cmbAllSetting.Text = "JIS";
                }
                else
                {
                    cmbAllSetting.Text = "US";
                }
            }
            else
            {
                cmbAllSetting.Text = "(なし)";
            }

            // キーボード毎の設定を取得
            foreach (var keybord in KeybordList)
            {
                rKeyName = string.Format(@"SYSTEM\CurrentControlSet\Enum\{0}\Device Parameters", keybord.InstanceID);

                if (Registy.GetRegistyValueDWORD(rKeyName, "OverrideKeyboardType", out valOverrideKeyboardType)
                    && Registy.GetRegistyValueDWORD(rKeyName, "OverrideKeyboardSubtype", out valOverrideKeyboardSubtype))
                {
                    if (valOverrideKeyboardType == 7)
                    {
                        keybord.Type = "JIS";
                    }
                    else
                    {
                        keybord.Type = "US";
                    }
                }
                else
                {
                    keybord.Type = "(なし)";
                }

                string keybordName = string.Empty;
                Registy.GetRegistyValueSTRING(rKeyName, "KeybordName", out keybordName);
                keybord.KeybordName = keybordName;
            }

            dgvKeybord.DataSource = null;
            var bindingList = new BindingList<DgvKeybordModel>(KeybordList);
            var source = new BindingSource(bindingList, null);
            dgvKeybord.DataSource = source;
        }

        /// <summary>再読み込み.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("入力内容は保存されません", btnUpdate.Text, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            UpdateKeybordInfo();
        }

        /// <summary>レジストリへ書き込み.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("書き込みしますか？", btnSave.Text, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            string rKeyName;

            // 韓国語の設定
            rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
            if (cmbKorSetting.Text == "無し")
            {
                Registy.DeleteRegistyValue(rKeyName, "LayerDriver KOR");
            }
            else
            {
                Registy.SetRegistyValueSTRING(rKeyName, "LayerDriver KOR", "kbd101a.dll");
            }

            if (!chkAllSetting.Checked)
            {
                rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
                // 統一設定しない
                Registy.DeleteRegistyValue(rKeyName, "OverrideKeyboardType");
                Registy.DeleteRegistyValue(rKeyName, "OverrideKeyboardSubtype");
            }
            else
            {
                // 全て統一
                rKeyName = @"SYSTEM\CurrentControlSet\Services\i8042prt\Parameters";
                if (cmbAllSetting.Text == "JIS")
                {
                    Registy.SetRegistyValueSTRING(rKeyName, "LayerDriver JPN", "kbd106.dll");
                    Registy.SetRegistyValueSTRING(rKeyName, "OverrideKeyboardIdentifier", "PCAT_106KEY");
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardType", 7);
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardSubtype", 2);
                    Registy.SetRegistyValueDWORD(rKeyName, "KeyboardTypeOverride", 7);
                    Registy.SetRegistyValueDWORD(rKeyName, "KeyboardSubtypeOverride", 2);
                }
                else if (cmbAllSetting.Text == "US")
                {
                    Registy.SetRegistyValueSTRING(rKeyName, "LayerDriver JPN", "kbd101.dll");
                    Registy.SetRegistyValueSTRING(rKeyName, "OverrideKeyboardIdentifier", "PCAT_101KEY");
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardType", 4);
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardSubtype", 0);
                    Registy.SetRegistyValueDWORD(rKeyName, "KeyboardTypeOverride", 4);
                    Registy.SetRegistyValueDWORD(rKeyName, "KeyboardSubtypeOverride", 0);
                }
                else
                {
                    Registy.SetRegistyValueDWORD(rKeyName, "KeyboardTypeOverride", 7);
                    Registy.SetRegistyValueDWORD(rKeyName, "KeyboardSubtypeOverride", 2);
                }
            }

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
                    Registy.SetRegistyValueSTRING(rKeyName, "LayerDriver JPN", "kbd106.dll");
                    Registy.SetRegistyValueSTRING(rKeyName, "OverrideKeyboardIdentifier", "PCAT_106KEY");
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardType", 7);
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardSubtype", 2);
                }
                else if (keybord.Type == "US")
                {
                    Registy.SetRegistyValueSTRING(rKeyName, "LayerDriver JPN", "kbd101.dll");
                    Registy.SetRegistyValueSTRING(rKeyName, "OverrideKeyboardIdentifier", "PCAT_101KEY");
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardType", 4);
                    Registy.SetRegistyValueDWORD(rKeyName, "OverrideKeyboardSubtype", 0);
                }
                else
                {
                    Registy.DeleteRegistyValue(rKeyName, "LayerDriver JPN");
                    Registy.DeleteRegistyValue(rKeyName, "OverrideKeyboardIdentifier");
                    Registy.DeleteRegistyValue(rKeyName, "OverrideKeyboardType");
                    Registy.DeleteRegistyValue(rKeyName, "OverrideKeyboardSubtype");
                }

                if (string.IsNullOrWhiteSpace(keybord.KeybordName))
                {
                    Registy.DeleteRegistyValue(rKeyName, "KeybordName");
                }
                else
                {
                    Registy.SetRegistyValueSTRING(rKeyName, "KeybordName", keybord.KeybordName);
                }
            }
        }

        /// <summary>キーボード情報データクラス.</summary>
        public class DgvKeybordModel
        {
            public bool Enable { get; set; } = true;
            public string InstanceID { get; set; }
            public string Type { get; set; } = "(なし)";
            public string KeybordName { get; set; } = "";
        }

        /// <summary>管理者権限の有無.</summary>
        /// <returns></returns>
        private bool IsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
        
        /// <summary>再起動.</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            var proc = new System.Diagnostics.ProcessStartInfo()
            {
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = System.Reflection.Assembly.GetEntryAssembly().Location,
                Verb = "RunAs"
            };

            //別プロセスで本アプリを起動する
            Process.Start(proc);

            //現在プロセス終了
            this.Close();
        }

        /// <summary>Windowsを再起動.</summary>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "shutdown.exe";

            psi.Arguments = " / r";

            Console.WriteLine(psi.Arguments);
            //ウィンドウを表示しないようにする
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            //起動
            Process.Start(psi);
        }
    }
}

