var loanForm = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {
            basicInfoLoad: {
                capital: 0,
                bankRate: 0.0,
                quantityAliquot: 0,
                modality: 0,
                startDate: '',
                dateHelper: Object
            },
            loanInformation: {},
            customers: {},
            customerId: 0
        };
    },
    methods: {
        generateLoan: function (e) {

            self = this;

            e.preventDefault();

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'loan/getamortization/';

            instance.post(
                endPoint,
                this.basicInfoLoad,
                config
            ).then(function (response) {
                self.loanInformation = response.data.feeInformations;
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
        ingrementIndex: function (index) {
            return index += 1;
        },
        createLoan: function (e) {

            e.preventDefault();

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'loan/createloan/';

            loanInformationDto = {
                basicInfoLoan: self.basicInfoLoad,
                loanInformation: self.loanInformation,
                customerId: self.customerId
            };

            instance.post(
                endPoint,
                config,
                loanInformationDto
            ).then(function (response) {

                window.location = '/loan/';

            }).catch(function (errors) {

                console.log(errors);

            });
        }
    },
    mounted: function () {
        self = this;
        self.dateHelper = new DateHelper();
        self.loadCustomers();
    }
});