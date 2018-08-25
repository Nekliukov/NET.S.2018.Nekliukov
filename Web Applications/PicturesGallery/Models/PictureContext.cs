using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PicturesGallery.Models
{
    public class PictureContext: DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
    }
}