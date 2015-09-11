using System;

namespace EmptyApplication.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string NewColumn { get; set; }
    }    
}
