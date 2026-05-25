using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ITaskService
    {
        Task<GenericResult> GetTasksAsync();
        Task<GenericResult> GetTaskByIdAsync(int id);
        Task<GenericResult> CreateTaskAsync(string task);
        Task<GenericResult> UpdateTaskAsync(int id, string task);
        Task<GenericResult> DeleteTaskAsync(int id);
    }
}
