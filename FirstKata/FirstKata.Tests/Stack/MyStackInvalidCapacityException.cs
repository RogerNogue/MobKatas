namespace FirstKata.Tests.Stack;

public class MyStackInvalidCapacityException : Exception {
    public MyStackInvalidCapacityException() : base("Invalid stack capacity") {
        
    }
}