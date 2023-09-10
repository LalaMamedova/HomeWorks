const rangeInput = document.getElementById("ageRange");
const ageChoice= document.getElementById("ageChoice");
const audio= document.getElementById("audio");
const playButton= document.getElementById("play-music");
const pauseButton= document.getElementById("stop-music");
const nextButton= document.getElementById("next-music");


let index = 0;
const songs = [
    "Messages from the Stars.mp3",
    "Careless Whisper.mp3", 
    "Sweet Dreams.mp3",
    'Stranger Things.mp3',
    'Lady of the 80.mp3'
]

const currentYear = new Date().getFullYear();
rangeInput.setAttribute("max", currentYear);

rangeInput.addEventListener("input", function() {
    ageChoice.textContent = rangeInput.value;
});


playButton.addEventListener("click", () => {
    audio.play(); 
});

pauseButton.addEventListener("click", () => {
    audio.pause(); 
});

nextButton.addEventListener("click", () => {
    if (index < songs.length-1) {
        index++;
    } else {
        index = 0;
    }
    audio.setAttribute("src", "/Media/" + songs[index]);
    audio.play(); 

});
