const fact = document.querySelector('#one-fact-in-temp');
const factsContainer = document.querySelector(".facts-div");
const addFactsButton = document.getElementById("add-fact-button");
const firstFact = document.querySelector("#input-fact");

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
    // input.style.width = "100%";

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
