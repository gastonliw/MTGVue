export default {
    getApi: (url) => {                
        return fetch(url, {
            method: 'get'
        }).then(function (response) {            
            return response.json();            
        }).then(function (response) {
            return response;
        });
    }
}