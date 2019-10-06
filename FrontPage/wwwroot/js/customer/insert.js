var customerVue = new Vue({
    el: "#customer",
    components: {
 
    },
    data: function () {
        return {
            dataModel: {
                id: 0,
                name: "",
                lastName: "",
                birthDate: "",
                mobilePhone: "",
                phoneNumber: "",
                identification: "",
                identificationType: "",
                city: "",
                country: "",
                region: "",
                address: ""
            }
        };
    },
    methods: {
        saveFile: function (file) {
            var self = this;
            //MApp.messageBoxWarning("Cargando Adjunto(s).");

            //MApp.ShowFullLoading();

            //var index = 0;

            //if (this.dataForm.fileItems.length > 0) {
            //    index = this.dataForm.fileItems[this.dataForm.fileItems.length - 1].id + 1;
            //}

            //self.dataForm.fileItems.push({ id: index, name: file.name, path: file.path, content: file.content });
            self.dataForm.fileItems.push(file);
            //MApp.HideFullLoading();
            //MApp.messageBoxSuccess("Adjunto(s) preparado(s).");

        },
        downloadListItem: function (path) {
        },
        deteleteListItem: function (id) {
            this.dataForm.fileItems = this.dataForm.fileItems.filter(function (value) {
                return value.id !== id;
            });
        },
        validInput: function () {
            var self = this;

            //var number = String(self.dataForm.bailAmountReal).replace(",", "").replace(".", "");

            //if (isNaN(Number(number))) {
            //    MApp.messageBoxError("Debe ingresar números en el campo: Monto de Fianza");
            //    return false;
            //}

            //return true;
        },
        saveCustomer: function (e) {

            e.preventDefault();

            var self = this;

            const config = { headers: { 'Content-Type': 'application/json' } };

            var endPoint = this.dataModel.id !== 0 ? 'customer/update/' : 'customer/insert/';

            instance.post(
                endPoint,
                self.dataModel,
                config
            ).then(function (response) {

                window.location = "/Customer/";

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
