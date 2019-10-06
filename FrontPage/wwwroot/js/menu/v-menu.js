var Menu = Vue.component('v-menu', {
    template: `
        <ul class="nav">
            <li :class="setActualLink(item)" v-for="item in menuOptions">
                <a class="nav-link" asp-area="" :href="getUri(item)">
                    <i class="material-icons">{{item.icon}}</i>
                    <p>{{item.text}}</p>
                </a>
            </li>
        </ul>`,
    props: {
        menuOptions: Array,
        currentController: "",
        currentAction: ""
    },
    methods: {
        setActualLink: function (item) {
       
            if (window.location.href.includes(item.controller) && window.location.href.includes(item.action)) {
                return "nav-item active";
            }

            return "nav-item";
        },
        getUri: function (item) {
            var self = this;

            return `/${item.controller}/${item.action}`;
        }
    },
    mounted: function () {
    }
});


new Vue({
    el: "#menuElement",
    component: Menu,
    data: function () {
        return {
            menuOptions: [
                {
                    text: 'Dashboard',
                    controller: 'Home',
                    action: 'Index',
                    icon: 'dashboard'
                },
                {
                    text: 'Clientes',
                    controller: 'Customer',
                    action: 'Index',
                    icon: 'person'
                },
                {
                    text: 'Prestamos',
                    controller: 'Loan',
                    action: 'Index',
                    icon: 'content_paste'
                }]
        };
    }
});