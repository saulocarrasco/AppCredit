//const AUTH_TOKEN = 'Bearer ' + MApp.getCookie('Authorization')

window.instance = axios.create({
    baseURL: 'https://prestamos.azurewebsites.net/api/'//`${mappUrls.gateway}`
});

//window.instance.defaults.headers.common['Authorization'] = AUTH_TOKEN;