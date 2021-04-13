
var mail = document.getElementById("email").value;
var regex = /\S+@\S+\.\S+/;
function validate() {

    var mail = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var regex = /\S+@\S+\.\S+/;


    if (mail == "" || regex.test(mail) == false) {

        alert("Please enter/format your email correctly.");
        return false;
    }

    if (password == "") {
        alert("Please enter your password.")
        return false;
    }
    alert("You have logged in.")
    return true;
}
console.log(regex.test(mail));