﻿using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Test.TestData;

namespace EmployeeManagement.Tests
{
    [Collection("EmployeeServiceCollection")]
    public class DataDrivenEmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public DataDrivenEmployeeServiceTests(
            EmployeeServiceFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }

        [Theory]
        [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedSecondObligatoryCourse(Guid courseId)
        {
            // Arrange


            // Act
            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(internalEmployee.AttendedCourses,
                course => course.Id == courseId);
        }

        [Fact]
        public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeTrue()
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act
            await _employeeServiceFixture
                .EmployeeService.GiveRaiseAsync(internalEmployee, 100);

            // Assert
            Assert.True(internalEmployee.MinimumRaiseGiven);
        }


        
        [Fact]
        public async Task GiveRaise_MoreThanMinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeFalse()
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act 
            await _employeeServiceFixture.EmployeeService
                .GiveRaiseAsync(internalEmployee, 200);

            // Assert
            Assert.False(internalEmployee.MinimumRaiseGiven);
        }

        // The return type must be an IEnumerable of an array of objects and access level must be static
        public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithProperty
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { 100, true },
                    new object[] { 200, false }
                };
            }
        }
        //strongly type
        public static TheoryData<int, bool> StronglyTypedExampleTestDataForGiveRaise_WithProperty
        {
            get
            {
                return new TheoryData<int, bool>()
                {
                    { 100, true },
                    { 200, false }
                };
            }
        }

        public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithMethod(
            int testDataInstancesToProvide)
        {
            var testData = new List<object[]>
            {
                new object[] { 100, true },
                new object[] { 200, false }
            };

            return testData.Take(testDataInstancesToProvide);
        }

        [Theory]
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
        //[MemberData(nameof(StronglyTypedExampleTestDataForGiveRaise_WithProperty))]
        //[ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        //[ClassData(typeof(EmployeeServiceTestData))]
        //[MemberData(nameof(ExampleTestDataForGiveRaise_WithMethod), 2 )]
        //[MemberData(
        //     nameof(DataDrivenEmployeeServiceTests.ExampleTestDataForGiveRaise_WithMethod),
        //     1,MemberType = typeof(DataDrivenEmployeeServiceTests) )]
        //Member data can be stored in a field or a property, and it can also be the result of a method.
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue(
            int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(
                internalEmployee, raiseGiven);

            // Assert
            Assert.Equal(expectedValueForMinimumRaiseGiven,
                internalEmployee.MinimumRaiseGiven);
        }

    }
}
