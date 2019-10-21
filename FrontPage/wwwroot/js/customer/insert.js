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

            var message = "";

            if (self.dataModel.identificationType == "") {
                message = "Debe elegir un tipo de identificacion!";
                alert(message);
                return false;
            }

            if (self.dataModel.identification == "") {
                message = "Debe ingresar el numero de identificacion!";
                alert(message);
                return false;
            }

            if (self.dataModel.name == "") {
                message = "Debe ingresar el nombre del cliente!"; 
                alert(message);
                return false;
            }

            if (self.dataModel.lastName == "") {
                message = "Debe ingresar el apellido del cliente";
                alert(message);
                return false;
            }

            if (self.dataModel.birthDate == "") {
                message = "Debe ingresar la fecha de nacimiento!";
                alert(message);
                return false;
            }

            if (self.dataModel.mobilePhone == "") {
                message = "Debe ingresar el celular del cliente";
                alert(message);
                return false;
            }

            if (self.dataModel.phoneNumber == "") {
                message = "Debe ingresar el telefono del cliente";
                alert(message);
                return false;
            }

            if (self.dataModel.address == "") {
                message = "Debe ingresar una direccion para el cliente";
                alert(message);
                return false;
            }

            return true;

        },
        saveCustomer: function (e) {

            e.preventDefault();

            var self = this;

            if (!self.validInput()) {
                return false;
            }

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
