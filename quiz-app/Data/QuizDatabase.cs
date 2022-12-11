using System;
using SQLite;
using QuizSQLite.Models;
using System.Reflection;

namespace quiz_app;

public class QuizDatabase
{
	SQLiteAsyncConnection Database;

	public QuizDatabase()
	{
	}

	async Task Init()
	{
		if (Database is not null)
			return;
        //string fileName = AppDomain.CurrentDomain.BaseDirectory;
        //var directory = System.IO.Path.GetDirectoryName(fileName);
        //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

        var enviroment = System.Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(enviroment).Parent.Parent.Parent.Parent.FullName;


        //using (Stream stream = assembly.GetManifestResourceStream("quiz_app.quizset.db"))
        //{
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        stream.CopyTo(memoryStream);
        //        File.WriteAllBytes(QuizRepository.DbPath, memoryStream.ToArray());
        //    }
        //}
        Database = new SQLiteAsyncConnection(Path.Combine(projectDirectory, "quizset.db"), Constants.Flags);
		//var result = await Database.CreateTableAsync<QuizSet>();
	}

    public async Task<List<QuizSet>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<QuizSet>().ToListAsync();
    }

    //public async Task<int> SaveItemAsync(QuizItem item)
    //{
    //    await Init();
    //    if (item.ID != 0)
    //        return await Database.UpdateAsync(item);
    //    else
    //        return await Database.InsertAsync(item);
    //}

    //public async Task<int> DeleteItemAsync(QuizItem item)
    //{
    //    await Init();
    //    return await Database.DeleteAsync(item);
    //}

    //public async Task<List<QuizItem>> GetQuestionsAsync()
    //{
    //    await Init();
    //    return await Database.QueryAsync<QuizItem>("SELECT Questions FROM [QuizItem]");
    //}

    //public async Task<List<QuizItem>> GetAnswersAsync()
    //{
    //    await Init();
    //    return await Database.QueryAsync<QuizItem>("SELECT Answers FROM [QuizItem]");
    //}
}


