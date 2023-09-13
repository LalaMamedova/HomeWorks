// let num1 = Number.parseInt(prompt("Введите первое число из диапазона"));
// let num2 = Number.parseInt(prompt("Введите второе число из диапазона"));
// let sum=0;
// for (let i = num1; i < num2; i++) {
//     sum=+i;
// }
// alert("Summ is "+sum);


// let nod1 = Number.parseInt(prompt("Введите первое число"));
// let nod2 =  Number.parseInt(prompt("Введите второе число"));
// function NOD (x, y) {
//     if (y > x) return NOD(y, x);
//     if (!y) return x;
//     return NOD(y, x % y);
// }
//
// alert(NOD(nod1,nod2));


// let  userNum = prompt('Введите число');
// let dividers = [];
// for (let i = 2; i * 2 <= userNum; i++) {
//     if (userNum % i == 0) {
//         dividers.push(i);
//         dividers.push(' ');
//     }
// }
// alert(dividers);


// let userNumber = prompt("Введите любое длинное число");
// alert(userNumber.length);


// let even = 0;
// let odd = 0;
// let negative = 0;
// let  positive =0;
// let tenNums = 0;
// for (let i = 0; i < 4; i++) {
//     tenNums = Number.parseInt(prompt(`Вводите любое ${i+1} число`));
//
//     if(tenNums%2 === 0){
//         even++;
//     } if(tenNums % 2!= 0){
//         odd++;
//     } if(tenNums > 0){
//         positive++;
//     } if(tenNums < 0){
//         negative++;
//     }
//
// }
//
// alert('Итого вы ввели \n' +
//     'Положительных ' + positive +'\n' +
//     'Отрицательных ' + negative +'\n' +
//     'Нечетных ' + odd +'\n' +
//     'Четных ' + even +'\n')


// while (true){
//
//     let calcNum1 = Number.parseInt(prompt(`Вводите первое число`));
//     let calcNum2 = Number.parseInt(prompt(`Вводите второе число`));
//     let symbChoice =  Number.parseInt(prompt("Какой знак хотите выбрать?" +
//         "\n1.+" +
//         "\n2.-" +
//         "\n3.-*" +
//         "\n4./"));
//
//     switch (symbChoice){
//         case 1:
//             alert(calcNum1 + calcNum2);
//             break;
//         case 2:
//             alert(calcNum1 - calcNum2);
//             break;
//         case 3:
//             alert(calcNum1 * calcNum2);
//             break;
//         case 4:
//             alert(calcNum1 / calcNum2);
//             break;
//     }
//
//     let stopOrNot = confirm("Хотите остановить?");
//     if(!stopOrNot)
//         break;
// }

// const inputNumber = prompt("Введите число:");
// const shiftAmount = parseInt(prompt("На сколько цифр сдвинуть число:"));
//
// if (!isNaN(inputNumber) && !isNaN(shiftAmount)) {
//     const numberStr = inputNumber.toString();
//
//     const shiftedNumberStr = numberStr.slice(shiftAmount) + numberStr.slice(0, shiftAmount);
//
//     alert(`Исходное число: ${inputNumber}`);
//     alert(`Сдвинутое число: ${parseInt(shiftedNumberStr)}`);
// } else {
//     alert("Пожалуйста, введите корректные числовые значения.");
// }


// let dayOfWeek = ["Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"];
// let currentIndex = 0;
//
// while (true) {
//     alert(`День недели: ${dayOfWeek[currentIndex]}`);
//     const wantNextDay = confirm("Хотите увидеть следующий день?");
//     if (!wantNextDay) {
//         break;
//     }
//     currentIndex = (currentIndex + 1) % 7;
// }

let min = 0;
let max = 100;
let guess= prompt("Загадайте число от 0 до 100, а я попробую его угадать.");

while (true) {
    guess = Math.floor((min + max) / 2);

    const userInput = prompt(`Ваше число > ${guess}, < ${guess} или == ${guess}? (Введите >, < или ==)`);

    if (userInput === ">") {
        min = guess + 1; // Уменьшаем диапазон
    } else if (userInput === "<") {
        max = guess - 1; // Увеличиваем диапазон
    } else if (userInput === "==") {
        alert(`Я угадал ваше число! Оно равно ${guess}.`);
        break; // Выход из цикла при правильном ответе
    } else {
        alert("Пожалуйста, введите >, < или ==.");
    }

    if (min > max) {
        alert("Что-то пошло не так. Вы, возможно, допустили ошибку в ответах.");
        break;
    }
}
