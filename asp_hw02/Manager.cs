using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace asp_hw02
{
    public class Manager
    {
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool isCompleted { get; set; }
        public int id { get; set; }
    }
}

    //    public static List<Manager> tasks = new List<Manager>();
    //    private static int next = 0;
    //    public static void AddTask(string n, string d, bool c)
    //    {
    //        tasks.Add(new Manager
    //        {
    //            Name = n,
    //            Description = d,
    //            isCompleted = c,
    //            id = next++
    //        });


    //    }

    //    public static bool RemoveTask(int id)
    //    {
    //        var remove = tasks.FirstOrDefault
    //            (t => t.id == id);
    //        if (remove != null)
    //        {
    //            tasks.Remove(remove);
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public static List<Manager> GetAllTasks()
    //    {
    //        return tasks;
    //    }

    //    public static List<Manager> GetById(int id)
    //    {
    //        return tasks.Where(task => task.id == id).ToList();
    //    }

    //    public static bool Update(int id, string n, string d, bool c)
    //    {
    //        var updateTask = tasks.FirstOrDefault(t => t.id == id);
    //        if (updateTask != null)
    //        {
    //            updateTask.id = id;
    //            updateTask.Name = n;
    //            updateTask.Description = d;
    //            updateTask.isCompleted = c;
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }


    //}

