using System.Web.Http.Description;
using System.Collections.Generic;
using CodingExercise.API.Models;
using Application.Interfaces;
using System.Web.Http;
using Domain.Entities;
using AutoMapper;
using System.Web;
using System;

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

        [HttpGet]
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
            catch(Exception ex)
            {
                return InternalServerError();
            }

        }

        [HttpPost]
        [ResponseType(typeof(int))]
        public IHttpActionResult AddToDoItem(AddToDoItemModel item)
        {
            try
            {
                var username = HttpContext.Current.User.Identity.Name;

                var user = UserManager.FindByNameAsync(username).GetAwaiter().GetResult();

                var itemId = _todoListService.AddToDoItem(item, user.Id);

                return Ok(itemId);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [ResponseType(typeof(int))]
        public IHttpActionResult SetItemDone(int itemId)
        {
            try
            {
                _todoListService.SetItemStatusDone(itemId);

                return Ok(itemId);
            }
            catch
            {
                return InternalServerError();
            }
        }


        [HttpPost]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeleteToDoItem(int itemId)
        {
            try
            {
                _todoListService.DeleteToDoItem(itemId);

                return Ok(itemId);
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
