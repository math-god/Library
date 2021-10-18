using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using CsvHelper;
using Library.Models;

namespace Library.FileExplorer
{
    public class CsvFileService
    {
        public static List<Reader> Open(string filename)
        {
            using (StreamReader streamReader = new StreamReader(filename))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        var records = csvReader.GetRecords<Reader>().ToList();
                        return records;
                    }
                    catch (HeaderValidationException exception)
                    {
                        MessageBox.Show("В выбранном файле содержится модель," +
                                        " не соответсвующая объекту \"Читатель\"");
                        return null;
                    }
                }
            }
        }
    }
}