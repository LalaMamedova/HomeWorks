import { cardTemp } from "./templates.js";
document.addEventListener("DOMContentLoaded", function() {
    
    const rangeInput = $("#yearRange");
    const yearChoice= $("#yearChoice");
    const modebtn = $('#mode-btn');
    const addTempBtn = document.querySelector('#add-temp');
    const currentYear = new Date().getFullYear();

    var techList = document.querySelector('#tech-list');
    var cardDiv = $("#tech-card");
    let isDarkMode = true;
    var AllCards = [];

    window.onload = loadPage(700);

    function loadPage(loadAnimationDelay){
        
        setTimeout(() => {$('#loader-container').css({'display':'none'})}, loadAnimationDelay)
        getFromApi(0);
        isDarkMode = localStorage.getItem('mode') === 'true'? true:false;
        setTimeout(() => {changeMode(isDarkMode);}, 100); 
        sessionStorage.clear();
    }
    
    modebtn.on("click", function(){
        if(isDarkMode === false){isDarkMode = true;} else{isDarkMode = false;}
        changeMode(isDarkMode);
        localStorage.setItem('mode', isDarkMode);
    });

    function changeMode(isDarkMode){

        if(isDarkMode === true){
            modebtn.find('i').removeClass('fa-sun-o').addClass('fa-moon-o');
            $('body').css({'background':'black'});
            $("#sideBar").css({"background":"#2B3865"});
            $('.main-header-div').css({'filter':'brightness(60%)'});
            changeBackgroundColorAllElement('#tech-card',"#182945");
            changeColorAllElement('h3,p,h1',"white");
        }else{
            modebtn.find('i').removeClass('fa-moon-o').addClass('fa-sun-o');
            $('body').css({'background':'linear-gradient(285deg, #34eeff, #ff269d)'});
            $('#sideBar').css({"background":"linear-gradient(85deg, #ffc273, #b222ff"}) 
            $('.main-header-div').css({'filter':'brightness(100%)'});
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
            AllCards.push(data);
        }).catch(error => console.error('Error:', error));
        
        cardDiv = $("#tech-card");
    }


    async function deleteFromApi(dataId){
        await fetch(`https://localhost:7189/technologies/${dataId}`, {method: 'DELETE',})
        .then(res => res.json()) 
        .then(res => console.log(`Ответ от сервера: ${res}`))
    }
    
    addTempBtn.addEventListener('click',()=>{

        techList.innerHTML ='';
        AllCards.forEach(json => {
            json.forEach(data => {
                var card = cardTemp(data.id, data.images[0], data.name, data.year, data.type, data.description, data.interestingfacts[0]);
                techList.innerHTML += `${card} `;
            });
        
        });
    });



    techList.addEventListener('click', (event) => {
        const target = event.target;
    
        if (target.tagName === 'BUTTON') {
            const card = target.closest('#tech-card'); 

            if (card) {
                const techId = card.querySelector("h5").textContent;            
                AllCards.forEach(techs => {
                    techs.forEach(techs => {
                        if (techs.id == techId) {
                            if(target.value === 'info'){
                                sessionStorage.setItem('infoData', JSON.stringify(techs));
                                window.location.href = `/Html/InfoPage.html`;

                            }else if(target.value === 'delete'){
                                
                                deleteFromApi(techId);
                                setTimeout(() => {location.reload();}, 120);
                            }
                            else if(target.value === 'edit'){
                            
                                sessionStorage.setItem('editData', JSON.stringify(techs));
                                window.location.href = `/Html/AddRedactPage.html`;
                                
                            }
                        }
                    });
                
                });
                
            }
        }
    });

    $('#add-tech').on('click',function(){
        window.location.href = `/Html/AddRedactPage.html`;
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

    rangeInput.attr("max", currentYear);
    rangeInput.on("input", function() {
        yearChoice.text(rangeInput.val());
    });


});