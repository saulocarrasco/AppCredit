DateHelper = function () {

    this.formatWithMoment =  function (date) {
        return moment(date).format("DD/MM/YYYY");
    };
};

