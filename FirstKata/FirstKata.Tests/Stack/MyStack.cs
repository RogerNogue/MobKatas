namespace FirstKata.Tests.Stack;

public class MyStack<T> {
    readonly int capacity;

    public MyStack() : this(int.MaxValue) {
    }

    MyStack(int capacity) {
        this.capacity = capacity;
    }

    public bool IsEmpty { get; set; } = true;

    public int Size { get; set; }

    public void Push(T element) {
        if (Size >= capacity) {
            throw new MyStackOverflowException();
        }
        
        IsEmpty = false;
        Size++;
    }

    public static MyStack<T> LimitedTo(int capacity) {
        return new MyStack<T>(capacity);
    }
}