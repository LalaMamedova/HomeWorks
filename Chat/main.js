const popUp =  document.getElementById("myForm");
const openClick =  document.querySelector('.open-button');
const closeClick =  document.querySelector('.cancel');

openClick.addEventListener('click', ()=>{
    if(popUp.style.display === 'none'){
        popUp.style.display = "block";
    }else{
        popUp.style.display = "none";
    }

});
closeClick.addEventListener('click', ()=>{
    popUp.style.display = "none";
});
