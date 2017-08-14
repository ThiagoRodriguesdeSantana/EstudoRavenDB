using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View(new News().NewList());
        }
        public ActionResult Create(News news)
        {
            if (!string.IsNullOrEmpty(news.Title))
                AddNews(news);
                                
            return View();
        }
        public void AddNews(News news)
        {
            var newsForAdd = new News(news);
            newsForAdd.Save();     
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var newsForAdd = new News().SearchNews(id);
            
            return View(newsForAdd);

        }
        [HttpPost]
        public ActionResult Edit(News news)
        {
            
            news.Save();
            return View(new News());

        }
        [HttpGet]
        public void Delete(int id)
        {
            new News().Delete(id);
        }
        [HttpGet]
        public ActionResult Find(int id)
        {
            return View(new News().SearchNews(id));
        }

    }
}