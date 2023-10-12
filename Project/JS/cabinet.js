import {btnClick,changeDefaultElements} from './changeMode.js'
import {getById} from './apiMethods.js'

let isDarkMode = localStorage.getItem('mode') === 'true'? true:false;
let signOut = $('#sign-out-btn');
let likedTechnology = [];


window.onload = async function () {
   let user = JSON.parse(localStorage.getItem('user'));

    if(user!=null){
        if(user.likedTechnology.length>0){
            for(let i=0; i<user.likedTechnology.length; i++){

                let data = await getById('technologies', user.likedTechnology[i]);
                likedTechnology.push(data);
                
                document.querySelector('.tech-list').innerHTML +=
                    `<div id="tech-card" class='tech-card'">
                    <img src="${data.images[0]}" alt="${data.name}">
                    <h2>${data.name}</h2>
                    <h6>${data.year}</h6>
                    <h4>${data.type}</h4>
                    <p>${data.description}</p>
                    
                    <div class="interest-fact">
                        <span id="tech-fact">${data.interestingfacts[0]}</span>
                    </div>
                    
                        <div class="to-full-info-div">
                            <button id="to-full-info-btn" value="info">More info...</button>
                        </div>
                        <h5>${data.id}</h5>
                </div>`
            }
        }if(user.likedTechnology.length===0){
            document.querySelector('.tech-list').innerHTML+=
           ` <h1>You have no favorite technology. <a href ='MainPage.html'>Here</a> you can like some</h1>`
        }
    }
    changeHeaderBtn(user);
    changeDefaultElements(isDarkMode, "#mode-btn");
}

$('.tech-list').on('click', function(event) {
    const target = event.target;
    
    if (event.target.tagName === 'BUTTON') {
        const card = target.closest('.tech-card'); 
        
        if (card) {
            const techId = card.querySelector("h5").textContent;  
            
            likedTechnology.forEach(techs => {
                if (techs.id == techId) {
                    sessionStorage.setItem('infoData', JSON.stringify(techs));
                    window.location.href = `/Html/InfoPage.html?tech=${techs.name}`;
                }
            
            });
            
        }
    }
});

signOut.on('click',function(){
    localStorage.removeItem('user');
});

function changeHeaderBtn(user){
    if(user!=null){
        signOut.css({'display':'flex'});
        document.querySelector('#sign-in-btn').style.display = 'none';
        document.querySelector('#sign-up-btn').style.display = 'none';
    }else{
        signOut.css({'display':'none'});
        document.querySelector('#sign-in-btn').style.display = 'flex';
        document.querySelector('#sign-up-btn').style.display = 'flex';
    }
}


$('#mode-btn').on('click',function(){
    isDarkMode = btnClick(isDarkMode);
    changeDefaultElements(isDarkMode,"#mode-btn");
});

