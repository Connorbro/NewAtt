using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_Group_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {

        private readonly Models.DapperORM dapperSqlLink;

        public MovieController()
        {
            dapperSqlLink = new Models.DapperORM();
        }
        [HttpGet]
        public IEnumerable<Models.MovieModel> Get()
        {
            return dapperSqlLink.GetAllMovies();
        }

        [HttpGet("{id}")]
        public Models.MovieModel Get(int id)
        {
            return dapperSqlLink.GetByID(id);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}