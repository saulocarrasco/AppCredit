var customerVue = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {

            loans: [],
            sectionText: "Registro de Fianzas",
            dateHelper: Object,
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
        goDetail: function (id) {
            window.location = `/Loan/LoanDetail/${id}`;
        }

    },
    mounted: function () {
        var self = this;
        self.dateHelper = new DateHelper();
        self.loadLoans();
    },
    watch: {
        //"dataForm.appSelected": function (value) {
        //    this.onSelectedAppHandler();
        //},
    }
    //dataForm: {
    //    handler: function () {

    //    },
    //    deep: true
    //}
    //}
});
