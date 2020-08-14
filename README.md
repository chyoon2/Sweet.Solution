# <h1 align = "center"> Factory

## <h3 align = "center"> Entity Framework in ASP.NET MVC, Many to Many Relationships 8.7.20

## <h2 align = "center"> About

<p align = "center"> This is an application for a factory. The user may create new machines and engineers, and connect those objects with a many to many relationship.

## **✅REQUIREMENTS**
* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

## **💻SETUP**
* to clone this content, copy the url provided by the green 'Code' button in GitHub
* in command line use the command 'git clone (GitHub url)'
* open the program in a code editor
* navigate to the Factory directory and type dotnet build in the command line to compile the code
* remaining in the Factory directory type dotnet ef database update to create the database
* type dotnet run in the command line to run the program


## 🔍Specs

| Behavior    | Input | Output |
| :---------- | ----- | -----: |
| Program can create an Engineer object | none | none |
| Engineer object holds engineer name and machines they are licensed to repair | none | none |
| Program can show list of all engineers | none | list |
| Program can show engineer details, including machines they are licensed to repair | none | none |
| Program can create new engineers | none | none |
| Program can create a Machine object | none | none |
| Machine object holds machine name and engineers licensed to repair them | none | none |
| Program can show list of all machines | none | list |
| Program can show machine details, including engineers licensed to repair them | none | none |
| Program can create new machines | none | none |
| Engineer <=> Machine reflects many to many relationship | none | none |
| Join relationships between Engineer & Machine can be added or deleted | none | none |

As a patron, I want to check a book out, so that I can take it home with me.

As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)

- a search to find a book. 
- in details of a book - show how many copies of a book there are left
- where are we adding copies?(ie into our copies table) on our website.  
    - in copies create, viewbagbookname and "add/submit" a copy in the table.
- 
-be able to obtain and pass a copyId.
-be able to find first copyid that isnt already checked out. in controller.
-change that copyid record to true.
-
@*<form action="Copies" method="post">
  </form>*@
  @* , value="@(copy.CopyId)" *@

@*@Html.HiddenFor(copy=>copy.CopyId)*@
@*new {bookId = Model.BookId}*@
@*add a value to button to pass back}*@
@*make sure to pass back copyId.*@
@*@using(Html.BeginForm("IsCheckedOut", "Copies", new { id= "@(copy.CopyId)"} ))*@
@*
@foreach (Copy copy in @Model.Copies)
{
  <form action="Copies" method="post">
  
    <input type="hidden", id="@(copy.CopyId)", name="@(copy.CopyId)" />
    <button class ="btn btn-info", type="submit">checkout</button>
  
  </form>
  <p>"@(copy.CopyId)"</p>
  <p>"@Model.Copies"</p>
}
*@


@foreach(Copy copy in @ViewBag.CopiesList)
{
  @using(Html.BeginForm("IsCheckedOut", "Copies"))
  {
    <input type="hidden", id="CopyId", name="CopyId" value="@(copy.CopyId)"/>
    <button class ="btn btn-info", type="submit">checkout</button>
  }
  <p>"@(copy.CopyId)"</p>
  
}
## 🐛Known Bugs

_No known bugs_

## 📫Support and contact details

Contact : Megan Hepner

## 🔧Technologies Used

* C#
* ASP.NET MVC
* Entity
* MySql


## **📘 License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

@{
  Layout = "_Layout";
}

@model Library.Models.Book;
@using Library.Models

<h2>Book Details</h2>
<hr />
<h3>@Html.DisplayNameFor(model => model.BookName): @Html.DisplayFor(model => model.BookName)</h3>

@if(@Model.Authors.Count == 0)
{
  <p>This Book does not have any Authors</p>
}
else
{
  <h4>Author of this book:</h4>
  <ul>
  @foreach(var join in Model.Authors)
  {
    <li>@join.Author.AuthorName</li>
  }
  </ul>
}


@using (Html.BeginForm("Create", "Copies", FormMethod.Post))
{
  @Html.HiddenFor(model => model.BookId)
  @Html.Label("Copies to Add")
  @Html.TextBox("Copies", "Enter Number to add", new {@type = "number"})
  <button class ="btn btn-info", type="submit">Add</button>
}


@foreach(Copy copy in @ViewBag.CopiesList)
{
  @using(Html.BeginForm("IsCheckedOut", "Copies"))
  {
    <input type="hidden", id="CopyId", name="CopyId" value="@(copy.CopyId)"/>
    <button class ="btn btn-info", type="submit">checkout</button>
  }
  <p>"@(copy.CopyId)"</p>
  
}

"@(copy.CopyId)"
@*new{name = copy.CopyId))*@
<p>@Html.ActionLink("Back to Book index", "Index")</p>
<p>@Html.ActionLink("Edit Link doesnt work not sorry", "Edit", new { id = Model.BookId })</p>
<p>@Html.ActionLink("Delete link doesnt work", "Delete", new { id = Model.BookId })</p>