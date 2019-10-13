new Vue({
    el: "#rootElement",
    component: {},
    data: function () {
        return {
            loans: {},
            customers: {}
        };
    },
    methods: {
        loadLoans: function () {

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'loan/getloansofdate/';

            instance.get(
                endPoint,
                config
            ).then(function (response) {

                self.loans = response.data;

            }).catch(function (errors) {

                console.log(errors);

            });

        },
        loadCustomers: function () {
            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = '/customer/';

            instance.get(
                endPoint,
                config
            ).then(function (response) {

                self.customers = response.data;

            }).catch(function (errors) {

                console.log(errors);

            });
        }
    },
    mounted: function () {
        var self = this;
        self.loadLoans();
        self.loadCustomers();
    }
});