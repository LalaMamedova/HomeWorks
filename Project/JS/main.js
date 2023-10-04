// import {techJson} from './alredyMakeCards.js';
const rangeInput = document.getElementById("yearRange");
const yearChoice= document.getElementById("yearChoice");
const modebtn = document.querySelector('#mode-btn');
const addTempBtn = document.querySelector('#add-temp');
const currentYear = new Date().getFullYear();
const defaulImg = "https://shirtigo.co/wp-content/uploads/2014/10/retrotechnology.jpg";
var techList = document.querySelector('#tech-list');
var cardDiv= document.querySelectorAll("#tech-card");
let isDarkMode = false;
var AllTech = [];
function setDarkMode(){
   if(isDarkMode === false){
    isDarkMode = true;
   }else{isDarkMode = false;}
}

window.onload = function() {
    let DarkMode = localStorage.getItem('mode') === 'true'? true:false;
    isDarkMode= DarkMode;
    changeMode(DarkMode);
    loadingCards();
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
        document.querySelector('#sideBar').style.background = '#2B3865';
        document.querySelector('.main-header-div' ).style.filter = 'brightness(60%)';
        changeBackgroundColorAllElement('#tech-card',"#182945");
        changeColorAllElement('h3,p,h1',"white");
    }else{
        modebtn.querySelector('i').className = 'fa fa-sun-o';
        document.body.style.background = "linear-gradient(285deg, #34eeff, #ff269d)";
        document.querySelector('#sideBar').style.background = "linear-gradient(85deg, #ffc273, #b222ff)";
        document.querySelector('.main-header-div' ).style.filter = 'brightness(100%)';
        changeBackgroundColorAllElement('#tech-card',"linear-gradient(285deg, #1e38ff, #ff78c7)");
        changeColorAllElement('h3,p,h1',"black");
    }
}

async function getFromApi(start){
    await fetch('https://localhost:7189/technologies')
    .then(response => response.json())
    .then(data => { 
        for(let i=start; i < data.length; i++ ){
            var card = cardTemp(data[i].id,data[i].images[0],data[i].name,data[i].year,data[i].type,data[i].description, data[i].interestingfacts[0]);
            techList.innerHTML +=`${card} `
        }
        AllTech.push(data);
    }).catch(error => console.error('Error:', error));
}

async function loadingCards(){
    cardDiv = document.querySelectorAll("#tech-card");
    getFromApi(0);
}

async function deleteFromApi(dataId){
    console.log(dataId);
    await fetch(`https://localhost:7189/technologies/id?id=${dataId}`,
    {
        method: 'DELETE',
    })
    .then(res => res.json()) 
    .then(res => console.log(`Ответ от сервера: ${res}`))
}
  
addTempBtn.addEventListener('click',()=>{

    techList.innerHTML ='';
    AllTech.forEach(json => {
        json.forEach(data => {
            var card = cardTemp(data.id, data.images[0], data.name, data.year, data.type, data.description, data.interestingfacts[0]);
            techList.innerHTML += `${card} `;
        });
       
    });
    cardDiv = document.querySelectorAll("#tech-card");
});



techList.addEventListener('click', (event) => {
    const target = event.target;
  
    if (target.tagName === 'BUTTON') {
        const card = target.closest('#tech-card'); 

        if (card) {
            const techId = card.querySelector("h5").textContent;            
            AllTech.forEach(techs => {
                techs.forEach(techs => {
                    if (techs.id == techId) {
                        if(target.value === 'info'){

                            if(sessionStorage.getItem('tempData')==null){
                                sessionStorage.removeItem('tempData');
                            }
                            
                            sessionStorage.setItem('tempData', JSON.stringify(techs));
                            window.location.href = `/Html/InfoPage.html`;
                        }else if(target.value === 'delete'){
                            
                            deleteFromApi(techId);
                            setTimeout(() => {
                                location.reload();
                            }, 150);
                            
                      
                        }
                    }
                });
               
            });
            
        }
    }
});



function changeBackgroundColorAllElement(param,color){
    let changeElement = document.querySelectorAll(`${param}`);
    changeElement.forEach(element=>{
        element.style.background = color;
    });
}

function changeColorAllElement(param,color){
    document.querySelectorAll(`${param}`).forEach(element=>{
        element.style.color = color;
        
    });
}
function cardTemp(id,images,name,year,type,description,interestingfacts){
    if(images==null){
        images=defaulImg;
    }else if(interestingfacts ==null){
        interestingfacts = 'Interesting fact';
    }
    let card =  `<div id="tech-card" >
             <img src="${images}" alt="${name}">
             <h2>${name}</h2>
             <h6>${year}</h6>
             <h4>${type}</h4>
             <p>${description}</p>
             
             <div class="interest-fact">
                 <span id="one-fact-in-temp">${interestingfacts}</span>
             </div>
             
             <div class="tech-card-buttons">
                 <button class="crud-btn-template edit-btn" value="edit">Edit</button>
                 <button class="crud-btn-template delete-btn"value="delete">Delete</button>
             </div>
             
                 <div class="to-full-info-div">
                     <button id="to-full-info-btn" value="info">More info...</button>
                 </div>
                 <h5>${id}</h5>
         </div>`       
         return card;
 }

rangeInput.max = currentYear;
rangeInput.addEventListener("input", function() {
    yearChoice.textContent = rangeInput.value;
});
