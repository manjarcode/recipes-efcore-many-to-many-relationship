using System;
using System.Collections.Generic;

namespace ManyToMany
{
    public class ImageEntity
    {
        public Guid Id { get; set; }

        public string Path { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public IEnumerable<PostImagesEntity> Posts { get; set; }
    }
}
