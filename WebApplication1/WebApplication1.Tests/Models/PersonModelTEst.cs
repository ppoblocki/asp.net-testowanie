using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication1.Tests
{
    [TestClass]
    public class PersonModelTest
    {
        [TestMethod]
        public void create_new_person_without_car()
        {
            var model = new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Login = "Jan123"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void create_new_person_with_car()
        {
            var car = new Car
            {
                Name = "Audi A4",
                HorsePower = 200
            };

            var model = new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Login = "Jan123",
                Car = car
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void create_new_person_wrong_name()
        {
            var name = "Jan";
            for (int i = 0; i < 10; ++i)
                name += name;

            var model = new Person
            {
                FirstName = name,
                LastName = "Kowalski",
                Login = "Jan123"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("First name must have between 2-25 characters.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_person_no_name()
        {
            var model = new Person
            {
                LastName = "Kowalski",
                Login = "Jan123"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("You have to enter first name.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_person_wrong_last_name()
        {
            var name = "Kowalski";
            for (int i = 0; i < 10; ++i)
                name += name;

            var model = new Person
            {
                FirstName = "Jan",
                LastName = name,
                Login = "Jan123"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("Last name must have between 2-25 characters.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_person_wrong_no_last_name()
        {
            var model = new Person
            {
                FirstName = "Jan",
                Login = "Jan123"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("You have to enter last name.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_person_wrong_username()
        {
            var model = new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Login = "Jan is the best !!!"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("Username can contain only characters, numbers, dashes and underscores.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_person_no_username()
        {
            var model = new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("You have to enter username.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_person_wrong_username_length()
        {
            var model = new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Login = "A"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("Username must have between 2-25 characters.", result[0].ErrorMessage);
        }
    }
}
