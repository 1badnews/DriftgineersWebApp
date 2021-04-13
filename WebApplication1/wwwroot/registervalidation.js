function validate() {

    var name = document.getElementById("name").value;
    var surname = document.getElementById("surname").value;
    var mail = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var regex = /\S+@\S+\.\S+/;
    var pswregex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
    var nameregex = /[a-zA-Z]+/;

    if (name == "" || nameregex.test(name) == false || name.length < 2) {
        alert("Please enter/format your name correctly.");
        return false;
    }

    if (surname == "" || nameregex.test(surname) == false || surname.length < 2) {
        alert("Please enter/format your surname correctly.");
        return false;
    }

    if (mail == "" || regex.test(mail) == false) {

        alert("Please enter/format your email correctly.");
        return false;
    }

    if (password == "") {
        alert("Please enter your password.");
        return false;
    }
    if (pswregex.test(password) == false) {
        alert("Password must contain 8 characters, one uppercase letter, one lowercase letter and one number.");
        return false;
    }
    alert("You have successfully registered.")
    return true;
}
