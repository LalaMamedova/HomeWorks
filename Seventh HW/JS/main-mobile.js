var mainCss = document.getElementById("main-style");
var url = window.location.href.split("/Html");
const techList = document.getElementById("tech-list");
const li = techList.querySelectorAll('li');
url = url[0];

function changeCss(){

    if (window.innerWidth > 1024 && mainCss.href != `${url}/Css/Main.css`) {
        mainCss.href = "/Css/Main.css";
        gadjetVersion('25%');
    } 
    else if (window.innerWidth <= 1024 && mainCss.href != `${url}/Css/Main-Moble.css`) {
        mainCss.href = "/Css/Main-Mobile.css";
        gadjetVersion('40%');
    }

}

window.addEventListener('resize', changeCss);
window.addEventListener('beforeload', changeCss);
window.addEventListener('load', changeCss);


const sideBar = document.getElementById("sideBar");
const menuBtn = document.getElementById("menu-btn");
const ul = techList.querySelector('ul');

menuBtn.addEventListener("click", function() {
    const computedStyle = window.getComputedStyle(sideBar);
    const displayValue = computedStyle.getPropertyValue('display');
   
    if (displayValue === 'none') {
        sideBar.style.display = 'block'; 
        techList.style.marginLeft = '40%';

        sideBar.classList.add('slide-left-in');
        ul.classList.add('slide-left-in-side-bar');

        gadjetVersion('100%');

    } 
    else {

        techList.style.marginLeft = '0%'
        gadjetVersion('40%');
        
        sideBar.classList.add('slide-left-out');
        ul.classList.add('slide-left-out-side-bar');
        
        setTimeout(() => {
            sideBar.classList.remove('slide-left-in', 'slide-left-out');
            ul.classList.remove('slide-left-in-side-bar', 'slide-left-out-side-bar');
            sideBar.style.display = 'none';   
        }, 1000);

    }
});




function gadjetVersion(lielementWidth){
    li.forEach(liElement => {
        liElement.style.width = lielementWidth;});
    
}


