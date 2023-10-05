const inputName = document.querySelector("#input-name");
const inputDescription = document.querySelector("#input-description");
const firstFact = document.querySelector("#input-fact");
const inputDate = document.querySelector("#input-date");
const inputType = document.querySelector('#input-type');
const firstImg = document.querySelectorAll('#input-img');

const techName = document.querySelector("#tech-name");
const techDate = document.querySelector("#tech-date");
const techDescription = document.querySelector("#tech-description");
const techType = document.querySelector("#tech-type");
const fact = document.querySelector('#one-fact-in-temp');
const techId = document.querySelector('#tech-id');
const modebtn = document.querySelector('#mode-btn');
const submit = document.querySelector('#confirm-btn');

let isDarkMode = true;
let retroTech = {
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
  
window.onload = function() {
    if(sessionStorage.getItem('editData')){
        fromEditData(checkEditFile());
    }
    isDarkMode = localStorage.getItem('mode') === 'true'? true:false;
    changeMode(isDarkMode);
};

function checkEditFile(){
    const tempData = sessionStorage.getItem('editData');
    let techInfo = JSON.parse(tempData);
    retroTech = techInfo;
    return techInfo;
}

function fromEditData(techInfo){ 
    console.log(techInfo);
    techId.textContent = techInfo.id;
    inputName.value = techInfo.name;
    inputDate.value = techInfo.year;
    inputDescription.value = techInfo.description;
    inputType.value = techInfo.type;
    fact.value = techInfo.interestingfacts[0];     
    
    rewriteDiv('.add-img', `<h1>Tech Images</h1>`);
    for(let i = 0; i< techInfo.images.length; i++){
        document.querySelector('.add-img').innerHTML +=
        `<div id="add-img-box" class="add-box" >
            <input type="text" id="input-img" value="${techInfo.images[i]}" placeholder="Введите URL">
        </div>`;

        document.querySelectorAll('.tech-img')[i].src = techInfo.images[i];
    }
  
   
    rewriteDiv('.add-fact-div', `<h1>Interesting Facts</h1>`);
    for(let i = 0; i< techInfo.interestingfacts.length; i++){
        document.querySelector('.add-fact-div').innerHTML +=
        `<div id="fact-div"  class="add-box">
            <input type="text" value="${techInfo.interestingfacts[i]}" id="input-fact">
        </div>`;
    }

    let techChar = document.querySelector('.all-tech-char-div');
    techChar.innerHTML ='';
    for(let i = 0; i< techInfo.charname.length; i++){
        techChar.innerHTML +=
        `<div class="characteristic-input">
            <input type="text" value="${techInfo.charname[i]}" id="input-tech-char-name" placeholder="Название характеристики:">
            <input type="text" value="${techInfo.charvalue[i]}" id="input-tech-char-value" placeholder="Значение характеристики:">   
        </div>`;
    }

}
document.querySelector('.add-img').addEventListener('click',(event)=>{
    const target = event.target;
    if (target.id === 'input-img'){
        document.querySelectorAll('#input-img').forEach((imgInput,index) => {
            imgInput.addEventListener('input', (event) => {
                const inputImgValue = event.target.value;
                updateImageAtIndex(inputImgValue, index);
            });
        });
    }
});



function updateImageAtIndex(newImageUrl, index) {
    
    const defaultImgPath = 'https://avatars.dzeninfra.ru/get-zen_doc/3137181/pub_622c93eaa228967ff2d727e7_622c94198ae1c12db1140183/scale_1200';
    const allCaruselImg = document.querySelectorAll(".tech-img");
    if (allCaruselImg[index]) {
        if (allCaruselImg[index].src != newImageUrl) {

            if(newImageUrl != ""){
                allCaruselImg[index].src = newImageUrl;

             }else{
                allCaruselImg[index].src = defaultImgPath;
            }
            allCaruselImg[index].alt = 'GFG';
        } 
    }
}
function rewriteDiv(divClass,divH1){
    let mainDiv = document.querySelector(`${divClass}`);
    mainDiv.innerHTML = '';
    mainDiv.innerHTML += divH1;
}
modebtn.addEventListener('click',()=>{
    if(isDarkMode === false){isDarkMode = true;} else{isDarkMode = false;}
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
    }techType.textContent = 'Computer';
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


function inputValue(input,liElement,defaultText, value,){
    
    if (input.value.length == 0) {
        liElement.textContent = defaultText;
    }else{liElement.textContent = value;}
}

submit.addEventListener('click', () => {
    const allcharName = document.querySelectorAll('#input-tech-char-name');
    const allcharValue = document.querySelectorAll('#input-tech-char-value');
    const allImgInputs = document.querySelectorAll('#input-img');
    const allFactsInputs = document.querySelectorAll('#input-fact');
    const allInputs = [inputName,inputDescription, inputDate, inputType,...allImgInputs,...allFactsInputs,...allcharName,...allcharValue, ];
    let isEmpty = false;

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
    
    if(isEmpty === false && sessionStorage.getItem('editData') === null){
        post(retroTech);
    }else if(isEmpty === false && sessionStorage.getItem('editData') != null){
        put(retroTech.id, retroTech);
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
    await fetch('https://localhost:7189/technologies', {
        method: 'POST',
        headers: {'Content-Type': 'application/json',},
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

async function put(id,data){
    await fetch( `https://localhost:7189/technologies/${id}`, {
        method: 'PUT',
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify(data),
      })
        .then(response => response.json()) 
        .then(data => {
          console.log('Ответ от сервера:', data);
          alert('Карточка удачно изменена');
        })
        .catch(error => {
          console.error('Ошибка:', error); 
    });
}