import { getByEmail } from "./apiMethods.js";
import { changeDefaultElements,changeClassNameId,btnClick } from "./changeMode.js";
const modebtn = $('#mode-btn');
const email =  $('#signin-email');
const password =  $('#signin-pass');
let isDarkMode = localStorage.getItem('mode') === 'true'? true:false;

window.onload = function() {
    changeMode(isDarkMode);

    if(sessionStorage.getItem('user')!=''){
        email.val(sessionStorage.getItem('user'));
    }
};

function changeMode(isDarkMode){
    changeDefaultElements(isDarkMode,'#mode-btn');
    if(isDarkMode === true){
        changeClassNameId('.main-div','main-div-dark',false);
    }else{
        changeClassNameId('.main-div-dark','main-div',false);
    }
}

modebtn.on('click',function(){
    isDarkMode = btnClick(isDarkMode);
    changeMode(isDarkMode);
});



$('.submit-sign-in').on('click', async function(){
    if(email.val()!='' && password.val()!=''){
        let res = await getByEmail('users', email.val());

        if(res.email === email.val() && res.password==password.val()){
            localStorage.setItem('isLogin',true);
            localStorage.setItem('user',JSON.stringify(
            {
                id:res.id,
                email:res.email}));

            location.href = '/Html/MainPage.html'
        }else{
            $('.error-message').text('Incorrect password or email').css({'display':'flex'});
        } 
    }else{
        $('.error-message').text('Fill all field please').css({'display':'flex'});
    }
});
