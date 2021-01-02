document.getElementById("submitButton").addEventListener("click", function (event) {
    var FirstName = document.getElementById("firstNameInput").value;
    var LastName = document.getElementById("lastNameInput").value;
    var Email = document.getElementById("emailInput").value;
    var PhoneNumber = document.getElementById("phoneNumberInput").value;
    var Role = document.getElementById("roleInput").value;
    var Password = document.getElementById("passwordInput").value;
    var ConfirmPassword = document.getElementById("confirmPasswordInput").value;

    var settings = {
        "url": "http://localhost:5000/api/auth/signup",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            FirstName, LastName, Email, PhoneNumber, Role, Password, ConfirmPassword
        }),
    };

    $.ajax(settings).done(response => {
        window.location.href = "/auth/signin";
    });

    event.preventDefault();
});