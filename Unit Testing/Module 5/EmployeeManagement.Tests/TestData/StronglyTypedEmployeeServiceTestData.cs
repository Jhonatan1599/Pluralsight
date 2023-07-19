using Xunit;

namespace EmployeeManagement.Test.TestData
{
    // TheoryData is a class that allows providing data for theories based on collection initialization syntax. int and bool are type parameters 
    public class StronglyTypedEmployeeServiceTestData : TheoryData<int, bool>
    {
        public StronglyTypedEmployeeServiceTestData()
        {   
            // Adding test data
            Add(100, true);
            Add(200, false);
        }
    }
}
