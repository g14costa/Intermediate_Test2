using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intermediate_Test2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Intermediate_Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private List<Employee> MockDatabase;
        // GET api/withdraw/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetById(int id)
        {
            CreateDatabase();

            Employee employee = MockDatabase.FirstOrDefault(l => l.Id == id);
            double withdraw = 0;

            if (employee == null)
            {
                return StatusCode(500, "We could not find the employee. Please try again");
            }

            //Check the employee birthday and if the employee had already withdraw this year
            if (employee.Birthday.Month != DateTime.Today.Month || employee.Birthday.Day != DateTime.Today.Day || employee.HasWithdrawThisYear)
            {
                return StatusCode(500, "Today is not the employee birthday or you already had a withdraw this year. The withdraw only can occurs in employee birthday and once a year.");
            }

            withdraw = CalculeWithdraw(employee);

            return StatusCode(200, "Congratulations! You withdraw " + withdraw + " from your account balance. Have a nice day.");
        }

        private static double CalculeWithdraw(Employee employee)
        {
            double withdraw;
            if (employee.Balance < 500)
            {
                withdraw = 0 + ((employee.Balance / 100) * 50);
            }
            else if (employee.Balance < 1000)
            {
                withdraw = 50 + ((employee.Balance / 100) * 40);
            }
            else if (employee.Balance < 5000)
            {
                withdraw = 150 + ((employee.Balance / 100) * 30);
            }
            else if (employee.Balance < 10000)
            {
                withdraw = 650 + ((employee.Balance / 100) * 20);
            }
            else if (employee.Balance < 15000)
            {
                withdraw = 1150 + ((employee.Balance / 100) * 15);
            }
            else if (employee.Balance < 20000)
            {
                withdraw = 1900 + ((employee.Balance / 100) * 10);
            }
            else
            {
                withdraw = 2900 + ((employee.Balance / 100) * 5);
            }

            return withdraw;
        }

        private void CreateDatabase()
        {
            MockDatabase = new List<Employee>();
            MockDatabase.Add(new Employee() { Id = 1, Name = "Guilherme Costa", Birthday = new DateTime(1992, 09, 03), Balance = 400.30, HasWithdrawThisYear = false });
            MockDatabase.Add(new Employee() { Id = 2, Name = "Thiago Silva", Birthday = new DateTime(1991, 07, 01), Balance = 550, HasWithdrawThisYear = true });
            MockDatabase.Add(new Employee() { Id = 3, Name = "João Paulo", Birthday = new DateTime(1989, 05, 02), Balance = 1500, HasWithdrawThisYear = false });
            MockDatabase.Add(new Employee() { Id = 4, Name = "Maria Silva", Birthday = new DateTime(1990, 01, 03), Balance = 1600, HasWithdrawThisYear = true });
            MockDatabase.Add(new Employee() { Id = 5, Name = "Camila Costa", Birthday = new DateTime(1991, 03, 08), Balance = 6000, HasWithdrawThisYear = false });
            MockDatabase.Add(new Employee() { Id = 6, Name = "Joaquim Santos", Birthday = new DateTime(1982, 02, 10), Balance = 12000, HasWithdrawThisYear = false });
            MockDatabase.Add(new Employee() { Id = 7, Name = "Olivia Perez", Birthday = new DateTime(1982, 01, 22), Balance = 17000, HasWithdrawThisYear = false });
            MockDatabase.Add(new Employee() { Id = 8, Name = "Regina Souza", Birthday = new DateTime(1980, 05, 21), Balance = 22000, HasWithdrawThisYear = false });
            MockDatabase.Add(new Employee() { Id = 9, Name = "Eduardo Silva", Birthday = new DateTime(1990, 09, 10), Balance = 16000, HasWithdrawThisYear = true });
            MockDatabase.Add(new Employee() { Id = 10, Name = "Pedro Gomes", Birthday = new DateTime(1991, 11, 15), Balance = 11000, HasWithdrawThisYear = true });
        }

        // GET api/withdraw/name
        [HttpGet("[action]/{name}")]        
        public ActionResult<string> GetByName(string name)
        {
            CreateDatabase();

            Employee employee = MockDatabase.FirstOrDefault(l => l.Name == name);
            double withdraw = 0;

            if (employee == null)
            {
                return StatusCode(500, "We could not find the employee. Please try again");
            }

            //Check the employee birthday and if the employee had already withdraw this year
            if (employee.Birthday.Month != DateTime.Today.Month || employee.Birthday.Day != DateTime.Today.Day || employee.HasWithdrawThisYear)
            {
                return StatusCode(500, "Today is not the employee birthday or you already had a withdraw this year. The withdraw only can occurs in employee birthday and once a year.");
            }

            withdraw = CalculeWithdraw(employee);

            return StatusCode(200, "Congratulations! You withdraw " + withdraw + " from your account balance. Have a nice day.");
        }       
    }
}
