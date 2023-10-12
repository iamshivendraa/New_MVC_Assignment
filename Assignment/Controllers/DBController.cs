using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using System.Drawing.Drawing2D;

namespace NewProject.Controllers
{
    public class DBController : Controller
    {
        private readonly NewAccountContext _context;
        public DBController(NewAccountContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var userList = _context.UserDetails.ToList();
            var accountList = _context.Accounts.ToList();

            var mergeModel = new MergeModel()
            {
                UserList = userList,
                AccountList = accountList
            };

            return View(mergeModel);
        }

    }
}
