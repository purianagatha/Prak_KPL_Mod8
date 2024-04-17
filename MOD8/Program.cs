using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        BankTransferConfig BankTransConfig = new BankTransferConfig();

        string configPath = "BankTransfer_Config_1302223019.json";

        BankTransConfig.ReadAndWriteConfigFile(configPath);

        if (BankTransConfig.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (BankTransConfig.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        int nominalTransfer = int.Parse(Console.ReadLine());
        int totalBiaya = 0;

        if (nominalTransfer <= BankTransConfig.transfer.threshold)
        {
            totalBiaya = BankTransConfig.transfer.low_fee + nominalTransfer;
        }
        else
        {
            totalBiaya = BankTransConfig.transfer.high_fee + nominalTransfer;
        }

        if (BankTransConfig.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {totalBiaya - nominalTransfer}");
            Console.WriteLine($"Total amount = {totalBiaya}");
            Console.WriteLine("Select transfer method:");
        }
        else if (BankTransConfig.lang == "id")
        {
            Console.WriteLine($"Biaya transfer = {totalBiaya - nominalTransfer}");
            Console.WriteLine($"Total biaya    = {totalBiaya}");
            Console.WriteLine("Pilih metode transfer:");
        }

        for (int i = 0; i < BankTransConfig.methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {BankTransConfig.methods[i]}");
        }
        Console.Write("Masukkan pilihan: ");
        int pilihan = int.Parse(Console.ReadLine());

        if (BankTransConfig.lang == "en")
        {
            Console.WriteLine($"Please type {BankTransConfig.confirmation.en} to confirm the transaction: ");
        }
        else if (BankTransConfig.lang == "id")
        {
            Console.WriteLine($"Ketik {BankTransConfig.confirmation.id} untuk mengkonfirmasi transaksi:");
        }

        string confirmationInput = Console.ReadLine();

        if (BankTransConfig.lang == "en" && confirmationInput == BankTransConfig.confirmation.en)
        {
            Console.WriteLine("The transfer is completed");
        }
        else if (BankTransConfig.lang == "en")
        {
            Console.WriteLine("Transfer is cancelled");
        }

        if (BankTransConfig.lang == "id" && confirmationInput == BankTransConfig.confirmation.id)
        {
            Console.WriteLine("Proses transfer berhasil");
        }
        else if (BankTransConfig.lang == "id")
        {
            Console.WriteLine("Transfer dibatalkan");
        }
    }
}