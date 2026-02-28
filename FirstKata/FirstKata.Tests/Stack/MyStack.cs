namespace FirstKata.Tests.Stack;

public class MyStack<T> {
    readonly int capacity;
    readonly List<T> elements = new();
    
    public int Size { get; set; }
    public bool IsEmpty => Size == 0;
    
    MyStack(int capacity) {
        if (capacity <= 0) {
            throw new MyStackInvalidCapacityException();
        }
        
        this.capacity = capacity;
    }
    
    public void Push(T element) {
        if (Size >= capacity) {
            throw new MyStackOverflowException();
        }
        
        Size++;
        elements.Add(element);
    }

    public T Pop() {
        if (IsEmpty) {
            throw new MyStackUnderflowException();
        }

        Size--;
        var lastAddedElement = elements[^1];
        elements.Remove(lastAddedElement);
        return lastAddedElement;
    }

    public T Peek() {
        throw new MyStackUnderflowException();
    }

    public static MyStack<T> Limitless() {
        return LimitedTo(int.MaxValue);
    }

    public static MyStack<T> LimitedTo(int capacity) {
        return new MyStack<T>(capacity);
    }
}