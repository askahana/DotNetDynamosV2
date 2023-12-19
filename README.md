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

This program is written in C#, and it consists of x classes, x methods and x interfaces. 

intoruction sentences here...
* Customer-class

  This class models a customer. Customer-class, which implements ICustomer interface, has 9 propeties: UserName, PassWord, FIrstName, LastName, IDNumber, Email, Birthday, List<Account>Accounts and List <Transaction>.
  
* Admin-class

  This class has 5 properties: UserName, PassWord, FirstName, LastName, IDNumber.

* Account-class

  This class has four properties: AccountNumber, AccountName, Currency and Balance. 
  
* DataManager

  This class is to store all infomation about users. To store all infomation, Dictionary <string, Admin> adminList and Dictionary<string, Customer> customerList were used, which takes username as key and user-type as value. Both types of users have username, ID, first name etc. For customerList there is also List<Account> Accounts and List<Transaction>TransactionHistory. See Account-class and Transaction-class for more details.
  
* Starting screen

  This class has a StartProgram method that will be called at the very beginning when the program starts. This method is used so that the user can choose role to log in.

And then we started with login method. Users go to each login method and have three login attempts. 
* Admin Login : IAdminLogin
* Customer Login : ICustomerLogin

There are two different login systems and they implements IAdminLogin and ICustomerLogin. The login method runs in a while loop, where the user is asked to insert username and password. If username is valid, the user will be asked for password. And when both username and password are the same as one of those in Dictionary, then it returns a value which identifies each user. With this value, you can access each users information, such as accounts.

* CustomerManager(Menu) : ICustomerMenu
* AdminManager(Menu) : IAdminMenu

For menus, switch-statement was used. There are 6 choices for customer and 5 choices for administrator. The user is then directed to the method according to their choice.

* ShowBalance

  This is to show balance on each account. There are four methods.

* InterestManager
  
* LoanManager
  
* RegisterUser
  
* RegisterNewAdmin

  Same as RegisterNewCustomer
  
* RegisterNewCustomer

* Transfer Money

* Converter
  
  This calss is to convert currency from one to another. There are two fields for currency rate,
  one method to be able to change its rate. Four methods for converting rate between each other, and one method to use those four methods. ...and more

* Transaction

  This class is to show
* Validator

  This class is to give validated value. 




## Reflection
Here are some points we would like...?



### Contributors ✨
* Nathalee Wilund
* Philip Jönsson
* Stefan Johansson
* Vincent Bergqvist
* Asuka Hanada
