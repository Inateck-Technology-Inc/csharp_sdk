namespace csharp_sdk;
using InateckScannerBle;
using Newtonsoft.Json.Linq;

class Program
{
    public const string CommandPrefix = "!";
    public static string MacAddress { get; set; }
    public static ScannerBle Scanner { get; set; }

    static Program()
    {
        MacAddress = "";
        Scanner = new ScannerBle();
    }

    // scan for devices
    static void scan()
    {
        Scanner.Init();
        Scanner.Debug(true);
        string sdkVersion = Scanner.SdkVersion();
        Console.WriteLine("SDK Version: " + sdkVersion);
        Console.WriteLine("MacAddress: " + MacAddress ?? "N/A");
        string initResult = Scanner.Init();
        // json parse
        JObject initResultJson = JObject.Parse(initResult);
        int status = initResultJson["status"]?.ToObject<int>() ?? -1;
        if (status != 0)
        {
            Console.WriteLine("Init failed: " + status);
            Environment.Exit(1);
        }
        Console.WriteLine("init success Status: " + status);
        Scanner.WaitAvailable();
        Scanner.SetDiscoverCallback((message) =>
        {
            Console.WriteLine("Message: " + message);
        });

        Scanner.StartScan();

        // sleep 10s
        System.Threading.Thread.Sleep(10000);

        Scanner.StopScan();
    }

    // connect to device
    static void connect(string devideId)
    {
        string result = Scanner.Connect(devideId);
        Scanner.CheckCommunication(devideId);
        Scanner.Auth(devideId);
        Scanner.setCodeCallback(devideId, (message) =>
        {
            Console.WriteLine("DevideId: " + devideId);
            Console.WriteLine("Code: " + message);

            JObject msgAsJson = JObject.Parse(message);
            var cleanedScannedCode = msgAsJson["code"]?.ToString();
            if (cleanedScannedCode != null)
            {
                Console.WriteLine($"Cleaned scan result: {cleanedScannedCode}");
            }
            else
            {
                Console.WriteLine("Unable to extract code from json.");
            }
        });
    }

    static void GetHardwareVersion(string devideId)
    {
        string result = Scanner.GetHardwareVersion(devideId);
        Console.WriteLine("Hardware Version: " + result);
    }

    static void GetSoftwareVersion(string devideId)
    {
        string result = Scanner.GetSoftwareVersion(devideId);
        Console.WriteLine("Software Version: " + result);
    }

    static void GetSettingInfo(string devideId)
    {
        string result = Scanner.GetSettingInfo(devideId, DeviceType.ST75);
        Console.WriteLine("Setting Info: " + result);
    }

    static void Quiet(string devideId)
    {
        string closeVolume = "[{\"flag\":1001,\"value\":0}]";
        string info = Scanner.SetSettingInfo(devideId, closeVolume, DeviceType.ST75);
        Scanner.BeeOrShake(devideId);
        Console.WriteLine("SettingInfo: " + info.Replace("},", "},\n"));
    }

    static void Loud(string devideId)
    {
        string closeVolume = "[{\"flag\":1001,\"value\":4}]";
        string info = Scanner.SetSettingInfo(devideId, closeVolume, DeviceType.ST42);
        Scanner.BeeOrShake(devideId);
        Console.WriteLine("SettingInfo: " + info.Replace("},", "},\n"));
    }

    static void Main(string[] args)
    {
        scan();

        // find device id
        string deviceId = "BluetoothLE#BluetoothLEf4:4e:fc:89:ee:4a-aa:2b:00:03:95:83";

        connect(deviceId);

        GetHardwareVersion(deviceId);

        GetSoftwareVersion(deviceId);

        GetSettingInfo(deviceId);

        Quiet(deviceId);
        
        // sleep 5s
        System.Threading.Thread.Sleep(5000);

        Loud(deviceId);
    }
}
