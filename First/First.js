let name = prompt("Здраствуйте! Напишmите пожалуйста свое прекрасное имя");
alert("Здраствуйте " + name);


const thisYear = new Date().getFullYear();
let birthday=  Number.parseInt(prompt("Какого года вы рождения"));
let age= thisYear - birthday;
alert("Вам " + age + " лет");



let side1 = Number.parseInt( prompt("Введедите первую сторону квадрата"));
let side2 = Number.parseInt( prompt("Введедите вторую сторону квадрата"));
let summ = (side1*2) + (side2*2);
alert(summ);

let circle = Number.parseInt(prompt("Введите радиус окружности"));
let square = Math.pow(circle,2)*3.14;
alert(square);


let distance = Number.parseInt(prompt("Введите дистанцую которую надо пройти"));
let time = Number.parseInt(prompt("Введите за сколько часов вам надо доехать до место назначения"));
let speed = distance/time;
alert("Скорость, с которым вам надо ехать: " + speed + " метров в секунду")


const dollarToEvro = 0.93;
let dollar = Number.parseFloat(prompt("Введите сумму в долларах"));
let evro= dollar*dollarToEvro;
alert(evro.toFixed(2));

let flashSize = Number.parseInt(prompt("Введите Гб вашей флешки"));
let flashSizeGb = flashSize*1000;
let capacity = flashSizeGb/820;
alert("В вашу флешбку помещается " + capacity.toFixed(0) + " файлов с рамезром 820 Мб");



let moneyAmout = Number.parseFloat(prompt("Введите сумму в вашем кошельке"));
let chocolatePrice = Number.parseFloat(prompt("Введите сумму шоколадки"));
let chocolateQuantity  =   Math.floor(moneyAmout/chocolatePrice);
let delivery =  moneyAmout - (chocolateQuantity * chocolatePrice);
alert("Вы можете купить " + chocolateQuantity.toFixed(0) + " шоколад, у вас останется "+ delivery);

let number = Number.parseInt(prompt("Введите число"));
number%2 !=0 ? alert("Число не четное"): alert("Число  четное");

