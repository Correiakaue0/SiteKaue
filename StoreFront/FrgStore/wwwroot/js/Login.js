


function Validate() {
    var alert = document.getElementById("alertaLogin");
    var u = document.getElementById("email").value;
    var p = document.getElementById("password").value;
    var alertLoginIncorreto = document.getElementById("alertaLoginIncorreto");

    if (u == "" && p == "") {
        setTimeout(function () {
            alert.style.display = "none";
        }, 2500);
        alert.style.display = "block";
        return false;
    }

    $.ajax({
        url: 'https://localhost:5001/Usuario/login?email='+u+'&senha='+p,
        type: 'GET',
        dataType: 'json',
        error: function (err) {
            alertLoginIncorreto.style.display = "block";
            alertLoginIncorreto.innerHTML = err.responseText;
        },
        success: function (data) {
            window.location.assign("Home/Carrossel");
        }

    });
}