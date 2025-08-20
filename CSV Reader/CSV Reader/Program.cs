using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        string folderPath = @"C:\Users\admin\Downloads\CompressedAccountingEntries"; // Folder with ZIP files
        string searchString = "00514"; // String to search

        foreach (string zipFilePath in Directory.GetFiles(folderPath, "*.zip"))
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var reader = new StreamReader(entry.Open()))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains(searchString))
                                {
                                    Console.WriteLine($"Found in: {Path.GetFileName(zipFilePath)} | Entry: {entry.FullName}");
                                    // Optionally break here if only one match per CSV or per ZIP is enough.
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
