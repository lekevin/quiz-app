using System;
using QuizSQLite.Models;
using System.IO;
using System.Collections.Generic;
using SQLite;

namespace quiz_app
{
	public class QuizRepository
	{
		private readonly SQLiteConnection _database;

        public static string DbPath { get; } =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mockquizset.db");

		public QuizRepository()
		{
			_database = new SQLiteConnection(DbPath);
			_database.CreateTable<QuizSetTest>();
		}

		public List<QuizSetTest> List()
		{
			return _database.Table<QuizSetTest>().ToList();
		}
	}
}

