using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMX.api.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        object GetEmployeeDetails(int empId);

        /// <summary>
        /// 
        /// </summary>
        object GetEmployeeList();
    }
}
