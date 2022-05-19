﻿using System.Collections.Generic;

namespace SimpleRepo.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
