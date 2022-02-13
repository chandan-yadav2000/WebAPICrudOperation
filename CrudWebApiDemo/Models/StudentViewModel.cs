using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApiDemo.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }
    }
}