using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tatar.Services;

namespace Tatar.Api.Controllers
{
    [Route("api/[controller]")]
    public class TranslateController : Controller
    {
        public TranslateController(ITranslator translator)
        {
            Translator = translator;
        }

        public ITranslator Translator { get; }

        [HttpGet("")]
        public async Task<string> Get(string word)
        {
            return await Translator.Translate(word);
        }
    }
}
