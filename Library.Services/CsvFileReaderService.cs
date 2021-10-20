using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Documents;
using Library.Logic;
using Library.Storage.EntityModels;

namespace Library.Services
{
    public class CsvFileReaderService : FileReader
    {
        /*private const string ReaderCsvPattern = "Id,Name,Surname,MiddleName,";*/

        public override List<T> ReadFile<T>(string filename)
        {
            using (StreamReader streamReader = new StreamReader(filename))
            {
                try
                {
                    var records = GetRecords(streamReader);
                    return (List<T>) records;
                }
                catch (Exception)
                {
                    MessageBox.Show("В выбранном файле содержится модель," +
                                    " не соответсвующая объекту \"Читатель\"");
                    return null;
                }
            }
        }

        private static IEnumerable<Reader> GetRecords(StreamReader streamReader)
        {
            var rawData = new List<string[]>();
            var outputData = new List<Reader>();

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine()?.Split(',');
                rawData.Add(line);
            }

            foreach (var rawString in rawData)
            {
                var entity = new Reader()
                {
                    Name = rawString[0],
                    Surname = rawString[1],
                    MiddleName = rawString[2],
                    Email = rawString[3],
                    Phone = rawString[4],
                    Rating = rawString[5],
                    Password = rawString[6]
                };
                outputData = (List<Reader>) outputData.Append(entity);
            }

            return outputData;
        }
    }
}