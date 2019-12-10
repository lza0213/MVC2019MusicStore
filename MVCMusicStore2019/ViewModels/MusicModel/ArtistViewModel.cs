using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicModel
{
    public class ArtisDisplayViewMOdel
    {
        public Guid Id { get; set; }//专辑编号


        [Display(Name = "序号")]
        public string OrderNumber { get; set; }//序号

        [Required(ErrorMessage = "专辑是必填字段！")]
        [Display(Name = "名字")]
        public string Name { get; set; }//专辑名

        [Required(ErrorMessage = "简介是必填字段！")]
        [Display(Name = "歌手简介")]
        public string Description { get; set; }//简介
    }
    public class ArtistViewModel
    {
        public Guid Id { get; set; }//专辑编号

        
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }//序号

        [Required(ErrorMessage = "专辑是必填字段！")]
        [Display(Name = "名字")]
        public string Name { get; set; }//专辑名

        [Required(ErrorMessage = "简介是必填字段！")]
        [Display(Name = "歌手简介")]
        public string Description { get; set; }//简介

        public ArtistViewModel(){}

        public ArtistViewModel(Artist model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(Artist model)
        {
            model.Id = this.Id;
            model.Name = this.Name;
            model.Description = this.Description;

        }
    }
}