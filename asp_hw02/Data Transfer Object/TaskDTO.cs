using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace asp_hw02.Data_Transfer_Object
{
    public class TaskDTO
    {
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool isCompleted { get; set; }
    }
}
