namespace Exercises
{
    public class ImageRepository {

        //todo:// Make this class Singleton.

        public Image LoadImage(string instanceUid)  {
            return new Image() {InstanceUid = instanceUid};
        }
    }
}