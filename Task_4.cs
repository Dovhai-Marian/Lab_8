using System;
using System.Collections.Generic;
using System.IO;

interface IDataTemplate : ICloneable
{
    void LoadData(string data);
    string ExportData();
}

class CsvDataTemplate : IDataTemplate
{
    private List<string[]> data;

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void LoadData(string data)
    {
        this.data = new List<string[]>(data.Split('\n').Select(row => row.Split(',')));
    }

    public string ExportData()
    {
        return string.Join('\n', data.Select(row => string.Join(',', row)));
    }
}

class XmlDataTemplate : IDataTemplate
{
    private string data;

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void LoadData(string data)
    {
        this.data = data;
    }

    public string ExportData()
    {
        return data;
    }
}

class JsonDataTemplate : IDataTemplate
{
    private string data;

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void LoadData(string data)
    {
        this.data = data;
    }

    public string ExportData()
    {
        return data;
    }
}
class DataFormatAdapter
{
    private IDataTemplate sourceTemplate;
    private IDataTemplate targetTemplate;

    public DataFormatAdapter(IDataTemplate sourceTemplate, IDataTemplate targetTemplate)
    {
        this.sourceTemplate = sourceTemplate;
        this.targetTemplate = targetTemplate;
    }

    public void ConvertAndExportData(string sourceData)
    {
        sourceTemplate.LoadData(sourceData);

        string exportedData = sourceTemplate.ExportData();

        targetTemplate.LoadData(exportedData);

        Console.WriteLine("Converted data in target format:");
        Console.WriteLine(targetTemplate.ExportData());
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the source data format (csv/xml/json): ");
        string sourceFormat = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the target data format (csv/xml/json): ");
        string targetFormat = Console.ReadLine().ToLower();

        IDataTemplate sourceTemplate = CreateTemplate(sourceFormat);
        IDataTemplate targetTemplate = CreateTemplate(targetFormat);

        if (sourceTemplate != null && targetTemplate != null)
        {
            DataFormatAdapter adapter = new DataFormatAdapter(sourceTemplate, targetTemplate);

            Console.WriteLine("Enter the source data: ");
            string sourceData = Console.ReadLine();

            adapter.ConvertAndExportData(sourceData);
        }
        else
        {
            Console.WriteLine("Invalid data format.");
        }

        Console.ReadLine();
    }

    static IDataTemplate CreateTemplate(string format)
    {
        switch (format)
        {
            case "csv":
                return new CsvDataTemplate();
            case "xml":
                return new XmlDataTemplate();
            case "json":
                return new JsonDataTemplate();
            default:
                return null;
        }
    }
}
