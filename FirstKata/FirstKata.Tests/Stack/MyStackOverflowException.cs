namespace FirstKata.Tests.Stack;

public class MyStackOverflowException : Exception {
    public MyStackOverflowException() : base("Tried to add more elements than allowed to the stack") {
        
    }
}