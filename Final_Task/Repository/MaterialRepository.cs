using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Task.Data.Models;
using Final_Task.Data;
using Microsoft.EntityFrameworkCore;

namespace Final_Task.Repository
{
    public class MaterialRepository : IMaterialRepository, IDisposable
    {
        private readonly ApplicationContext context;

        public MaterialRepository(ApplicationContext context)
        {
            this.context = context;
        }
       
        public IList<Material> GetMaterials()
        {
            return context.Materials.Include(p => p.Versions).ToList<Material>();
        }

        public IList<Material> GetFilteredMaterial(string category)
        {
            return context.Materials.Include(p => p.Versions).Where(p => p.Category == category).ToList();
        }

        public Material GetMaterialById(int id)
        {
            return context.Materials.Find(id);
        }

        public Material GetMaterialByName(string name)
        {
            Material material = context.Materials.Include(p => p.Versions).Where(p => p.Name == name).FirstOrDefault();
            return (material);
        }

        public void InsertMaterial(Material material)
        {
            context.Materials.Add(material);
        }

        public void DeleteMaterial(int materialId)
        {
            Material material = context.Materials.Find(materialId);
            context.Materials.Remove(material);
        }

        public void UpdateMaterial(Material material)
        {
            context.Entry(material).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
