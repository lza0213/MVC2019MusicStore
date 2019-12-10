using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Infrastructure;

namespace MVCMusicStore2019.Models
{
    public class Genre:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre()
        {
            this.Id = Guid.NewGuid();
        }
        public Genre(Genre genre)
        {
            this.Id = genre.Id;
            this.Name = genre.Name;
            this.Description = genre.Description;
        }

    }
}