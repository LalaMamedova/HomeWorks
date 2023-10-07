import { cardTemp,changeBtns } from "./templates.js";
import { get,remove } from "./apiMethods.js";
import { changeDefaultElements,btnClick } from "./changeMode.js";
let isDarkMode = localStorage.getItem('mode') === 'true'? true:false;

document.addEventListener("DOMContentLoaded", function() {
    
    const rangeInput = $("#yearRange");
    const yearChoice= $("#yearChoice");
    const modebtn = $('#mode-btn');
    const addTempBtn = document.querySelector('#add-temp');
    const currentYear = new Date().getFullYear();

    var techList = document.querySelector('#tech-list');
    var cardDiv = '';
    var AllCards = [];

    window.onload = async function () {
      
        sessionStorage.clear();
        await loadPage(700);
        changeBtns();
    };
    
    async function loadPage(loadAnimationDelay) {
        setTimeout(() => {$('#loader-container').css({'display': 'none'})},loadAnimationDelay);
        AllCards = await get('technologies');

        AllCards.forEach(data => {
            var card = cardTemp(data.id,data.images[0],data.name,data.year,data.type,data.description, data.interestingfacts[0]);
            techList.innerHTML +=`${card} `
        });
        
        cardDiv = document.querySelectorAll(".tech-card,#tech-card");
        await changeMode(isDarkMode);
    }

    modebtn.on("click", async function(){
        isDarkMode = btnClick(isDarkMode);
        await changeMode(isDarkMode);
    });


    async function changeMode(isDarkMode){

        changeDefaultElements(isDarkMode,"#mode-btn");

        if(isDarkMode === true){
            $('.side-bar-div,.side-bar-div-active').css({'background':'#2B3865'});
            cardDiv.forEach(card=>{
                card.style.background = '#2B3865';
            });            
            
        }else{
            $('.side-bar-div,.side-bar-div-active').css({'background':'linear-gradient(85deg, #ffc273, #b222ff)'});
            cardDiv.forEach(card=>{
                card.style.background = 'linear-gradient(135deg, #1e38ff, #ff78c7)';
            });

        }
    
    }

    
    addTempBtn.addEventListener('click',()=>{
        AllCards.forEach(data => {
            var card = cardTemp(data.id, data.images[0], data.name, data.year, data.type, data.description, data.interestingfacts[0]);
            techList.innerHTML += `${card}`;
        });
    });

    techList.addEventListener('click', (event) => {
        const target = event.target;
    
        if ( event.target.tagName === 'BUTTON') {
            const card = target.closest('.tech-card'); 

            if (card) {
                const techId = card.querySelector("h5").textContent;            
                AllCards.forEach(techs => {
                    if (techs.id == techId) {
                        if(target.value === 'info'){
                            sessionStorage.setItem('infoData', JSON.stringify(techs));
                            window.location.href = `/Html/InfoPage.html`;

                        }else if(target.value === 'delete'){
                            
                            remove("technologies",techId);
                            setTimeout(() => {location.reload();}, 120);
                        }
                        else if(target.value === 'edit'){
                            sessionStorage.setItem('editData', JSON.stringify(techs));
                            window.location.href = `/Html/AddRedactPage.html`;
                            
                        }
                    }
                
                });
                
            }
        }
    });

    $('#add-tech').on('click',function(){
        window.location.href = `/Html/AddRedactPage.html`;
    });


    rangeInput.attr("max", currentYear);
    rangeInput.on("input", function() {
        yearChoice.text(rangeInput.val());
    });

});