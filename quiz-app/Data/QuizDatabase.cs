using System;
using SQLite;
using QuizSQLite.Models;

namespace quiz_app;

public class QuizDatabase
{
	static SQLiteAsyncConnection Database;

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

    public async Task<List<QuizItem>> GetItemsNotDoneAsync()
    {
        await Init();
        return await Database.Table<QuizItem>().Where(t => t.Done).ToListAsync();

        // SQL queries are also possible
        //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    }

    public async Task<QuizItem> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<QuizItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
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
}


