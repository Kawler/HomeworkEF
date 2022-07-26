using System;
using System.Collections.Generic;

namespace HomeworkEF.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
