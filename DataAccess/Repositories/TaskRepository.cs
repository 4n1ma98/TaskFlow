using Dapper;
using DataAccess.Db;
using DataAccess.Repositories.Interfaces;
using Models.Entities;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbConnectionFactory _iDbConnectionFactory;
        public TaskRepository(IDbConnectionFactory iDbConnectionFactory)
        {
            _iDbConnectionFactory = iDbConnectionFactory;
        }

        public async Task<GenericResult> GetTasks()
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };

            // 1. Declaramos la consulta SQL
            const string query = "SELECT * FROM Tasks";

            // 2. Usamos la fábrica para obtener la conexión limpia
            using IDbConnection db = _iDbConnectionFactory.CreateConnection();

            // 3. Dapper ejecuta el query y con .ToList() lo volcamos directo a List<TaskEntity>
            List<TaskEntity> tasks = [.. (await db.QueryAsync<TaskEntity>(query))];

            resultCallApi.Id = 0;
            resultCallApi.IsSuccesfull = true;
            resultCallApi.Message = string.Empty;
            resultCallApi.Data = tasks; 

            return resultCallApi;
        }

        public async Task<GenericResult> GetTaskById(int id)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };

            var task = $"Task {id}";
            resultCallApi.Id = id;
            resultCallApi.IsSuccesfull = true;
            resultCallApi.Message = string.Empty;
            resultCallApi.Data = task;

            return resultCallApi;
        }

        public async Task<GenericResult> CreateTask(string task)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };

            resultCallApi.Id = 0;
            resultCallApi.IsSuccesfull = true;
            resultCallApi.Message = "Task created successfully.";
            resultCallApi.Data = task;

            return resultCallApi;
        }

        public async Task<GenericResult> UpdateTask(int id, string task)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };

            resultCallApi.Id = id;
            resultCallApi.IsSuccesfull = true;
            resultCallApi.Message = "Task updated successfully.";
            resultCallApi.Data = task;

            return resultCallApi;
        }

        public async Task<GenericResult> DeleteTask(int id)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };
            resultCallApi.Id = id;
            resultCallApi.IsSuccesfull = true;
            resultCallApi.Message = "Task deleted successfully.";
            resultCallApi.Data = null;
            return resultCallApi;
        }
    }
}
