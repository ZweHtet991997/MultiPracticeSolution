using CRUDOperationWithAjax.DBContext;
using CRUDOperationWithAjax.Models;

namespace CRUDOperationWithAjax.DbServices
{
    public class EmployeeDbServices
    {
        private readonly EFDBContext _DB;

        public EmployeeDbServices(EFDBContext DB)
        {
            _DB = DB;
        }

        public int AddEmployee(EmployeeModel model)
        {
            try
            {
                _DB.Employees.Add(model);
                return _DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> EmployeeList()
        {
            try
            {
                var lstEmployee = _DB.Employees.OrderByDescending(x => x.ID).ToList();
                return lstEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel GetEmployeeById(string ID)
        {
            return _DB.Employees.Where(x => x.ID == Convert.ToInt32(ID)).FirstOrDefault();
        }

        public int EditEmployee(EmployeeModel model)
        {
            _DB.Employees.Update(model);
            return _DB.SaveChanges();
        }

        public int DeleteEmployee(string Id)
        {
            var dataResult = _DB.Employees.Where(x => x.ID == Convert.ToInt32(Id)).FirstOrDefault();
            _DB.Employees.Remove(dataResult);
            int effectedRow = _DB.SaveChanges();
            return effectedRow;
        }
    }
}
