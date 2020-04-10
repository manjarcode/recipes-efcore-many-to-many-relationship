using System;

namespace ManyToMany
{
    public class PostImagesEntity
    {
        public Guid PostId { get; set; }

        public PostEntity Post { get; set; }

        public Guid ImageId { get; set; }

        public ImageEntity ImageEntity { get; set; }
    }
}
