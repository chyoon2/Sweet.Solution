# _Pierre's Sweets_

#### _A Collection of Sweets_
##### __Created:__ 8/7/2020
##### __Last Updated:__ 8/14/2020 
##### By _**Chris Yoon**_  

## Description

_This is a web application that allows for bakers like Pierre to show user which treats have which flavors. And more importantly give log in authorization to the Admin who can add, delete or update the pastries._

## Behaviors

| Spec| Example input | Example Output
| ----------- | ----------- | ----------- |
| The program takes a user input of a Treat or Flavor | "Treat: Pastry" or "Flavor: Vanilla| N/A |
| The program allows user to EDIT Treat or Flavor | N/A | N/A |
| The program allows user to DELETE Treat or Flavor | N/A | N/A |
| The program displays user home page | N/A | "Hello john@gmail.com"|
| The program allows user to Log in and Log out| N/A | N/A |

## Setup/Installation Requirements

#### Open via Bash/GitBash:

1. Clone this repository onto your computer:
    "git clone https://github.com/chyoon2/Sweet.Solution"
2. Navigate into the "Sweet.Solution" directory in Visual Studio Code or preferred text editor:
3. Open the project
    "code ."
4. Open your computer's terminal and navigate to the directory bearing the name of the program and containing the top level subdirectories and files.
5. Enter the command "dotnet build" in the terminal and press "Enter".
6. Enter the command "dotnet watch run" in the terminal and press "Enter".

##### Configue Appsettings.json Database:
1. Create an 'appsettings.json' file in your root folder.
2. Add the following code
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=FIRSTNAME_LASTNAME;uid=root;pwd=YOURPASSWORD"
  }
}
```
3. In the YOURPASSWORD, add your password, if you're with epicodus enter 'epicodus'.
4. This program's database name is set to lowercase 'chris_yoon'

##### Configure Migration:
1. In your terminal run 'dotnet ef migrations add ENTERAPPROPRIATENAME'
2. Then run 'dotnet ef database update'
3. Refresh your Sql workbench to check for the 'chris_yoon' schema. You may have named it differently.

## Known Bugs

* When submitting an edit/update the program adds another engineer/machine into the list.

## Support and contact details
Reach out to chy.yoon@gmail.com for support.

## Technologies Used

* Visual Studio Code
* HTML
* CSS
* Bootstrap
* C#
* MVC
* MySQL Workbench
* Entity Framework
* .NET Core

## Resources:

### License

Copyright (c) 2020 ** _Chris Yoon_**

This software is licensed under the MIT license.