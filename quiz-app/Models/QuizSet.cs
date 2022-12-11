using System;
using SQLite;
namespace QuizSQLite.Models;

[Table("QuizSet")]
public class QuizSet
{
    public QuizSet() {}

    [PrimaryKey, AutoIncrement, Column("ID")]
    public int ID { get; set; }
    [Column("QuizID")]
    public int QuizID { get; set; }
    [Column("Question")]
    public string Question { get; set; }

    [Column("Answer")]
    public string Answer { get; set; }
}