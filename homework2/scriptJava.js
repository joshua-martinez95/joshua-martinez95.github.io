/*
This function gets called last to make the changes to the page to show introduction and play music
*/
function introduction(first, last, group){
    var phrase, audio;
    audio = new Audio('songs/NWO.mp3');
    audio.pause();
    if (group == "None"){
        phrase = "Making their way to the ring, " + first + " " + last;
    }
    else {
        phrase = "Making their way to the ring, representing " + group + ", " + first + " " + last + "!";
    }
    // Below we check to see what image and songs will play
    if (group == "Los Ingobernables de Japon") {
        audio = new Audio('songs/Naito.mp3');
        audio.play();
        document.getElementById('logo').src='pictures/lij Logo.png';
    }
    else if (group == "Bullet Club") {
        audio = new Audio('songs/BC.mp3');
        audio.play();
        document.getElementById('logo').src='pictures/BClogo.jpg';
    }
    else if (group == "Chaos") {
        audio = new Audio('songs/Okada.mp3');
        audio.play();
        document.getElementById('logo').src='pictures/chaosLogo.png';
    }
    else if (group == "Suzuki-Gun") {
        audio = new Audio('songs/Suzuki.mp3');
        audio.play();
        document.getElementById('logo').src='pictures/Suzukigun.jpeg';
    }
    else if (group == "The NWO") {
        audio = new Audio('songs/NWO.mp3');
        audio.play();
        document.getElementById('logo').src='pictures/nwoLogo.jpg';
    }
    else if (group == "The Undisputed Era") {
        audio = new Audio('songs/UE.mp3');
        audio.play();
        document.getElementById('logo').src='pictures/UELogo.png';
    }
    else {
        console.log("No Audio")
    }
    document.getElementById("intro").innerHTML = phrase;
    $("#button").click(function(){
        audio.pause();
    });
    
}

/*
This function decides the name for the person pased on gender and names. Also, calls the final function
*/
function getName(first, last, gen, group){
    var firstpart, secondpart;
    if (gen == "male") {
        var firstA= ["Mighty", "Grand", "Primal", "Maverick", "Bad News","Dirk", "Diamond", "Johnny", "Gunner", "Cerebral", "Butch", "Brooklyn", "Outlaw", "Prince", "Bunkhouse", "Titanic", "Bionic", "Doctor", "Freak", "Fusion", "Rocky", "Sundance", "Triple", "King Kong", "Beefy", "Crazy"]
        var secondA= ["Shadow", "Hellfire", "Basher", "Swagger","Spider", "Snake","Hulk", "Viper", "Spike", "Magnum", "Hercules", "Spawn", "Warrior", "Sniper" ,"Tiger", "Swarm", "Champ", "Show", "Ninja", "Executioner", "Tornado", "Cowboy", "Hawk", "Slate", "Assassin", "Tank"]
    }
    else if (gen == "female") {
        var firstA = ["Brooklyn", "Outlaw", "Princess", "Bunkhouse", "Titanic", "Legendary", "The Incredible", "Bulldog", "The Grand", "Roaring", "Venus", "Sonic", "Yorkshire", "Cool", "Ms.", "Sundance", "Triple", "King Kong", "Beefy", "Crazy", "Maverick", "Bad News","Sam", "Diamond", "Jen", "Mercedez"]
        var secondA = ["Spawn", "Warrior", "Sniper" ,"Tiger", "Swarm", "Master", "Machine", "Crunch", "Master", "Power", "Shadow", "Hellfire", "Basher", "Swagger","Spider", "Earthquake", "Monk", "Awesome", "Apocalypse", "Gold", "Flytrap", "Champ", "Show", "Ninja", "Executioner", "Tornado"]
    }
    
    else {
        var firstA = ["Sweet", "King Kong", "Pyscho", "Sir", "Abdullah", "Red Hot", "Stone Cold", "Legendary", "The Incredible", "Bulldog", "The Grand", "Roaring", "Max", "The Iron", "Captin", "The Dark", "Heartbreak", "Doctor", "Sonic", "Yorkshire", "Cool", "Hitman", "Rabid", "X-", "Calamity", "Rocky"]
        var secondA = ["Earthquake", "Monk", "Awesome", "Apocalypse", "Gold", "Legend", "Dragon", "Bullseye", "Bear", "Angel", "Punk", "Angle", "Rock", "Ninja", "Beast", "Brawler", "Rose", "Vicious", "Brute", "Comet", "Roar", "Master", "Machine", "Crunch", "Master", "Power"]
    }
    var alph = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w","x","y","z"]
    //gets first letters from first name and last name
    var fNameLet = first.charAt(0);
    var lNameLet = last.charAt(0);
    var fNameLet = fNameLet.toLowerCase();
    var lNameLet = lNameLet.toLowerCase();
    //get index as key to what names to use
    firstpart = alph.indexOf(fNameLet);
    firstpart = firstA[firstpart];   
    secondpart = alph.indexOf(lNameLet);
    secondpart = secondA[secondpart];
    // call intro function
    introduction(firstpart, secondpart, group)
}

/*
gets values from appropriate fields
*/

function check() {
    var sex, lastN, fact;
    //get names from text field
    lastN = document.getElementById("lN").value;
    firstN = document.getElementById("fN").value;
    // get gender from radio button
    sex = document.querySelector('input[name = "gender"]:checked').value;
    // get value from drop down
    fact = document.getElementById("faction");
    fact = fact.options[fact.selectedIndex].value;
    console.log(lastN)
    console.log(firstN)
    // call getName function
    getName(firstN, lastN, sex, fact)
    return false;
}
/*
On click command
*/
$(document).ready(function(){
    $("#button").click(function(){
        check()
    });
});