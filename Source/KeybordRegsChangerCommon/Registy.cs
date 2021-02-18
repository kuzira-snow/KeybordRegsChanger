using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeybordRegsChangerCommon
{
    public class Registy
    {
        #region 取得系
        public static bool GetRegistyValueSTRING(string keyName, string valueName, out string value)
        {
            value = string.Empty;
            object objValue;

            bool isExists = GetRegistyValue(keyName, valueName, out objValue);
            if (isExists)
            {
                value = Convert.ToString(objValue);
            }

            return isExists;
        }

        public static bool GetRegistyValueDWORD(string keyName, string valueName, out long value)
        {
            value = 0;
            object objValue;

            bool isExists = GetRegistyValue(keyName, valueName, out objValue);
            if (isExists)
            {
                if (!long.TryParse(Convert.ToString(objValue), out value))
                {
                    isExists = false;
                }
            }

            return isExists;
        }

        public static bool GetRegistyValue(string keyName, string valueName, out object value)
        {
            bool isExists = true;
            value = null;
            RegistryKey rKey = null;

            try
            {
                // レジストリ・キーのパスを指定してレジストリを開く
                rKey = Registry.LocalMachine.OpenSubKey(keyName);

                // レジストリの値を取得
                value = rKey.GetValue(valueName);
            }
            catch (NullReferenceException)
            {
                isExists = false;
            }
            catch (Exception)
            {
                isExists = false;
                throw;
            }
            finally
            {
                // 開いたレジストリ・キーを閉じる
                if (rKey != null)
                    rKey.Close();
            }

            return isExists;
        }
        #endregion 取得系

        #region 登録系
        public static void SetRegistyValueSTRING(string keyName, string valueName, string value)
        {
            SetRegistyValue(keyName, valueName, value, RegistryValueKind.String);
        }

        public static void SetRegistyValueDWORD(string keyName, string valueName, long value)
        {
            SetRegistyValue(keyName, valueName, value, RegistryValueKind.DWord);
        }

        public static void SetRegistyValue(string keyName, string valueName, object value, RegistryValueKind valueKind)
        {
            RegistryKey rKey = null;

            try
            {
                // レジストリ・キーのパスを指定してレジストリを開く
                rKey = Registry.LocalMachine.OpenSubKey(keyName, true);

                // レジストリの値を設定
                rKey.SetValue(valueName, value, valueKind);
            }
            finally
            {
                // 開いたレジストリ・キーを閉じる
                if (rKey != null)
                    rKey.Close();
            }
        }


        public static string SetRegistyValueSTRINGLite(string keyName, string valueName, string value)
        {
            return SetRegistyValueLite(keyName, valueName, value, RegistryValueKind.String);
        }

        public static string SetRegistyValueDWORDLite(string keyName, string valueName, long value)
        {
            return SetRegistyValueLite(keyName, valueName, value, RegistryValueKind.DWord);
        }

        public static string SetRegistyValueLite(string keyName, string valueName, object value, RegistryValueKind valueKind)
        {
            string commands;

            string key = @"HKEY_LOCAL_MACHINE\" + keyName;

            string kind = "";
            switch (valueKind)
            {
                case RegistryValueKind.String:
                    kind = "REG_SZ";
                    break;
                case RegistryValueKind.DWord:
                    kind = "REG_DWORD";
                    break;
                default:
                    kind = "REG_SZ";
                    break;
            }

            commands = $"reg add \"{key}\" /v \"{valueName}\" /t \"{kind}\" /d \"{Convert.ToString(value)}\" /f ";
            
            return commands;
        }
        #endregion 登録系

        #region 削除系
        public static void DeleteRegistyValue(string keyName, string valueName)
        {
            RegistryKey rKey = null;

            try
            {
                //string executeUser = System.Environment.UserName;
                //System.Security.AccessControl.RegistrySecurity rSec = new System.Security.AccessControl.RegistrySecurity();
                
                //System.Security.Principal.NTAccount account = new System.Security.Principal.NTAccount(Environment.UserDomainName, Environment.UserName);

                //rSec.SetOwner(account);
                //Registry.LocalMachine.SetAccessControl(rSec);

                // レジストリ・キーのパスを指定してレジストリを開く
                rKey = Registry.LocalMachine.OpenSubKey(keyName, true);

                // レジストリの存在チェック
                if (rKey.GetValueNames().Contains(valueName))
                {
                    // レジストリの値を設定
                    rKey.DeleteValue(valueName, true);
                }
            }
            finally
            {
                // 開いたレジストリ・キーを閉じる
                if (rKey != null)
                    rKey.Close();
            }
        }

        public static string DeleteRegistyValueLite(string keyName, string valueName)
        {
            string commands;

            string key = @"HKEY_LOCAL_MACHINE\" + keyName;

            commands = $"reg delete \"{key}\" /v \"{valueName}\" /f ";

            return commands;
        }
        #endregion 削除系

    }
}
