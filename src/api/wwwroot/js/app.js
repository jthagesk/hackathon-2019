function Welcome(person) {
    alert("Hello " + person + ", welcome to the site of your dreams!");
}

function ClickMeButton() {
    var user = "MithunVP";
    document.getElementById("divMsg").innerHTML = Welcome(user);
}
