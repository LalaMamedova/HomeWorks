document.addEventListener('DOMContentLoaded', function () {

    const searchBtn = document.querySelector('.search-btn');
    let weatherResDiv =  document.querySelector('.weather-res-div')
    let nullResDiv =  document.querySelector('.null-res-div')
    let mainDiv =  document.querySelector('.main-div');

    searchBtn.addEventListener('click', async () => {
        
        let input = document.querySelector('.city-name-btn');
        weatherResDiv.style.display = 'none';
        let url = `https://api.openweathermap.org/data/2.5/weather?q=${input.value}&appid=2b1fd2d7f77ccf1b7de9b441571b39b8&units=metric`;
        let cityName =  document.querySelector('.city-name').textContent =input.value;
    
        let res = await fetch(url);

        if(res.status >=400){
            weatherResDiv.style.display = 'none';
            nullResDiv.style.display = 'block';
            return;
        } else{
            nullResDiv.style.display = 'none';
            weatherResDiv.style.display = 'flex';
        }

        await changeHTML(await res.json());
        input.value = '';
        
    });


   async function changeHTML(data){
        
        weatherResDiv.style.display = 'flex';
        let temperature =  document.querySelector('.temperature').textContent = data.main.temp+ '\xB0'+'C';
        let humidity =  document.querySelector('.humidity').textContent = data.main.humidity;
        let feelsLike =  document.querySelector('.feels-like').textContent = data.main.feels_like;
        let wind =  document.querySelector('.wind').textContent = data.wind.speed + ' m/s';
        let weatherIcon =  document.querySelector('.weather-icon');
        let body =  document.querySelector('.main-body');


        let mainValues = data.weather.map((weatherItem) => weatherItem.main);
        mainDiv.style.height = '600px';

        switch(mainValues[0]){
            case 'Clear':{
                weatherIcon.src = '/asset/sunny.png';
                mainDiv.style.background = "linear-gradient(to bottom, #96BFFD, #8250E5)";
                body.style.backgroundImage = "url('/backgroundImg/sunny.jpg')";
                setBackgroundImg(body);
                break
            }
            case 'Clouds':{
                weatherIcon.src = '/asset/cloudy.png';
                mainDiv.style.background = "linear-gradient(to bottom, #6C7481, grey)";
                body.style.backgroundImage  = "url('/backgroundImg/clody.jpg')";
                setBackgroundImg(body);
                break
            }
            case 'Rain':{
                weatherIcon.src = '/asset/rainy.png';
                mainDiv.style.background = "linear-gradient(to bottom, #000000,#4A515A )";
                body.style.backgroundImage  = "url('/backgroundImg/rain.jpg')";
                setBackgroundImg(body);
                break
            }
            case 'Snow':{
                weatherIcon.src = '/asset/snowy.png';
                mainDiv.style.background = "linear-gradient(to bottom, white, grey)";
                break
            }
        
        }


    }
});

function setBackgroundImg(body){
    body.style.backgroundRepeat = "no-repeat";
    body.style.backgroundSize = "cover";
  
}