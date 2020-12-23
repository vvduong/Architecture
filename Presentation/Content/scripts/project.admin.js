var Vpa_Project_Admin = Vpa_Project_Admin || {};

Vpa_Project_Admin.Menus = function (services) {
    'use strict';
    this.uiComponents = {
        menuIsActiveSwitch: '.admin-menu-is-active',
        menuAddButton: '#admin-menu-add-button',
        menuEditButton: '.admin-menu-edit-button',
        menuDeleteButton: '.admin-menu-delete-button',
        menuDynamicContent: '#admin-menus-dynamic-content',
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
        $(this.uiComponents.menuIsActiveSwitch).bootstrapSwitch({
            onText: 'Kích hoạt',
            offText: 'Tạm dừng'
        });
    }

    var handEvents = function () {
        $(this.uiComponents.menuIsActiveSwitch).on('switchChange.bootstrapSwitch', $.proxy(handlers.menuIsActiveSwitchOnSwitchChangeHandler, this));
        $(this.uiComponents.menuAddButton).on('click', $.proxy(handlers.menuAddButtonOnClickHandler, this));
        $(this.uiComponents.menuEditButton).on('click', $.proxy(handlers.menuEditButtonOnClickHandler, this));
        $(this.uiComponents.menuDeleteButton).on('click', $.proxy(handlers.menuDeleteButtonOnClickHandler, this));
    }

    var handlers = {
        menuIsActiveSwitchOnSwitchChangeHandler: function (event, state) {
            var $currentTarget = $(event.currentTarget);
            this.services.post({
                url: baseUri + 'admin/menus/UpdateMenuActiveState',
                data: {
                    id: $currentTarget.data('id'),
                    isActive: state
                }
            }).done(function (result) {
                if (result) {
                    toastr.success('Cập nhật trạng thái thành công');
                }
            });
        },
        menuEditButtonOnClickHandler: function (event) {
            var $currentTarget = $(event.currentTarget);
            this.services.load({
                selector: this.uiComponents.menuDynamicContent,
                url: baseUri + 'admin/menus/AddEditMenu',
                data: {
                    id: $currentTarget.data('id')
                }
            }).done(function () {
                var addEditmenu = Vpa_Project.Injector.resolveDependency(Vpa_Project_Admin.AddEditMenu);
                addEditmenu.init(true);
                addEditmenu.onModalSaved = function (result) {
                    $('#' + result.ID).children('td:nth-child(1)').text(result.Name);
                    if (result.IsActive) {
                        if (!$('.admin-menu-is-active[data-id="' + result.ID + '"]').is(':checked')) {
                            $('.admin-menu-is-active[data-id="' + result.ID + '"]').bootstrapSwitch('state', true, true);
                        }
                    }
                    else {
                        if ($('.admin-menu-is-active[data-id="' + result.ID + '"]').is(':checked')) {
                            $('.admin-menu-is-active[data-id="' + result.ID + '"]').bootstrapSwitch('state', false, true);
                        }
                    }
                }
            });
        },
        menuDeleteButtonOnClickHandler: function (event) {
            var $currentTarget = $(event.currentTarget);
            this.services.post({
                url: baseUri + 'admin/menus/DeleteMenu',
                data: {
                    id: $currentTarget.data('id')
                }
            }).done($.proxy(function (result) {
                if (result) {
                    $('#' + $currentTarget.data('id')).remove();
                }
            }, this));;
        },
        menuAddButtonOnClickHandler: function () {
            this.services.load({
                selector: this.uiComponents.menuDynamicContent,
                url: baseUri + 'admin/menus/AddEditmenu'
            }).done(function () {
                var addEditmenu = LacViet_SurePortal.Injector.resolveDependency(Vpa_Project_Admin.AddEditmenu);
                addEditmenu.init(false);
                addEditmenu.onModalSaved = function (result) {
                    this.services.get({
                        url: baseUri + 'admin/menus'
                    }).done($.proxy(function (result) {
                        var html = '';
                        for (var i = 0; i < result.length; i++) {
                            html += '<tr id="' + result[i].ID + '">';
                            html += '<td class="td100 text-center">' + result[i].Name + '</td>';
                            html += '<td class="td100 text-center">';
                            var check = '';
                            if (result[i].IsActive) {
                                check = 'checked';
                            }
                            else {
                                check = '';
                            }
                            html += '<input data-id="' + result[i].ID + '" type="checkbox" class="admin-menu-is-active" ' + check + ' />';
                            html += '</td>';
                            html += '<td class="td100 text-center">' + result[i].MapingID + '</td>';
                            html += '</td>';
                            html += '<td class="td100 text-center">';
                            html += '<a data-id="' + result[i].ID + '" class="btn btn-circle btn-icon-only yellow admin-menu-edit-button"><i class="fa fa-edit"></i></a>';
                            html += '<a data-id="' + result[i].ID + '" class="btn btn-circle btn-icon-only red admin-menu-delete-button"><i class="fa fa-trash"></i></a>';
                            html += '</td>';
                            html += '</tr>';
                        }
                        $('#admin-menu-table').html(html);
                        LacViet_SurePortal.Injector.resolveDependency(Vpa_Project_Admin.Menus).init();
                    }, this));
                }
            });
        }
    }

    return {
        init: init
    }

}();

