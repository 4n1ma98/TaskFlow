using DataAccess.Repositories.Interfaces;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        public async Task<GenericResult> GetTasks()
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };

            var tasks = new List<string> { "Task 1", "Task 2", "Task 3" };
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
