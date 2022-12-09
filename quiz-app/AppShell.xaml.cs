using quiz_app.Views;

namespace quiz_app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
        Routing.RegisterRoute(nameof(StudyPage), typeof(StudyPage));
    }
}
