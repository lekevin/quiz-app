using System;
using SQLite;

namespace quiz_app
{
    public static class Constants
    {
        public const string DatabaseFilename = "quiz.db";

        private const SQLite.SQLiteOpenFlags flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public static SQLiteOpenFlags Flags => flags;
    }
}

