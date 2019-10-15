var userVue = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {
            dataModel: {
                userName: "",
                email: "",
                passWord: ""
            }
        };
    },
    methods: {
        saveUser: function (e) {

            e.preventDefault();

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint =  'authentication/insertuser/';

            instance.post(
                endPoint,
                self.dataModel,
                config
            ).then(function (response) {

                window.location = "/Account/";

            }).catch(function (errors) {

                console.log(errors);

            });

        }
    },
    mounted: function () {
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
