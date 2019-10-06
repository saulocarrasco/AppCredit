AddressHelper = function () {

    this.format = function (addresses)
    {
        if (addresses && addresses.length > 0)
        {
            return addresses[0].street + " " + addresses[0].city + " " + addresses[0].region;
        }

        return "";
    };
};
