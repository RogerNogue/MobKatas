namespace FirstKata.Tests.Stack;

// In computer science, a stack is a famous abstract data type that provides certain operations on a collection of elements.
// [x] Push - Add an element to the top of the stack    
// [x] Pop - Remove an element from the top of the stack, returning it
// [x] Empty check - Check if the stack is empty or not
// [x] Size - Count of the elements in the stack
// Peek - Check the top of the stack without popping

// [x] Handle overflows when too many elements are pushed to the stack
// [x] Handle underflows when too many elements are popped off the stack
// Handle underflows when there are no elements to peek on the stack
// Handle attempts to create a stack with an invalid capacity (negative numbers)

public class StackTests {
    readonly MyStack<string> sut = MyStack<string>.Limitless();

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

    [Fact]
    public void PopFromStack_ThrowsUnderflow_WhenEmpty() {
        Assert.Throws<MyStackUnderflowException>(() => sut.Pop());
    }

    [Fact]
    public void PopFromStack_DecreasesSize() {
        sut.Push("1");
        sut.Push("2");
        
        sut.Pop();
        
        Assert.Equal(1, sut.Size);
    }
    
    [Fact]
    public void CanPop_UntilEmpty() {
        sut.Push("1");
        
        sut.Pop();
        
        Assert.True(sut.IsEmpty);
    }

    [Fact]
    public void Pop_ReturnsLastAddedElement() {
        const string element1 = "1";
        const string element2 = "2";
        sut.Push(element1);
        sut.Push(element2);

        var retrievedResult1 = sut.Pop();
        var retrievedResult2 = sut.Pop();
        
        Assert.Equal(element2, retrievedResult1);
        Assert.Equal(element1, retrievedResult2);
    }
}