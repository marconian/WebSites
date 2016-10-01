using StalRondo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StalRondo.Utilities
{
    public enum Gender
    {
        Stallion = 1,
        Mare = 2
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class GenderAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Cannot be of this gender";
        private const string NotHorseErrorMessage = "Must be of type Horse";

        public Gender ValidGender { get; private set; }

        public GenderAttribute(Gender gender) : base(DefaultErrorMessage)
        {
            ValidGender = gender;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, ValidGender);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            if (value.GetType() != typeof(Horse))
                return new ValidationResult(NotHorseErrorMessage);

            Horse horse = (Horse)value;

            if (horse.Gender != ValidGender)
                return new ValidationResult(DefaultErrorMessage);

            return ValidationResult.Success;
        }
    }
}