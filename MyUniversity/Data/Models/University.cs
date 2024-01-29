using MyUniversity.Base;

namespace MyUniversity.Data.Models
{
    public class University:EntityBase
    {
       
        public int Rate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
       
    }
}
