﻿using AlbumPhoto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbumPhoto.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var service = new AlbumFotoService();
            return View(service.GetPoze());
        }

        [HttpPost]
        public ActionResult IncarcaPoza(HttpPostedFileBase file)
        {
            var service = new AlbumFotoService();
            if (file!=null && file.ContentLength > 0)
            {
                service.IncarcaPoza("guest", file.FileName, file.InputStream);
            }

            return View("Index", service.GetPoze());
        }
        [HttpPost]
        public ActionResult AddComment(string user, string comment, string image)
        {
            var service = new AlbumFotoService();
            if (comment != "" && image != "" && user != "")
            {
                service.AddComment(user, comment, image);
            }
            return View("Index", service.GetPoze());
        }      
       

        [HttpGet]
        public ActionResult ViewComments(string image)
        {
            var service = new AlbumFotoService();
            return View("ViewComments", service.ViewComments(image));
        }
    }
}