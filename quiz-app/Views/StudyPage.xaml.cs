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

        if (Color.FromHex("#554971").Equals(Color.FromHex(label.BackgroundColor.ToString())))
        {
            label.RotateYTo(360, 200);
            label.BackgroundColor = Colors.LightGray;
            label.Text = "sup bruh";
        }
        else
        {
            // Background color is not #554971
        }

    }
}
