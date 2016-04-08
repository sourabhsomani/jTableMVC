using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jTableMVC.Entities
{
    public class Marks
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string RollNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MarksObtained  { get; set; }
        [Required]
        public string TotalMarks { get; set; }
    }
}