'use strict';

cdkApp.factory('validationErrorsParser', function () {
    var fac = {};

    fac.parseError = function (err) {
        if (err.data) {
            if (err.data.ModelState) {
                var errorMessages = [];
                for (var key in err.data.ModelState) {
                    var value = err.data.ModelState[key];

                    if (value && value.length) {
                        for (var i = 0; i < value.length; i++) {
                            errorMessages.push(value[i]);
                        }
                    }
                }

                return errorMessages;
            }
        }

        if (err.error_description) {
            return [err.error_description];
        }



        return [];
    };

    return fac;
});