namespace FirstKata.Tests.Stack;

public class MyStackUnderflowException : Exception {
    public MyStackUnderflowException() : base("Tried to pop from an empty stack") {
        
    }
}