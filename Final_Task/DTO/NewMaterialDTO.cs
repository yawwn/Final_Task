using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.DTO
{
    public class NewMaterialDTO
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
