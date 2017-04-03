using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication1.Tests
{
    [TestClass]
    public class CarModelTest
    {
        [TestMethod]
        public void create_new_car()
        {
            var model = new Car
            {
                Name = "Audi A4",
                HorsePower = 200,
                Year = 2015
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void create_new_car_datetime_now()
        {
            var model = new Car
            {
                Name = "Audi A4",
                HorsePower = 200,
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);

            Assert.AreEqual(model.Year, 2017);
        }

        [TestMethod]
        public void create_new_car_wrong_name()
        {
            var name = "Audi A4";
            for (int i = 0; i < 10; ++i)
                name += name;

            var model = new Car
            {
                Name = name,
                HorsePower = 200,
                Year = 2015
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("Car name must have between 2-25 characters.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_car__no_name()
        {
            var model = new Car
            {
                HorsePower = 200,
                Year = 2015
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("You have to enter car name.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_car_wrong_hp()
        {
            var model = new Car
            {
                Name = "Audi A4",
                HorsePower = 2000,
                Year = 2015
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("Choose value between 1 and 1000.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void create_new_car_wrong_year()
        {
            var model = new Car
            {
                Name = "Audi A4",
                HorsePower = 200,
                Year = 2020
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);

            Assert.AreEqual("Choose value between 1900 and 2017.", result[0].ErrorMessage);
        }

        [TestMethod]
        public void horsepowerToKilowattsTest()
        {
            var model = new Car
            {
                Name = "Audi A4",
                HorsePower = 200,
                Year = 2020
            };

            Assert.AreEqual(149, model.horsepowerToKilowatts());
        }
    }
}
