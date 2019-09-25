var customerVue = new Vue({
    el: "#form-bail",
    components: {
 
    },
    data: function () {
        return {
            dataForm: {
                name: "",
                lastName: "",
                birthDate: "",
                mobilePhone: "",
                phone: "",
                address: "",
                identification: "",
                identificationType: "",
                city: "",
                country: ""
            },
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

            if (!self.dataForm.declarationNo.isValidStr()) {
                MApp.messageBoxError("Ingrese el número de declaración");
                return false;
            }

            if (self.dataForm.typeId === 0 || !self.dataForm.typeId) {
                MApp.messageBoxError("Seleccione el tipo de fianza");
                return false;
            }

            if (!self.dataForm.importer.isValidStr()) {
                MApp.messageBoxError("Ingrese el Importador");
                return false;
            }

            if (!self.dataForm.regime.isValidStr()) {
                MApp.messageBoxError("Ingrese el régimen");
                return false;
            }

            if (self.dataForm.policyNumber === 0 || !self.dataForm.policyNumber) {
                MApp.messageBoxError("Ingrese la póliza de seguro");
                return false;
            }

            //if (!self.dataForm.rncInsureceCompany.isValidStr()) {
            //    MApp.messageBoxError("Seleccione la compañia de seguros.");
            //    return false;
            //}

            //if (!self.dataForm.insureCompanyName.isValidStr()) {
            //    MApp.messageBoxError("Ingrese la compañia de seguro");
            //    return false;
            //}

            if (!self.dataForm.selectedEnsure.isValidStr()) {
                MApp.messageBoxError("Ingrese la compañia de seguro");
                return false;
            }

            if (self.dataForm.issueDate === '' || self.dataForm.issueDate.length == 0) {
                MApp.messageBoxError("Ingrese el día de emisión");
                return false;
            }

            if (self.dataForm.expiryDate === '' || self.dataForm.expiryDate.length == 0) {
                MApp.messageBoxError("Ingrese el día de expiración");
                return false;
            }

            if (self.dataForm.bailAmountExpected <= 0) {
                MApp.messageBoxError("Ingrese el monto de la fianza");
                return false;
            }

            if (self.dataForm.bailAmountReal <= 0) {
                MApp.messageBoxError("Ingrese el monto de la fianza");
                return false;
            }

            var number = String(self.dataForm.bailAmountReal).replace(",", "").replace(".", "");

            if (isNaN(Number(number))) {
                MApp.messageBoxError("Debe ingresar números en el campo: Monto de Fianza");
                return false;
            }

            //if ((self.dataForm.bailAmountExpected !== self.dataForm.bailAmountReal) && (self.dataForm.justify == '' || self.dataForm.justify.length == 0)) {
            //    $("#modal-confirm").modal('show'); 
            //    return false;
            //}  

            return true;
        },
        sameAmountBail: function () {
            var self = this;
            return self.dataForm.bailAmountExpected == self.dataForm.bailAmountReal;
        },
        saveBail: function () {

            var self = this;

            if (!self.validInput()) {
                return false;
            }

            this.dataForm.comment = $('.summernote').summernote("code");

            MApp.ShowFullLoading();

            var form = new FormData();

            form.append("declarationNo", this.dataForm.declarationNo);
            form.append("importer", this.dataForm.importer);
            form.append("rncImporter", this.dataForm.rncImporter);
            form.append("regime", this.dataForm.regime);
            form.append("rncInsureceCompany", this.dataForm.rncInsureceCompany);
            form.append("insureCompanyName", this.dataForm.insureCompanyName);
            form.append("initDate", moment(this.dataForm.initDate).format('YYYY-MM-DD HH:mm:ss'));
            form.append("issueDate", moment(this.dataForm.issueDate).format('YYYY-MM-DD HH:mm:ss'));
            form.append("expiryDate", moment(this.dataForm.expiryDate).format('YYYY-MM-DD HH:mm:ss'));
            form.append("bailReliquidatedAmount", this.dataForm.bailReliquidatedAmount);
            form.append("bailAmountExpected", this.dataForm.bailAmountExpected);
            form.append("bailAmountReal", this.dataForm.bailAmountReal);
            form.append("comment", this.dataForm.comment);
            form.append("justify", this.dataForm.justify);
            form.append("asignTo", this.dataForm.asignTo);
            form.append("requestState", this.dataForm.requestState);
            form.append("policyNumber", this.dataForm.policyNumber);
            form.append("typeId", this.dataForm.typeId);
            form.append("updateUser", this.dataForm.updateUser);
            form.append("appSelected", this.dataForm.appSelected);
            form.append("selectedEnsure", this.dataForm.selectedEnsure);
            form.append("refurbishment", this.dataForm.refurbishment);
            form.append("id", this.dataForm.id);
            form.append("userName", $("#userName").val());

            for (var index = 0; index < this.dataForm.fileItems.length; index++) {
                //console.log(fileToSend[index].content);
                form.append("fileItems", this.dataForm.fileItems[index]);
            }

            const config = { headers: { 'Content-Type': 'multipart/form-data' } };

            var endPoint = this.dataForm.id !== "" ? 'bailsystem/bail/updatebail/' : 'bailsystem/bail/addbail/';

            instance.post(
                endPoint,
                form,
                config
            ).then(function (response) {

                self.clearInputs();
                MApp.HideFullLoading();
                MApp.messageBoxSuccess("Los cambios fueron guardados satisfactoriamente.");
                window.location = "/Apps/bailsystem/home/bails";

            }).catch(function (errors) {

                MApp.ShowFullLoading();
                console.log(errors);

            });

        },
        searchDeclaration: function () {
            var self = this;

            if (self.dataForm.declarationNo === "") {
                MApp.messageBoxError("Ingrese el número de declaración que desea buscar");
                return false;
            }
            this.searchState = { 'fa-spin': true, 'fa-spinner': true };

            instance.get(
                `bailsystem/sigadata/getdeclaration?declarationNo=${this.dataForm.declarationNo}`
            ).then(function (response) {

                var reponseData = response.data;

                if (reponseData) {

                    if (reponseData[0]) {
                        self.dataForm.declarationNo = reponseData[0].declarationNo;
                        self.dataForm.bailAmountExpected = reponseData[0].bailAmountExpected;
                        self.dataForm.importer = reponseData[0].importer;
                        self.dataForm.regime = reponseData[0].regime;
                        self.dataForm.rncImporter = reponseData[0].rncImporter;

                        if (reponseData.length > 1) {
                            self.dataForm.bailReliquidatedAmount = reponseData[1].bailAmountExpected;
                        }
                    } else {
                        MApp.messageBoxError('No se encontraron datos, para el número de declaración proporcionado.');
                    }
                } else {
                    MApp.messageBoxError('No se encontraron datos, para el número de declaración proporcionado.');
                }

            }).finally(function () {
                self.searchState = { 'fa-search': true };
            });
        },
        modalConfirmationHandle: function () {
            var self = this;

            if (self.dataForm.justify === "") {
                MApp.messageBoxError('Escriba una justificación para guardar');
                return false;
            } else {
                $("#modal-confirm").modal("toggle");
            }
        },
        cancelBailHandler: function () {
            this.clearInputs();
        },
        selectedCompanyHandler: function (event, element, row) {
            console.log(row);
            this.dataForm.rncInsureceCompany = row.rnc;
            this.dataForm.insureCompanyName = row.companyName;
            this.dataForm.selectedEnsure = row.companyName;

            $("#modal-employee").modal("toggle");
        },
        clearInputs: function () {
            var self = this;

            self.dataForm.declarationNo = "";
            self.dataForm.importer = "";
            self.dataForm.rncImporter = "";
            self.dataForm.regime = "";
            self.dataForm.noBail = 0;
            self.dataForm.rncInsureceCompany = "";

            self.dataForm.initDate = "";
            self.dataForm.issueDate = "";
            self.dataForm.expiryDate = "";

            self.dataForm.bailAmountExpected = 0;
            self.dataForm.bailAmountReal = 0;
            self.dataForm.reliquidatedAmount = 0;

            self.dataForm.comment = "";
            self.dataForm.fileItems = [];
            self.dataForm.justify = "";
            self.dataForm.asignTo = "";
            self.dataForm.requestState = "";
            self.dataForm.typeId = 0;
            self.dataForm.policyNumber = 0;
            self.dataForm.updateUser = "";
            self.dataForm.selectedEnsure = "";
            self.requestState = "";
            self.dataForm.refurbishment = false;
        },
        onSelectedAppHandler: function () {
            var self = this;
            this.selectedAppStatus = this.states[this.dataForm.appSelected];
            this.selectedAppEmployees = this.employees[this.dataForm.appSelected];
        },
        downloadListItem: function (path) {

            var extension = (path != undefined ? path.split(".")[1] : null);

            var mime = getMimeType(extension);

            var url = `${mappUrls.gateway}/bailsystem/bail/getfile?url=${encodeURIComponent(path)}&mimeType=${encodeURIComponent(mime)}`;

            window.open(url, "_blank");
        }

    },
    mounted: function () {

        var self = this;

        var url_string = window.location.href;
        var url = new URL(url_string);
        var id = url.searchParams.get("id");
        var caseId = url.searchParams.get("caseId");
        var mode = url.searchParams.get("mode");

        instance.get(`bailsystem/bail/getchildcatalog?parent=bail`).then(function (response) {

            self.typesBail = response.data;
            /* self.typesBail.map(function (value, index) {
                 currentAplications.push(value.acronym.toUpperCase());
             });*/

        }).then(function () {
            if (id) {

                self.sectionText = "Actualización De Fianza";

                instance.get(
                    `bailsystem/bail/getbail?id=${id}`
                ).then(function (response) {

                    self.dataForm = response.data || {};
                    $('.summernote').summernote("code", self.dataForm.comment);

                }).then(function () {

                    if (mode && mode === "detail") {

                        $('.summernote').summernote('disable');

                        //setTimeout(() => {
                        //    $('.justifyText').summernote("code", self.dataForm.justify);
                        //    $('.justifyText').summernote('disable');
                        //}, 2);

                        self.sectionText = "Información de Fianza";
                        self.isDetail = true;

                    } else if (id) {
                        self.sectionText = "Actualización De Fianza";
                        self.dataForm.fileItems = [];
                    } else {
                        self.sectionText = "Registro De Fianza";
                    }
                });
            }
        });
    },
    watch: {
        "dataForm.appSelected": function (value) {
            this.onSelectedAppHandler();
        },
    }
    //dataForm: {
    //    handler: function () {

    //    },
    //    deep: true
    //}
    //}
});
