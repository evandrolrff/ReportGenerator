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
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into Activity values (@id, @name, @description, @typeActivity, @descriptionURL)";
                command.Parameters.Add("@id", DbType.Int32).Value = null;
                command.Parameters.Add("@name", DbType.String).Value = actModel.Name;
                command.Parameters.Add("@description", DbType.String).Value = actModel.Description;
                command.Parameters.Add("@typeActivity", DbType.String).Value = actModel.Type;
                command.Parameters.Add("@descriptionURL", DbType.String).Value = actModel.DescriptionURL;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete from Activity where id = @id";
                command.Parameters.Add("@id", DbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(ActivityModel actModel)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Update Activity 
                                        set name = @name, description = @description, typeActivity = @typeActivity,
                                        descriptionURL = @descriptionURL where id = @id";
                command.Parameters.Add("@name", DbType.String).Value = actModel.Name;
                command.Parameters.Add("@description", DbType.String).Value = actModel.Description;
                command.Parameters.Add("@typeActivity", DbType.String).Value = actModel.Type;
                command.Parameters.Add("@descriptionURL", DbType.String).Value = actModel.DescriptionURL;
                command.Parameters.Add("@id", DbType.Int32).Value = actModel.Id;
                command.ExecuteNonQuery();
            }
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
                        actModel.Id = Convert.ToInt32(reader["id"]);
                        actModel.Name = reader["name"].ToString();
                        actModel.Description = reader["description"].ToString();
                        actModel.Type = reader["typeActivity"].ToString();
                        actModel.DescriptionURL = reader["descriptionURL"].ToString();
                        activityList.Add(actModel);
                    }
                }
            }
            return activityList;
        }

        public IEnumerable<ActivityModel> GetByValue(string value)
        {
            var activityList = new List<ActivityModel>();
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
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
                        actModel.Id = Convert.ToInt32(reader["id"]);
                        actModel.Name = reader["name"].ToString();
                        actModel.Description = reader["description"].ToString();
                        actModel.Type = reader["typeActivity"].ToString();
                        actModel.DescriptionURL = reader["descriptionURL"].ToString();
                        activityList.Add(actModel);
                    }
                }
            }
            return activityList;
        }
    }
}
