using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAU.Models;
using System.Data.Entity;
using VidlyAU.ViewModels;
using System.Data.Entity.Validation;

namespace VidlyAU.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New() {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
            }
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Customers");
          
        }
        // GET: Customers
        public ActionResult Index()
        {
            //var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList().SingleOrDefault(c=> c.Id == Id);
            return View(customer);
        }


        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null) {
                return HttpNotFound();
            }
            
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }
        //private IEnumerable<Customers> GetCustomers() {


        //    return new List<Customers> {

        //        new Customers { Id=1, Name="Paul Wright" },
        //        new Customers { Id=2, Name="Mary Blues" },
        //    };
        //}
    }
}