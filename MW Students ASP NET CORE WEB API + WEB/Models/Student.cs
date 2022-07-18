using System;

namespace MW_Students_ASP_NET_CORE_WEB_API___WEB.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Group { get; set; }
    }
}
