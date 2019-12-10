using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    /// <summary>
    /// !!!!!!!!!该案例为了上课方便使用，违反编程规范，编程时不要使用此种实现方式
    /// </summary>
    /// 学生类
    public class StudentDemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
    }
    public class ExampleTransferparameterController : Controller
    {
        public ActionResult StuList()
        {
            //通过泛型集合定义一个学生集合，同时进行初始化操作，并返回该集合列表
            //List<T>
            List<StudentDemo> stuList = new List<StudentDemo>();
            StudentDemo stu1 = new StudentDemo { Id = 1, Name = "张三", ClassName = "2018软件技术一班" };
            StudentDemo stu2 = new StudentDemo { Id = 2, Name = "李四", ClassName = "2018软件技术一班" };
            StudentDemo stu3 = new StudentDemo { Id = 3, Name = "王五", ClassName = "2018软件技术一班" };
            StudentDemo stu4 = new StudentDemo { Id = 4, Name = "申七", ClassName = "2018软件技术一班" };
            StudentDemo stu5 = new StudentDemo { Id = 5, Name = "秦六", ClassName = "2018软件技术一班" };
            stuList.Add(stu1);
            stuList.Add(stu2);
            stuList.Add(stu3);

            return View();
        }
        // GET: ExampleTransferparameter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JumpSite()
        {
            return new RedirectResult("http://163.com");
        }
        public void NotReturn1() { }
        public EmptyResult NullResult1()
        {
            return null ;
        }
        public ActionResult NullResult2()
        {
            return null;
        }
    }
}