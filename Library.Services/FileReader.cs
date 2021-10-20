﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;

namespace Library.Services
{
    public abstract class FileReader
    {
        public abstract List<T> ReadFile<T>(string filename);

        public bool IsFileEmpty(StreamReader streamReader)
        {
            return streamReader.ReadToEnd() == string.Empty;
        }
    }
}