using System.Collections.ObjectModel;
using QuizSQLite.Models;

using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace quiz_app.Views;
public partial class StudyPage : ContentPage
{
    public ObservableCollection<QuizSet> Items { get; set; } = new();
    QuizDatabase database = new QuizDatabase();
    int quizID;
    int questionCounter = 0;
   
    public StudyPage(int i)
    {
        quizID = i;
        
        InitializeComponent();
        init();
        
    }
    public void BindData()
    {
        this.Answer.Text = Items[questionCounter].Answer;
        this.Question.Text = Items[questionCounter].Question;
    }

    
    public async void init()
    {
        var items = await database.GetItemsAsync();
        
            foreach (var item in items)
                if (item.QuizID == quizID)
                {
                    Items.Add(item);
                }
       
        BindData();
    }
    private void OnCardTapped(object sender, EventArgs e)
    {
        var label = sender as Label;
        
        if (label.BackgroundColor == Colors.Lavender)
        {
            label.RotateXTo(360, 300);
            label.BackgroundColor = Colors.White;
            label.Text = "one";
        }
        else
        {
            label.RotateXTo(360, 300);
            label.Text = "two";
            label.BackgroundColor = Colors.Lavender;
        }

    }
    public void onNext(object sender, EventArgs e)
    {
        quizID++;
        BindData();
    }
}
