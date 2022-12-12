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
        //var label = sender as Label;

        
        this.Question.RotateXTo(x, (uint)x2);

        if (this.Question.BackgroundColor == Colors.Lavender)
        {
            this.Question.BackgroundColor = Colors.White;
            this.Question.Text = Items[questionCounter].Answer;
            x = 360;
            x2 = 360;
        }
        else
        {

            this.Question.Text = Items[questionCounter].Question;
            this.Question.BackgroundColor = Colors.Lavender;
            x = 0;
            x2 = 360;
        }

    }
    public void onNext(object sender, EventArgs e)
    {
        questionCounter++;
        this.Question.BackgroundColor = Colors.Lavender;
        BindData();
    }
    public void onPrevious(object sender, EventArgs e)
    {
        if (questionCounter == 0)
            return;
        questionCounter--;

        this.Question.BackgroundColor = Colors.Lavender;
        BindData();
    }
}
