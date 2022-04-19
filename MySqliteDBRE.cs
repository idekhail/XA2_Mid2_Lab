using System;
using SQLite;
using System.IO;

namespace XA2_Mid2_Lab
{
    class MySqliteDBRE
    {
        //database path
        private string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyCodeDB.db3");
        public MySqliteDBRE()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Codes>();
            }
        }
        //Insert data into DB  
        public void Insert(Codes code)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(code);
        }
        //Update data in DB   
        public void Update(Codes code)
        {
            var db = new SQLiteConnection(dbPath);          
            db.Update(code);
        }
        // Return True if data is found othewies return false
        public bool Check(string mobile)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Codes>().Where(i => i.Mobile == mobile).FirstOrDefault();
            if (table == null)
                return true;
            return false;
        }
        //Return Table from DB  
        public Codes GetCode(string mobile, string code)
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<Codes>().Where(i => i.Mobile == mobile && i.Code == code).FirstOrDefault();                      
        }

        public Codes GetCodeById(int id)
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<Codes>().Where(i => i.Id == id).FirstOrDefault();
        }

        [Table("Codes")]
        public class Codes
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }
            public string Mobile { get; set; }
            public string Code { get; set; }
        }
    }
}
