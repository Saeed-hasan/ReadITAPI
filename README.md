# ReadITAPI
my project Read IT and it's about E-commerce book store
I decided to build the Back-end part of the project only using C# ASP.NET Core API with Entity Framework,
The project contains 3 main parts
- Models
- Repositories
- API Controllers

models: represents the Database Tables, each model represnt a table and each property represent a column

Repositories: contains the main functionalities like the CRUD operations, GetALL, Get, Add, Remove, Edit and will also contain any 
custom Methods like Buy nad Order here in the oreder repository
controllers: will use the unit of work pattern to make sure there is only one instance for each repository, and in each API end point
will use the corresponding method in the repository, for example the Get Categories will use the GetALL method in the category repository


API Endpoints:
Books:
/api/Books/Get
/api/Books/Get{id}
/api/Books/Put{id}
/api/Books/Post
/api/Books/Delete{id}


Categories:
/api/categories/Get
/api/Books/Get{id}
/api/Books/Put{id}
/api/Books/Post
/api/Books/Delete{id}
/api/Books/BooksInsideOneCategory

Orders:
/api/Orders/Get
/api/Orders/post
/api/Orders/Get{id}
/api/Orders/Put{id}
/api/Orders/Delete{id}
/api/Orders/OrderNow (post)
/api/Orders/BuyNow (post)


Publishers:
/api/Publishers/Get
/api/Publishers/post
/api/Publishers/Get{id}
/api/Publishers/Put{id}
/api/Publishers/Delete{id}


Requstions:
/api/Requstions/Get
/api/Requstions/post
/api/Requstions/Get{id}
/api/Requstions/Put{id}
/api/Requstions/Delete{id}


Sales:
/api/Sales/Get
/api/Sales/post
/api/Sales/Get{id}
/api/Sales/Put{id}
/api/Sales/Delete{id}
