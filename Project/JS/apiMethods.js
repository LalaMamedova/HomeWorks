let dataFromApi = [];

export async function get(apisDB){
    await fetch(`https://localhost:7189/${apisDB}`)
    .then(response => response.json())
    .then(data => { 
        dataFromApi = data;
    }).catch(error => console.error('Error:', error));
    
    return dataFromApi;
}
export async function getByEmail(apisDB, email) {
  try {
    const response = await fetch(`https://localhost:7189/${apisDB}/${email}`);
    const data = await response.json();
    console.log('Ответ от сервера:', data);
    return data;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
}

export async function remove(apisDb,id){
    await fetch(`https://localhost:7189/${apisDb}/${id}`, {
        method: 'DELETE',})
        .then(response => response.json()) 
        .then(data => {
          console.log('Ответ от сервера:', data);})
        .catch(error => {
          console.error('Ошибка:', error); 
    });
}
export async function post(apisDb, data) {
  try {
      const response = await fetch(`https://localhost:7189/${apisDb}`, {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(data),
      });

      const responseData = await response.json();
      
      if (response.ok) {
          return { success: true, data: responseData, status: response.status };
      } else {
          return { success: false, error: responseData.error, status: response.status };
      }
  } catch (error) {
      return { success: false, error: error.message };
  }
}
export async function put(apisDb,id,data){
    await fetch( `https://localhost:7189/${apisDb}/${id}`, {
        method: 'PUT',
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify(data),
      })
        .then(response => response.json()) 
        .then(data => {
          console.log('Ответ от сервера:', data);})
        .catch(error => {
          console.error('Ошибка:', error); 
    });
}