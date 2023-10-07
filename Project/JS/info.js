import {changeDefaultElements,changeClassNameId,btnClick } from "./changeMode.js";
import { changeBtns } from "./templates.js";
import {getByEmail, put } from "./apiMethods.js";

const modebtn = document.querySelector('#mode-btn');
let isDarkMode = localStorage.getItem('mode') === 'true'? true:false;
let techInfo = '';
var userRes = '';

window.onload = async function() {
    if(sessionStorage.getItem('infoData')){

        if(localStorage.getItem('user')!=null){

            let user = JSON.parse(localStorage.getItem('user'));
            userRes = await getByEmail('users',user.email);    
        }
        await changeTemplate(getFullInfoTech());
    }
    await changeMode(isDarkMode);
    changeBtns();
};

modebtn.addEventListener('click',()=>{
    isDarkMode = btnClick(isDarkMode);
    changeMode(isDarkMode);
});

async function changeMode(isDarkMode){
    changeDefaultElements(isDarkMode,'#mode-btn')

    if(isDarkMode === true){
        changeClassNameId('.section','dark-section',false);
        changeClassNameId('.interactiv-btn-div',"interactiv-btn-dark-div",false);
    }else{
        changeClassNameId('.interactiv-btn-dark-div',"interactiv-btn-div",false);
        changeClassNameId('.dark-section',"section",false);
    }
}


function getFullInfoTech(){
    const tempData = sessionStorage.getItem('infoData');
    techInfo = JSON.parse(tempData);
    return techInfo;
}
async function changeTemplate(techInfo){
    let likeBtnType = await addLikeBtn();
    let imgDiv = makeImgDiv(techInfo);
    let charDiv = makeCharLi(techInfo);
    let factDiv = makeFactDiv(techInfo);

    document.querySelector('.main-div').innerHTML = 
    `<div class="all-img-div">
                <div id="GFG" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img class="tech-img" src="${techInfo.images[0]}"  alt="${techInfo.name}">
                            <p>1</p>
                        </div>

                        ${imgDiv}

                    </div>
                    <a class="carousel-control-prev" href="#GFG"
                        data-slide="prev">
                        <span class="carousel-control-prev-icon"></span>
                    </a>
                    <a class="carousel-control-next" href="#GFG"
                        data-slide="next">
                        <span class="carousel-control-next-icon" ></span>
                    </a>
                </div>
            </div>

            <div class="mini-info-div">  
                <div class="interactiv-btn-div" >
                   ${likeBtnType};
                    <button id='share-btn' class="interactiv-btn"><i class="fa fa-share-alt" style="font-size:24px"></i></button>
                </div>  
                <div>
                    <section class='section' id="name-section">
                        <label for="tech-name">Name:</label>
                        <span id="tech-name">${techInfo.name}</span>
                    </section>
                    
                    <section  class='section' id="type-section">
                        <label for="tech-type">Type:</label>
                        <span id="tech-type">${techInfo.type}</span>
                    </section>
                    
                    <section class='section' id="date-section">
                        <label for="tech-date">Release date:</label>
                        <span id="tech-date">${techInfo.year}</span>
                    </section>
                </div>
            </div>

            <div class="other-info-div">
                <section class='section' id="description-section">
                    <label for="tech-description">Description:</label>
                    <span id="tech-description">${techInfo.description}</span>
                </section>
            </div>

            <div class="fact-and-char-div">
                <section class='section' id="char-section">
                    <label for="tech-char-value">Technical characteristics :</label>
                    ${charDiv}
                </section>

                <section class='section' id="fact-section">
                    <label for="tech-fact">Interesting facts:</label>
                    ${factDiv}
                </section>
            </div>
        `

        await likeBtnClick();
}


async function likeBtnClick(){

    $('#like-btn').on('click', async function(){
        if(userRes != '')
        {
        
            const techInfoString = JSON.stringify(techInfo);
            const likedTechStrings = userRes.likedTechnology.map(item => JSON.stringify(item));

            if(!likedTechStrings.includes(techInfoString)){
                userRes.likedTechnology.push(techInfo);
                put('users',userRes.id,userRes);
                document.querySelector('#like-btn').querySelector('i').className= ('fa fa-heart fa-beat');
            }else{
                alert('You alredy liked this');
            }

        }else{
            alert('Sign in')
        };  
        
    });
}


async function addLikeBtn(){
    if(userRes != ''){
        const techInfoString = JSON.stringify(techInfo);
        const likedTechStrings = userRes.likedTechnology.map(item => JSON.stringify(item));
        if(likedTechStrings.includes(techInfoString)){
            return `<button id='like-btn' class="interactiv-btn"><i class="fa fa-heart fa-beat" style="font-size:24px" aria-hidden="true"></i> </button>`
        }
    }      
    return `<button id='like-btn' class="interactiv-btn"><i class="fa fa-heart-o fa-beat" style="font-size:24px" aria-hidden="true"></i> </button>`

}
function makeImgDiv(json){
    let div = '';
    if(json.images.length>1){
        for(let i=1;i<json.images.length;i++){
            
            div +=`<div class="carousel-item">
            <img class="tech-img" src="${json.images[i]}"  alt="${json.name}">
            <p>${i+1}</p>
            </div>`
        }
    }
    return div;
    
}
function makeCharLi(json){
    let div = '';
    for(let i=0; i<json.charname.length ; i++){
        div +=` <li> 
                    <span id="tech-char-name">${json.charname[i]}:</span>
                    <span id="tech-char-value">${json.charvalue[i]}</span>
                </li>`
    }
    return div;
}

function makeFactDiv(json){
    let div = '';
    for(let i=0; i<json.interestingfacts.length ;i++){

        div +=`<li> 
            <span id="tech-fact">${i+1}. ${json.interestingfacts[i]}</span>
        </li>`
    }
    return div;

}
