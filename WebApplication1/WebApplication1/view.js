function getInputValues() {
    const num1 = document.getElementById("number1").value;
    const num2 = document.getElementById("number2").value;
    const op = document.getElementById("operator").value;
    return [Number(num1), Number(num2), op];
}

function setResult(value) {
    document.getElementById("result").innerText = "결과: " + value;
}

function bindCalculateButton(callback) {
    document.getElementById("calculateBtn").addEventListener("click", callback);
}