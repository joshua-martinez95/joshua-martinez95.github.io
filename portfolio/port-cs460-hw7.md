# CS460 Homework 7

# Shortcuts
### [Code Repo](https://github.com/joshua-martinez95/joshua-martinez95.github.io/tree/master/homework7) 
### [Home](../index.md) 
### [CS460 Assignments](portMain-cs460.md) 



# 1.) Setup
The very first step I took to setup was setup a blank MVC web app. But made sure to check the box that added folders and core references for MVC. Then cunstructed a simple Index view and controller.

```html
@{
    ViewBag.Title = "Index";
}
<header></header>
<script>

</script>
<!-- Center everything-->
<div style="text-align: center;">
    <h2>Internet Language Translator</h2>
    <br />
    <!-- Input text box-->
    <input style="width: 100%" type="text" id="textString" name="textString" placeholder="Start typing your message here..." /><br /><br />
    <!-- Where the phrases will be inputedd-->
    <div id="phrase"></div>
    <br />
</div>

@section PageScripts
{
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="~/Scripts/giphyScript.js"></script>
}
```

Since I knew I needed a text box I added an input tag. I also knew we needed to add the @section part that would link to the script I made. An the controller I made was just a blank one.

Lastly I needed to get an API key to connect to giphy. I had to make a dev account with giphy. Then once I had the api key I had to make a .config file 

```html
<appSettings>
    <add key="giphyAPIkey" value="************"/>
</appSettings>

```

And finally I had to edit my web.config file in my project so that the appsettings tag read like.
```html
<appSettings file="..\..\..\AppSettingsSecrets.config">
```

On last step, we will have to setup our database and instal Entity Framework. After doing so, we will have to build a table
```sql
CREATE TABLE [dbo].[RecordsInputs]
(
	[ID] INT IDENTITY(0,1) NOT NULL,
	[Date]		DateTime NOT NULL,
	[Input]		NVARCHAR(120) NOT NULL,
	[IP]		VARCHAR(16) NOT NULL,
	[BrowserAG]	VARCHAR(25) NOT NULL
	CONSTRAINT [PK_dbo.RecordsInputs] PRIMARY KEY CLUSTERED ([ID] ASC)
);
```

Then after this we can use the tools provided to us to make a context file and a model.
# 2.) Code

Now that I have everything set up. It was time to start actually doing some coding. From here i decided to start working on a controller that uses JsonResult instead of an ActionResult. Right off the bat we can start setting some things up for the webRequest we will send giphy. 

```csharp

string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIkey"];
// this will use our apiKey to send a request to giphy, first making a var called website
var website = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + word;
var request = WebRequest.Create(website);
// request a json object
request.ContentType = "application/json; charset=utf-8";
// will save the response in a var
var response = (HttpWebResponse)request.GetResponse();
            
string text;
//  read the response into a string
using (var sr = new StreamReader(response.GetResponseStream()))
    {
        text = sr.ReadToEnd();
        sr.Close();
    }
```
As explained in the comments, we are setting up the request that we will sned giphy. Which will respond with a json object. The last lines of codes read this response into a string. Now we would actually need to parse this, if we have NewtonSoft.Json installed we can do:
```csharp
string fullData = JObject.Parse(text)["data"].ToString();
string embed = JObject.Parse(fullData)["embed_url"].ToString();

var ip = Request.UserHostAddress;
var agent = Request.Browser.Type;
```
This will get the actual line we need to display the gif and store it in a string variable named embed. And we also call to get the ip and user agent.

Now in order to save all the required information in our database:

```csharp
var newRecord = new RecordsInput
{
    Date = DateTime.Now,
    Input = word,
    IP = ip,
    BrowserAG = agent
};
// put new record into table
db.RecordsInputs.Add(newRecord);
db.SaveChanges();
```

In order to get the gif url for the gif that will be posted

```csharp
var data = new
{
    thing = ip + ": " + agent,
    urlGifEm = embed
};
return Json(data, JsonRequestBehavior.AllowGet);
```

We can start working on the javascript that will be used to deteremine when a word is typed and call this json controller. This script will be saved into our javascript folder.

```javascript
$("#textString").keypress(function (e)
```
This is the method we call, which will be called anythime a key is pressed in the textbox.

Now we need to check that the key pressed was a space 

```javascript
    var check = 0;
    /// make input into a value
    var word = $("#textString").val();
    var lastWord;

    /// check console type for space
    if (e.keyCode == 0 || e.keyCode == 32) {
        /// split input words
        check = 2
        var prev_word = word.toString().split(" ");

        /// get last word
        lastWord = prev_word[prev_word.length - 1];
        //$("#phrase").append(" " + lastWord);
        console.log("Last word was this " + lastWord);
        /// compare last word to noun array
        for (i = 0; i < nouns.length; i++) {
            if (lastWord.match(nouns[i])) {
                console.log(lastWord + " is a noun");
                check = 1;
            }
        }
        /// compare last word to verb array
        for (i = 0; i < verbs.length; i++) {
            if (lastWord.match(verbs[i])) {
                console.log(lastWord + " is a verb");
                check = 1;
            }
        }
```

This will check if the key pressed was a space, and if it was it will set a certain flag if that last word typed is in our list of nouns or verbs. If the last word typed was anything else, then it will set another flag. 

Now, we will check which flag is set
```javascript
    // if last word was special
if (check == 1) {

    var source = "/GiphyAPI/Gif/" + lastWord;

// Send an async request to our server, requesting JSON back
$.ajax({
    type: "GET",
    dataType: "json",
    url: source,
    success: displayData,
    error: errorOnAjax
    });
}
/// if last word wasn't in the list
else if (check == 2) {
    $("#phrase").append(lastWord + " ");
}
```
If the last word typed was in the list of nouns and verbs we will use ajax to call our json controller and then call another function in our javascript.
If it was just a regular word, just append this word to the html phrase tag.

That function that gets called upon success of a word being in the list

```javascript
function displayData(data) {
    console.log("the data " + data["thing"]);
    // get string and turn it into a value
    var str = $("#textString").val();
    // split by space
    str = str.trim().split(' ');
    //console.log("The string: " + str + " the length: " + str.length);
    //console.log(data["urlGifEm"]);
    // insert a space
    str[str.length - 1] = " "
    // joing via spaces
    str = str.join(" ");
    // insert gif
    $("#phrase").append("<iframe src='" + data.urlGifEm + "' height='100' width='100'frameBorder='0'>");

}
```

This will get what's in the text box and get the last word and get the url for the gif and add a iframe tag to display this gif.



# 3.) Final Product

Video demo

<iframe width="560" height="315" src="https://www.youtube.com/embed/cngw0JAygp4" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
