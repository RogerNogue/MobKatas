namespace FirstKata.Tests.Stack;

public class MyStack<T> {
    readonly int capacity;
    readonly List<T> elements = new();
    
    public int Size => elements.Count;
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
        
        elements.Add(element);
    }

    public T Pop() {
        var lastAddedElement = Peek();
        elements.Remove(lastAddedElement);
        return lastAddedElement;
    }

    public T Peek() {
        if (IsEmpty) {
            throw new MyStackUnderflowException();
        }
        
        return elements[^1];
    }

    public static MyStack<T> Limitless() {
        return LimitedTo(int.MaxValue);
    }

    public static MyStack<T> LimitedTo(int capacity) {
        return new MyStack<T>(capacity);
    }
}