using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerWPF.Model.Database
{
    internal class ModifyTasksList
    {

        public int TaskID { get; set; }
        public string TaskName { get; set; }
        
        public string TaskExecutor { get; set; }
        public string TaskContext { get; set; }

        public System.DateTime TaskStart { get; set; }
        public System.DateTime TaskEnd { get; set; }
        public int TaskStatusID { get; set; }
        public int EmployeeID { get; set; }

        
        public string TaskStatusName { get; set; }

        public string Surname { get; set; }

        private static ModifyTasksList CreateFromContext(Task result)
        {
            TaskManagerDBEntities db = new TaskManagerDBEntities();

            string x = "";
            string y = "";
           

            foreach (var item in db.GetStatusName(result.TaskStatusID))
            {
                x = item;
            }

            foreach (var item in db.GetEmployeeSurname(result.EmployeeID))
            {
                y = item;
            }

            var modify = new ModifyTasksList
            {
                TaskID = result.TaskID,
                TaskName = result.TaskName,
                TaskExecutor = result.TaskExecutor,
                TaskContext = result.TaskContext,
                TaskStart = result.TaskStart,
                TaskEnd = result.TaskEnd,
                TaskStatusName = x,
                Surname = y
        

            };
            return modify;
        }

        public static implicit operator ModifyTasksList(Task result) => CreateFromContext(result);

    }
}

