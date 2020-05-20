"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;
var myMap = new Map();
var itemCount = 0;
connection.on("ReceiveSort", function (user, message) {
    myMap.set(user,message);
    for(var i = 1;i<=itemCount;i++){
        var itemMap = new Map();
        for (var [key, value] of myMap) {
          if(value.length == itemCount){
            var c = itemMap.get(value[i-1]);
            if(c == null){
                itemMap.set(value[i-1],1);
            }else{
                itemMap.set(value[i-1],c+1);
            }
          }
        }
        var ctx = document.getElementById( "result_"+i ).getContext('2d');
        var example = new Chart(ctx, {
				// 參數設定[註1]
				type: "bar", // 圖表類型
				data: {
					// 資料設定[註2]
					labels:[ ...itemMap.keys() ], // 標題
					datasets: [{
						// 資料參數設定[註3]
						label: "# "+i+"of Votes", // 標籤
						data: [ ...itemMap.values() ],// 資料,
                        backgroundColor: ["red", "orange", "yellow", "green", "blue", "purple"], 
						borderWidth: 1 // 外框寬度
					}]
				},
options: {
        scales: {
            yAxes: [{
                ticks: {
                    stepSize:1,
                    beginAtZero: true
                }
            }]
        }
    }
			});
    }
    
   //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " says " + message[0];
   // var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("canvas");
    itemCount = itemCount+1;
    li.id = "result_"+itemCount;
    li.height = 50;
    document.getElementById("result").appendChild(li);
});


connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
