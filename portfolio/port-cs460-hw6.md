# CS460 Homework 5

# Shortcuts
### [Code Repo](https://github.com/joshua-martinez95/joshua-martinez95.github.io/tree/master/homework5) 
### [Home](../index.md) 
### [CS460 Assignments](portMain-cs460.md) 



# 1.) Setup
So first things first, make a new branch. Then after this, we start up a new project. But, before we get access to any database, we're gonna need a databaase. So after downloading the .bak file, we have to use SQL Server Manager to unpack this and after doing so we need to use Visual Studio to connect to his newly restored server. Once it's connected, we can start using LinQ Pad to test SQL commands to test the queries and then implement them to the Project.

# 2.) Code

So for the most part, all the models are made so the ones I actually had to make sure to make two models. PersonVM and PurchasedItem.
Person will look like 
```csharp
    public class PersonVM
    {
        //Default Details
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ValidFrom { get; set; }

        //Customer Company Details information
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyWebsite { get; set; }
        public DateTime CompanyValidFrom { get; set; }

        //Purchase History Details information
        public double Orders { get; set; }
        public decimal GrossSales { get; set; }
        public decimal GrossProfit { get; set; }

        //Items Purchased Details information. Seen in PurchasedItem.cs
        public List<PurchasedItem> ItemPurchaseList { get; set; }
    }
```

This will be for the Details of the pserosn, customer company, purchase history, and a list for the PurchasedItem. 
After making sure those two classes were done, we can start working on the controllers. But first, we must make a UserContext file that will be used. Now the controller work cnat yes. 



# 3.) Final Product

<iframe width="560" height="315" src="https://www.youtube.com/embed/xliCUjWNAAk" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>