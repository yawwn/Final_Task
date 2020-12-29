using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Task.Data.Models;

namespace Final_Task.Repository
{
    public interface IMaterialRepository : IDisposable
    {
        public IList<Material> GetMaterials();
        public IList<Material> GetFilteredMaterial(string category);
        public Material GetMaterialById(int materialId); 
        public Material GetMaterialByName(string name);
        public void InsertMaterial(Material material);
        public void DeleteMaterial(int materialId); 
        public void UpdateMaterial(Material material);
        public void Save();
    }
}
