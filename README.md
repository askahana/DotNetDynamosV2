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

## planning and implementation (Notion: En ReadMe-fil som innehåller en förklaring av strukturen i källkoden (grov förklaring av alla klasser, objekt m.m))

This program is written in C#, and it consists of x classes and x methods. 
Dictionary, which takes username as key and User-type as value, was used to store all infomation about users, and it is located in the DataManager class.


![login](https://github.com/askahana/DotNetDynamosV2/assets/144675449/18d44490-12c9-404b-bfe3-e267bc3fba52)

We started with the login method. Users have three login attempts. The login method runs in a while loop, if the username and passwords are the same as one of them in the Dictionary, then it returns a value which identify each user. With this value, you can access each users accounts.

After finishing this part, we started other function parts such as showing all accounts and transferring money.

* ResisterUser
* ShowBalance
* Converter
  Converter-class has two fields for currency rate, one method to be able to change its rate. Four methods for converting rate between each other, and one method to use those four methods. ...and more

* Transaction





## Reflection
Here are some points we would like...?



### Members
* Nathalee Wilund
* Philip Jönsson
* Stefan Johansson
* Vincent Bergqvist
* Asuka Hanada
