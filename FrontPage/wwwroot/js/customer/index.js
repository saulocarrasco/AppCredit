var customerVue = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {
           
            customers: [],
            sectionText: "Registro de Fianzas",
            dateHelper: Object,
            addressHelper: Object
        };
    },
    methods: {
       
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
        self.dateHelper = new DateHelper();
        self.addressHelper = new AddressHelper();
        self.loadCustomers();
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