//// ---- Add Edit Admin Menu ----- ////
// constructor
Vpa_Project_Admin.AddEditMenu = function (services) {
    'use strict';
    // variables from external source, get from init
    this.isEdit = false;
    // UI Components
    this.uiComponents = {
        addEditMenuModal: '#add-edit-admin-menu-modal',
        addEditMenuIsActive: '.add-edit-admin-menu-is-active',
        addEditMenuSaveButton: '#add-edit-admin-menu-save-button',
        editMenuID: '#edit-admin-menu-id',
        editMenuName: '#edit-admin-menu-name',
        editMenuMapingID: '#edit-admin-menu-maping-id',
        editMenuIsActive: '#edit-admin-menu-is-active',
        addMenuName: '#add-admin-menu-name',
        addMenuMapingID: '#add-admin-menu-maping-id',
        addMenuIsActive: '#add-admin-menu-is-active'
    };
    // dependency
    this.services = services;
    this.onModalSaved;
};
// prototype
Vpa_Project_Admin.AddEditMenu.prototype = function () {
    'use strict';
    var init = function (isEdit) {
        // initialize variables from external source
        this.isEdit = isEdit;
        // initialize components
        $.proxy(initializeComponents, this)();
        // handle events
        $.proxy(handleEvents, this)();
        // show modal when everything is ready
        $(this.uiComponents.addEditMenuModal).modal('show');
    };
    var initializeComponents = function () {
        $(this.uiComponents.addEditMenuIsActive).bootstrapSwitch({
            onText: 'Kích hoạt',
            offText: 'Tạm dừng'
        });
    };
    var handleEvents = function () {
        $(this.uiComponents.addEditMenuSaveButton).on('click', $.proxy(handlers.addEditMenuSaveButtonOnClickHandler, this));
    };
    var handlers = {
        addEditMenuSaveButtonOnClickHandler: function () {
            if (this.isEdit) {
                if ($(this.uiComponents.editMenuName).val() === '') {
                    $(this.uiComponents.editMenuName).notify('Tên không thể để trống', "error");
                }
                else {
                    var model = {
                        ID: $(this.uiComponents.editMenuID).text(),
                        Name: $(this.uiComponents.editMenuName).val(),
                        IsActive: $(this.uiComponents.editMenuIsActive).is(':checked')
                    }
                    this.services.post({
                        url: baseUri + 'admin/menus/EditMenu',
                        data: model
                    }).done($.proxy(function () {
                        $(this.uiComponents.addEditMenuModal).modal('hide');
                        this.onModalSaved(model);
                    }, this));
                }
            }
            else {
                if ($(this.uiComponents.addMenuName).val() === '') {
                    $(this.uiComponents.addMenuName).notify('Tên không thể để trống', "error");
                }
                else {
                    var model = {
                        Name: $(this.uiComponents.addMenuName).val(),
                        IsActive: $(this.uiComponents.addMenuIsActive).is(':checked'),
                    }
                    console.log(model);
                    this.services.post({
                        url: baseUri + 'admin/menus/AddMenu',
                        data: model
                    }).done($.proxy(function () {
                        $(this.uiComponents.addEditMenuModal).modal('hide');
                        this.onModalSaved(model);
                    }, this));
                }
            }
        }
    }
    return {
        init: init
    }
}();

