using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Task.Data.Models;
using Final_Task.Data;
using Version = Final_Task.Data.Models.Version;
using Microsoft.AspNetCore.Http;

namespace Final_Task.Repository
{
    public class VersionRepository : IVersionRepository, IDisposable
    {
        private readonly ApplicationContext context;

        public VersionRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Version> GetVersions()
        {
            return context.Versions.ToList();
        }

        public Version GetVersionById(int id)
        {
            return context.Versions.Find(id);
        }

        public void InsertVersion(Version version)
        {
            context.Versions.Add(version);
        }

        public void DeleteVersion(int versionId)
        {
            Version version = context.Versions.Find(versionId);
            context.Versions.Remove(version);
        }

        public void UpdateVersion(Version version)
        {
            context.Entry(version).State = EntityState.Modified;
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
