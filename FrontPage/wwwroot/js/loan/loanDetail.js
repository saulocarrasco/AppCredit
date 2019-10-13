var loanForm = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {
            loanId: 0,
            Id: 0,
            loanInformation: {}
        };
    },
    methods: {
        loadLoan: function () {

            self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var uriValues = window.location.href.split('/');
            var id = uriValues[uriValues.length - 1];
            self.loanId = id;
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
        payFee: function () {

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'loan/payFee/';

            var feeInformation = {
                loanId: self.loanId,
                Id: self.Id
            };

            instance.post(
                endPoint,
                feeInformation,
                config
            ).then(function (response) {

                window.location.reload();

            }).catch(function (errors) {

                console.log(errors);

            });
        },
        ingrementIndex: function (index) {
            return index += 1;
        },
        setCurrentFee: function (id) {
            var self = this;
            self.Id = id;
        }
    },
    mounted: function () {
        self = this;
        self.dateHelper = new DateHelper();
        self.loanHelper = new LoanHelper();
        self.loadLoan();
    }
});