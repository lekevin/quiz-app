namespace quiz_app.Views;
public partial class StudyPage : ContentPage
{
	public StudyPage()
	{
		InitializeComponent();
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
}
