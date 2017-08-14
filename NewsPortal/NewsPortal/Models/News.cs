using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class News
    {
        public News()
        {

        }

        public News(News news)
        {
            Id = news.Id;
            Title = news.Title;
            Descrition = news.Descrition;
            Date = news.Date;
            Author = news.Author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }

        
        public bool Compare(News news)
        {
            if(this.Id == news.Id && 
                this.Title == news.Title && 
                this.Descrition == news.Descrition &&
                this.Date == news.Date &&
                this.Author == news.Author)
            {
                return true;
            }

            return false;
        }

        public void Save()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(this);
                session.SaveChanges();
            }

        }

        public List<News> NewList()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<News>().ToList();
            }

        }

        public News SearchNews(int id)
        {

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var find = session.Load<News>(id);
                if (find == null)
                    throw new Exception("Noticia Não encotrada!");
                return find;

            }

        }
        public void Delete(int id)
        {

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var news = session.Load<News>(id);

                if (news.Equals(null))
                    throw new Exception("Noticia Não encotrada!");

                session.Delete(news);
                session.SaveChanges();

            }

        }

    }
}