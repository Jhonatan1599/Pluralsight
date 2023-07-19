using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Tests.Services;

namespace EmployeeManagement.Tests.Fixtures
{
    public class EmployeeServiceFixture : IDisposable
    {
        public IEmployeeManagementRepository EmployeeManagementTestDataRepository { get;  }
        public EmployeeService EmployeeService { get; }

        //dependencies required by our tests 
        public EmployeeServiceFixture()
        {
            EmployeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            EmployeeService = new EmployeeService(EmployeeManagementTestDataRepository, new EmployeeFactory());
        }


        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}
