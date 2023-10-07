let signOut = document.querySelector('#sign-out-btn');

signOut.addEventListener('click',()=>{
    localStorage.setItem('isLogin',false); 
    localStorage.removeItem('user');

});

if(localStorage.getItem('isLogin')=='true'){
    signOut.style.display = 'flex';
    document.querySelector('#sign-in-btn').style.display = 'none';
    document.querySelector('#sign-up-btn').style.display = 'none';

}else{
    signOut.style.display = 'none';
    document.querySelector('#sign-in-btn').style.display = 'flex';
    document.querySelector('#sign-up-btn').style.display = 'flex';
}