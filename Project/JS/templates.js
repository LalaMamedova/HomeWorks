export function cardTemp(id,images,name,year,type,description,interestingfacts){
    let card = `<div id="tech-card"">
            <img src="${images}" alt="${name}">
            <h2>${name}</h2>
            <h6>${year}</h6>
            <h4>${type}</h4>
            <p>${description}</p>
            
            <div class="interest-fact">
                <span id="one-fact-in-temp">${interestingfacts}</span>
            </div>
            
            <div class="tech-card-buttons">
                <button class="crud-btn-template edit-btn" value="edit">Edit</button>
                <button class="crud-btn-template delete-btn"value="delete">Delete</button>
            </div>
            
                <div class="to-full-info-div">
                    <button id="to-full-info-btn" value="info">More info...</button>
                </div>
                <h5>${id}</h5>
        </div>`       
        return card;
}