Introduction:
	-This is the README file for the project LibraryAPP developed in Visual Studio. 
	-This document provides an overview of the features and overview of project.

Project Description:
	-This application is developed using .NET Core 6.0
	-For Data access Entity Framework core is used.
	-This is an API application developed for the given scenario.

Features:
	-Implemented with Auto mapper, Repository pattern and DTO.
	-Documentation done using Swagger UI.

Overview:
	-IBookRepository interface is inherited to BookRepository for designing the application loosely coupled.
	-In BookRepository implemented API method for
	1). Action method to return sorted list of books by Publisher, AuthorLastName, AuthorFirstName then Title.
	2). Action method to return sorted list of books by AuthorLastName, AuthorFirstName then Title.
	3). Write a stored procedure in SQL server for scenario (1) and (2) and call from VS to return the same output.
	4). Action method to return total price of all books in Book Class.
	5). Created a data in memory and created action method to save the book list to the database in single call to the server.
	6). Created ResearchScholar and Thesis model to describe one to many relationship 
		and database diagram is attached in the Images folder.
	7). Added Property to the book class and returns MLA and Chicago citation output as a string.
	8). Action method to save list of book to the database. The book list is passed from swagger as a parameter.
	9). To avoid duplication entry creation in Title attribute made index as unique.
