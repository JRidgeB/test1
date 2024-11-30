using Blazor_Lab_Starter_Code;
using System.Linq.Expressions;
using System.Xml.Linq;
namespace TestUnit1;

    public class UnitTest1
    {
    
    [Fact]
        public void TestReadBooks()
        {
        //this is more of a test that this works. if the try does not send message, this it works
        int comp = 0; int test = 0;
        try
        {
            testclass.ReadBooks();
        }
        catch (Exception ex)
        {
            test = 1;
        }
        Assert.Equal(comp, test);
        }
    
    public void TestAddUserHappy()
    {
        //Arrange: Set up any necessary objects or input values. AddUser(string inputOne,string InputTwo)
        string inputOne = "test1";
        string inputTwo = "test2";
        int inputThree = 1000;
        User test = new User { Id = inputThree, Name = inputOne, Email = inputTwo };
        User comp;
        //Act: Call the method being tested.
        comp = testclass.AddUser(inputOne, inputTwo, inputThree);
        testclass.DeleteUser(inputThree);
        //Assert: Verify the results*/
        Assert.Equal(comp, test);

    }
    public void TestEditUserHappyOne()
    {
        //Arrange: Set up any necessary objects or input values.
        
        int inputOne = 1000;
        string inputTwo = "test";
        string inputThree = "test";
        User test = new User { Id = inputOne, Name = inputTwo, Email = inputThree };
        //Act: Call the method being tested.
        User comp = testclass.AddUser( inputTwo, inputThree, inputOne);
         comp = testclass.EditUser(inputOne, inputTwo, inputThree);
        testclass.DeleteUser(inputOne);
        //Assert: Verify the results
        Assert.Equal(comp, test);
    }
    public void TestEditUserHappyTwo()
    {
        //Arrange: Set up any necessary objects or input values.

        int inputOne = 1000;
        string inputTwo = "test";
        string inputThree = "test";
        User test = new User { Id = inputOne, Name = inputTwo, Email = inputThree };
        //Act: Call the method being tested.
        User comp = testclass.AddUser(inputTwo, inputThree, inputOne);
        inputTwo = null;
         inputThree = null;
        comp = testclass.EditUser(inputOne, inputTwo, inputThree);
        testclass.DeleteUser(inputOne);
        //Assert: Verify the results
        Assert.Equal(comp, test);

    }
    public void TestDeleteUserHOne()
    {
        //Arrange: Set up any necessary objects or input values.
        int inputOne = 1000;
        string inputTwo = "test";
        string inputThree = "test";
        User temp = new User { Id = inputOne, Name = inputTwo, Email = inputThree };
        string test = "User deleted successfully!";

        //Act: Call the method being tested.
        string comp = testclass.DeleteUser(inputOne);
        //Assert: Verify the results
        Assert.Equal(comp, test);
    }
    public void TestDeleteUserHTwo()
    {
        //Arrange: Set up any necessary objects or input values.
        int inputOne = 1000;

        string test = "User not found!";

        //Act: Call the method being tested.
        string comp = testclass.DeleteUser(inputOne);
        //Assert: Verify the results
        Assert.Equal(comp, test);
    }
    public void TestListUser()
    {
        //Arrange: Set up any necessary objects or input values.
        int test = 0;
        //Act: Call the method being tested.
        int comp = testclass.ListUsers();
        //Assert: Verify the results
        Assert.Equal(comp, test);
    }
    public void TestAddBook()
    {
        //Arrange: Set up any necessary objects or input values.
        string test= "Book added successfully!\n");
        string title = "test";
        string author = "test";
        string isbn = "test";
        int bId = 1000;
        //Act: Call the method being tested.
        string comp = testclass.AddBook(title, author, isbn,bId);
        //Assert: Verify the results
        string temp = testclass.DeleteBook(bId);
        Assert.Equal(comp, test);
    }
    public void TestDeleteBook()
    {
        //Arrange: Set up any necessary objects or input values.
        string test = "Book deleted successfully!\n");
        string title = "test";
        string author = "test";
        string isbn = "test";
        int bId = 1000;
        string temp = testclass.AddBook(title, author, isbn, bId);

        //Act: Call the method being tested.
        string comp = testclass.DeleteBook(bId);
        //Assert: Verify the results
        Assert.Equal(comp, test);
    }

    public void TestReadUsers()
    {
        //this is more of a test that this works. if the try does not send message, this it works
        int comp = 0; int test = 0;
        try
        {
            testclass.ReadUsers();
        }
        catch (Exception ex)
        {
            test = 1;
        }
        Assert.Equal(comp, test);
    }

}

/*  
     public void TestREadUser()
    {
        //Arrange: Set up any necessary objects or input values.
        //Act: Call the method being tested.
        //Assert: Verify the results
    }
 */
