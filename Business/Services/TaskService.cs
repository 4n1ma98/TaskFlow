using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository iTaskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            iTaskRepository = taskRepository;
        }

        public async Task<GenericResult> GetTasksAsync()
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };

            resultCallApi = await iTaskRepository.GetTasks();
            return resultCallApi;
        }

        public async Task<GenericResult> GetTaskByIdAsync(int id)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };
            resultCallApi = await iTaskRepository.GetTaskById(id);
            return resultCallApi;
        }
        public async Task<GenericResult> CreateTaskAsync(string task)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };
            resultCallApi = await iTaskRepository.CreateTask(task);
            return resultCallApi;
        }

        public async Task<GenericResult> UpdateTaskAsync(int id, string task)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };
            resultCallApi = await iTaskRepository.UpdateTask(id, task);
            return resultCallApi;
        }

        public async Task<GenericResult> DeleteTaskAsync(int id)
        {
            GenericResult resultCallApi = new() { IsSuccesfull = false };
            resultCallApi = await iTaskRepository.DeleteTask(id);
            return resultCallApi;
        }
    }
}
