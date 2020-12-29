using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Data.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<Version> Versions { get; set; }
    }
}
