document.getElementById("submitButton").addEventListener("click", function (event) {
    var Email = document.getElementById("emailInput").value;
    var Password = document.getElementById("passwordInput").value;

    var settings = {
        "url": "http://localhost:5000/api/auth/signin",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            Email, Password
        }),
    };

    $.ajax(settings).done(response => {
        window.location.href = "/chat";
    });

    event.preventDefault();
});