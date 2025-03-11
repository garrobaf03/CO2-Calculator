using System;
using BASE.Modelos;
using SQLite;
using System.IO;

namespace BASE.Datos
{
    public class OperacionesDatabase
    {
        static SQLiteAsyncConnection db;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Operaciones.db3"));
                    db.CreateTableAsync<Operacion>().Wait();
                }
                return db;
            }


        }
    }

}