namespace FirstKata.Tests.Stack;

public class MyStack<T> {
    readonly int capacity;
    
    public int Size { get; set; }
    public bool IsEmpty => Size == 0;
    
    MyStack(int capacity) {
        this.capacity = capacity;
    }
    
    public void Push(T element) {
        if (Size >= capacity) {
            throw new MyStackOverflowException();
        }
        
        Size++;
    }

    public T Pop() {
        if (IsEmpty) {
            throw new MyStackUnderflowException();
        }

        Size--;
        return default;
    }

    public static MyStack<T> Limitless() {
        return LimitedTo(int.MaxValue);
    }

    public static MyStack<T> LimitedTo(int capacity) {
        return new MyStack<T>(capacity);
    }
}