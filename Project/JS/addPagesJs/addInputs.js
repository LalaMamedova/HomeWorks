const fact = document.querySelector('#one-fact-in-temp');
const factsContainer = document.querySelector(".add-fact-div");
const addFactsButton = document.getElementById("add-fact-button");
const firstFact = document.querySelector("#input-fact");
const addImgsButton = document.getElementById("add-img-char-button");
const imgContainer = document.querySelector(".add-img");
var allImgInputs = imgContainer.querySelectorAll('#input-img');
var prevInput = null;

if(firstFact!=null){

    firstFact.addEventListener('input',()=>{
        if(firstFact.value!=''){
            fact.textContent = firstFact.value;
        }else{
            fact.textContent = 'Some Interesting fact'
        }
    });
}

addFactsButton.addEventListener("click", function() {
    var newFactDiv = document.createElement("div");
    newFactDiv.className = "add-box";
    newFactDiv.style.marginTop = '15px';

    var input = document.createElement("input");
    input.type = "text";
    input.id = "input-fact";

    newFactDiv.appendChild(input);

    if(prevInput === null ){
        prevInput = firstFact;

        if(prevInput.value !== ''){
            factsContainer.appendChild(newFactDiv);
        
        } else{alert('Введите факт');}

    }else if (factsContainer.childElementCount < 7 && prevInput.value !== '') {        
        factsContainer.appendChild(newFactDiv);
        prevInput = input; 
        
    }else if (prevInput.value === '') {
        alert('Введите факт');
    }else if (factsContainer.childElementCount >= 6){
        alert('Слишком много фактов');
    }
    
});


const techContainer = document.querySelector(".all-tech-char-div");
const addTechButton = document.getElementById("add-tech-char-button");
var prevTechInputName = null;
var prevTechInputValue = null;

addTechButton.addEventListener("click", ()=> {

    var newTechDiv = document.createElement("div");
    newTechDiv.className = "characteristic-input";
    newTechDiv.style.marginTop = '15px';

    var inputName = document.createElement("input");
    inputName.type = "text";
    inputName.id = "input-tech-char-name";
    inputName.placeholder = 'Название характеристики'

    var inputValue = document.createElement("input");
    inputValue.type = "text";
    inputValue.id = "input-tech-char-value";
    inputValue.placeholder = 'Значение характеристики'

    newTechDiv.appendChild(inputName);
    newTechDiv.appendChild(inputValue);


    if(prevTechInputValue === null && prevTechInputName === null ){
        prevTechInputName = document.querySelector("#input-tech-char-name")
        prevTechInputValue = document.querySelector("#input-tech-char-value")

        if( prevTechInputName.value !== ''&& prevTechInputValue.value!=''){
            techContainer.appendChild(newTechDiv);
        
        } else{alert('Введите характеристику');}

    }else if ( prevTechInputName.value !== '' && prevTechInputValue.value !== '') {        
        techContainer.appendChild(newTechDiv);
        prevTechInputName = inputName; 
        prevTechInputValue = inputValue; 
        
    }else if (prevTechInputValue.value === '') {
        alert('Введите характеристику');
    }
});


const imgLimit = 3;
var prevImg = null;

addImgsButton.addEventListener("click", () => {

    var newImgDiv = document.createElement("div");
    newImgDiv.id = "add-img-box";
    newImgDiv.className = "add-box";
    newImgDiv.style.marginTop = '15px';

    var input = document.createElement("input");
    input.type = "text";
    input.id = "input-img";

    newImgDiv.appendChild(input);

    if (prevImg === null) {
        prevImg = document.querySelector("#input-img");

        if (prevImg.value !== '') {
            imgContainer.appendChild(newImgDiv);
        }else {
            alert('Введите URL');
        }

    } else if (imgContainer.childElementCount <=imgLimit && prevImg.value !== '') {
        imgContainer.appendChild(newImgDiv);
    
    } else if (prevImg.value === '') {
        alert('Введите URL');
    } else if(imgContainer.childElementCount > imgLimit){
        alert(`Лимит фотографий: ${imgLimit}`)
    }

    // allImgInputs = imgContainer.querySelectorAll('#input-img');
    // allImgInputs.forEach((imgInput, index) => {
    //     imgInput.addEventListener('input', (event) => {
    //         const inputImgValue = event.target.value;
    //             updateImageAtIndex(inputImgValue, index);
    //     });
    // });
});

