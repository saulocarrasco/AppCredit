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
        currentController: String,
        currentAction: String
    },
    methods: {
        setActualLink: function (item) {

            if (window.location.pathname  === "/" && item.text === "Dashboard") {
                return "nav-item active";
            }

            if (window.location.href.includes(item.controller) && window.location.href.includes(item.action)) {
                return "nav-item active";
            }

            if (this.isDefaultUri() && item === this.menuOptions[0]) {
                return "nav-item active";
            }

            return "nav-item";
        },
        getUri: function (item) {
            return `/${item.controller}/${item.action}`;
        },
        isDefaultUri: function () {
            var self = this;
            return self.currentController === "Home" && self.currentAction === "Index";
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
                    text: 'Crear prestamo',
                    controller: 'Loan',
                    action: 'Index',
                    icon: 'account_balance_wallet'
                },
                {
                    text: 'Prestamos Actuales',
                    controller: 'Loan',
                    action: 'CurrentLoans',
                    icon: 'list'
                }
            ]
        };
    }
});