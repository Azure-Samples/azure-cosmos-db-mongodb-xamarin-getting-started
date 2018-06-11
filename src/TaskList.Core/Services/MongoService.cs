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
        string dbName = "MyTasks";
        string collectionName = "TaskList";

        IMongoCollection<MyTask> tasksCollection;
        IMongoCollection<MyTask> TasksCollection
        {
            get
            {
                if (tasksCollection == null)
                {
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
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    tasksCollection = db.GetCollection<MyTask>(collectionName, collectionSettings);
                }
                return tasksCollection;
            }
        }

        #region Get Functions

        public async Task<List<MyTask>> GetAllTasks()
        {
            try
            {
                var allTasks = await TasksCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                return allTasks;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<List<MyTask>> GetIncompleteTasks()
        {
            var incompleteTasks = await TasksCollection
                .Find(mt => mt.Complete == false)
                .ToListAsync();

            return incompleteTasks;
        }

        public async Task<MyTask> GetTaskById(Guid taskId)
        {
            var singleTask = await TasksCollection
                .Find(f => f.Id.Equals(taskId))
                .FirstOrDefaultAsync();

            return singleTask;
        }

        #endregion

        #region Search Functions

        public async Task<List<MyTask>> GetIncompleteTasksDueBefore(DateTime date)
        {
            var tasks = await TasksCollection
                            .AsQueryable()
                            .Where(t => t.Complete == false)
                            .Where(t => t.DueDate < date)
                            .ToListAsync();

            return tasks;
        }

        #endregion

        #region Save/Delete Functions

        public async Task CreateTask(MyTask task)
        {
            await TasksCollection.InsertOneAsync(task);
        }

        public async Task UpdateTask(MyTask task)
        {
            await TasksCollection.ReplaceOneAsync(t => t.Id.Equals(task.Id), task);
        }

        public async Task DeleteTask(MyTask task)
        {
            await TasksCollection.DeleteOneAsync(t => t.Id.Equals(task.Id));
        }

        #endregion

    }
}
