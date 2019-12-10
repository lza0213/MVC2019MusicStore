using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 音乐专辑
    /// </summary>
    public class album:IEntity
    {
        public Guid Id { get; set; }//专辑编号
        public string Name { get; set; }//专辑名称
        public string Description { get; set; }//简介
        public DateTime LssueTime { get; set; }//发行时间
        public string Issuer { get; set; }//发行人
        public string LanguageClassification { get; set; }//语种
        public decimal price { get; set; }//价格 
        public virtual Genre Genre { get; set; }//流派
        public virtual albumType albumType { get; set; }//类型
        

    }
}