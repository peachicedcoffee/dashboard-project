function calculate(a, b, op) {
    switch(op){
        case "+":
            return a+b;
        case "-":
            return a-b;
        case "*":
            return a*b;
        case "/":
            return b !== 0 ? a/b : "0으로 나눌 수 없습니다!";
        default:
            return "잘못된 연산자입니다.";
    }
}

function onCalculate() {
    const [num1, num2, op]=getInputValues();

    if(isNaN(num1) || isNaN(num2))
    {
        setResult("숫자를 정확히 입력하세요.");
        return;
    }

    const result = calculate(num1,num2,op);
    setResult(result);
}

window.onload = function(){
    bindCalculateButton(onCalculate);
}