import { cardTemp } from "./templates.js";
var type = document.querySelector('#tech-type-box');
var cardDiv= document.querySelectorAll("#tech-card");
var mainCardDiv= document.querySelector("#tech-list");

// async function getFromApi(start){

//     await fetch('https://localhost:7189/technologies')
//     .then(response => response.json())
//     .then(data => { 
//         for(let i=start; i < data.length; i++ ){

//             var card = cardTemp(data[i].id,data[i].images[0],data[i].name,data[i].year,data[i].type,data[i].description, data[i].interestingfacts[0]);
//             mainCardDiv.innerHTML +=`${card} `
//         }
//     }).catch(error => console.error('Error:', error));
// }


function filtred(inputId,cardInnerElement){
    const userSerach = document.getElementById(inputId).value.toLowerCase();
    
    cardDiv.forEach(card => {
        const techName = card.querySelector(cardInnerElement).textContent.toLowerCase();
    
        if(techName.includes(userSerach)){
            mainCardDiv.innerHTML+=
            `<div id="tech-card">
                 ${card.innerHTML}
            </div>` ;
        }
    });
}


function sortByName(){
   
    filtred('search-name','h2');
}


function sortByDescription(){
    filtred('description-search','p');

}
function sortByYear(){
    const year = document.querySelector('#yearChoice').textContent;

    cardDiv.forEach(card => {
        const techYear = card.querySelector('h6').textContent;
        
        if(year<=techYear){
            mainCardDiv.innerHTML+=
            `<div id="tech-card">
                 ${card.innerHTML}
            </div>` ;
        }
    });
   
}



function sortByType(){
    const userSerach = type.value;
    cardDiv.forEach(card => {
        const techType = card.querySelector('h4').textContent;
        if(techType===userSerach){
            mainCardDiv.innerHTML+=
            `<div id="tech-card">
                 ${card.innerHTML}
            </div>` ;
        }
    });
}


$('#filter-btn').on('click',function(){
    cardDiv = document.querySelectorAll("#tech-card");

    mainCardDiv.innerHTML = '';
    sortByYear();

    mainCardDiv.innerHTML = '';
    sortByType();

    mainCardDiv.innerHTML = '';
    sortByName();
    
    mainCardDiv.innerHTML = '';
    sortByDescription();
    
    if(mainCardDiv.childElementCount === 0){
        mainCardDiv.innerHTML+=
        `${noFoundTemp()}`;
    }
});


function noFoundTemp(){

    return `<div class='glitch' style="z-index:0; justify-content: center;display:flex; position:relative; margin:20%;">
            <h1  style="font-weight:bolder; color:cyan; font-size: 120px;">Sory,but there are no result</h1>
        </div>`
}

