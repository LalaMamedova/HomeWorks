const rangeInput = document.getElementById("ageRange");
const ageChoice= document.getElementById("ageChoice");
const currentYear = new Date().getFullYear();
rangeInput.setAttribute("max", currentYear);

rangeInput.addEventListener("input", function() {
    const value = rangeInput.value;
    ageChoice.textContent = rangeInput.value;
});


// const toggleButton = document.getElementById("toggleButton");
// const filtersContainer = document.getElementById("filtersContainer");
// toggleButton.addEventListener("click", function() {
//     if (filtersContainer.style.display === "none") {
//         filtersContainer.style.display = "block";
//     } else {
//         filtersContainer.style.display = "none";
//     }
// });