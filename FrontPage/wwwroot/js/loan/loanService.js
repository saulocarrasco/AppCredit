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

            if (!self.validInput()) {
                return false;
            }

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

            if (self.customerId == 0) {
                alert("Debe elegir un cliente para crear el prestamo");
                return false;
            }

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

                window.location = '/Loan/Currentloans/';

            }).catch(function (errors) {

                console.log(errors);

            });
        },
        validInput: function () {
            var self = this;

            var message = "";

            if (self.basicInfoLoad.capital == 0) {
                message = "Ingrese el capital a prestar!";
                alert(message);
                return false;
            }

            if (self.basicInfoLoad.bankRate == 0) {
                message = "Ingrese el interes a prestar!";
                alert(message);
                return false;
            }

            if (self.basicInfoLoad.quantityAliquot == 0) {
                message = "Ingrese la cantidad de cuotas!";
                alert(message);
                return false;
            }

            if (self.basicInfoLoad.startDate == "") {
                message = "Debe ingresar la fecha de inicio!";
                alert(message);
                return false;
            }

            if (self.basicInfoLoad.modality == 0) {
                message = "Ingrese la modalidad o metodo de pago";
                alert(message);
                return false;
            }

            return true;

        }
    },
    mounted: function () {
        self = this;
        self.dateHelper = new DateHelper();
        self.loadCustomers();
    }
});