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
        //this.Answer.Text = Items[questionCounter].Answer;
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
    int x = 360;
    int x2 = 300;
    private void OnCardTapped(object sender, EventArgs e)
    {
        var label = sender as Label;

        
        label.RotateXTo(x, (uint)x2);

        if (label.BackgroundColor == Colors.Lavender)
        {
            label.BackgroundColor = Colors.White;
            label.Text = Items[questionCounter].Answer;
            x = 360;
            x2 = 360;
        }
        else
        {

            label.Text = Items[questionCounter].Question;
            label.BackgroundColor = Colors.Lavender;
            x = 0;
            x2 = 360;
        }

    }
    public void onNext(object sender, EventArgs e)
    {
        quizID++;
        BindData();
    }
}
