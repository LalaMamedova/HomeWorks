import { cardTemp } from "./templates.js";
var mainCardDiv= document.querySelector("#tech-list");
let filtredDivs = []; 

async function getFromApi(start){
    await fetch('https://localhost:7189/technologies')
    .then(response => response.json())
    .then(data => { 
        for(let i=start; i < data.length; i++ ){

            var card = cardTemp(data[i].id,data[i].images[0],data[i].name,data[i].year,data[i].type,data[i].description, data[i].interestingfacts[0]);
            mainCardDiv.innerHTML +=`${card} `
        }
    }).catch(error => console.error('Error:', error));
}

function filtred(inputId, cardInnerElement) {
    const userSearch = document.getElementById(inputId).value.toLowerCase();

    for(let i = 0; i< filtredDivs.length; i++){
        const techValue = filtredDivs[i].querySelector(cardInnerElement).textContent.toLowerCase();
        if(!techValue.includes(userSearch)){
            filtredDivs.splice(i,1) ;
            i--;

        }
    }

}

function sortByName() {
    filtred('search-name', 'h2');
}

function sortByDescription() {
    filtred('description-search', 'p');
}

function sortByType() {
    filtred('tech-type-box', 'h4');
}

function sortByYear() {
    const userSearch = document.getElementById('yearChoice').textContent;

    console.log(userSearch);
    for(let i = 0; i< filtredDivs.length; i++){
        const techValue = filtredDivs[i].querySelector('h6').textContent;
        if(techValue<userSearch){
            filtredDivs.splice(i,1) ;
            i--;

        }
    }
 
}

$('#filter-btn').on('click', function () {
   
    let cardDiv = document.querySelectorAll(".tech-card");
    filtredDivs = Array.from(cardDiv); 
    mainCardDiv.innerHTML = '';

    sortByYear();
    sortByName();
    sortByDescription();
    sortByType();


    if (filtredDivs.length === 0) {
        mainCardDiv.innerHTML +=
            `${noFoundTemp()}`;
        return;
    }else{
    
        let classId = filtredDivs[0].id;
        filtredDivs.forEach(card => {
            mainCardDiv.innerHTML +=
                `<div id="${classId}" class="tech-card">
                    ${card.innerHTML}
                </div>`;
        });
    }

});

function noFoundTemp(){
    let btnClassName = 'main-button';
    if(localStorage.getItem('mode') === 'true'){
        btnClassName+='-dark';
    }
    return `<div class='glitch' style="z-index:0; justify-content: center;display:flex; position:relative; margin:20%;">
            <h1  style="font-weight:bolder; color:cyan; font-size: 120px;">Sory,but there are no result</h1>
            <button id='reload-btn' class=${btnClassName} >Retry</button>
        </div>`
    $('#reload-btn').on('click',function(){
        location.reload();

    });
}

