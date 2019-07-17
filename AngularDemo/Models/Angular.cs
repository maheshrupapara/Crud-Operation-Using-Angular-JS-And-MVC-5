using System.ComponentModel.DataAnnotations;

namespace AngularDemo.Models
{
    public class Angular
    {
        [Key]
        public int Id {get;set;}
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}