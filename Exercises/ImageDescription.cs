using System;

namespace Exercises {
    public class ImageDescription  {

        public ImageDescription()  {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }
}