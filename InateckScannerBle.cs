using System.Runtime.InteropServices;

namespace InateckScannerBle
{
    public enum DeviceType
    {
        None = 0,
        Pro8,
        ST45,
        ST23,
        ST91,
        ST42,
        ST54,
        ST55,
        ST73,
        ST75,
        ST43,
        P7,
        ST21,
        ST60,
        ST70,
        P6,
        ST35,
    }

    public delegate void Callback(string message);

    public class ScannerBle
    {
        public ScannerBle()
        {

        }

        public string Init()
        {
            return ScannerBleC.inateck_scanner_ble_init();
        }

        public string SetDiscoverCallback(Callback callback)
        {
            return ScannerBleC.inateck_scanner_ble_set_discover_callback(callback);
        }

        public string WaitAvailable()
        {
            return ScannerBleC.inateck_scanner_ble_wait_available();
        }

        public string StartScan()
        {
            return ScannerBleC.inateck_scanner_ble_start_discover();
        }

        public string StopScan()
        {
            return ScannerBleC.inateck_scanner_ble_stop_discover();
        }

        public string GetDevices()
        {
            return ScannerBleC.inateck_scanner_ble_get_devices();
        }

        public string Connect(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_connect(mac);
        }

        public string CheckCommunication(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_check_communication(mac);
        }

        public string Auth(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_auth(mac);
        }

        public string setCodeCallback(string mac, Callback callback)
        {
            return ScannerBleC.inateck_scanner_ble_set_code_callback(mac, callback);
        }

        public string setDisconnectCallback(string mac, Callback callback)
        {
            return ScannerBleC.inateck_scanner_ble_set_disconnect_callback(mac, callback);
        }

        public string Disconnect(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_disconnect(mac);
        }

        public string GetBattery(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_battery(mac);
        }

        public string GetHardwareVersion(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_hardware_version(mac);
        }

        public string BeeOrShake(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_bee_or_shake(mac);
        }

        public string GetSoftwareVersion(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_software_version(mac);
        }

        public string GetSettingInfo(string mac, DeviceType deviceType)
        {
            return ScannerBleC.inateck_scanner_ble_get_setting_info(mac, (int)deviceType);
        }

        public string SetSettingInfo(string mac, string cmd, DeviceType deviceType)
        {
            return ScannerBleC.inateck_scanner_ble_set_setting_info(mac, cmd, (int)deviceType);
        }

        public string SetName(string mac, string name)
        {
            return ScannerBleC.inateck_scanner_ble_set_name(mac, name);
        }

        public string SetTime(string mac, long time)
        {
            return ScannerBleC.inateck_scanner_ble_set_time(mac, time);
        }

        public string InventoryClearCache(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_inventory_clear_cache(mac);
        }

        public string InventoryUploadCache(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_inventory_upload_cache(mac);
        }

        public string InventoryUploadCacheNumber(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_inventory_upload_cache_number(mac);
        }

        public string Reset(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_reset(mac);
        }

        public string Restart(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_restart(mac);
        }

        public string CloseAllCode(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_close_all_code(mac);
        }

        public string OpenAllCode(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_open_all_code(mac);
        }

        public string ResetAllCode(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_reset_all_code(mac);
        }

        public string SdkVersion()
        {
            return ScannerBleC.inateck_scanner_ble_sdk_version();
        }

        public string Debug(bool enable)
        {
            return ScannerBleC.inateck_scanner_ble_set_debug(enable);
        }
    }

    class ScannerBleC
    {
        const string LibPath = "./inateck_scanner_ble.dll";

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_init();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_discover_callback(Callback callback);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_wait_available();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_start_discover();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_stop_discover();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_devices();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_connect(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_check_communication(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_auth(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_code_callback(string devideId, Callback callback);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_disconnect_callback(string devideId, Callback callback);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_disconnect(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_battery(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_hardware_version(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_bee_or_shake(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_set_bee(string devideId, int voiceTime, int silentTime, int count);

       [DllImport(LibPath)]
        public static extern string inateck_scanner_set_led(string devideId, int color, int lightTime, int darkTime, int count);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_software_version(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_set_bee(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_set_led(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_setting_info(string devideId, int deviceType);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_setting_info(string devideId, string cmd, int deviceType);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_name(string devideId, string name);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_time(string devideId, long time);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_inventory_clear_cache(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_inventory_upload_cache(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_inventory_upload_cache_number(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_reset(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_restart(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_close_all_code(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_open_all_code(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_reset_all_code(string devideId);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_sdk_version();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_debug(bool enable);
    }
}
