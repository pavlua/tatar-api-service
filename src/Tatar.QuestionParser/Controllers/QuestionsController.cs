using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tatar.QuestionParser.Context;
using Tatar.Services.Questions;

namespace Tatar.QuestionParser.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер вопросов
    /// </summary>
    [Produces("application/json")]
    [Route("api/question")]
    public class QuestionsController : Controller
    {
        static QuestionsController()
        {
            foreach (QuestionType qtype in Enum.GetValues(typeof(QuestionType)))
            {
                var attr = (DisplayNameAttribute)typeof(QuestionType)
                    .GetMember(qtype.ToString())
                    .First()
                    .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                    .FirstOrDefault();

                STypes.Add(attr?.DisplayName ?? qtype.ToString(), qtype);
            }
        }

        /// <summary>
        /// Регулярное выражение для поиска вопросов
        /// </summary>
        private static readonly Regex SQuestion = new Regex(@"^\s*(?<name>\w+)\s(?<text>.*)");

        /// <summary>
        /// Сопоставление русских вопросов перечислению
        /// </summary>
        private static readonly Dictionary<string, QuestionType> STypes = new Dictionary<string, QuestionType>();

        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly QuestionDbContext _context;

        public QuestionsController(QuestionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<Question[]> Get()
        {
            return await _context.Questions.ToArrayAsync();
        } 

        [HttpPost]
        public async Task<IActionResult> SaveQuestion(string questionText)
        {
            if (string.IsNullOrWhiteSpace(questionText))
            {
                return BadRequest("Не передан текст вопроса");
            }

            var match = SQuestion.Match(questionText);
            if (!match.Success)
            {
                return BadRequest($"Переданный текст {questionText} не удалось преобразовать в вопрос");
            }

            var type = match.Groups["name"];
            if (!STypes.ContainsKey(type.Value))
            {
                return BadRequest($"Переданный текст '{questionText}' содержит странный тип вопроса '{type.Value}'");
            }

            var question = new Question(STypes[type.Value], match.Groups["text"].Value);
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }
    }
}