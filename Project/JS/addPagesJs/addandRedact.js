const inputName = document.querySelector("#input-name");
const inputDescription = document.querySelector("#input-description");
const firstFact = document.querySelector("#input-fact");
const inputDate = document.querySelector("#input-date");
const inputType = document.querySelector('#input-type');

const techName = document.querySelector("#tech-name");
const techDate = document.querySelector("#tech-date");
const techDescription = document.querySelector("#tech-description");
const techType = document.querySelector("#tech-type");
const fact = document.querySelector('#one-fact-in-temp');
const techId = document.querySelector('#tech-id');
const modebtn = document.querySelector('#mode-btn');
var techArr = [];
let isDarkMode = false;

function setDarkMode(){
   if(isDarkMode === false){
    isDarkMode = true;
   }
   else{
    isDarkMode = false;
   }
}
window.onload = function() {
    let DarkMode = localStorage.getItem('mode') === 'true'? true:false;
    isDarkMode= DarkMode;

    changeMode(DarkMode);
    // fromLocaleStorage();
};
modebtn.addEventListener('click',()=>{
    setDarkMode();
    changeMode(isDarkMode);
    localStorage.setItem('mode',isDarkMode);
});

function changeMode(isDarkMode){
    if(isDarkMode === true){
        document.body.style.background = 'black';
        modebtn.querySelector('i').className = 'fa fa-moon-o';
        document.querySelector('.tech-temp' ).style.background = '#182945';
        document.querySelector('.main-header-div' ).style.filter = 'brightness(60%)';
        changeColorAllElement('h1',"white");
    }else{
        modebtn.querySelector('i').className = 'fa fa-sun-o';
        document.body.style.background = "linear-gradient(285deg, #34eeff, #ff269d)";
        document.querySelector('.tech-temp' ).style.background = "linear-gradient(285deg, #1e3cff, #ff1f75)";
        document.querySelector('.main-header-div' ).style.filter = 'brightness(100%)';
        changeColorAllElement('h1',"black");
    }
}

function changeColorAllElement(param,color){
    document.querySelectorAll(`${param}`).forEach(element=>{
        element.style.color = color;
    });
}

function defautValue(){
   
    if (techName.textContent.length === 0) {
        techName.textContent = "Старая техника";
    }if (techDate.textContent.length === 0) {
        techDate.textContent = "1700";
    }if (techDescription.textContent.length === 0) {
        techDescription.textContent = "Очень приочень длинное описание старой техники";
    }if(firstFact.textContent.length === 0){
        fact.textContent = 'Some Interesting fact';
    }
    techType.textContent = 'Computer';
    techId.textContent = generateUID();

}; defautValue();
techId.addEventListener('click',()=>{techId.textContent = generateUID();});

inputName.addEventListener("input", ()=> {
    inputValue(inputName,techName,"Старая техника",inputName.value);});
inputDate.addEventListener("input", ()=> {
    inputValue(inputDate,techDate,"1700",inputDate.value);});
inputDescription.addEventListener("input",()=> {
    inputValue(inputDescription,techDescription,"Очень при-очень длинное описание старой техники",inputDescription.value);});
inputType.addEventListener('click',()=>{
    inputValue(inputType,techType,"Computer",inputType.value);});


function inputValue(input,temliElement,defaultText, value,){
    
    if (input.value.length == 0) {
        temliElement.textContent = defaultText;
    }
    else{
        temliElement.textContent = value;
    }
}

const submit = document.querySelector('#confirm-btn');

submit.addEventListener('click', () => {
    const allcharName = document.querySelectorAll('#input-tech-char-name');
    const allcharValue = document.querySelectorAll('#input-tech-char-value');
    const allImgInputs = document.querySelectorAll('#input-img');
    const allFactsInputs = document.querySelectorAll('#input-fact');
    const allInputs = [inputName, inputDate, inputDescription, inputType,...allImgInputs,...allFactsInputs,...allcharName,...allcharValue, ];
    let isEmpty = false;

    const retroTech = {
        id :generateUID(),
        name: "",
        year: "",
        description: "",
        type: "",
        images: [],
        interestingfacts: [],
        charname: [],
        charvalue: [],
    };
      
    for(let i= 0,inputCount = 1; i< allInputs.length; i++,inputCount++)
    {
        let inputField = allInputs[i].id.replace('input-', '').replace('tech-', '');
        if(!isNullOrEmpty(allInputs[i])){
            if(inputField === 'fact' || inputField ==='img' || inputField ==='char-name' || inputField==='char-value') {
                let prevField = inputField;
                while(prevField === inputField){
                    
                    retroTech[Object.keys(retroTech)[inputCount]].push(allInputs[i].value);
                    i++;
                    
                    if(i < allInputs.length){ inputField = allInputs[i].id.replace('input-', '').replace('tech-', '');}
                    else{break; }
                }
                i--;
            } else{
                retroTech[Object.keys(retroTech)[inputCount]] = allInputs[i].value;
            }
        } else{
            isEmpty = true;
        }
    }
    
    if(isEmpty === false){
        post(retroTech);
    }else{
        alert('Fill the empty place please');
    }
  
});

function isNullOrEmpty(input) {
    return !input || input.value.trim() === '';
}

function generateUID() {
    var firstPart = (Math.random() * 46656) | 0;
    var secondPart = (Math.random() * 46656) | 0;
    return firstPart + secondPart;
}

async function post(data){
    const url = 'https://localhost:7189/technologies';
    fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      })
        .then(response => response.json()) 
        .then(data => {
          console.log('Ответ от сервера:', data);
          alert('Карточка удачно сохранена');
        })
        .catch(error => {
          console.error('Ошибка:', error);
          
        });
}