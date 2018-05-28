using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Tatar.Services.Questions
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Конструктор для наследников
        /// </summary>
        protected Question()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип вопроса</param>
        /// <param name="text">Текст вопроса</param>
        public Question(QuestionType type, [NotNull] string text)
        {
            Type = type;
            Text = text;
        }

        /// <summary>
        /// Идентификтаор
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public QuestionType Type { get; protected set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; protected set; }
    }
}
