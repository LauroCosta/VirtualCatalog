using System;
using System.Collections.Generic;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public abstract class User : Base
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        protected User(){}

        public User (string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override bool Validate()
        {
            var validate = new UserValidator();
            var validation = validate.Validate(this);

            if(!validation.IsValid){
                foreach(var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new Exception("Erros");
            }

            return true;
        }
    }
}
