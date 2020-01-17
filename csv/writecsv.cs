using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
namespace Csv
{ 
public class Writecvsfiles
{
    public static IList<T> Writecvs <T, M> (string absolutePath, CsvHelper.TypeConversion.ITypeConverter DoubleTypeConversion)
    {
        var path =  absolutePath;
     
        Type mapType = typeof(M);
        IList<T> records = new List<T>();
        
        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer))
        {
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.TypeConverterCache.AddConverter(typeof(double), DoubleTypeConversion);
            csv.Configuration.RegisterClassMap(mapType);

            csv.WriteRecords(records);
        }
        return records;

    }
}
}
