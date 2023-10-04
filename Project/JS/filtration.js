const yearRange = document.querySelector('#yearRange');
const name = document.querySelector('#name-search');
const type = document.querySelector('#tech-type-box');
const description = document.querySelector('#description-search');
var cardDiv= document.querySelectorAll("#tech-details");
var mainCardDiv= document.querySelector("#tech-list");

var tempCardDiv = [];
function sortByYear(){
    const year = document.querySelector('#yearChoice');
    mainCardDiv.innerHTML = '';
    cardDiv.forEach(card => {
        const techYear =card.querySelector('h6').textContent;
        if(techYear<=1995){
            mainCardDiv+=card;
            console.log(mainCardDiv);

        }
    });
}

yearRange.addEventListener('input',()=>{
    sortByYear();
});