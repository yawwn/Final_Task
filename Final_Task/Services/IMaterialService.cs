using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final_Task.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Version = Final_Task.Data.Models.Version;

namespace Final_Task.Services
{
    public interface IMaterialService
    {
        public Material AddMaterial(Material material, IFormFile file);
        public Version AddVersion(string name, IFormFile file);
        public Material ChangeCategory(string name, string category);
        public Material GetMaterialByName(string name);
        public IList<Material> GetAllMaterials(string category);
        public IList<Material> GetFilteredMaterials(string category);
        public byte[] DownloadMaterial(string name, int? version);
        public string GetFilesType();
    }
}
