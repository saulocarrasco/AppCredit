new Vue({
    el: "#rootElement",
    component: {},
    data: function () {
        return {
            loans: {},
            customers: {},
            paymentsDate: {},
            profit: 0
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
        },
        loadPaymentsDate: function () {
            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'payment/getpaymentsdate/';

            instance.get(
                endPoint,
                config
            ).then(function (response) {

                self.paymentsDate = response.data;

            }).catch(function (errors) {

                console.log(errors);

            });
        },
        getProfits: function () {
            var self = this;
            var profit = 0;

            for (var i = 0; i < self.paymentsDate.length; i++) {
                profit += self.paymentsDate[0].profit;
            }

            return profit.toFixed(2);
        },
        ingrementIndex: function (index) {
            return index += 1;
        },
    },
    mounted: function () {
        var self = this;
        self.loadLoans();
        self.loadCustomers();
        self.loadPaymentsDate();
    }
});