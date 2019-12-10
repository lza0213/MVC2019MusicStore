using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ExampleGenreController : Controller
    {
        // GET: ExampleGenre
        public ActionResult Index()
        {
            return View(StuList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult GetSingleGenre()
        {
            List<Genre> list = StuList();
            //假设Genre有Insert的时间/日期，Linq表达式找最后一条数据并提取 假设日期字段为UpdateData
            //Genre genre=list。Where（x=>=x.UpdateData）.OrderbyDesc.FirstOreDefault
            Genre genre = list.FirstOrDefault();
            return View(genre);
        }
        public List<Genre>StuList()
        {
            //List<T>
            List<Genre> stuList = new List<Genre>();
            Genre m1 = new Genre { Id = Guid.NewGuid(), Name = "摇滚", Description = "流行音乐之一" };
            Genre m2 = new Genre { Id = Guid.NewGuid(), Name = "伤感", Description = "流行音乐之一" };
            Genre m3 = new Genre { Id = Guid.NewGuid(), Name = "Rap", Description = "流行音乐之一" };
            Genre m4 = new Genre { Id = Guid.NewGuid(), Name = "美声", Description = "专业歌手炫技之一" };
            Genre m5 = new Genre { Id = Guid.NewGuid(), Name = "电音", Description = "流行音乐之一" };
            stuList.Add(m1);
            stuList.Add(m2);
            stuList.Add(m3);
            stuList.Add(m4);
            stuList.Add(m5);

            return stuList;
        }
    }
}