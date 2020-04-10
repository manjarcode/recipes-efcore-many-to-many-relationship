using System;
using System.Collections.Generic;

namespace ManyToMany
{
    public class PostEntity
    {
        public Guid Id { get; set; }

        public IEnumerable<PostImagesEntity> Images { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Description { get; set; }
    }
}
