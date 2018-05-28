using System;
using System.ComponentModel;

namespace Tatar.Services.Questions
{
    /// <summary>
    /// Тип вопроса
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// Почему
        /// </summary>
        [DisplayName("Почему")]
        Why,

        /// <summary>
        /// Кто
        /// </summary>
        [DisplayName("Кто")]
        Who,

        /// <summary>
        /// Зачем
        /// </summary>
        [DisplayName("Зачем")]
        WhatFor,

        /// <summary>
        /// Зачем
        /// </summary>
        [DisplayName("Что")]
        What
    }
}
