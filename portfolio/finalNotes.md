create up script
scaffold context
scaffold crud
create javascript
    setting up passing from jquery to controller back to jquery to controller via json/ajax


# javascript stuff

script will pass data to controller via ajax
Controller will pass a json object back


var url = window.location.href;
var id = url.substr(url.lastIndexOf('/') + 1);
var source = "Items/Update/" + id;

new contoller with MVC folder
in controller, variable has to be "id" unless asked otherwise

#json finding bid
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

### links
https://www.w3schools.com/js/js_json_intro.asp

# Razor
https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-2.1

# jquery
https://oscarotero.com/jquery/

# dot notation
https://msdn.microsoft.com/en-us/library/bb394939.aspx

### Git

##### Configure User Info
Configure user information for all local repositories

| Command | Description     |
| :------------- | :------------- |
| ```git config --global user.name "[name]"```    | Set the global username       |
| ```git config --global user.emial "[email address]"```   | Set the global email address |

##### Creating Repositories
Start a new repository or obtain existing repository

| Command | Description     |
| :------------- | :------------- |
| ```git init [project-name]```       | Create a new local repository        |
| ```git clone [url]```   | Clone the repository from url  |

##### Making Changes
Review edits and craft a commit

| Command | Description     |
| :------------- | :------------- |
| ```git status```       | List all new or modified files        |
| ```git diff```   | Shows file differences not yet staged  |
| ```git add [file]```   | Add the file use "." to add all files  |
| ```git diff --staged```   | Shows file differences between staging and the last file version  |
| ```git reset [file]```   | Unstages the file, but preserves it's contents  |
|	```git commit -m "[descriptive message]"```   | Records file snapshot and adds it in version history  |

##### Branches
Create and combine branches

| Command | Description     |
| :------------- | :------------- |
|	```git branch```   | List all local branches in current repository   |
| ```git branch [branch-name]```    | Create a new branch       |
| ```git checkout [branch-name]```   | Switches to the specified branch and updates working directory |
| ```git merge [branch]```  | Merges specified branch with current branch   |
| ```git branch -d [branch]```  | Deletes the specified branch  |

[Git Merge](https://stackoverflow.com/questions/5601931/best-and-safest-way-to-merge-a-git-branch-into-master)  
[Git Merge w/ Conflicts](https://help.github.com/articles/resolving-a-merge-conflict-using-the-command-line/)  
[W3Schools - Razor](https://www.w3schools.com/ASP/webpages_razor.asp)  
[W3Schools - Javascript](https://www.w3schools.com/js/default.asp)  
[W3Schools - HTML](https://www.w3schools.com/html/default.asp)  
[Microsoft - Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-2.1)  
[JQuery Cheat Sheet](https://oscarotero.com/jquery/)  
[Scot's Azure DB Video](http://www.wou.edu/~morses/classes/cs46x/lecture/Videos.html)  