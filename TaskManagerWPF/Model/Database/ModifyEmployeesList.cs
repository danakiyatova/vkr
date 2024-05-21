using System.Windows.Media.Imaging;

namespace TaskManagerWPF.Model.Database
{
    internal class ModifyEmployeesList
    {
        public int EmployeeID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int JobID { get; set; }
        public System.DateTime LastLogin { get; set; }
        public byte[] EmployeeImage { get; set; }
        public BitmapSource BitmapImage { get; set; }

        private static ModifyEmployeesList CreateFromContext(Employee result)
        {
            var modify = new ModifyEmployeesList
            {
                EmployeeID = result.EmployeeID,
                Surname = result.Surname,
                Name = result.Name,
                Patronymic = result.Patronymic,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                JobID = result.JobID,
                LastLogin = result.LastLogin,
                EmployeeImage = result.EmployeeImage
            };
            return modify;
        }

        public static implicit operator ModifyEmployeesList(Employee result) => CreateFromContext(result);

    }
}
