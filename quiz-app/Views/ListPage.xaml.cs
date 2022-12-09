using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using QuizSQLite.Models;
using System.Runtime.CompilerServices;
namespace quiz_app.Views;

public partial class ListPage : ContentPage
{
    public ObservableCollection<QuizSetTest> SetTest { get; set; } = new ObservableCollection<QuizSetTest>();

    public ListPage()
	{
		InitializeComponent();

        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

        using (Stream stream =
            assembly.GetManifestResourceStream("quiz_app.mockquizset.db"))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);

                File.WriteAllBytes(QuizRepository.DbPath,
                    memoryStream.ToArray());
            }
        }

        QuizRepository repository = new QuizRepository();
        foreach (var quizsettestitem in repository.List())
        {
            SetTest.Add(quizsettestitem);
        }

        BindingContext = this;
    }
}