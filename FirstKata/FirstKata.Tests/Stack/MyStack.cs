namespace FirstKata.Tests.Stack;

public class MyStack<T> {
    readonly int capacity;

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

    public T Pop() {
        if (IsEmpty) {
            throw new MyStackUnderflowException();
        }

        Size--;
        if (Size == 0)
            IsEmpty = true;
        
        return default;
    }

    public static MyStack<T> Limitless() {
        return LimitedTo(int.MaxValue);
    }

    public static MyStack<T> LimitedTo(int capacity) {
        return new MyStack<T>(capacity);
    }
}