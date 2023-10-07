export function changeDefaultElements(isDarkMode,modebtnId){
 
    if(isDarkMode === true){
        document.body.style.background = '#091324';
        document.querySelector(modebtnId).querySelector('i').className = 'fa fa-moon-o';
        $('.main-header-div' ).css({'filter':'brightness(75%)'});
        $('#loader-container').css({'background':'#0a0f2e'});
        $('h1,h2,h3,h4,p').css({'color':'white'});
        changeClassNameId('.main-button','main-button-dark',false)
        changeClassNameId('.music-button','music-button-dark',false)
      
    }else{
        document.body.style.background = "linear-gradient(285deg, #34eeff, #ff269d)";
        document.querySelector(modebtnId).querySelector('i').className = 'fa fa-sun-o';
        $('.main-header-div' ).css({'filter':'brightness(100%)'});
        $('#loader-container').css({'background':'linear-gradient(285deg, #34eeff, #ff269d)'});
        $('h1,h2,h3,h4,p').css({'color':'black'});
        changeClassNameId('.main-button-dark','main-button',false)
        changeClassNameId('.music-button-dark','music-button',false)
    }
}


export function changeClassNameId(className,classNewName,classOrId){
    let changeId = document.querySelectorAll(className);
    changeId.forEach(element=>{
        classOrId === true? element.id = classNewName : element.className=classNewName;
    });
}
export function btnClick(isDarkMode){
    if(isDarkMode === false) {isDarkMode = true;} else{isDarkMode = false;}
        localStorage.setItem('mode', isDarkMode);
        return isDarkMode;
}
