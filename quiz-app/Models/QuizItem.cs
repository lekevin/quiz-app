using System;
using SQLite;
namespace QuizSQLite.Models;

[Table("Quiz Content")]
public class QuizItem
{
    public QuizItem() {}

    [PrimaryKey, AutoIncrement, Column("ID")]
    public int ID { get; set; }

    [Column("QuizID")]
    public int QuizID { get; set; }

    [Column("Question")]
    public string Question { get; set; }

    [Column("Answer")]
    public string Answer { get; set; }

    public bool Done { get; set; }
}