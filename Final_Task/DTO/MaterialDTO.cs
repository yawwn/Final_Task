using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Final_Task.DTO
{
    public class MaterialDTO 
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public IFormFile File { get; set; }
    }
}
