"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

document.getElementById("sendBtn").disabled = true;

connection.on("ReceiveMessage", function (userName, content) {
    var table = document.getElementById("messagesTable");
    var row = document.getElementById("messagesTable").insertRow();

    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    cell1.innerHTML = userName;
    cell2.innerHTML = content;
});

connection.start().then(function () {
    document.getElementById("sendBtn").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendBtn").addEventListener("click", function (event) {
    var userName = document.getElementById("userName").value;
    var content = document.getElementById("content").value;
    connection.invoke("SendMessage", userName, content).catch(function (err) {
        return console.error(err.toString());
    });

    post();

    event.preventDefault();
});

function post() {
    var message = {
        UserName: document.getElementById("userName").value,
        Content: document.getElementById("content").value
    };

    $.ajax({
        type: "POST",
        url: "/api/Message/Post",
        data: message
    });

    document.getElementById("userName").value = "";
    document.getElementById("content").value = "";
}