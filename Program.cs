// See https://aka.ms/new-console-template for more information
using System;


public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    //initialize our constructor
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }
    // now setup our getters for all these properties
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    //setter for all properties
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //Now Main Method to run the actual ATM
    public static void Main(String[] args)
    {
        //function for options
        void printOptions()
        {

            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");

        }

        //for handling Deposits
        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            //the compiler is telling you there that you haven't done anything to ensure Console.Readline() isn't null. You can either check it with the null-coalescing operator (??) or tell the compiler you know what you're doing with the null-forgiving (!) operator.
            double deposit = Double.Parse(Console.ReadLine() ?? "0");
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }

        //for handling withdrawals
        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money in $ would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine() ?? "0");
            // check if the user has enough money
            if (currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficient balance: (");
            }
            else
            {
                //double newBalance = currentUser.getBalance() - withdrawl;
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You are good to go! Thank you :)");
            }

        }

        //final function
        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new CardHolder("4532761841325802", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new CardHolder("5128381368581872", 9999, "Frida", "Dickson", 105.59));
        cardHolders.Add(new CardHolder("6011188364697109", 2468, "Muneeb", "Bhut", 851.84));
        cardHolders.Add(new CardHolder("3490693153147110", 4826, "Dawn", "Smith", 54.27));

        // promt user
        Console.WriteLine("Welome to ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine() ?? "0";
                // check against database(db)
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("cardHolder not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine() ?? "0");
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine() ?? "0");
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");


    }

}