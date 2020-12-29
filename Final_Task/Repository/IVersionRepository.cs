using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Task.Data.Models;
using Microsoft.AspNetCore.Http;
using Version = Final_Task.Data.Models.Version;

namespace Final_Task.Repository
{
    public interface IVersionRepository : IDisposable
    {
        public IEnumerable<Version> GetVersions();
        public Version GetVersionById(int versionId);
        public void InsertVersion(Version version);
        public void DeleteVersion(int versionId);
        public void UpdateVersion(Version version);
        public void Save();
    }
}
