using Cities;
using Csv;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace csv.Tests
{
        [TestClass()]
        public class WritecvsfilesTests
        {
            [TestMethod()]
            public void WritecvsTest()
            {
            
            var path = "c://Users//mukukach//Documents//csvfiles//worldcities.csv";
                var doubleTypeConversion = new DoubleConversion();
                IList<CityModelImport> myList = ReadCsv.ReadCsvFile<CityModelImport, CityMap>(path, doubleTypeConversion);
                var Capital_Regular = from s in myList
                                where s.Capital.Equals("admin")
                                orderby s.Capital ascending
                                select s;
                // SOme Update
                foreach (CityModelImport city in Capital_Regular)
                {
                    Debug.Write(city.Capital + ": " + city.City_name + Environment.NewLine);
                }
                var queryName = nameof(Capital_Regular);
                var writePath = "c://csvfiles//" + queryName + ".csv";
                using (var writer = new StreamWriter(writePath))
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(Capital_Regular);
                }
                Assert.IsTrue(File.Exists(writePath));

                var QSCount = (from city in Capital_Regular
                               select city).Count();

                Debug.Write(QSCount);

                Assert.AreEqual(15493, myList.Count());


            }
        }
    
}