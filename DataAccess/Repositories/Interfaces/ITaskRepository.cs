using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<GenericResult> GetTasks();
        Task<GenericResult> GetTaskById(int id);
        Task<GenericResult> CreateTask(string task);
        Task<GenericResult> UpdateTask(int id, string task);
        Task<GenericResult> DeleteTask(int id);
    }
}
