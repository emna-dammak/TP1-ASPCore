using ASPCoreAppication2023.Models;
using ASPCoreAppication2023.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppication2023.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {            
                Movie movie = new Movie()
                {
                    Name =
                    "movie 1"
                };
                List<Movie> movies = new List<Movie>()
            {
                new Movie{Name="movie 2"},
                new Movie{Name="movie 3"},
            };
                return View(movies);
        }
        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);
        }
        public IActionResult ByRelease(int year, int month)
        {
            return Content("Month :" + month + ", Year :" + year);
        }
        public IActionResult MovieAndCustomers()
        {
            Movie movie = new Movie() { Id = 1, Name = "movie 1" };
            List<Customer> customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "Emna" },
            new Customer { Id = 2, Name = "Ismail" },
        };

            MovieCustomerViewModel viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public IActionResult Client(int id)
        {
            Movie movie = new Movie() { Name = "movie 1" };
            List<Customer> customers = new List<Customer>()
            {
                new Customer{Id = 1, Name="Emna"} ,
                new Customer{Id =2 , Name="Ismail"} ,
                new Customer{Id = 3,Name="Fatma"}};
            ViewModel viewModel = new ViewModel() { Movie = movie, Customers = customers };
            bool found = false;
            Customer customer1 = null;
            foreach (var customer in viewModel.Customers)
            {
                if (customer.Id == id)
                {
                    found = true;
                    customer1 = customer;
                    break;

                }
            }
            if (!found)
            {
                return Content("Error 404 : not found");
            }
            return Content("Name: " + customer1.Name) ;
        }
    }
}
