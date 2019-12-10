using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Infrastructure;

namespace MVCMusicStore2019.Models
{
    public class Album:IEntity
    {
        public Guid Id { get; set; }//专辑编号
        public string OrderNumber { get; set; }//序号
        public string Name { get; set; }//专辑名
        public string Description { get; set; }//简介
        public string  GenreId { get; set; }//流派Id
        public string  AlbumTypeId { get; set; }//音乐类型Id
        public string  ArtistId { get; set; }//歌手Id

        public decimal Theprice { get; set; }//价格
        public DateTime Releasetime { get; set; }//发行时间
        public string Language { get; set; }//语种
        public string Issuer { get; set; }//发行人
        public string UrlString { get; set; }//图片传入路径及文件名

        public virtual Genre Genre { get; set; }//流派
        public virtual AlbumType AlbumType { get; set; }//类型
        public virtual Artist Artist { get; set; }//歌手

        public Album()
        {
            this.Id = Guid.NewGuid();
            this.Releasetime = DateTime.Now;
            this.Theprice = 0.00M;
        }
        public Album(Album bo)
        {
            this.Id = bo.Id;
            this.Name = bo.Name;
            this.Description = bo.Description;

            this.Releasetime = bo.Releasetime;
            this.Issuer = bo.Issuer;
            this.Language = bo.Language;
            this.Theprice = bo.Theprice;
            if (Genre != null)
            {
                this.GenreId = bo.Genre.Id.ToString();
                this.Genre.Id = bo.Genre.Id;
                this.Genre.Name = bo.Genre.Name;
                this.Genre.Description = bo.Genre.Description;
            }
            if (AlbumType != null)
            {

                this.AlbumTypeId = bo.Artist.Id.ToString();
                this.AlbumType.Id = bo.Artist.Id;
                this.AlbumType.Name = bo.AlbumType.Name;
                this.AlbumType.Description = bo.AlbumType.Description;
            }
            if (Artist != null)
            {
                this.ArtistId = bo.Artist.Id.ToString();
                this.Artist.Id = bo.Artist.Id;
                this.Artist.Name = bo.Artist.Name;
                this.Artist.Description = bo.Artist.Description;
            }
        }
    }
}