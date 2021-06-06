using System.Collections.Generic;

namespace Exercises  {

    public class ImageLoader {

        //todo:// Refcator and remove the design violations.

        public Image Load(string instanceUid) {
            Cache.Cache cache = new Cache.Cache(25);

            var cachedImage = cache.GetItem(instanceUid);
            if (cachedImage != null) {
                return cachedImage;
            }

            ImageRepository imageRepository = new ImageRepository();
            var image = imageRepository.LoadImage(instanceUid);
            cache.PutItem(instanceUid, image);

            return image;
        }
    }
}