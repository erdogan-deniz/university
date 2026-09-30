$(document).ready(function () {
    var password = document.getElementById("pass");
    var password2 = document.getElementById("pass2");

    function comparePassword() {
        if (password.value != password2.value) {
            password2.setCustomValidity("Пароли не совпадают!");
        }
        else
        {
            password2.setCustomValidity("");
        }
    }
password.onchange=comparePassword;
password2.onkeyup=comparePassword;
})