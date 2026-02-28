namespace FirstKata.Tests.Stack;

// In computer science, a stack is a famous abstract data type that provides certain operations on a collection of elements.
// Push - Add an element to the top of the stack    
// Pop - Remove an element from the top of the stack, returning it
// Empty check - Check if the stack is empty or not
// Size - Count of the elements in the stack
// Peek - Check the top of the stack without popping

// Handle overflows when too many elements are pushed to the stack
// Handle underflows when too many elements are popped off the stack
// Handle underflows when there are no elements to peek on the stack
// Handle attempts to create a stack with an invalid capacity (negative numbers)

public class StackTests {
    [Fact]
    public void Stack_IsEmpty_ByDefault() {
        Assert.True(new MyStack<string>().IsEmpty);
    }
    
    [Fact]
    public void Stack_HasSizeOfZero_ByDefault() {
        Assert.Equal(0, new MyStack<int>().Size);
    }
}

public class MyStack<T> {
    public bool IsEmpty { get; set; } = true;
    public int Size { get; set; }
}