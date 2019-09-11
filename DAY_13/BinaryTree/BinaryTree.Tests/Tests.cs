using Binary;
using BinarySearchTreeTests;
using NUnit.Framework;
using System.Collections.Generic;
using Test.BinarySearchTreeTests;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void BinaryTreeTest_int_default()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            bt.Insert(50);
            bt.Insert(17);
            bt.Insert(12);
            bt.Insert(23);
            bt.Insert(19);
            bt.Insert(9);
            bt.Insert(14);
            bt.Insert(72);
            bt.Insert(76);
            bt.Insert(54);
            bt.Insert(67);
            Assert.AreEqual(11, bt.NumOfElements);
            CollectionAssert.AreEqual(new int[] { 9, 12, 14, 17, 19, 23, 50, 54, 67, 72, 76 }, bt.InOrder());
            CollectionAssert.AreEqual(new int[] { 50, 17, 12, 9, 14, 23, 19, 72, 54, 67, 76 }, bt.PreOrder());
            CollectionAssert.AreEqual(new int[] { 9, 14, 12, 19, 23, 17, 67, 54, 76, 72, 50 }, bt.PostOrder());
            //bt.Remove(54);
            //CollectionAssert.AreEqual(new int[] { 9, 12, 14, 17, 19, 23, 50, 67, 72, 76 }, bt.InOrder());
        }

                [Test]
        public void BinaryTreeTest_string_default()
        {
            BinaryTree<string> bt = new BinaryTree<string>();
            bt.Insert("dddd");
            bt.Insert("bbb");
            bt.Insert("aaaa");
            bt.Insert("hhh");
            bt.Insert("eeee");
            Assert.AreEqual(5, bt.NumOfElements);
            CollectionAssert.AreEqual(new string[] { "aaaa", "bbb", "dddd", "eeee", "hhh" }, bt.InOrder());
            CollectionAssert.AreEqual(new string[] { "dddd", "bbb", "aaaa", "hhh", "eeee" }, bt.PreOrder());
            CollectionAssert.AreEqual(new string[] { "aaaa", "bbb", "eeee", "hhh", "dddd" }, bt.PostOrder());
        }


        [Test]
        public void BinaryTreeTest_string_comp()
        {
            BinaryTree<string> bt = new BinaryTree<string>(new StringLengthComparer());
            bt.Insert("aaa");
            bt.Insert("d");
            bt.Insert("hhhh");
            bt.Insert("bb");
            bt.Insert("eeeeee");
            Assert.AreEqual(5, bt.NumOfElements);
            CollectionAssert.AreEqual(new string[] { "d", "bb", "aaa", "hhhh", "eeeeee" }, bt.InOrder());
        }     

        [Test]
        public void BinaryTreeTest_book_comp()
        {
            BinaryTree<Book> bt = new BinaryTree<Book>(new BookComparer());
            bt.Insert(new Book("Ernest Heminguei", "Pokom zvonit kololol", 600));
            bt.Insert(new Book("Lev Tolstoi", "Voina i Mir", 1234));
            bt.Insert(new Book("Nickolai Gogol", "Mertvie Dushi", 152));
            bt.Insert(new Book("Nickolai Gogol", "Revizor", 400));
            bt.Insert(new Book("Alex Pushkin", "Evgenii Onegin", 95));
            bt.Insert(new Book("Lev Tolstoi", "Ann Karanina", 1000));

            Assert.AreEqual(6, bt.NumOfElements);

            IEnumerable<Book> expected = new Book[] {
                new Book("Nickolai Gogol", "Revizor", 400),
                new Book("Lev Tolstoi", "Voina i Mir", 1234),
                new Book("Lev Tolstoi", "Ann Karanina", 1000),
                new Book("Nickolai Gogol", "Mertvie Dushi", 152),
                new Book("Alex Pushkin", "Evgenii Onegin", 95),
                new Book("Ernest Heminguei", "Pokom zvonit kololol", 600) };

            CollectionAssert.AreEqual(expected, bt.InOrder());
        }
        
    }
}