using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Xamarin.Android;

namespace CookingApplication
{
    [Activity(Label = "SQLite_Android")]
    public class SQLite_Android : Activity
    {
        public SQLite_Android() { }
        public string GetDbPath(string sqliteFilename)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFilename);
            if (!File.Exists(path))
                {
                var dbAssetStream = Android.App.Application.Context.Assets.Open(sqliteFilename);
                var dbFileStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                var buffer = new byte[1024];
                int b = buffer.Length;
                int lenght;
                while ((lenght= dbAssetStream.Read(buffer, 0, b)) >0)
                {
                    dbFileStream.Write(buffer, 0, lenght);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
                }
            return path;
        }
    }
}