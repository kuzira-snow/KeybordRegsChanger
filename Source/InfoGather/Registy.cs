using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeybordRegsChanger.InfoGather
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
        #endregion 削除系

    }
}
