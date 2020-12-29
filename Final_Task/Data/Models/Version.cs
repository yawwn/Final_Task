using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Data.Models
{
    public class Version
    {
        public int Id { get; set; }
        public DateTime UploadTime { get; set; }
        public long Size { get; set; }
        public int VersionCounter { get; set; }
        public int MaterialId { get; set; } // внешний ключ
        public Material Material { get; set; } // навигационный ключ
    }
}
