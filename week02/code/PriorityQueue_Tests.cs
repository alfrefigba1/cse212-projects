using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items where the item with the highest priority is last.
    // Expected Result: Dequeue should return the item with the highest priority.
    // Defect(s) Found: The loop in Dequeue() did not check the last item in the queue,
    // so it could fail to return the item with the highest priority when that item
    // was at the end of the queue. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
     // Scenario: Add an item to the queue and dequeue it, then dequeue again.
    // Expected Result: The first item is returned and removed, and the second dequeue throws an exception.
    // Defect(s) Found: The original Dequeue method returned the item but did not remove it from the queue. therefore it could return the the same item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}