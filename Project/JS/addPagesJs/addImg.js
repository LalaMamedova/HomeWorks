const addImgsButton = document.getElementById("add-img-char-button");
const imgContainer = document.querySelector(".add-img");
var allImgInputs = imgContainer.querySelectorAll('#input-img');
const imgLimit = 3;
var prevImg = null;

allImgInputs.forEach((imgInput) => {
    imgInput.addEventListener('input', (event) => {
        const inputImgValue = event.target.value;
            updateImageAtIndex(inputImgValue, 0);
    });
});


addImgsButton.addEventListener("click", () => {
    var newImgDiv = document.createElement("div");
    newImgDiv.id = "add-img-box";
    newImgDiv.className = "add-box";
    newImgDiv.style.marginTop = '15px';

    var input = document.createElement("input");
    input.type = "text";
    input.id = "input-img";

    newImgDiv.appendChild(input);

    if (prevImg === null) {
        prevImg = document.querySelector("#input-img");

        if (prevImg.value !== '') {
            imgContainer.appendChild(newImgDiv);
        }else {
            alert('Введите URL');
        }

    } else if (imgContainer.childElementCount <=imgLimit && prevImg.value !== '') {
        imgContainer.appendChild(newImgDiv);
    
    } else if (prevImg.value === '') {
        alert('Введите URL');
    } else if(imgContainer.childElementCount > imgLimit){
        alert(`Лимит фотографий: ${imgLimit}`)
    }

    allImgInputs = imgContainer.querySelectorAll('#input-img');

    allImgInputs.forEach((imgInput, index) => {
        imgInput.addEventListener('input', (event) => {
            const inputImgValue = event.target.value;
                updateImageAtIndex(inputImgValue, index);
        });
    });
});

function updateImageAtIndex(newImageUrl, index) {
    
    const defaultImgPath = 'https://avatars.dzeninfra.ru/get-zen_doc/3137181/pub_622c93eaa228967ff2d727e7_622c94198ae1c12db1140183/scale_1200';
    const allCaruselImg = document.querySelectorAll(".tech-img");
    if (allCaruselImg[index]) {
        if (allCaruselImg[index].src != newImageUrl) {

            if(newImageUrl != ""){
                allCaruselImg[index].src = newImageUrl;

             }else{
                allCaruselImg[index].src = defaultImgPath;
            }
            allCaruselImg[index].alt = 'GFG';
        } 
    }
}