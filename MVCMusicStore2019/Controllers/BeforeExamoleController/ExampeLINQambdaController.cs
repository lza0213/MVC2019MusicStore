using MVCMusicStore2019.Controllers;
using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{

    public class ExampleGenriceList
    {
        public List<StudentDemo> GetAll()
        {
            List<StudentDemo> stuList = new List<StudentDemo>();
            StudentDemo stu1 = new StudentDemo { Id = 1, Name = "张三", ClassName = "2018软件技术一班" };
            StudentDemo stu2 = new StudentDemo { Id = 2, Name = "李四", ClassName = "2018软件技术一班" };
            StudentDemo stu3 = new StudentDemo { Id = 3, Name = "王五", ClassName = "2018软件技术一班" };
            StudentDemo stu4 = new StudentDemo { Id = 4, Name = "申七", ClassName = "2018软件技术一班" };
            StudentDemo stu5 = new StudentDemo { Id = 5, Name = "秦六", ClassName = "2018软件技术一班" };
            stuList.Add(stu1);
            stuList.Add(stu2);
            stuList.Add(stu3);
            return stuList;
        }
    }
    public class ExampeLINQambdaController : Controller
    {
        // GET: ExampeLINQambda
        public ActionResult Index()
        {
            ExampleGenriceList genriceList = new ExampleGenriceList();
            var list = genriceList.GetAll();
            //当前我们对list这个集合进行LINQ简单查询
            var linqListl = from x in list
                            select x;
            //SQL条件精确查询：select*from表名 where条件
            var linqList2 = from x in list
                            where x.Name == "前四"//精确查询
                            select x;
            //SQL条件模糊查询：select*from表名 字段 like '%软件%'
            var linqList3 = from x in list
                            where x.ClassName.Contains("软件")//Contains:包含
                            select x;
            //SQL排序：select*from list order by Name desc
            var linqList4 = from x in list
                            orderby x.Name descending// descending; 降序排序
                            select x;

            //SQl计数：select count(*) from list
            var linqList5 = (from x in list
                             select x).Count();

            //SQL联接：select*from x inner join on y where x.Id=y.Id
            var linqList6 = from x in list
                            join y in list on x.Id equals y.Id
                            select x;

            //SQL分组查询：select count(*) from list group by ClassName
            var linqList7 = from x in list
                            group x by x.ClassName into y
                            select new
                            {
                                y.Key,
                                count = y.Count()
                            };

            //SQL取第一条数据：select top 1 * from list
            var linqList8 = (from x in list
                             select x).FirstOrDefault();

            //SQL取第10条数据：select top 1 * from list
            var linqList9 = (from x in list
                             select x)
                             .Take(10);
            //取从16条数据~第30条数据
            var linqList10 = (from x in list
                              select x)
                             .Skip(15).Take(30);

            return View();
        }
    }
    }


    public class ExampleLambdaController : Controller
    {
        public ActionResult Index()
        {
            ExampleGenriceList genriceList = new ExampleGenriceList();
            var stuList = genriceList.GetAll();
            //模糊查询
            IEnumerable<StudentDemo> list1 = stuList.Where(x => x.ClassName.Contains("软件"));
            //精确查询
            IEnumerable<StudentDemo> list2 = stuList.Where(k => k.Name == "王五");
            //获取符合条件的单条数据
            StudentDemo stu1 = stuList.Where(k => k.Name == "王五").FirstOrDefault();

            return null;
        }
    }

    public class ExampleAblumList
    {
        public List<Album> GetAlbumList()
        {
            List<Album> aList = new List<Album>();
            Album a1 = new Album { Id = Guid.NewGuid(), Name = "说好不哭(with 五月天阿信)", Description = "周杰伦专辑", Releasetime = DateTime.Parse("2019-9-16"), Issuer = "周杰伦", Language = "中文", Theprice = 30.00M };
            Album a2 = new Album { Id = Guid.NewGuid(), Name = "睡皇后", Description = "邓紫棋专辑", Releasetime = DateTime.Parse("2018-12-4"), Issuer = "睡皇后", Language = "中文", Theprice = 70.00M };
            Album a3 = new Album { Id = Guid.NewGuid(), Name = "来日方长", Description = "薛之谦专辑", Releasetime = DateTime.Parse("2018-9-12"), Issuer = "薛之谦", Language = "中文", Theprice = 30.00M };
            Album a4 = new Album { Id = Guid.NewGuid(), Name = "对的时间点/As I Believe", Description = "林俊杰专辑", Releasetime = DateTime.Parse("2019-8-20"), Issuer = "睡皇后", Language = "中文", Theprice = 50.00M };
            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);
            return aList;

        }
        public void SearchResultList()
        {
            List<Album> list = GetAlbumList();
            IEnumerable<Album> resultLinqList = from x in list
                                                where x.Theprice >= 50
                                                select x;
            IEnumerable<Album> resultLambdaList = list.Where(x => x.Theprice >= 50).ToList();
        }
    

}