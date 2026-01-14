"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationUserHub?userId=" + userId).build();
connection.on("ReceiveNotification", (message) => {
    toastr.success(message);
});
connection.start().catch(err => console.error(err.toString()))
    .then(function () {
        connection.invoke("GetConnectionId").then(function (connectionId) {
            document.getElementById("signalRconnectionId").innerHTML = connectionId;
        })
    });
        
