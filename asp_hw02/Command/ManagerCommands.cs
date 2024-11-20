using asp_hw02.Data;
using asp_hw02.Data_Transfer_Object;
using Microsoft.AspNetCore.Connections.Features;

namespace asp_hw02.Command
{
    public static class ManagerCommands
    {
        public static IResult AddTask(string n, string d, bool c)
        {
            var manager = new Manager
            {
                Name = n,
                Description = d,
                isCompleted = c
            };
            TasksDB.Managers.Add(manager);
            return Results.Ok(manager);
        }

        public static IResult GetAll()
        {
            var taskDTOs = TasksDB.Managers.Select(task => new TaskDTO
            {
                Name = task.Name,
                Description = task.Description,
                isCompleted = task.isCompleted
            }).ToList();

            return Results.Ok(taskDTOs);
        }

        public static IResult GetTask(string n)
        {
            var tasks = TasksDB.Managers.FirstOrDefault(manager => manager.Name == n);
            if (tasks != null)
            {
                var taskDTO = new TaskDTO { Name = tasks.Name, Description = tasks.Description, isCompleted = tasks.isCompleted };
                return Results.Ok(taskDTO);
            }
            else
            {
                return Results.BadRequest();
            }
        }

        public static IResult DeleteTask(string n)
        {
            var task = TasksDB.Managers.FirstOrDefault(Manager => Manager.Name == n);
            if (task != null)
            {
                    TasksDB.Managers.Remove(task);
               return Results.Ok($"Task {n} is deleted");
            }
            else    
            {
                return Results.NotFound();
            }
        }

        public static IResult Update(string n, string newName = null, string newDescription = null, bool? isCompleted = null)
        {

            var task = TasksDB.Managers.FirstOrDefault(manager => manager.Name == n);

            if (task != null)
            {
                if (!string.IsNullOrEmpty(newName))
                    task.Name = newName;

                if (!string.IsNullOrEmpty(newDescription))
                    task.Description = newDescription;

                if (isCompleted.HasValue)
                    task.isCompleted = isCompleted.Value;

                return Results.Ok($"Task '{n}' was successfully updated.");
            }

           
            return Results.NotFound($"Task with name '{n}' not found.");
        }

    }
}
