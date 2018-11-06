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
After making sure those two classes were done, we can start working on the controllers. But first, we must make a UserContext file that will be used. Now the controller work can start. Making the controler for index was easy. 

```csharp
        public ActionResult Index()
        {
            return View();
        }
```
This is so when you start up the page, it will show the search bar. Nothing too special here.
But next we can start working on the Index controller. This was farely easy to make the controller.
We took in a string and then used sql dot notaion to write a query on search through and finding any names that contain the searchString as a substring. This will make a list of people with model PersonVM. This will also check if there are no entries that match with the subString. If no entries, then display an error message.

```csharp
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            /// But search Result in ViewBag
            ViewBag.result = searchString;

                /// Make a list of people that fit the search string
                /// Using sql dot notation
                List<PersonVM> listPeople = db.People.Select(p => new PersonVM
                {
                    FullName = p.FullName,
                    PreferredName = p.PreferredName,
                }).Where(per => per.FullName.Contains(searchString)).ToList();
            ///If there is atleast one search result
            /// turn on toggle to display search results
            if(listPeople.Count > 0)
            {
                ViewBag.toggle = 1;
                ViewBag.result = "Search results for \"" + searchString + "\"";
            }
            ///else, show this messages
            else
            {
                ViewBag.result = "Sorry, no results have been made!";
                return View(listPeople);
            }

            return View(listPeople);

        }
```

To display this in html I used this:
```csharp
            @if (ViewBag.toggle == 1)
            {
                <div class="col-md-4">

                    @foreach (var row in Model)
                    {
                        <div class="container" style="border: ridge; border-color: grey;">
                            <!--Displays the names along with a link to a details page-->
                            <div class="row" style="padding: 10px;">@Html.ActionLink(linkText: row.FullName + "\t" + "(" + row.PreferredName + ")", actionName: "Details", controllerName: "Home", routeValues: new { fName = row.FullName }, htmlAttributes: null)</div>
                        </div>
                        <br />
                    }

                </div>
            }
```

Using razor commands to check if there were results.
Now we can start working on the controller for the details page. 
A simple check to make sure there is something that matches thte search string
```csharp
if (fName == null || fName == "")
{
/// If an error, redirect to Index page
return (RedirectToAction("Index"));
}
```
Then for the first requirment, we will do a simple command that is simmilar to the one we used for searching throught the people.
Only difference this time we will be grabbing more information.

After this, we will start to grab the customer information details. Now, there is a possiblity that nothing comes up here and that would mean that they are an employee. But we check for this later.

```csharp
var CustomerCoDetails = db.People
    .Where(p => p.FullName == fName)
    .Include("PrimaryContactPersonID")
    .SelectMany(p => p.Customers2).ToList();
```
Now here is where we will check to see if anything came up, it's pretty simple actually. If the count of CustomerCoDetails is more than one, then we will display more information about the person.

Then this will get the details font he Purchased Items with using SQL dot noation by using the Full Name to match and we will include the PrimaryContactPersonID from the Customer model. This will be be to show the purchase history. 

```csharp
//Details on the Purcased Items.
var ItemDetails = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
    .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
    .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
    .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10).ToList();
```

Now we will start to get the information for the top 10 items sold. Again we will use the Full Name to find the needed information. This too will use much of the same code from the Purchased Items. But we will include the SelectMany SQL command 
```csharp
//A list of salespeople and the top 10 items sold to the customer
var SalesP = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
    .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
    .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
    .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10)
    .Include("InvoiceID").Select(x => x.Invoice).Include("SalespersonID").Select(x => x.Person4)
    .ToList();
```

Then we will start to make the list of the top 10 items bought from the sold

```csharp
List<PurchasedItem> Top10Items = new List<PurchasedItem>();

//Intializes a list of PurchasedItem classes with details for the top 10 items bought by customer
for (int i = 0; i < 10; i++)
{
    /// add each line of information for the top 10
    Top10Items.Add(new PurchasedItem
    {
    StockItemID = ItemDetails.ElementAt(i).StockItemID,
    ItemDescription = ItemDetails.ElementAt(i).Description,
    LineProfit = ItemDetails.ElementAt(i).LineProfit,
    SalesPerson = SalesP.ElementAt(i).FullName
    });
}
```

```csharp
///Make a "list" of the singular customer information
List <PersonVM> Customers = new List<PersonVM>
{
    new PersonVM{
    ///The basic details for a person
    FullName = result.First().FullName,
    PreferredName = result.First().PreferredName,
    PhoneNumber = result.First().PhoneNumber,
    FaxNumber = result.First().FaxNumber,
    EmailAddress = result.First().EmailAddress,
    ValidFrom = result.First().ValidFrom,
    ///The details for a customer's company
    CompanyName = CustomerCoDetails.First().CustomerName,
    CompanyPhone = CustomerCoDetails.First().PhoneNumber,
    CompanyFax = CustomerCoDetails.First().FaxNumber,
    CompanyWebsite = CustomerCoDetails.First().WebsiteURL,
    CompanyValidFrom = CustomerCoDetails.First().ValidFrom,
    /// The purchase history of that customer. Including Total orders, GrossSales and Gross profit.
    Orders = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
        .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders).Count(),

    GrossSales = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
        .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
        .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
        .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.ExtendedPrice),

    GrossProfit = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
        .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
        .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
        .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.LineProfit),
    ///Details for the items purchased. Top 10 most profitable
    ItemPurchaseList = Top10Items
    }
};
```
This gets all the information to the list and actually puts all the Person, customer company details and purchase history . This is actually fairly simple to assign the needed variables. This is where we will do the math of of summing items for totals using the .Sum SQL dot notation.

