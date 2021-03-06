﻿"use strict";

var connectionUrl = "http://localhost:5000/chatHub";

var connection = new signalR.HubConnectionBuilder().withUrl(connectionUrl).build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveConnID", function (connid) {
    document.getElementById("connIDLabel").innerHTML = "ConnID: " + connid;
})

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var to = document.getElementById("toInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, to, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});