// const techTemp = document.querySelector("tech-temp");
// const techImg = techTemp.querySelector("tech-img");
// const techName = techTemp.querySelector(".tech-name");
// const techname = techTemp.querySelector("h2");
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


inputName.addEventListener("input", function(event) {
    const inputValue = event.target.value;
    techName.textContent = inputValue;
});


inputImg.addEventListener("click", function(event) {
    fileInput.click();
    const inputValue = event.target.value;
    techImg.textContent = inputValue;
});

inputDate.addEventListener("input", function(event) {
    const inputValue = event.target.value;
    techDate.textContent = inputValue;
});
inputImg.addEventListener("input", function(event) {
    const inputValue = event.target.value;
    techImg.textContent = inputValue;
});

inputDescription.addEventListener("input", function(event) {
    const inputValue = event.target.value;
    techDescription.textContent = inputValue;
});