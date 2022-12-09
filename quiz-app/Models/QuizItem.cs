using System;
using SQLite;

namespace QuizSQLite.Models;

public class QuizItem
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public bool Done { get; set; }
}


