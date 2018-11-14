## Report
The application consists of four main components. Their methods are exposed as public interfaces. The examplary usage is shown in the Library.cs class.

### Catalog
The main part of the library. Keeps track of states of all the books, such as title or author, as well as their borrowing/returns.

### ProcessState
Provides the convinient way to access the library contents.

### Events
API to keep track of all the important events happening in the library - such as registering of a new user or borrowing.returning a book.

### Users
Utility component to store all the information of the library's users. 
