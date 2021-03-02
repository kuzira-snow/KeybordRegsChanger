using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace KeybordRegsChangerCommon
{
    /// <summary>デバイスマネージャ操作クラス.</summary>
    public class Device
    {
        /// <summary>デバイスマネージャから取得できる情報からキーボードの一覧を取得.</summary>
        /// <returns></returns>
        public static List<DeviceInfo> GetKeybordDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                collection = searcher.Get();

            bool isKeybord = false;

            foreach (var device in collection)
            {
                isKeybord = false;
                foreach (var param in device.Properties)
                {
                    if (param.Value?.ToString() == "HID キーボード デバイス")
                    {
                        isKeybord = true;
                    }

#if DEBUG
                    Console.WriteLine("");
                    Console.Write($"Name:{param.Name}");
                    Console.Write($"  Value:{param.Value?.ToString()}");
                    Console.Write($"  Type:{param.Type}");
                    Console.Write($"  Origin:{param.Origin}");
#else
                    if (isKeybord)
                    {
                        break;
                    }
#endif
                }

#if DEBUG
                Console.WriteLine("");
                Console.WriteLine("");
#endif

                if (isKeybord)
                {
                    devices.Add(new DeviceInfo(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Description")
                    ));
                }
            }

            collection.Dispose();
            return devices;
        }

        /// <summary>デバイスマネージャから取れる情報の一部.</summary>
        /// <remarks> 
        /// Name:Availability Value:  Type:UInt16
        /// Name:Caption Value:HID キーボード デバイス Type:String
        /// Name:ClassGuid Value:{4d36e96b-e325-11ce-bfc1-08002be10318}  Type:String
        /// Name:CompatibleID Value:  Type:String
        /// Name:ConfigManagerErrorCode Value:0  Type:UInt32
        /// Name:ConfigManagerUserConfig Value:False Type:Boolean
        /// Name:CreationClassName Value:Win32_PnPEntity Type:String
        /// Name:Description Value:HID キーボード デバイス Type:String
        /// Name:DeviceID Value:HID\VID_00F0&PID_000A&MI_00\0&00AA000&0&0000  Type:String
        /// Name:ErrorCleared Value:  Type:Boolean
        /// Name:ErrorDescription Value:  Type:String
        /// Name:HardwareID Value:System.String[] Type:String
        /// Name:InstallDate Value:  Type:DateTime
        /// Name:LastErrorCode Value:  Type:UInt32
        /// Name:Manufacturer Value:(標準キーボード) Type:String
        /// Name:Name Value:HID キーボード デバイス Type:String
        /// Name:PNPClass Value:Keyboard Type:String
        /// Name:PNPDeviceID Value:HID\VID_00F0&PID_000A&MI_00\0&00AA000&0&0000  Type:String
        /// Name:PowerManagementCapabilities Value:  Type:UInt16
        /// Name:PowerManagementSupported Value:  Type:Boolean
        /// Name:Present Value:True Type:Boolean
        /// Name:Service Value:kbdhid Type:String
        /// Name:Status Value:OK Type:String
        /// Name:StatusInfo Value:  Type:UInt16
        /// Name:SystemCreationClassName Value:Win32_ComputerSystem Type:String
        /// Name:SystemName Value:PcName Type:String
        /// </remarks>
    public class DeviceInfo
        {
            public DeviceInfo(string deviceID, string pnpDeviceID, string description)
            {
                this.DeviceID = deviceID;
                this.PnpDeviceID = pnpDeviceID;
                this.Description = description;
            }
            public string DeviceID { get; private set; }
            public string PnpDeviceID { get; private set; }
            public string Description { get; private set; }
        }
    }
}