Now we will just assign a value to a variable make sure that this is a customer.

```csharp
ViewBag.MoreInfo = true;
return View(Customers);
```

For HTML, I used this code. 

```html
    <div class="container">
        <!-- First Row -->
        <div class="row">
            @foreach (var item in Model)
            {
                <!-- This will make a box filled with the information -->
                <div class="col-md-6 detailCon">

                    <!-- Displays the person information -->
                    <h4 class="FullName"> @Html.DisplayFor(modelItem => item.FullName) </h4>
                    <hr />
                    <div class="row">
                        <div class="col-md-4">
                            Preferred Name:
                            <br />
                            Phone:
                            <br />
                            Fax:
                            <br />
                            Email:
                            <br />
                            Member Since:
                        </div>
                        <div class="col-md-4">
                            @Html.DisplayFor(modelItem => item.PreferredName)
                            <br />
                            @Html.DisplayFor(modelItem => item.PhoneNumber)
                            <br />
                            @Html.DisplayFor(modelItem => item.FaxNumber)
                            <br />
                            @Html.DisplayFor(modelItem => item.EmailAddress)
                            <br />
                            @item.ValidFrom.Date.ToString("MM/yyyy")
                        </div>
                    </div>
                </div>
                <!-- Photo placeholder -->
                <div class="col-md-6"> <img src="../../Images/vaultBoy.jpg" alt="Photo" width="220px" height="190px"/></div>
            }
        </div>
        <!-- this will only show if person is a customer -->
        @if (ViewBag.MoreInfo == true)
        {

        <br />
        <div class="row">

            @foreach (var item in Model)
            {
                <!-- This will show the Company information -->
                if (item.CompanyName != null || item.CompanyName != "")
                {
                    <div class="col-md-6 detailCon">

                        <h4 class="FullName"> Company Profile </h4>
                        <hr />

                        <div class="col-md-4">
                            Company:
                            <br />
                            Phone:
                            <br />
                            Fax:
                            <br />
                            Website:
                            <br />
                            Member Since:
                        </div>
                        <div class="col-md-4">
                            @Html.DisplayFor(modelItem => item.CompanyName)
                            <br />
                            @Html.DisplayFor(modelItem => item.CompanyPhone)
                            <br />
                            @Html.DisplayFor(modelItem => item.CompanyFax)
                            <br />
                            @Html.DisplayFor(modelItem => item.CompanyWebsite)
                            <br />
                            @item.CompanyValidFrom.Date.ToString("MM/yyyy")
                        </div>
                    </div>
                }
            }
        </div>
        <br />
        <div class="row">

            @foreach (var item in Model)
            { 
                <!-- This will show the purchase history -->
                if (item.CompanyName != null || item.CompanyName != "")
                {
                    <div class="col-md-6 detailCon">

                        <h4 class="FullName"> Purchase History Summary </h4>
                        <hr />

                        <div class="col-md-4">
                            Orders:
                            <br />
                            Gross Sales:
                            <br />
                            Gross Profit:
                            <br />
                        </div>
                        <div class="col-md-4">
                            @string.Format("{0:C}", item.Orders)
                            <br />
                            @string.Format("{0:C}", item.GrossSales)
                            <br />
                            @string.Format("{0:C}", item.GrossProfit)
                            <br />
                        </div>
                    </div>
                }
            }
        </div>

        <br />
        <div class="row">

                <div class="col-md-6 detailCon">
                    <h4 class="FullName"> Item Purchased (10 Highest by Profit) </h4>
                    <hr />
                    <div class="row">
                        <div class="col-md-4">
                            <!-- This will display the table of top 10 products-->
                            <table class="table">
                                <tr>
                                    <th>
                                        @Html.DisplayNameFor(model => model.ItemPurchaseList.FirstOrDefault().StockItemID)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(model => model.ItemPurchaseList.FirstOrDefault().ItemDescription)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(model => model.ItemPurchaseList.FirstOrDefault().LineProfit)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(model => model.ItemPurchaseList.FirstOrDefault().SalesPerson)
                                    </th>
                                </tr>

                                @foreach (var item in Model.FirstOrDefault().ItemPurchaseList)
                                {
                                 <tr>
                                 <td>
                                    @Html.DisplayFor(modelItem => item.StockItemID)
                                 </td>
                                 <td>
                                    @Html.DisplayFor(modelItem => item.ItemDescription)
                                 </td>
                                 <td>
                                    @string.Format("{0:C}", item.LineProfit)
                                 </td>
                                 <td>
                                    @Html.DisplayFor(modelItem => item.SalesPerson)
                                 </td>
                                    </tr>
                                }
                            </table>
                        </div>
                    </div>
                </div>
        </div>
        <br />
        }
    </div>
```

# 3.) Final Product

<iframe width="560" height="315" src="https://www.youtube.com/embed/xliCUjWNAAk" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>