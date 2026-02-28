namespace FirstKata.Tests.Stack;

public class MyStack<T> {
    public bool IsEmpty { get; set; } = true;
    public int Size { get; set; }

    public void Push(T element) {
        IsEmpty = false;
        Size++;
    }
}