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
        generateLoan: function (e) {

            self = this;

            e.preventDefault();

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'loan/';

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
        ingrementIndex: function (index) {
            return index += 1;
        }
    },
    mounted: function () {
        self = this;
        self.dateHelper = new DateHelper();
    }
});