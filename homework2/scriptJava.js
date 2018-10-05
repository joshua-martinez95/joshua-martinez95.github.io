function check() {
    var sex, lastN;
    lastN = document.getElementById("lN").value;
    firstN = document.getElementById("fN").value;
    sex = document.querySelector('input[name = "gender"]:checked').value;
    alert(lastN + firstN+sex);
}