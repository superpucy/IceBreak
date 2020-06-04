"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ynHub").build();

//Disable send button until connection is established
document.getElementById("createRoom").disabled = true;

connection.on("ReceiveYNRoomId", function (roomId) {
    var li = document.createElement("li");
    li.textContent = roomId;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("createRoom").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("createRoom").addEventListener("click", function (event) {
    connection.invoke("CreateYNRoom").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});