using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.UI.ModelWrapper
{
    public class Wrapper<T> : NotifyDataErrorInfoBase
    {
        public Wrapper(T model)
        {
            Model = model;
        }
        public T Model { get; }

        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }
        protected virtual void SetValue<TValue>(TValue value,[CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model,value);
            OnPropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName,value);
        }

        private void ValidatePropertyInternal(string propertyName,object current)
        {
            ClearErrors(propertyName);

            ValidateDataAnnotations(propertyName, current);
            ValidateCustomErrors(propertyName);
        }

        private void ValidateDataAnnotations(string propertyName, object current)
        {
            ClearErrors(propertyName);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(Model) { MemberName = propertyName };
            Validator.TryValidateProperty(current, context, results);

            foreach (var r in results)
            {
                AddError(propertyName, r.ErrorMessage);
            }
        }

        private void ValidateCustomErrors(string propertyName)
        {
            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var e in errors)
                {
                    AddError(propertyName, e);
                }
            }
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
    }
}
