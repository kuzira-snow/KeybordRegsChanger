using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeybordRegsChanger.InfoGather
{
    /// <summary>
    /// Vista以降で可能
    /// </summary>
    public class Pnputil
    {
        public static List<PnputilInfo> GetKeybordPnputil()
        {
            List<PnputilInfo> ret = new List<PnputilInfo>();

            string output = RunPnputil();

            StringReader sr;
            sr = new StringReader(output);

            string line;
            int retIdx = -1;
            int itemIdx = -1;
            while ((line = sr.ReadLine()) != null)
            {
                if (itemIdx == -1 && string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                itemIdx++;

                if (itemIdx == 0)
                {
                    retIdx++;
                    ret.Add(new PnputilInfo());
                    ret[retIdx].InstanceID = line;
                }
                if (itemIdx == 1)
                {
                    ret[retIdx].Description = line;
                }
                if (itemIdx == 2)
                {
                    ret[retIdx].ClassName = line;
                }
                if (itemIdx == 3)
                {
                    ret[retIdx].ClassGUID = line;
                }
                if (itemIdx == 4)
                {
                    ret[retIdx].MakerName = line;
                }
                if (itemIdx == 5)
                {
                    ret[retIdx].Status = line;
                }
                if (itemIdx == 6)
                {
                    ret[retIdx].DriverName = line;
                    itemIdx = -1;
                }
            }

            return ret;
        }

        private static string RunPnputil()
        {
            if (!File.Exists("pnputil.exe"))
            {
                return string.Empty;
            }

            string exePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "pnputil.exe");

            ProcessStartInfo psInfo = new ProcessStartInfo();
            psInfo.FileName = exePath; // 実行するファイル
            psInfo.Arguments = @"/enum-devices /connected /class Keyboard";
            psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
            psInfo.UseShellExecute = false; // シェル機能を使用しない
            psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
            Process p = Process.Start(psInfo); // アプリの実行開始

            string output = p.StandardOutput.ReadToEnd(); // 標準出力の読み取り
            p.Close();

            return output;
        }

        public class PnputilInfo
        {
            // インスタンス ID:        HID\RCA_VKD&Col01\1&2dZ00ZZ0&0&0000
            // デバイスの説明:         HID キーボード デバイス
            // クラス名:               Keyboard
            // クラス GUID:            {4d36e96b-e325-11ce-bfc1-00000ZZ00000}
            // 製造元の名前:           (標準キーボード)
            // 状態:                   開始
            // ドライバー名:           keyboard.inf

            /// <summary>インスタンス ID.</summary>
            public string InstanceID { get; set; }
            /// <summary>デバイスの説明.</summary>
            public string Description { get; set; }
            /// <summary>クラス名.</summary>
            public string ClassName { get; set; }
            /// <summary>クラス GUID.</summary>
            public string ClassGUID { get; set; }
            /// <summary>製造元の名前.</summary>
            public string MakerName { get; set; }
            /// <summary>状態.</summary>
            public string Status { get; set; }
            /// <summary>ドライバー名.</summary>
            public string DriverName { get; set; }
        }
    }
}
