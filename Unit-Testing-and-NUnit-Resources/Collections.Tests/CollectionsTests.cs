using NUnit.Framework;
using System;

namespace Collections.Tests
{
    public class CollectionsTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var nums = new Collection<int>();

            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_EmptyConstructorCount()
        {
            var nums = new Collection<int>();

            Assert.That(nums.Count, Is.EqualTo(0), "Count Property");
        }

        [Test]
        public void Test_Collection_EmptyConstructorCapacity()
        {
            var nums = new Collection<int>();

            Assert.That(nums.Capacity, Is.EqualTo(16));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);

            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItemCount()
        {
            var nums = new Collection<int>(5);

            Assert.That(nums.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItemCapacity()
        {
            var nums = new Collection<int>(5);

            Assert.That(nums.Capacity, Is.EqualTo(16));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 6);

            Assert.That(nums.ToString(), Is.EqualTo("[5, 6]"));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItemsCount()
        {
            var nums = new Collection<int>(5, 6);

            Assert.That(nums.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItemsCapacity()
        {
            var nums = new Collection<int>(5, 6);

            Assert.That(nums.Capacity, Is.EqualTo(16));
        }

        public void Test_Collection_Add()
        {
            var nums = new Collection<int>();

            nums.Add(5);

            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }

        [Test]
        public void Test_Collection_AddCount()
        {
            var nums = new Collection<int>();

            nums.Add(5);

            Assert.That(nums.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_AddCapacity()
        {
            var nums = new Collection<int>();

            nums.Add(5);

            Assert.That(nums.Capacity, Is.EqualTo(16));
        }

        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            nums.Add(17);

            Assert.That((nums.Count * 2), Is.EqualTo(nums.Capacity));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collection<int>(1,2,3,4,5,6,7,8);

            nums.AddRange(9, 10,11,12,13,14,15,16, 17,18);

            Assert.That(nums.Capacity, Is.EqualTo(32));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.That(nums[0], Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Assert.That(nums[15], Is.EqualTo(1));
            });
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            nums[3] = 111;

            Assert.That(nums[3], Is.EqualTo(111));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                nums[299] = 1;
            });
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            int initialCount = nums.Count;

            nums.InsertAt(0, 111);

            Assert.AreEqual(nums.Count, initialCount + 1);
            Assert.That(nums[0], Is.EqualTo(111));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            int initialCount = nums.Count;

            nums.InsertAt(initialCount, 111);

            Assert.AreEqual(nums.Count, initialCount + 1);
            Assert.That(nums[initialCount], Is.EqualTo(111));
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            nums.AddRange(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);

            int countAfterAddRange = nums.Count;

            nums.InsertAt(1, 111);

            Assert.That(countAfterAddRange * 2, Is.EqualTo(nums.Capacity));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                nums.InsertAt(299, 1);
            });
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            nums.Exchange(2, 3);

            Assert.That(nums.ToString, Is.EqualTo("[1, 2, 4, 3, 5, 6, 7, 8]"));
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            int numsCount = nums.Count;

            nums.Exchange(0, numsCount-1);

            Assert.That(nums.ToString, Is.EqualTo("[8, 2, 3, 4, 5, 6, 7, 1]"));
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                nums.Exchange(299, 1);
            });
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            int initialCount = nums.Count;

            int removedElement = nums.RemoveAt(0);

            Assert.AreEqual(nums.Count, initialCount - 1);
            Assert.That(removedElement, Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            int initialCount = nums.Count;

            int removedElement = nums.RemoveAt(initialCount - 1);

            Assert.AreEqual(nums.Count, initialCount - 1);
            Assert.That(removedElement, Is.EqualTo(8));
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            int initialCount = nums.Count;

            int removedElement = nums.RemoveAt(2);

            Assert.AreEqual(nums.Count, initialCount - 1);
            Assert.That(removedElement, Is.EqualTo(3));
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int removedElement = nums.RemoveAt(82);
            });
        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            var collectionLength = nums.Count;
            
            for (int i = 0; i < collectionLength; i++)
            {
                nums.RemoveAt(0);
            }

            Assert.AreEqual(nums.Count, 0);
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);

            nums.Clear(); 

            Assert.AreEqual(nums.Count, 0);
        }

    }
}