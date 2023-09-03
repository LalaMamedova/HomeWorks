// const techTemp = document.querySelector("tech-temp");
// const techImg = techTemp.querySelector("tech-img");
// const techName = techTemp.querySelector(".tech-name");
// const techDate = techTemp.querySelector("tech-date");
// const techDescription = techTemp.querySelector("tech-description");
const inputName = document.getElementById("input-name");
const inputImg = document.getElementById("input-img");
const inputDescription = document.getElementById("input-description");
const inputDate = document.getElementById("input-date");

const techImg = document.getElementById("tech-img");
const techName = document.getElementById("tech-name");
const techDate = document.getElementById("tech-date");
const techDescription = document.getElementById("tech-description");

if (!techImg.getAttribute("src") || techImg.getAttribute("src").length == 0) {
    techImg.setAttribute("src", "https://avatars.dzeninfra.ru/get-zen_doc/3137181/pub_622c93eaa228967ff2d727e7_622c94198ae1c12db1140183/scale_1200");
}
if (techName.textContent.length == 0) {
    techName.textContent = "Старая техника";
}
if (techDate.textContent.length == 0) {
    techDate.textContent = "1700";
}
if (techDescription.textContent.length == 0) {
    techDescription.textContent = "Очень приочень длинное описание старой техники";
}

inputName.addEventListener("input", function(event) {
    if (event.target.value.length == 0) {
        techName.textContent = "Старая техника";
    }
    else{
        techName.textContent =  event.target.value;;
    }
});


// inputImg.addEventListener("click", function(event) {
//     let input = document.createElement('input');
//     input.type = 'file';
//     input.onchange = _ => 
//     {
//         let files = Array.from(input.files);
//         console.log(files[0].from);
//         techImg.setAttribute("src", files[0].name)
//     };
//     input.click();
   
// });

inputImg.addEventListener("input", function(event) {
    if (event.target.value.length <= 4) {
        techImg.setAttribute("src", "https://avatars.dzeninfra.ru/get-zen_doc/3137181/pub_622c93eaa228967ff2d727e7_622c94198ae1c12db1140183/scale_1200");
    } 
    else {
        techImg.setAttribute("src", event.target.value);
    }
});

inputDate.addEventListener("input", function(event) {

    if (event.target.value.length == 0) {
        techDate.textContent = "1700";
    }
    else{
        techDate.textContent =  event.target.value;;
    }
});


inputDescription.addEventListener("input", function(event) {

    if (event.target.value.length == 0) {
        techDescription.textContent = "Очень приочень длинное описание старой техники";
    }
    else{
        techDescription.textContent =  event.target.value;;
    }
});