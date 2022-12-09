using System;
using SQLite;
namespace QuizSQLite.Models;

[Table("QuizSetTest")]
public class QuizSetTest
{
    public QuizSetTest() {}

    [PrimaryKey, AutoIncrement, Column("qID")]
    public int qID { get; set; }

    [Column("Question")]
    public string Question { get; set; }

    [Column("Answer")]
    public string Answer { get; set; }
}