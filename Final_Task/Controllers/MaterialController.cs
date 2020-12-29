using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Final_Task.Data.Models;
using Final_Task.Services;
using Final_Task.DTO;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        private readonly List<string> Categories = new List<string> { "Presentation", "Application", "Other" };

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost]
        [Route("addMaterial")]
        public IActionResult AddMaterial([FromForm] MaterialDTO material)
        {
            if (material.File != null && material.Name != null
                && material.Category != null && material.File.Length < 2147483648 && Categories.Contains(material.Category))
            {
                Material newMaterial = new Material { Name = material.Name, Category = material.Category };
                var result = _materialService.AddMaterial(newMaterial, material.File);
                if (result != null)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("addVersion")]
        public IActionResult AddVersion([FromForm] NewMaterialDTO material)
        {
            if (material.File != null && material.Name != null)
            {
                var result = _materialService.AddVersion(material.Name, material.File);
                if (result != null)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("changeCategory")]
        public IActionResult ChangeCategory(string name, string category)
        {
            if (name != null && Categories.Contains(category))
            {
                var material = _materialService.ChangeCategory(name, category);
                if (material != null)
                    return Ok(material);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getByName")]
        public IActionResult GetMaterialByName(string name)
        {
            var material = _materialService.GetMaterialByName(name);
            if (material != null)
                return Ok(material);
            return BadRequest();
        }

        [HttpGet]
        [Route("getAllMaterials")]
        public ActionResult<IList<Material>> GetAllMaterials(string category)
        {
            if (category == null)
            {
                var materials = _materialService.GetAllMaterials(category);
                return Ok(materials);
            }
            else if (Categories.Contains(category))
            {
                var materials = _materialService.GetFilteredMaterials(category);
                return Ok(materials);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("downloadMaterial")]
        public IActionResult DownloadMaterial(string name, int? version)
        {
            var res = _materialService.DownloadMaterial(name, version);
            if (res != null)
            {
                return File(res, _materialService.GetFilesType(), name);
            }
            return BadRequest();
        }
    }
}
