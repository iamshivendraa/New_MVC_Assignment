using Assignment.Controllers;
using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace NewProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() {
            
                var accountList = _db.Accounts.FromSqlRaw<AccountModel>("showAccounts").ToList();
                return View(accountList);
        }

       [HttpPost]
       public IActionResult GetAccount(int rowCount)
       {
                //List<AccountModel> accountList = _db.Accounts.ToList();
                var newlist = _db.Accounts.FromSqlRaw("EXEC GetAccountByRowCount @RowCount", new SqlParameter("@RowCount", rowCount)).ToList();
                return View("Index",newlist);
       }
    }
}
