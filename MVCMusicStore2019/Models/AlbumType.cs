using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Infrastructure;


namespace MVCMusicStore2019.Models
{
    public class AlbumType:IEntity
    {
       public  Guid Id { get; set; }
       public string Name { get; set; }
        public string Description { get; set; }


        public AlbumType()
        {
            this.Id = Guid.NewGuid();
        }
        public AlbumType(AlbumType albumType)
        {
            this.Id = albumType.Id;
            this.Name = albumType.Name;
            this.Description = albumType.Description;
        }

    }
   

}