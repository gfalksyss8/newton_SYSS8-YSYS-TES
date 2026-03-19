using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookstore;

namespace Bookstore.Tests;

[TestClass]
public class BookstoreInventoryTests
{
    private BookstoreInventory _inventory;

    [TestInitialize]
    public void Setup()
    {
        _inventory = new BookstoreInventory();
        Book HarryPotter = new Book("1", "Harry Potter", "J.K. Rowling", 10);
        _inventory.AddBook(HarryPotter);
        Book WesternFront = new Book("2", "All Quiet On The Western Front", "Erich Maria Remarque", 2);
        _inventory.AddBook(WesternFront);

    }

    [TestMethod]
    public void Test1()
    {
        //Implement tests
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void CreateValidBook_ShouldBeTrue()
    {
        var book = new Book("15353263", "BookTitle", "BookAuthor", 5);

        Assert.IsTrue(!String.IsNullOrWhiteSpace(book.ISBN));
        Assert.IsTrue(!String.IsNullOrWhiteSpace(book.Title));
        Assert.IsTrue(!String.IsNullOrWhiteSpace(book.Author));
        Assert.IsTrue(book.Stock != 0);
    }

    [TestMethod]
    public void AddBook_NewBookShouldCreateNewObject()
    {
        Book test = new Book("3", "New book", "Author test", 1);
        _inventory.AddBook(test);

        var result = _inventory.FindBookByTitle("New book");
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void AddBook_ExistingBookShouldAddStock()
    {
        Book test = new Book("3", "New book", "Author test", 1);
        _inventory.AddBook(test);

        var initialStock = _inventory.CheckStock(test.ISBN);

        _inventory.AddBook(test);
        var newStock = _inventory.CheckStock(test.ISBN);

        Assert.AreEqual(initialStock + 1, newStock);
    }

    [TestMethod]
    public void FindBookByTitle_IgnoresOrdinalCase()
    {
        var book = _inventory.FindBookByTitle("hArRy PoTtEr");
        var caseBook = _inventory.FindBookByTitle("Harry Potter");
        Assert.AreSame(book, caseBook);
    }

    [TestMethod]
    public void RemoveBook_RemovingUnexistingBook()
    {
        Assert.IsFalse(_inventory.RemoveBook("10"));
    }

    [TestMethod]
    public void RemoveBook_RemoveExistingBook()
    {
        var initialStock = _inventory.CheckStock("1");
        Assert.IsTrue(_inventory.RemoveBook("1"));

        var newStock = _inventory.CheckStock("1");
        Assert.AreEqual(newStock, initialStock -1);
    }
}