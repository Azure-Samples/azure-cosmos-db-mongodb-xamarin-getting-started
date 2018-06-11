using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace TaskList.Core
{
    public class MyTask : INotifyPropertyChanged
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }

        string _name;
        [BsonElement("Name")]
        public string Name
        {
            get => _name; set
            {
                if (_name == value)
                    return;

                _name = value;

                HandlePropertyChanged();
            }
        }

        string _category;
        [BsonElement("Category")]
        public string Category
        {
            get => _category;
            set
            {
                if (_category == value)
                    return;

                _category = value;

                HandlePropertyChanged();
            }
        }

        bool _complete;
        [BsonElement("Complete")]
        public bool Complete
        {
            get => _complete;
            set
            {
                if (_complete == value)
                    return;

                _complete = value;

                HandlePropertyChanged();
            }
        }


        DateTime _dueDate = DateTime.Today.AddDays(7);
        [BsonElement("DueDate")]
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate == value)
                    return;

                _dueDate = value;

                HandlePropertyChanged();
            }
        }

        void HandlePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
