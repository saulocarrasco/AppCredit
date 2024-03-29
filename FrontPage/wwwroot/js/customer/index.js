﻿var customerVue = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {     
            customers: [],
            sectionText: "Registro de Fianzas",
            dateHelper: Object,
            addressHelper: Object,
            currentCustomerId: 0
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

        },
        setCurrentItem: function(id) {
            var self = this;
            self.currentCustomerId = id;
        },
        deleteCustomer: function () {

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = `/customer/delete/${self.currentCustomerId}`;

            instance.get(
                endPoint,
                config
            ).then(function (response) {

                self.loadCustomers();
                alert("El cliente fue borrado de forma exitosa");

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
