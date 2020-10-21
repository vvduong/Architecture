var Vpa_Project_Admin = Vpa_Project_Admin || {};

Vpa_Project_Admin.Menus = function (services) {
    'use strict';
    this.uiComponents = {
        menuTable: '.admin-menus-table',
    }
    this.services = services;
}

Vpa_Project_Admin.Menus.prototype = function () {
    'use strict';

    var init = function () {

        $.proxy(initalizeComponents, this)();

        $.proxy(handEvents, this)();

        $(this.uiComponents.menuTable).DataTable();
    }

    var initalizeComponents = function () {

    }

    var handEvents = function () {

    }

    return {
        init: init
    }

}();

