using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace csgo_app
{
    public interface IFileHelper
    {
    string GetLocalFilePath(string filename);
    }
}