const modebtn = document.querySelector('#mode-btn');
let isDarkMode = true;




window.onload = function() {
    isDarkMode = localStorage.getItem('mode') === 'true'? true:false;
    changeMode(isDarkMode);
    changeTemplate(getFullInfoTech());
};

modebtn.addEventListener('click',()=>{
    if(isDarkMode === false){isDarkMode = true;} else{isDarkMode = false;}
    changeMode(isDarkMode);
    localStorage.setItem('mode',isDarkMode);
});


function changeMode(isDarkMode){
    if(isDarkMode === true){
        document.body.style.background = 'black';
        modebtn.querySelector('i').className = 'fa fa-moon-o';
        document.querySelector('.main-header-div' ).style.filter = 'brightness(60%)';
        changeBackgroundColorAllElement('section','#182945');
        changeColorAllElement('label,span',"white");
        changeColorAllElement('.interactiv-btn',"white");
    }else{
        modebtn.querySelector('i').className = 'fa fa-sun-o';
        document.querySelector('.main-header-div' ).style.filter = 'brightness(100%)';
        document.body.style.background = "linear-gradient(285deg, #34eeff, #ff269d)";
        changeBackgroundColorAllElement('section',"linear-gradient(285deg, #8a98ff, #ff78c7)");
        changeColorAllElement('label,span',"black");
        changeColorAllElement('.interactiv-btn',"black");
    }

}

function changeBackgroundColorAllElement(param,color){
    document.querySelectorAll(`${param}`).forEach(element=>{
        element.style.background = color;

    });
}

function changeColorAllElement(param,color){
    document.querySelectorAll(`${param}`).forEach(element=>{
        element.style.color = color;
    });
}



function getFullInfoTech(){
    const tempData = sessionStorage.getItem('infoData');
    let techInfo = JSON.parse(tempData);
    console.log(techInfo);
    return techInfo;
}
function changeTemplate(techInfo){
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
                    <button class="interactiv-btn"><i class="fa fa-heart-o fa-beat" style="font-size:24px" aria-hidden="true"></i> </button>
                    <button class="interactiv-btn"><i class="fa fa-share-alt" style="font-size:24px"></i></button>
                </div>  
                <div>
                    <section id="name-section">
                        <label for="tech-name">Name:</label>
                        <span id="tech-name">${techInfo.name}</span>
                    </section>
                    
                    <section id="type-section">
                        <label for="tech-type">Type:</label>
                        <span id="tech-type">${techInfo.type}</span>
                    </section>
                    
                    <section id="date-section">
                        <label for="tech-date">Release date:</label>
                        <span id="tech-date">${techInfo.year}</span>
                    </section>
                </div>
            </div>

            <div class="other-info-div">
                <section id="description-section">
                    <label for="tech-description">Description:</label>
                    <span id="tech-description">${techInfo.description}</span>
                </section>
            </div>

            <div class="fact-and-char-div">
                <section id="char-section">
                    <label for="tech-char-value">Technical characteristics :</label>
                    ${charDiv}
                </section>

                <section id="fact-section">
                    <label for="tech-fact">Interesting facts:</label>
                    ${factDiv}
                </section>
            </div>
        `
        
}

function makeImgDiv(json){
    let div = '';
    if(json.images.length>1){
        for(i=1;i<json.images.length;i++){

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
    for(i=0;i<json.charname.length;i++){

        div +=` <li> 
                    <span id="tech-char-name">${json.charname[i]}:</span>
                    <span id="tech-char-value">${json.charvalue[i]}</span>
                </li>`
    }
    return div;
  
}


function makeFactDiv(json){
    let div = '';

    for(i=0; i<json.interestingfacts.length ;i++){

        div +=`<li> 
            <span id="tech-fact">${i+1}. ${json.interestingfacts[i]}</span>
        </li>`
    }
    return div;
  
}

