using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicModel
{
    public class AlbumDisplayViewMOdel
    {
        public Guid Id { get; set; }//专辑编号
     
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }//序号

        [Required(ErrorMessage = "专辑是必填字段！")]
        [Display(Name = "专辑")]
        public string Name { get; set; }//专辑名

        [Required(ErrorMessage = "简介是必填字段！")]
        [Display(Name = "简介")]
        public string Description { get; set; }//简介

        [Display(Name = "流派")]
        public string  GenreId { get; set; }//流派Id
        [Display(Name = "流派名")]
        public string GenreName { get; set; }//流派name


        [Display(Name = "专辑类型")]
        public string  AlbumTypeId { get; set; }//音乐类型Id
        [Display(Name = "类型名")]
        public string AlbumTypeName { get; set; }//类型name

        [Display(Name = "歌手")]
        public string  ArtistId { get; set; }//歌手Id
        [Display(Name = "歌手名")]
        public string ArtistName { get; set; }//歌手Name


        [Display(Name = "价格")]
        [Range(typeof(decimal), "10.00", "100.00", ErrorMessage = "价格数值为10.00--100.00之间的数值")]//decimal取值范围
        public decimal Theprice { get; set; }//价格

        [Required(ErrorMessage = "发行日期是必填字段！")]
        [Display(Name = "发行日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入正确日期")]
        public DateTime Releasetime { get; set; }//发行时间

        [Required(ErrorMessage = "语种是必填字段！")]
        [Display(Name = "语种")]
        public string Language { get; set; }//语种

        [Required(ErrorMessage = "发行人是必填字段！")]
        [Display(Name = "发行人")]
        public string Issuer { get; set; }//发行人


        [Required(ErrorMessage = "封面链接是必填字段！")]
        [Display(Name = "封面链接")]
        public string UrlString { get; set; }//封面链接


        public List<Genre> GenreItem { get; set; }//流派
        public List<AlbumType> AlbumTypeItem { get; set; }//类型
        public List<Artist> ArtistItem { get; set; }//歌手
    }

    public class AlbumViewModel
    {
        public Guid Id { get; set; }//专辑编号


        [Required(ErrorMessage = "序号是必填字段！")]
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }//序号

        [Required(ErrorMessage = "专辑是必填字段！")]
        [Display(Name = "专辑")]
        public string Name { get; set; }//专辑名

        [Required(ErrorMessage = "简介是必填字段！")]
        [Display(Name = "简介")]
        public string Description { get; set; }//简介

        [Display(Name = "流派")]
        public string GenreId { get; set; }//流派Id
        public string GenreName { get; set; }//流派name


        [Display(Name = "专辑类型")]
        public string AlbumTypeId { get; set; }//音乐类型Id
        public string AlbumTypeName { get; set; }//类型name

        [Display(Name = "歌手")]
        public string ArtistId { get; set; }//歌手Id
        public string ArtistName { get; set; }//歌手Name


        [Display(Name = "价格")]
        [Range(typeof(decimal), "10.00", "100.00", ErrorMessage = "价格数值为10.00--100.00之间的数值")]//decimal取值范围
        public decimal Theprice { get; set; }//价格

        [Required(ErrorMessage = "发行日期是必填字段！")]
        [Display(Name = "发行日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入正确日期")]
        public DateTime Releasetime { get; set; }//发行时间

        [Required(ErrorMessage = "语种是必填字段！")]
        [Display(Name = "语种")]
        public string Language { get; set; }//语种

        [Required(ErrorMessage = "发行人是必填字段！")]
        [Display(Name = "发行人")]
        public string Issuer { get; set; }//发行人


        [Required(ErrorMessage = "封面链接是必填字段！")]
        [Display(Name = "封面链接")]
        public string UrlString { get; set; }//封面链接


        public List<Genre> GenreItem { get; set; }//流派
        public List<AlbumType> AlbumTypeItem { get; set; }//类型
        public List<Artist> ArtistItem { get; set; }//歌手

        public AlbumViewModel()
        {


        }

        public AlbumViewModel(Album model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
            this.Theprice = model.Theprice;
            this.UrlString = model.UrlString;

            if (model.Genre != null)
            {
                this.GenreId = model.Genre.Id.ToString();
                this.GenreName = model.Genre.Name;
            }
            if (model.AlbumType != null)
            {
                this.AlbumTypeId = model.AlbumType.Id.ToString();
                this.GenreName = model.Genre.Name;
            }
            if (model.Artist != null)
            {
                this.ArtistId = model.Artist.Id.ToString();
                this.ArtistName = model.Artist.Name;
            }

        }
        public void MapToModel(Album model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Theprice = model.Theprice;
            this.Description = model.Description;
            this.UrlString = model.UrlString;
            //if (model.Genre != null)
            //{
            //    this.GenreId = model.Genre.Id.ToString();
            //    this.GenreName = model.Genre.Name;
            //}
            //if (model.AlbumType != null)
            //{
            //    this.AlbumTypeId = model.AlbumType.Id.ToString();
            //    this.GenreName = model.Genre.Name;
            //}
            //if (model.Artist != null)
            //{
            //    this.ArtistId = model.Artist.Id.ToString();
            //    this.ArtistName = model.Artist.Name;
            //}
        }
    }
}