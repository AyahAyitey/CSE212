using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 5), C (priority 3). Dequeue three times.
    // Expected Result: B, C, A (highest priority removed first, then the next highest, and so on).
    // Defect(s) Found: FAILED before the fix. Dequeue returned the highest priority value but never removed
    // the item from the list, so B was returned again on the second call instead of C. Fixed by calling
    // _queue.RemoveAt(highPriorityIndex) before returning. PASSES after the fix.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 3), B (priority 3), C (priority 1). Dequeue three times.
    // Expected Result: A, B, C (items with the same highest priority leave in FIFO order, closest to the
    // front first).
    // Defect(s) Found: FAILED before the fix. The search used ">=" to compare priorities, so on a tie the
    // LATER item replaced the earlier one and B was returned first instead of A. Fixed by changing ">=" to
    // ">". (The missing RemoveAt would also have caused repeated values.) PASSES after the fix.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 2), C (priority 9) so the highest priority item is the
    // LAST one in the queue. Dequeue once.
    // Expected Result: C.
    // Defect(s) Found: FAILED before the fix. The search loop condition was "index < _queue.Count - 1",
    // which never looked at the last item, so B was returned instead of C. Fixed by changing the condition
    // to "index < _queue.Count". PASSES after the fix.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (priority 10), B (priority 2), C (priority 4) so the highest priority item is at the
    // FRONT of the queue. Dequeue twice.
    // Expected Result: A, then C.
    // Defect(s) Found: FAILED before the fix. The first Dequeue correctly returned A, but A was never
    // removed, so the second Dequeue returned A again instead of C. Fixed by removing the item from the
    // list. PASSES after the fix.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 4);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A, B, C all with priority 5 (Enqueue always adds to the back). Dequeue three times.
    // Expected Result: A, B, C (pure FIFO order when every priority is equal).
    // Defect(s) Found: FAILED before the fix. Because of ">=" the later item won every tie, so B was
    // returned first instead of A, and nothing was removed from the list. Fixed by using ">" and RemoveAt.
    // PASSES after the fix.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue a single item A (priority 1), Dequeue it, then Dequeue again.
    // Expected Result: The first Dequeue returns A. The second Dequeue throws an InvalidOperationException
    // with the message "The queue is empty." because Dequeue must remove the item.
    // Defect(s) Found: FAILED before the fix. The item was never removed, so the second Dequeue returned A
    // instead of throwing. Fixed by removing the item from the list. PASSES after the fix.
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Create a new queue and call Dequeue without adding anything.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None. This test PASSED both before and after the fix. The empty check already throws
    // the correct exception type and message.
    public void TestPriorityQueue_7()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}
