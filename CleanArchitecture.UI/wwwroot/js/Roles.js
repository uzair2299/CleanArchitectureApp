$(document).ready(function () {
    roles.getRoles();
    //roles.loadGird();
});



/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Roles            *
 * -------------------------------------------------------
 */



var roles = {
    rolesBaseURL: "/Roles/",

    //Penal buttons section
    rolesPanelbtn: "_RolesPanelbtn",

    //Panel container section
    rolesPanelContainer: "_RolesPanelContainer",

    //panel section (modal id)
    rolesPanel: "_RolePanel",
    rolesPanelUpdateTitle: "Update Role",

    //form Name
    rolesForm: "#Roles",
    rolesSearchForm: "#RolesSearchForm",

    rolesGetPanel: "_GetRoles",

    validateRole: function (event) {
        event.preventDefault();
        $(roles.rolesForm).validate({
            rules: {
                RoleName: {
                    required: true
                }
            },
            messages: {
                RoleName: {
                    required: "Role Name is Required"
                }
            }
        });

        if ($(roles.rolesForm).valid()) {
            roles.saveRoles();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadRolesPanel: function () {
        var params = autoSolutionService.ajaxParams('', roles.rolesBaseURL + 'SaveRole', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(roles.rolesPanelContainer);
            AutoSolutionUtility.appendHTML(roles.rolesPanelContainer, response);
            AutoSolutionUtility.showPanel(roles.rolesPanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editRole: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, roles.rolesBaseURL + 'EditRole', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(roles.rolesPanelContainer);
            AutoSolutionUtility.appendHTML(roles.rolesPanelContainer, response);
            $("#" + roles.rolesPanel + " .modal-title").text(roles.rolesPanelUpdateTitle);
            $("#" + roles.rolesPanel + " #btnRole").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(roles.rolesPanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveRoles: function () {
        var params = autoSolutionService.ajaxParams($(roles.rolesForm).serialize(), roles.rolesBaseURL + 'SaveRole', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    rolesS.getRoles();
                    AutoSolutionUtility.hidePanel(roles.rolesPanelContainer);
                    AutoSolutionUtility.clearHTML(roles.rolesPanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    roles.getRoles();
                    AutoSolutionUtility.hidePanel(roles.rolesPanelContainer);
                    AutoSolutionUtility.clearHTML(roles.rolesPanelContainer);
                    break;
                case statusCode.ALREADY:
                    AutoSolutionUtility.toastNotifiy(toastType.WARNING, toastMessage.ALREADYEXIST);
                    break;
                default:
                    AutoSolutionUtility.toastNotifiy(toastType.WARNING, toastMessage.ERROR);
            }
            AutoSolutionUtility.hideLoader();
        });
    },

    getRoles: function (data) {
        if (data) {
            data['PageSize'] = $('#pageSize').val();
        }
        var params = autoSolutionService.ajaxParams(data, roles.rolesBaseURL + 'GetRoles', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(roles.rolesGetPanel);
            AutoSolutionUtility.appendHTML(roles.rolesGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }

            $('#' + roles.rolesGetPanel + ' Table').DataTable({
                "searching": false,
                "autoWidth": false,
                "info": false,
                "lengthChange": false,
                "paging": false,
                "columnDefs": [{
                    "targets": -1,
                    "orderable": false
                }]
            });
            AutoSolutionUtility.hideLoader();
        })
    },
    deleteRole: function (id) {
        console.log(id);
        data = { Id: id }
        AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
            if (result.value) {
                var params = autoSolutionService.ajaxParams(data, roles.rolesBaseURL + 'DeleteRole', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        roles.getRoles(data);
                    }
                });
            }
        });
    },

    searchRoles: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormDate(roels.rolesSearchForm);
        roles.getRoles(data);
    },
}

/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */