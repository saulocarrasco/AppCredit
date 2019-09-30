window.FormDataHelper = function () {

    this.createForm = function (properties, model) {
        var formData = new FormData();

        for (var i = 0; i < properties.length; i++) {
            formData.append(properties[i], model[properties[i].toLowerCase()]);
        }

        return formData;
    }

};