using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.Controllers
{
    [Route("api/language")]
    public class LanguageController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public LanguageController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreateLanguage([FromBody] Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid language");
            }

            _humanResourcesContext.Languages.Add(language);
            _humanResourcesContext.SaveChanges();

            return Ok("Language saved successfully");
        }

        [HttpGet("{languageId}")]
        public IActionResult GetLanguage(Guid languageId)
        {
            if (languageId == Guid.Empty)
            {
                return BadRequest("Invalid language identification");
            }

            Language language = _humanResourcesContext.Languages.Find(languageId);

            if (language == null)
            {
                return BadRequest("Language not found");
            }

            return Ok(language);
        }

        [HttpGet]
        public IActionResult GetAllLanguages()
        {
            ISet<Language> languages = _humanResourcesContext.Languages.ToHashSet();

            if (languages.Count == 0)
            {
                return BadRequest("Languages not found");
            }

            return Ok(languages);
        }

        [HttpPut("{languageId}")]
        public IActionResult UpdateLanguages(Guid languageId, [FromBody] Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid language");
            }

            language.Id = languageId;

            _humanResourcesContext.Languages.Update(language);
            _humanResourcesContext.SaveChanges();

            return Ok(language);
        }

        [HttpDelete("{languageId}")]
        public IActionResult DeleteLanguage(Guid languageId)
        {
            if (languageId == Guid.Empty)
            {
                return BadRequest("Invalid language identification");
            }

            Language language = _humanResourcesContext.Languages.Find(languageId);

            if (language == null)
            {
                return BadRequest("Language not found");
            }

            _humanResourcesContext.Languages.Remove(language);
            _humanResourcesContext.SaveChanges();

            return Ok("Language removed successfully");
        }
    }
}