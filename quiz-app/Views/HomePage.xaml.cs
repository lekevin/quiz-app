namespace quiz_app.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
        InitializeComponent();
	}

    public async void OnContinueTapped(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync("ListPage");
    }
}