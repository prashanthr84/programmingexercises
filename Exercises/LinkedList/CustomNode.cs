namespace Exercises.LinkedList {

    public class CustomNode  {

        public CustomNode(string data) {
            Data = data;
        }

        public CustomNode Previous { get; set; }

        public string Data { get; }

        public CustomNode Next { get; set; }
    }
}