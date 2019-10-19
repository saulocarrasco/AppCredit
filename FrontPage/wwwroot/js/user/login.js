var userVue = new Vue({
    el: "#rootElement",
    components: {

    },
    data: function () {
        return {
            dataModel: {
                userNameOrEmail: "",
                password: ""
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

                if (response.data) {
                    self.setCookie("TrueUser", "true", 1);
                    window.location = "/Home/Index";
                } 

            }).catch(function (errors) {

                console.log(errors);

            });

        },
        setCookie: function (cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toUTCString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
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
