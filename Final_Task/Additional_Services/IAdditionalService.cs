using Final_Task.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Additional_Services
{
    public interface IAdditionalService
    {
        public void SaveFile(string name, IFormFile file);
        public void SaveNewFile(Material material, IFormFile file);
        public string GetPathToFile(Material material, int? version);
        public string GetValueAppSett();
    }
}
