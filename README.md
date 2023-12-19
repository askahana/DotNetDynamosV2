# Projekt i grupp, Bank
## About the program
Bank is a program which simulates a simple banking software for both administrator and bank customer.

Once the user starts the program, they are supposed to choose role first, administrator or customer. Then they are navigated to each login system. There are two log-in systems, one for administrator and one for customer, and the user needs to log in with their username and password.
If the user logged in succesfully, they are directed to each menu according to their role. The user can do the following:

As customer
1. See their accounts
2. Transfer money between their own accounts
3. Transfer money to others
4. Open new accounts
5. See transactions

As administrator
1. Create new user accounts
2. See customer accounts
3. Change interest
4. Change exchange rate

## Planning and implementation

This program is written in C#, and it consists of x classes, x methods and x interfaces. 

We initiated the project by defining fields and properties.

### Property

* Customer-class

  This class models a customer. Customer-class, which implements ICustomer interface, has 9 propeties: UserName, PassWord, FirstName, LastName, IDNumber, Email, Birthday, List <Account> Accounts and List <Transaction> TransactionHistory.
  
* Admin-class

  This repersents an administrator. This class has five properties: UserName, PassWord, FirstName, LastName, IDNumber.

* Account-class

  This class has four properties: AccountNumber, AccountName, Currency and Balance. 
  
* DataManager-class

  This class is to store all infomation about users. To store all infomation, Dictionary <string, Admin> adminList and Dictionary<string, Customer> customerList were used, which takes username as key and user-type as value. Both types of users have username, ID, first name etc. For customerList there is also List<Account> Accounts and List<Transaction>TransactionHistory. See Account-class and Transaction-class for more details.

### Login
  
* Starting screen-class

  This class has a StartProgram method that will be called at the very beginning when the program starts. In this method, switch-statment is used so that the user can choose role to log in.

  Users go to each login method and have three login attempts. 
* Admin Login : IAdminLogin
* Customer Login : ICustomerLogin

  There are two different login systems and they implement IAdminLogin and ICustomerLogin. The login method runs in a while loop, structured to control the login process, and it continues until the user inserts the correct information or exceeds three attempts. The user is asked to insert username and if the username is valid, the user will be asked for password. When both username and password are the same as one of those in Dictionary, then it returns a value which identifies each user. With this value, you can access each users information, including email and accounts and other relevant details.

### Menu and other functions
After the user logged in succesfully, they are directed to each menu according to their role. As mentioned above, the value which was returned to LoginSystem allows the program to access the specific user's information. Essentially, the login process establishes a session for the logged-in user, allowing the system to tailor interactions and display information specific to that user.

* CustomerManager(Menu) : ICustomerMenu
* AdminManager(Menu) : IAdminMenu

  These classes are to display Menus and switch-statement was used to direct to different methods. There are 6 choices for customer and 5 choices for administrator. The user is then directed to the method based on their selections.

* ShowBalance

  This class provides functionality for displaying account information.

  * ShowAccount(): Displays options to the user, allowing them to choose between showing the balance of a specific account or all accounts(switch-statement).
  * ShowSpecificAccount(): Displays a list of the user's accounts, allowing them to select a specific account and showing its balance.
  * ShowAllAccounts(): Displays the balances for all accounts belonging to the logged-in customer(foreach).
  * DisplayUserAccounts(): Helper method to display a numbered list of the user's accounts(for-loop).

* InterestManager

  This class manages interest rates for savings and loans. This contains two fields for rates.
  
  * SetSavingsInterestRate(): Sets a new interest rate for savings.
  * SetLoanInterestRate(): Sets a new interest rate for loans.
  * DisplayInterestRates(): Displays the current interest rates for savings and loans.
  * AdminSetInterestRates(): Allows an administrator to set new interest rates for savings or loans based on user input(switch-statement).
  * SavingsInterestRate(): Retrieves the current savings interest rate.
  * GetLoanInterestRate(): Retrieves the current loan interest rate.
  
* AccountManager

  This class facilitates the process of adding new accounts for a logged-in customer. 
  * AddAccount(): For opening new account, asks the user to input details for a new account to insert.
  * CaluculateEarnedInterest(): Calculates the earned interest based on the provided balance and interest rate.
  * GenerateNewAccountNumber(): Generates a new account number for the customer based on the existing account numbers.
  
* LoanManager

  This class handles the process of requesting and approving personal loans, considering the loan amount, interest rate, and account selection.

  * RequestPersonalLoan() : Takes user input for the loan amount, shows the applicable loan interest rate and adds the loan amount to the selected account's balance.
  * DisplayUserAccounts: Show users account.
  * CaluculateTOtalBalance(): Calculates the total balance across all customer accounts.
  
* RegisterUser

  This class has a method, Register(), for administrator to choose whether to register an administrator or a customer.
   
* RegisterNewAdmin

  * RegisterAdmin() : Guide the admin through the process of registering a new administrator. The user needs to insert username, firstname and lastname etc to register.
  Infomation will be stored in Dictionary <string, Admin> adminList.

 * RegisterNewCustomer

   Same as RegisterNewAdmin.
   
* ShowAllCustomer

  This class is for administrator to display information about admins and customers.
  
  * ShowAllInfo(): Displays a menu with switch-statement for the admin to choose the type of user, Admin or Customer or Exit, account to view. Uses a while loop to allow continuous interaction until the admin chooses to exit.
  * ShowAdminInfo()
  * ShowCustomerInfo() 
  
* Transfer Money

  This class includes two methods, that is to transfer money to between accounts and transfer money to someone else.

* Converter

  This class is designed for converting currency from one type to another. It includes two fields for currency rates to SEK, Euro, and Yen. Additionally, there is a method to change these rates. The class consists of four methods for converting rates between each other, along with an overarching method that utilizes these four conversion methods.

* Transaction

  This class includes three properties, TransactionType, Amount and Timestamp, and one method designed to display the transaction history. The method is added in transfermoney-class and invoked whenever a customer initiates a money transfer.

* Validator

  Validator class contains several static methods to validate and retrieve user inputs for various data types, int and decimal etc.

## Reflection
Here 

### Contributors ✨
* Nathalee Wilund
* Philip Jönsson
* Stefan Johansson
* Vincent Bergqvist
* Asuka Hanada
