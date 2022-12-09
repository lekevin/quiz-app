using System;
using SQLite;
using QuizSQLite.Models;

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

		Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		var result = await Database.CreateTableAsync<QuizItem>();
	}

    public async Task<List<QuizItem>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<QuizItem>().ToListAsync();
    }

    public async Task<int> SaveItemAsync(QuizItem item)
    {
        await Init();
        if (item.ID != 0)
            return await Database.UpdateAsync(item);
        else
            return await Database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(QuizItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<List<QuizItem>> GetQuestionsAsync()
    {
        await Init();
        return await Database.QueryAsync<QuizItem>("SELECT Questions FROM [QuizItem]");
    }

    public async Task<List<QuizItem>> GetAnswersAsync()
    {
        await Init();
        return await Database.QueryAsync<QuizItem>("SELECT Answers FROM [QuizItem]");
    }
}


