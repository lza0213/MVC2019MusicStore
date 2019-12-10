using MVCMusicStore2019.Models;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleMusicController
{
    public class AdminAlbumController : Controller
    {
        // GET: AdminAlbum
        private readonly IEntityRepository<Album> _Service;

        public AdminAlbumController(IEntityRepository<Album> service)
        {
            this._Service = service;
        }
        // GET: AdminArtist
        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<AlbumViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                var vm = new AlbumViewModel(item);
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);

            }
            ViewBag.Title = "音乐编辑";
            return View(vmCollention);
        }
        /// <summary>
        /// 流派（Genre）下拉菜单内容数据集
        /// </summary>
        /// <returns></returns>

        public JsonResult GetGenreList()
        {
            var entityList = _Service.GetRelevance<Genre>().ToList();//流派数据集
            var vmList = new List<GenreViewModel>();//音乐专辑的VM
            var count = 0;
            foreach (var item in entityList)
            {
                var boVM = new GenreViewModel(item);
                vmList.Add(boVM);
            }
            return Json(vmList);
        }
        public JsonResult GetArtistList()
        {
            var entityList = _Service.GetRelevance<Artist>().ToList();//歌手数据集
            var vmList = new List<ArtistViewModel>();//音乐专辑的VM
            var count = 0;
            foreach (var item in entityList)
            {
                var boVM = new ArtistViewModel(item);
                vmList.Add(boVM);
            }
            return Json(vmList);
        }
        public JsonResult GetAlbumTypeList()
        {
            var entityList = _Service.GetRelevance<AlbumType>().ToList();//歌手数据集
            var vmList = new List<AlbumTypeViewModel>();//音乐专辑的VM
            var count = 0;
            foreach (var item in entityList)
            {
                var boVM = new AlbumTypeViewModel(item);
                vmList.Add(boVM);
            }
            return Json(vmList);
        }


        public ActionResult CreatOrEdit(string id = null)//string id = null;允许形参id不传值
        {
            bool isNew = false;//判断当前操作是新增，还是修改；默认；新增
            Guid Id;
            var vm = new AlbumViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new AlbumViewModel(entity);
                ViewBag.Operation = "修改";

            }
            else
            {
                ViewBag.Operation = "新增";
                //  ViewBag.isNew = isNew;

            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatOrEdit(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                Album entity = new Album
                {
                    Id = model.Id,
                    OrderNumber =model .OrderNumber,
                    Name = model.Name,
                    Description = model.Description,
                    GenreId = model.GenreId,
                    ArtistId =model .ArtistId,
                    AlbumTypeId=model .AlbumTypeId,
                    Theprice=model .Theprice ,
                    Releasetime=model .Releasetime ,
                    Language =model .Language ,
                    Issuer=model .Issuer 
                };
                if (model.GenreId != null || model.GenreId != "")
                {
                    var gid = Guid.Parse(model.GenreId);
                    entity.Genre = _Service.GetSingleRelevance<Genre>(gid);
                }
                if (model.ArtistId != null || model.ArtistId != "")
                {
                    var gid = Guid.Parse(model.ArtistId);
                    entity.Artist = _Service.GetSingleRelevance<Artist>(gid);
                }
                if (model.AlbumTypeId != null || model.AlbumTypeId != "")
                {
                    var gid = Guid.Parse(model.AlbumTypeId);
                    entity.AlbumType = _Service.GetSingleRelevance<AlbumType>(gid);
                }
                if (model.Id != Guid.Empty)
                {
                    var vm = new AlbumViewModel();
                    _Service.Edit(entity);
                    ViewBag.Message = "修改成功";
                }
                else
                {
                    entity.Id = Guid.NewGuid();
                    _Service.AddAndSave(entity);
                    ViewBag.Message = "新增成功";
                }
                return RedirectToAction("Index");

            }
            return View(model);
        }

        ///<summary>
        ///图片上传功能
        /// </summary>
        /// 
        public JsonResult UploadImaFile(HttpPostedFileBase imgFie)
        {
            if (imgFie.ContentLength == 0)
            {
                return Json(new

                {
                    upStaus = false,
                    upMessage = "请上传图片"
                }, "text/html");
            }
            //生成图片文件名
            var timeStampString = DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss-ffff", DateTimeFprmatInfo.InvariantInfo);
            var result = "Album_" + timeStampString;

            int startIndex = imgFie.FileName.IndexOf(".");
            var suffix = imgFie.FileName.Substring(startIndex, imgFie.FileName.Length - startIndex);//获取文件后缀名
            var fileName = Path.Combine(Request.MapPath("`/Pics"), Path.GetFileName(result + suffix));

            try
            {
                imgFie.SaveAs(fileName);
                return Json(new {
                    imgUrlString = result + suffix,
                    upStatus = true,
                    upMessage = "图片上传成功！"
                });
            }
            catch(Exception e)
            {
                return Json(new
                {
                    upStatus = false,
                    upMessage = "图片上传失败！"
                }, "json/html");
            }
        }
    }
}