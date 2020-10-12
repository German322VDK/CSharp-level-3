using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Project_send_Email.Infrastructure.ValidationRules
{
    public class RegExValidation : ValidationRule
    {
        private Regex _Regax;
        public string Pattern
        {
            get => _Regax?.ToString();
            set => _Regax = string.IsNullOrEmpty(value) ? null : new Regex(value);
        }
        public bool AllowNull { get; set; }
        public string ErrorMessage { get; set; }
        public override ValidationResult Validate(object value, CultureInfo culture)
        {
            if (value is null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new ValidationResult(false, ErrorMessage ?? "Отсуствует ссылка на строку");
            if (_Regax is null) return ValidationResult.ValidResult;
            if (!(value is string str))
                str = value.ToString();
            return _Regax.IsMatch(str)
                 ? ValidationResult.ValidResult
                 : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет требованию выражения {Pattern}"); ; ; ;
        }
    }
}
