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
    readonly MyStack<string> sut = new();

    [Fact]
    public void Stack_IsEmpty_ByDefault() {
        Assert.True(sut.IsEmpty);
    }
    
    [Fact]
    public void Stack_HasSizeOfZero_ByDefault() {
        Assert.Equal(0, sut.Size);
    }

    [Fact]
    public void PushToStack_MakesIt_NonEmpty() {
        sut.Push("1");
        
        Assert.False(sut.IsEmpty);
        Assert.Equal(1, sut.Size);
    }

    [Fact]
    public void PushToStack_AccumulatesSize() {
        sut.Push("1");
        sut.Push("2");
        
        Assert.Equal(2, sut.Size);
    }

    [Fact]
    public void PushTo_FullStack_ThrowsOverflow() {
        var sut = MyStack<string>.LimitedTo(capacity: 1);
        
        sut.Push("1");
        
        Assert.Throws<MyStackOverflowException>(() => sut.Push("Anything"));
    }
}