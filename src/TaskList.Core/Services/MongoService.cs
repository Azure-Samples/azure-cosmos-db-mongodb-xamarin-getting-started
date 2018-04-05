using System;
using System.Security.Authentication;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;

namespace TaskList.Core
{
    public class MongoService
    {
        IMongoCollection<MyTask> tasksCollection;

        string dbName = "MyTasks";
        string collectionName = "TaskList";

        void Init()
        {
            if (tasksCollection != null)
                return;

            // APIKeys.Connection string is found in the portal under the "Connection String" blade
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(APIKeys.ConnectionString)
            );

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            // Initialize the client
            var mongoClient = new MongoClient(settings);

            // This will create or get the database
            var db = mongoClient.GetDatabase(dbName);

            // This will create or get the collection
            tasksCollection = db.GetCollection<MyTask>(collectionName);
        }

        #region Get Functions

        public async Task<List<MyTask>> GetAllTasks()
        {
            Init();

            var allTasks = await tasksCollection
                .Find(new BsonDocument())
                .ToListAsync();

            return allTasks;
        }

        public async Task<List<MyTask>> GetIncompleteTasks()
        {
            Init();

            var incompleteTasks = await tasksCollection
                .Find(mt => mt.Complete == false)
                .ToListAsync();

            return incompleteTasks;
        }

        public async Task<MyTask> GetTaskById(Guid taskId)
        {
            Init();

            var singleTask = await tasksCollection
                .Find(f => f.Id.Equals(taskId))
                .FirstOrDefaultAsync();

            return singleTask;
        }

        #endregion

        #region Save/Delete Functions

        public async Task CreateTask(MyTask task)
        {
            Init();

            await tasksCollection.InsertOneAsync(task);
        }

        public async Task UpdateTask(MyTask task)
        {
            Init();

            await tasksCollection.ReplaceOneAsync(t => t.Id.Equals(task.Id), task);
        }

        public async Task DeleteTask(MyTask task)
        {
            Init();

            await tasksCollection.DeleteOneAsync(t => t.Id.Equals(task.Id));
        }

        #endregion

    }
}
