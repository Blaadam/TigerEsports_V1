using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerEsports_V1.Databases
{
    using SQLite;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TigerEsports_V1.Data;

    public class UserDatabase
    {
        private SQLiteAsyncConnection _database;

        public UserDatabase()
        {
        }

        public async Task Init()
        {
            if (_database != null)
                return;

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await _database.CreateTableAsync<User>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Init();
            return await _database.Table<User>().ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            await Init();
            return await _database.GetAsync<User>(id);
        }

        public async Task<List<User>> SearchUsersAsync(string searchUsername)
        {
            await Init();
            return await _database.Table<User>()
                .Where(u => u.Username.ToLower() == searchUsername)
                .ToListAsync();
        }

        public async Task<int> SaveUserAsync(User user)
        {
            await Init();
            if (user.Id != 0)
                return await _database.UpdateAsync(user);
            else
                return await _database.InsertAsync(user);
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            await Init();
            return await _database.DeleteAsync(user);
        }
    }

}
