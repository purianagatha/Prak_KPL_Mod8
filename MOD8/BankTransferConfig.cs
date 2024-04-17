using System;
using System.IO;
using System.Text.Json;

internal class BankTransferConfig
{
    public string lang { get; set; }
    public transf transfer { get; set; }
    public string[] methods { get; set; }
    public conf confirmation { get; set; }

    public class transf
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }
    public class conf
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public BankTransferConfig()
    {
        lang = "en";
        transfer = new transf();
        transfer.threshold = 25000000;
        transfer.low_fee = 6500;
        transfer.high_fee = 15000;
        methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        confirmation = new conf();
        confirmation.en = "yes";
        confirmation.id = "ya";
    }

    public void ReadConfigFile(string path)
    {
        if (File.Exists(path))
        {
            string jsonText = File.ReadAllText(path);
            BankTransferConfig config = JsonSerializer.Deserialize<BankTransferConfig>(jsonText);
            this.lang = config.lang;
            this.transfer = config.transfer;
            this.methods = config.methods;
            this.confirmation = config.confirmation;
        }
        else
        {
            Console.WriteLine("File config tidak ditemukan.");
        }
    }

    public void WriteConfigFile(string path)
    {
        string jsonText = JsonSerializer.Serialize(this);
        File.WriteAllText(path, jsonText);
        Console.WriteLine("File config berhasil ditulis.");
    }

    public void ReadAndWriteConfigFile(string path)
    {
        if (File.Exists(path))
        {
            ReadConfigFile(path);
        }
        else
        {
            WriteConfigFile(path);
            ReadConfigFile(path);
        }
    }
}