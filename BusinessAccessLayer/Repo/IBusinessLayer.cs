using System.Collections.Generic;
using DataTransferObject.DTO;

namespace BusinessAccessLayer.Repo
{
    public interface IBusinessLayer
    {
        IEnumerable<HelperModel> GetEmployees();
        IEnumerable<HelperModel> GetEmployeeById(int id);
        void Create(HelperModel model);
        void Update(int id , HelperModel model);
        void Delete(int id);
    }
}
