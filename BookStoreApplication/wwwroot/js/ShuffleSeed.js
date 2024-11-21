function shuffleSeed() {
    var inputField = document.getElementById("IntegerInput");
    inputField.value = Math.floor(Math.random() * 1000000000); 
    sendDataToServer();
}