using System;
using System.Collections.Generic;
using System.Text;

namespace Tatar.Services.Settings
{
    public class YandexApiResponse
    {
        public string Code { get; set; }
        public string Lang { get; set; }
        public string[] Text { get; set; }
    }
}
