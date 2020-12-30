using Final_Task.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task.Additional_Services
{
    public class AdditionalService : IAdditionalService
    {
        private readonly IConfiguration _config;

        public AdditionalService(IConfiguration config)
        {
            _config = config;
        }

        public void SaveFile(string name, IFormFile file)
        {
            string path = _config.GetValue<String>("FilesPath:Type:ProjectDirectory") + name + "_v1";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
            }
        }

        public void SaveNewFile(Material material, IFormFile file)
        {
            string path = _config.GetValue<String>("FilesPath:Type:ProjectDirectory") + material.Name + "_v" + (material.Versions.Count() + 1);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
            }
        }

        public string GetPathToFile(Material material, int? version)
        {
            string path;
            if (version != null)
                path = _config.GetValue<String>("FilesPath:Type:ProjectDirectory") + material.Name + "_v" + version;
            else
                path = _config.GetValue<String>("FilesPath:Type:ProjectDirectory") + material.Name + "_v" + material.Versions.Count();
            return (path);
        }

        public string GetValueAppSett()
        {
            return (_config.GetValue<String>("Filestype"));
        }
    }
}
