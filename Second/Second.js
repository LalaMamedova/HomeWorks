// 1. Запросить у пользователя его возраст и определить, кем он
// является: ребенком (0–2), подростком (12–18), взрослым (18_60) или пенсионером (60– ...).

let age = Number.parseInt(prompt("Введите свой возраст"));
if(age > 0 && age < 3){
    alert("You just a baby");
} else if(age >=12 && age < 18){
    alert("How u fellow, kiddo");
}else if( age >=18 && age<=60){
    alert("Go to work");
} else if(age > 60){
    alert("Wow, you are an old (wo)man");
}


// 2. Запросить у пользователя число от 0 до 9 и вывести ему спецсимвол, который расположен на этой клавише (1–!,2–@, 3–# и т. д).

let number = Number.parseInt(prompt("Введите от 0 до 9"));
const numberToFontSymbol = {
    0: '0',
    1: '!',
    2: '"',
    3: '#',
    4: '$',
    5: '%',
    6: '&',
    7: "'",
    8: '(',
    9: ')'
};
if(number<10) {
    alert(numberToFontSymbol[number])
}
// 3. Запросить у пользователя трехзначное и число и проверить, есть ли в нем одинаковые цифры.
let threeDigitNum = Number.parseInt(prompt("Введите трехзначное число"));
const ones = threeDigitNum % 10;
const tens = Math.floor((threeDigitNum % 100) / 10);
const hundreds = Math.floor(threeDigitNum / 100);

if (ones === tens || tens === hundreds || ones === hundreds) {
   alert("Есть 2 одинаковых цифр");
} else{
    alert("Нет одинаковых цифр");
}

////4. Запросить у пользователя год и проверить, високосный онили нет. Високосный год либо кратен 400, либо кратен 4 и при этом не кратен 100.

let  year = Number.parseInt(prompt("Любой год"));
if(year % 400== 0 || year % 4==0 && year % 100 !=0){
    alert("Высокосный");
} else{
    alert("Невсокосный");
}


// 5. Запросить у пользователя пятиразрядное число и определить, является ли оно палиндромом.
const inputNumber = prompt("Введите пятиразрядное число:");
if (inputNumber.length === 5) {
    const digits = inputNumber.split("");
    if (
        digits[0] === digits[4] &&
        digits[1] === digits[3]
    ) {
        alert("Введенное число является палиндромом.");
    } else {
        alert("Введенное число не является палиндромом.");
    }
} else {
    alert("Введите корректное пятиразрядное число.");
}


// 6. Написать конвертор валют. Пользователь вводит количество USD, выбирает, в какую валюту хочет перевести: EUR,
// UAN или AZN, и получает в ответ соответствующую сумму.

let dollar = Number.parseFloat(prompt("Введите доллары"));
const euroToDollar = 0.93;
const uanToDollar = 36.95;
const aznToDollar = 1.70;
let valute =Number.parseInt(prompt("Во что вы хотите конвертировать доллары?" +
    "\n1.Евро" +
    "\n2.Гривни" +
    "\n3.Манаты"));
switch (valute){
    case 1:{
        alert(dollar*euroToDollar);
        break;
    }case 2:{
        alert(dollar*uanToDollar);
        break;
    }case 3:{
        alert(dollar*aznToDollar);
        break;
    }
}

// 7. Запросить у пользователя сумму покупки и вывести сумму к оплате со скидкой: от 200 до 300 – скидка будет 3%,
// от 300 до 500 – 5%, от 500 и выше – 7%.

let summ = Number.parseFloat(prompt("Введите сумму покупки"));
let discount = null;

if(summ>=200 && summ<=300){
    discount = summ *3 /100;

} else if(summ>=300 && summ<=500){
    discount = summ *5 /100;

} else if(summ > 500){
    discount = summ *7 /100;
}
summ -= discount;
alert(summ);

// 8. Запросить у пользователя длину окружности и периметр квадрата. Определить, может ли такая окружность поместиться в указанный квадрат.
const circumferenceLength = parseFloat(prompt("Введите длину окружности:"));
const squarePerimeter = parseFloat(prompt("Введите периметр квадрата:"));

if (!isNaN(circumferenceLength) && circumferenceLength <= squarePerimeter) {
    alert("Окружность может поместиться в указанный квадрат.");
} else {
    alert("Окружность не может поместиться в указанный квадрат.");
}


// 9. Задать пользователю 3 вопроса, в каждом вопросе по 3 варианта ответа. За каждый правильный ответ начисляется 2
// балла. После вопросов выведите пользователю количество  набранных баллов.

const questions = [
    {
        question: "Какая столица Франции?",
        options: ["Лондон", "Париж", "Рим"],
        correctAnswer: "Париж"
    },
    {
        question: "Какой год был основании Google?",
        options: ["2000", "1998", "2004"],
        correctAnswer: "1998"
    },
    {
        question: "Сколько планет в Солнечной системе?",
        options: ["8", "9", "10"],
        correctAnswer: "8"
    }
];

let score = 0;

for (let i = 0; i < questions.length; i++) {
    const userAnswer = prompt(questions[i].question + "\n" + questions[i].options.join("\n"));
    if (userAnswer === questions[i].correctAnswer) {
        score += 2; // За каждый правильный ответ начисляется 2 балла
    }
}

alert("Вы набрали " + score + " баллов из " + (questions.length * 2));


// 10. Запросить дату (день, месяц, год) и вывести следующую  за ней дату. Учтите возможность перехода на следующий
// месяц, год, а также високосный год.

let userDate = prompt("Введите год/месяц/день");
let today = new Date(userDate)
let tomorrow = new Date(today)
tomorrow.setDate(today.getDate() + 1)
alert("Tomorrow is "+ tomorrow.toDateString())

