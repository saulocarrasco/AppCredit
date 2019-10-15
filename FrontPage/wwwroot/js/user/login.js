var userVue = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {
            dataModel: {
                userNameOrEmail: "",
                passWord: ""
            }
        };
    },
    methods: {
        saveUser: function () {


            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = 'authentication/login/';

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
