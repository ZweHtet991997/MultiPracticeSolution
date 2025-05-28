using CRUDOperationWithAjax.DbServices;
using CRUDOperationWithAjax.Models;
using CRUDOperationWithAjax.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDOperationWithAjax.Controllers
{

    public class EmployeeController : Controller
    {
        private int dataResult;
        private readonly EmployeeDbServices _services;
        private ResponseModel responseModel = new ResponseModel();

        public EmployeeController(EmployeeDbServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EmployeeViewModel viewModel)
        {
            if (viewModel != null)
            {
                EmployeeModel model = new EmployeeModel();
                model.EmployeeCode = viewModel.EmployeeCode;
                model.FullName = viewModel.FullName;
                model.Email = viewModel.Email;
                model.Address = viewModel.Address;
                model.PhoneNumber = viewModel.PhoneNumber;
                model.DOB = viewModel.DOB;
                dataResult = _services.AddEmployee(model);
                if (dataResult > 0)
                {
                    responseModel.RespCode = ResponseEnums.ResponseCode.I000.ToString();
                    responseModel.RespMessage = ResponseEnums.ResponseMessage.Success.ToString();
                    viewModel.response = responseModel;
                }
            }
            return Json(viewModel);
        }

        public string GetEmployeeList()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            var lstEmployee = _services.EmployeeList();
            foreach (var item in lstEmployee)
            {
                EmployeeViewModel viewModel = new EmployeeViewModel();
                viewModel.ID = item.ID;
                viewModel.EmployeeCode = item.EmployeeCode;
                viewModel.FullName = item.FullName;
                viewModel.Email = item.Email;
                viewModel.Address = item.Address;
                viewModel.PhoneNumber = item.PhoneNumber;
                viewModel.DOB_Str = item.DOB.ToString("dd-MM-yyyy");
                employeeList.Add(viewModel);
            }
            return JsonConvert.SerializeObject(employeeList);
        }

        public ActionResult Edit(string Id)
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();
            var dataResult = _services.GetEmployeeById(Id);
            viewModel.ID = dataResult.ID;
            viewModel.EmployeeCode = dataResult.EmployeeCode;
            viewModel.FullName = dataResult.FullName;
            viewModel.Email = dataResult.Email;
            viewModel.Address = dataResult.Address;
            viewModel.PhoneNumber = dataResult.PhoneNumber;
            viewModel.DateofBirth = dataResult.DOB;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel viewModel)
        {
            EmployeeModel model = new EmployeeModel();
            model.ID = viewModel.ID;
            model.EmployeeCode = viewModel.EmployeeCode;
            model.FullName = viewModel.FullName;
            model.Email = viewModel.Email;
            model.Address = viewModel.Address;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.DOB = viewModel.DateofBirth;
            var dataResult = _services.EditEmployee(model);
            if (dataResult > 0)
            {
                responseModel.RespCode = ResponseEnums.ResponseCode.I000.ToString();
                responseModel.RespMessage = ResponseEnums.ResponseMessage.Success.ToString();
                viewModel.response = responseModel;
                return Json(viewModel);
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();
            var dataResult = _services.GetEmployeeById(Id);
            viewModel.ID = dataResult.ID;
            viewModel.EmployeeCode = dataResult.EmployeeCode;
            viewModel.FullName = dataResult.FullName;
            viewModel.Email = dataResult.Email;
            viewModel.Address = dataResult.Address;
            viewModel.PhoneNumber = dataResult.PhoneNumber;
            viewModel.DateofBirth = dataResult.DOB;
            return View(viewModel);
        }

        [Route("api/deleteEmployee")]
        public ActionResult DeleteEmployee(string EmployeeID)
        {
            EmployeeID = JsonConvert.DeserializeObject(EmployeeID).ToString();
            EmployeeViewModel viewModel = new EmployeeViewModel();
            var dataResult = _services.DeleteEmployee(EmployeeID.ToString());
            if (dataResult > 0)
            {
                responseModel.RespCode = ResponseEnums.ResponseCode.I000.ToString();
                responseModel.RespMessage = ResponseEnums.ResponseMessage.Success.ToString();
                viewModel.response = responseModel;
            }
            return Json(viewModel);
        }
    }
}
