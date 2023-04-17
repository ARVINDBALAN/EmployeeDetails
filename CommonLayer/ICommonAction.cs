using Entities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public interface ICommonAction
    {
        //interface method to get the file path
        string IBaseAddress();
        string IAccessToken();
        string IEndPoints();
    }

    public interface ICallMethods
    {
        Task<List<Employee>> GetAllDetails();

        Task<List<Employee>> GetOneRecordByID(int id);

        void InsertNewDetail(Employee emp);

        void UpdateExistingRecord(Employee emp);

        void DeleteExistingRecord(int empId);
    }

}
