using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests  {

    [TestClass]
    public class ImageLoaderTests {

        [TestMethod]
        public void ShouldLoadImage()  {
            ImageLoader loader = new ImageLoader();
            var image = loader.Load("imageid");
            Assert.IsNotNull(image);
        }
    }
}
