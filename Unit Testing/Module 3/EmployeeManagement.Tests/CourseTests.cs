using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Tests
{
    public class CourseTests
    {
        [Fact]
        public void CourseContructor_ConstructCourse_IsNewMustBeTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var course = new Course("Disaster Managment 101");

            // Assert
            Assert.True(course.IsNew);
        }
    }
}
