using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Task.Data;
using Final_Task.Data.Models;
using Microsoft.Extensions.Configuration;
using Version = Final_Task.Data.Models.Version;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Final_Task.Repository;
using Final_Task.Additional_Services;

namespace Final_Task.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IVersionRepository _versionRepository;
        private readonly IAdditionalService _additionalService;


        public MaterialService(IMaterialRepository materialRepository, IVersionRepository versionRepository, IAdditionalService additionalService)
        {
            _materialRepository = materialRepository;
            _versionRepository = versionRepository;
            _additionalService = additionalService;
        }

        public Material AddMaterial(Material material, IFormFile file)
        {
            Version newVersion;
            if (material != null)
            {
                newVersion = new Version
                {
                    Material = material,
                    UploadTime = DateTime.Now,
                    Size = file.Length,
                    VersionCounter = 1
                };
                _additionalService.SaveFile(material.Name, file);
                _materialRepository.InsertMaterial(material);
                _versionRepository.InsertVersion(newVersion);
                _materialRepository.Save();
                _versionRepository.Save();
                return (material);
            }
            return null;
        }

        public Version AddVersion(string name, IFormFile file)
        {
            Material material = _materialRepository.GetMaterialByName(name);
            Version newVersion;
            if (material != null)
            {
                newVersion = new Version
                {
                    Material = material,
                    UploadTime = DateTime.Now,
                    Size = file.Length,
                    VersionCounter = material.Versions.Count() + 1
                };
                _additionalService.SaveNewFile(material, file);
                _versionRepository.InsertVersion(newVersion);
                _versionRepository.Save();
                return (newVersion);
            }
            return null;
        }

        public Material ChangeCategory(string name, string category)
        {
            var material = _materialRepository.GetMaterialByName(name);
            if (material != null)
            {
                material.Category = category;
                _materialRepository.Save();
                return (material);
            }
            return null;
        }

        public Material GetMaterialByName(string name)
        {
            var material = _materialRepository.GetMaterialByName(name);
            if (material != null)
                return (material);
            return null;
        }

        public IList<Material> GetAllMaterials(string category)
        {
            var material = _materialRepository.GetMaterials();
            return (material);
        }

        public IList<Material> GetFilteredMaterials(string category)
        {
            var filteredMaterials = _materialRepository.GetFilteredMaterial(category);
            if (filteredMaterials != null)
                return (filteredMaterials);
            return null;
        }

        public byte[] DownloadMaterial(string name, int? version)
        {
            string path;
            byte[] mas;
            var material = _materialRepository.GetMaterialByName(name);
            if (material != null)
            {
                path = _additionalService.GetPathToFile(material, version);
                mas = File.ReadAllBytes(path);
                return (mas);
            }
            return null;
        }

        public string GetFilesType()
        {
            return (_additionalService.GetValueAppSett());
        }
    }
}
