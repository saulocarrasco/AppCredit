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
        };
    },
    methods: {
        loadLoan: function () {

            self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var uriValues = window.location.href.split('/');
            var id = uriValues[uriValues.length - 1];

            var endPoint = 'loan/getloan/'+id;

            instance.get(
                endPoint,
                config
            ).then(function (response) {
                self.loanInformation = response.data;
            }).catch(function (errors) {
                console.log(errors);
            });
        },
        createLoan: function (e) {

            e.preventDefault();

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'loan/createloan/';

            var loanInformationDto = {
                basicInfoLoan: self.basicInfoLoad,
                loanInformation: self.loanInformation,
                customerId: self.customerId
            };

            instance.post(
                endPoint,
                loanInformationDto,
                config
            ).then(function (response) {

                window.location = '/Currentloans/';

            }).catch(function (errors) {

                console.log(errors);

            });
        },
        ingrementIndex: function (index) {
            return index += 1;
        },
    },
    mounted: function () {
        self = this;
        self.dateHelper = new DateHelper();
        self.loadLoan();
    }
});