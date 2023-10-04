var css = document.querySelectorAll('link');
var url = window.location.href.split("/Html");
const sideBar = document.getElementById("sideBar");
const menuBtn = document.getElementById("menu-btn");
var allTechDiv = document.querySelectorAll('#tech-card');
url = url[0];

function changeCss(){
    allTechDiv = document.querySelectorAll('#tech-card');
    if (window.innerWidth > 1200 && css[0].href !== `${url}/Scss/Main.css`) {
        css[0].href = `${url}/Scss/Main.css`;
        menuBtn.style.display = 'none';
        sideBar.style.display = 'block';
        allDivMargin(10);
        
    }else if (window.innerWidth < 1200 && css[0].href !== `${url}/Scss/Main-Mobile.css`) {
        css[0].href = `${url}/Scss/Main-Mobile.css`;
        sideBar.style.display = 'none';       
        menuBtn.style.display = 'flex';
        
 
    }
}

window.addEventListener('resize', changeCss);
window.addEventListener('load', changeCss);

menuBtn.addEventListener("click", function() {
    allTechDiv = document.querySelectorAll('#tech-card');
    const computedStyle = window.getComputedStyle(sideBar);
    const displayValue = computedStyle.getPropertyValue('display');

    if (displayValue === 'none') {
        sideBar.className = 'side-bar-div-active';
        sideBar.style.display = 'block'; 
        allDivMargin(30);
    } 
    else {

        sideBar.className = 'side-bar-div';
        setTimeout(() => {sideBar.style.display = 'none';}, 600);
        allDivMargin(10);
    }
});



function allDivMargin(marginPersent){
    allTechDiv.forEach(cards => {
        cards.style.marginLeft= `${marginPersent}%`;
    });
}

