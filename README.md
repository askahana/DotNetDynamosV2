# Projekt i grupp, Bank
## About the program
Bank is a program which simulates a simple banking software for both administrator and bank customer.

Once the user starts the program, they are supposed to choose role first, administrator or customer. Then they are navigated to each login system. There are two log-in systems, one for administrator and one for customer, and the user needs to log in with their username and password.
If the user logged in succesfully, they are directed to each menu according to their role. The user can do the following:

As customer
1. See their accounts
2. Transfer money between their own accounts
3. Transfer money to other
4. Open new account
5. See transaction

As administrator
1. Create new user account
2. See customers account
3. Change interest
4. Change exchange rate

## Planning and implementation (Notion: En ReadMe-fil som innehåller en förklaring av strukturen i källkoden (grov förklaring av alla klasser, objekt m.m))

This program is written in C#, and it consists of x classes and x methods. 

We started with propeties and fields for users.

* Customer

  This class models a customer. Customer-class, which implements ICustomer interface, has 9 propeties: UserName, PassWord, FIrstName, LastName, IDNumber, Email, Birthday, List<Account>Accounts and List <Transaction>.
  
* Admin

  Admin-class has 5 properties: UserName, PassWord, FirstName, LastName, IDNumber.



* DataManager

  To store all infomation about users, Dictionary <string, Admin> adminList and Dictionary<string, Customer> customerList were used, which takes username as key and user-type as value. Both types of users have username, ID, first name etc.
  For customerList there is also List<Account> Accounts and List<Transaction>TransactionHistory. See Account-class and Transaction-class for more details.

And then we started with the login method. Users go to each login method and have three login attempts. 
* Admin Login
* Customer Login

The login method runs in a while loop, where the user is asked to insert username and password. If username is valid, the user will be asked for password. And when both username and password are the same as one of those in Dictionary, then it returns a value which identifies each user. With this value, you can access each users information, such as accounts.

* CustomerManager(Menu)
* AdminManager(Menu)

After the user logged in succesfully, they are directed to each menu. For menus, switch-statement was used. There are 6 choices for customer and 5 choices for administrator. The user is then directed to the method according to their choice.



* IAdmin
* IAdminMenu
* ICustomer
* Account
* ICustomerLogin
* ICusomterMenu
* InterestManager
* LoanManager
* RegisterUser
* RegisterNewAdmin
* RegisterNewCustomer

  
* CustomerManager(Menu)
* AdminManager(Menu)




* DataManager
* Transfer Money
* ShowBalance
* Converter
  
  Converter-class has two fields for currency rate, one method to be able to change its rate. Four methods for converting rate between each other, and one method to use those four methods. ...and more

* Transaction

  Transfer!





## Reflection
Here are some points we would like...?



### Members
* Nathalee Wilund
* Philip Jönsson
* Stefan Johansson
* Vincent Bergqvist
* Asuka Hanada
