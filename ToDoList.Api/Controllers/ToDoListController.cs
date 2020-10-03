using System.Web.Http.Description;
using System.Collections.Generic;
using Application.Interfaces;
using System.Web.Http;
using Domain.Entities;
using AutoMapper;
using System.Web;
using System.Web.Http.Cors;

namespace CodingExercise.API.Controllers
{
    [Authorize]
    public class ToDoListController : BaseController
    {
        private readonly IToDoListService _todoListService;
        public ToDoListController(IToDoListService service, IMapper mapper)
        {
            _todoListService = service;
        }

        [ResponseType(typeof(List<ToDoItem>))]
        public IHttpActionResult GetToDoItems()
        {
            try
            {
                var username = HttpContext.Current.User.Identity.Name;

                var user =  UserManager.FindByNameAsync(username).GetAwaiter().GetResult();

                var result = _todoListService.GetToDoItems(user.Id);

                return Ok(result);
            }
            catch
            {
                return InternalServerError();
            }

        }

    }
}
