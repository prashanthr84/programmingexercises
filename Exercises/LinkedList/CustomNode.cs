namespace Exercises.LinkedList {

    public class CustomNode<T>  {

        public CustomNode(T data) {
            Data = data;
        }

        public CustomNode<T> Previous { get; set; }

        public T Data { get; }

        public CustomNode<T> Next { get; set; }
    }
}