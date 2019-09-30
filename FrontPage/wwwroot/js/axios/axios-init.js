//const AUTH_TOKEN = 'Bearer ' + MApp.getCookie('Authorization')

window.instance = axios.create({
    baseURL: 'http://localhost:59622/api'//`${mappUrls.gateway}`
});

//window.instance.defaults.headers.common['Authorization'] = AUTH_TOKEN;