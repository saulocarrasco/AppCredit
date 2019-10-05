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
                startDate:''
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
        },
        formatWithMoment: function (date) {
            return moment(date).format("DD/MM/YYYY");
        }
    }
});