﻿
//using System.Runtime.CompilerServices;
//using DB.DataLayer;


//[assembly: Dependency(typeof(SQLite_Android))]
//// ...
//public class SQLite_Android : ISQLite
//{
//    public SQLite_Android() { }
//    public SQLite.SQLiteConnection GetConnection()
//    {
//        var sqliteFilename = "TodoSQLite.db3";
//        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
//        var path = Path.Combine(documentsPath, sqliteFilename);
//        // Create the connection
//        var conn = new SQLite.SQLiteConnection(path);
//        // Return the database connection
//        return conn;
//    }
//}