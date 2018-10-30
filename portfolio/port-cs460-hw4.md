# CS460 Homework 4

# Shortcuts
### [Code Repo](https://github.com/joshua-martinez95/joshua-martinez95.github.io/tree/master/homework4) 
### [Home](../index.md) 
### [CS460 Assignments](portMain-cs460.md) 



# 1.) Setup
First I decided to start a new ASP.Net projct on Visual Studio.
Then I laid down the ground work on the index page

```
<div class="jumbotron">
    <h1>CS 460 Homework 4</h1>
    <p class="lead">A few forms and some simple server-side logic - learning the basics of GET, POST, query strings,
     form data and handling it all from an ASP.NET MVC 5 application.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Mile to Metric Converter</h2>
        <p>
            Want to Know how many millimeters there are in 26.2 miles? This calculator is for you. Uses query strings
            to send form data to the server, which performs the calculation and returns the answer in the requested page.
        </p>
        <p><a class="btn btn-primary" @Html.ActionLink("Try it out", "Converter", "Home")></a></p>
    </div>
    <div class="col-md-4">
        <h2>Color Chooser</h2>
        <p>Typical online color choosers are way too useful. We wanted something fun 
            and copmletely useless. This form POST's the date to the server.</p>
        <p><a class="btn btn-primary" @Html.ActionLink("Check it out", "ColorChooser", "Home")></a></p>
    </div>
</div>
```

Then I made two diffrent branches

```
git checkout -b homework4Branch
git checkout -b homework4Color
```



# 2.) Code

After this I made sure to first work on the converter, so I had to use that branch

```
git checkout homework4Branch
```

I had to work on the cshtml file first, using the razor code
```
@{
    ViewBag.Title = "Convert";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```
Then laying out the html, was pretty easy. Thanks to previous experience with html. The part I had somewhat of a trobule with was using the ViewBag functions

```
<div class="col-md-6" style="color: darkred;">
    @if (ViewBag.statement != null)
    {
        <h2>@ViewBag.statement</h2>
    }
</div>
```

Then working on the controller. This came fairly easy since I know a little bit of C#.
Some stuff I found challenge was getting information from the cshtml files. But I was able to do so:
```
//get input form the text box
string input = Request.QueryString["miles"];
// get the units from the radio button
string unitMetric = Request.QueryString["units"];
```

I decided to use a case function to check what metrics units was used.
```
if(input != null && input != "" && qError == false)
{
    // convert the input string into a double
    result = Convert.ToDouble(input);

    // switch case to do the math
    switch (unitMetric)
    {
    case "millimeters":
    result = result * 1609344;
    break;
    case "centimeters":
    result = result * 160934.4;
    break;
    case "meters":
    result = result * 1609.344;
    break;
    case "kilometers":
    result = result * 1.609344;
    break;
    default:
    qError = true;
    result = 0;
    break;
}
```

After setting the ViewBag.statement to the appropriate stirng. It was time to work on the colorchooser.
After switch to the homework4Color branch. I made a new folder called color and a new controller.

For the HttpPost I got the information put into the text boxes by using this code: 

```
Color leftColor = ColorTranslator.FromHtml(priColor);
Color rightColor = ColorTranslator.FromHtml(secColor);
```

In order to mix the colors
```
// initializing combo values
int aCombo = leftColor.A + rightColor.A;
int rCombo = leftColor.R + rightColor.R;
int gCombo = leftColor.G + rightColor.G;
int bCombo = leftColor.B + rightColor.B;
// Do checking for Alpha overflow
if (aCombo > 1)
    aCombo = 1;

// Do checking for Red overflow
if (rCombo > 255)
    rCombo = 255;

// Do checking for Green overflow
if (gCombo > 255)
    gCombo = 255;

// Do checking for Blue overflow
if (bCombo > 255)
    bCombo = 255;
                
// get the mixed color
    Color mixedColor = Color.FromArgb(aCombo, rCombo, gCombo, bCombo);
```
After making these into colors, I decided to work on the cshtml file

Using razor
```
@{
    /// mesages for the Title and Message
    ViewBag.Title = "Create a New Color";
    ViewBag.Message = "Please enter colors in HTML hexadecimal format: #AABBCC";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```
Only thing that was somewhat hard to use is setting the textboxes

```
<h5><b> First Color </b></h5>
@Html.TextBox("priColor", null, htmlAttributes: new { @class = "form-control", placeholder = "#000000", required = "required", pattern = "#[0-9a-fA-F]{6}" })

<h5><b> Second Color </b></h5>
@Html.TextBox("secColor", null, htmlAttributes: new { @class = "form-control",  placeholder = "#000000", required = "required", pattern = "#[0-9a-fA-F]{6}" })
```

# 3.) Final Touches
Link to video:

https://youtu.be/hhzP3ziEyfw