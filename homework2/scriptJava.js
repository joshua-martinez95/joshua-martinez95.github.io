function introduction(first, last, group){
    var phrase;
    if (group == "None"){
        phrase = "Making their way to the ring, " + first + " " + last;
    }
    else {
        phrase = "Making their way to the ring, representing " + group + ", " + first + " " + last + "!";
    }

    var audio = new Audio('/songs/BC.mp3');
    audio.play();
    document.getElementById("intro").innerHTML = phrase;
    return false;
}

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
    var fNameLet = first.charAt(0);
    var lNameLet = last.charAt(0);
    console.log(fNameLet)
    var fNameLet = fNameLet.toLowerCase();
    var lNameLet = lNameLet.toLowerCase();
    console.log(fNameLet)
    firstpart = alph.indexOf(fNameLet);
    console.log(firstpart)
    firstpart = firstA[firstpart];
    secondpart = alph.indexOf(lNameLet);
    secondpart = secondA[secondpart];
    introduction(firstpart, secondpart, group)
}

function check() {
    var sex, lastN, fact;
    lastN = document.getElementById("lN").value;
    firstN = document.getElementById("fN").value;
    sex = document.querySelector('input[name = "gender"]:checked').value;
    fact = document.getElementById("faction");
    fact = fact.options[fact.selectedIndex].value;
    console.log(lastN)
    console.log(firstN)
    getName(firstN, lastN, sex, fact)
    return false;
}

$(document).ready(function(){
    $("#button").click(function(){
        check()
    });
});