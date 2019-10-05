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
            },
            modelProperties: [
                "Id",
                "Name",
                "LastName",
                "BirthDate",
                "MobilePhone",
                "PhoneNumber",
                "Identification",
                "IdentificationType",
                "City",
                "Country",
                "Region",
                "Address"
            ],
            typesBail: [],
            sectionText: "Registro de Fianzas",
            isDetail: false,
            searchState: { 'fa-search': true },
            companies: {
                columns: [
                    //{
                    //    data: "code", "render": function (data, type, row, meta) {
                    //        return row.appAcronymOrigin + '-' + data;
                    //    },
                    //    label: "Código",
                    //},
                    { "data": "rnc", label: "Rnc" },
                    { "data": "companyName", label: "Nombre" },
                    //{
                    //    "data": "inputDate", render: function (data, type, row) {
                    //        return (new Date(data)).toLocaleString();
                    //    },
                    //    label: "Fecha"
                    //},
                    //{ "data": "asignedName", label: "Responsable" },
                    //{ "data": "inputByName", label: "Creado Por" },
                    //{ "data": "statusName", className: "app-status", label: "Estado" },
                    //{ "data": "isInternalString", label: "Interno" },
                    //{ "data": "appAcronym", label: "Aplicación Actual" },
                    {
                        data: null,
                        defaultContent: '',
                        label: 'Acciones'
                    }
                ],
                actions: [{
                    title: "select", innerHTML: "<i class='fa fa-check'> Seleccionar</i>", className: "btn btn-primary",
                    click: this.selectedCompanyHandler
                }]

            },
            employees: {},
            states: {},
            selectedAppStatus: [],
            selectedAppEmployees: [],
            dataTableUriSource: `bailsystem/sigadata/getsigacompany/`,
            ajaxMethod: 'GET',
            datePickerLanguage: {
                days: ['D', 'L', 'M', 'X', 'J', 'V', 'S'],
                months: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthsAbbr: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                language: 'Español',
                yearSuffix: ''
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

                window.location = "/api/customer/";

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
