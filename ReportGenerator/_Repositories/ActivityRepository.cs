using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using ReportGenerator.Models;

namespace ReportGenerator._Repositories
{
    public class ActivityRepository : BaseRepository, IActivityRepository
    {

        //Constructor
        public ActivityRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        //Method
        public void Add(ActivityModel actModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ActivityModel actModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityModel> GetAll()
        {
            var activityList = new List<ActivityModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText= "Select * from Activity order by id desc";
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var actModel = new ActivityModel();
                        actModel.Id = (int)reader["ID"];
                        actModel.Name = reader["Name"].ToString();
                        actModel.Description = reader["Description"].ToString();
                        actModel.Type = reader["Type"].ToString();
                        actModel.DescriptionURL = reader["Description"].ToString();
                        activityList.Add(actModel);
                    }
                }
            }
            return activityList;
        }

        public IEnumerable<ActivityModel> GetByValue(string value)
        {
            var activityList = new List<ActivityModel>();
            UInt64 id = int.TryParse(value, out _) ? Convert.ToUInt64(value) : 0;
            string name = value;

            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from Activity
                                        Where id=@id or name like @name+'%'
                                        order by id desc";
                command.Parameters.Add("@id", DbType.UInt64).Value = id;
                command.Parameters.Add("@name", DbType.String).Value = name;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var actModel = new ActivityModel();
                        actModel.Id = (int)reader["ID"];
                        actModel.Name = reader["Name"].ToString();
                        actModel.Description = reader["Description"].ToString();
                        actModel.Type = reader["Type"].ToString();
                        actModel.DescriptionURL = reader["Description"].ToString();
                        activityList.Add(actModel);
                    }
                }
            }
            return activityList;
        }
    }
}
