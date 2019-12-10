using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 公共接口类
    /// </summary>
    public class IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}