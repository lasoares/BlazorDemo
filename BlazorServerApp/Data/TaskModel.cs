using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class TaskModel
    {
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
