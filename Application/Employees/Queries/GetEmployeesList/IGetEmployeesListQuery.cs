using System.Collections.Generic;

namespace Architecture.Application.Employees.Queries.GetEmployeesList
{
    public interface IGetEmployeesListQuery
    {
        List<EmployeeModel> Execute();
    }
}