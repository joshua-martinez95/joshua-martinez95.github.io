# javascript stuff
var url = window.location.href;
var id = url.substr(url.lastIndexOf('/') + 1);
var source = "Items/Update/" + id;

new contoller with MVC folder
in controller, variable has to be "id" unless asked otherwise

json finding bid
var item = db.Items.Find(id);
var bid = item.Bids.LastOrDefault();
var recent = new
{

}


# when ready to publish
Run a rebuild
Connect the up.sql to the Azure server link in the explorer
Run the up.sql
Publish the project

# links
https://www.w3schools.com/js/js_json_intro.asp
