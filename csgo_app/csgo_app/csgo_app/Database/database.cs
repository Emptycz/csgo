using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace csgo_app.Database
{
    public class database
    {
        // SQLite connection
        private SQLiteAsyncConnection Database;

        public database(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<TodoItem>().Wait();
        }
        // Query
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return Database.Table<TodoItem>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] ");
        }
        public Task<List<TodoItem>> GetItemssearch(int item)
        {
            return Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [ISBN] = " + item);
        }


        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<List<TodoItem>> DeleteItemAsync(int item)
        {
            return Database.QueryAsync<TodoItem>("DELETE FROM [TodoItem] WHERE [ID] = " + item);
        }

    }
}
