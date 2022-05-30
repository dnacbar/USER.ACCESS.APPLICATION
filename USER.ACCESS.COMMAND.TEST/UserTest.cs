using System;
using System.Collections.Generic;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;
using USER.ACCESS.COMMAND.VALIDATION;
using Xunit;

namespace USER.ACCESS.COMMAND.TEST
{
    public class UserTest
    {
        public static IEnumerable<object[]> ListOfUser()
        {
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "hao@askura.com",
                    Phone = "11949310477",
                    IdSystem = Guid.NewGuid(),
                    Login = "hao@asakura.com",
                    User = "Hao Asakura"
                },
                true
            };
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.NewGuid(),
                    Login = "haoRyuken",
                    User = "Hao Asakura"
                },
                true
            };
            // INVALID
             
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.Empty,
                    Login = "haoRyuken",
                    User = "Hao Asakura"
                },
                false
            };
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.NewGuid(),
                    Login = null,
                    User = "Hao Asakura"
                },
                false
            };
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.NewGuid(),
                    Login = string.Empty,
                    User = "Hao Asakura"
                },
                false
            };
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.NewGuid(),
                    Login = "A",
                    User = null
                },
                false
            };
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.NewGuid(),
                    Login = "A",
                    User = string.Empty
                },
                false
            };
            yield return new object[]
            {
                new UserSignature()
                {
                    Email = "x@y",
                    Phone = "11949310477",
                    IdSystem = Guid.Empty,
                    Login = string.Empty,
                    User = string.Empty
                },
                false
            };
        }

        [Theory]
        [MemberData(nameof(ListOfUser))]
        public void CreateUserValidTest(UserSignature signature, bool result)
        {
            CreateUserValidation validationRules = new CreateUserValidation();

            var validationResult = validationRules.Validate(signature);

            Assert.Equal(validationResult.IsValid, result);
        }
    }
}