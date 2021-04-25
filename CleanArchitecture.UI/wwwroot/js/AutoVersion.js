﻿$(document).ready(function () {
    autoVersion.getAutoVersion();
});



/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto Version            *
 * -------------------------------------------------------
 */



var autoVersion = {
    autoVersionBaseURL: "/AutoVersion/",

    //Penal buttons section
    autoVersionPanelbtn: "_AutoVersionPanelbtn",

    //Panel container section
    autoVersionPanelContainer: "_AutoVersionPanelContainer",

    //panel section (modal id)
    autoVersionPanel: "_AutoVersionPanel",
    autoVersionPanelUpdateTitle: "Update Auto Version",

    //form Name
    autoVersionForm: "#VehicleVersion",
    autoVersioneSearchForm: "#AutoVersionSearchForm",

    autoVersionGetPanel: "_GetAutoVersion",

    validdateAutoVersion: function (event) {
        event.preventDefault();
        $(autoVersion.autoVersionForm).validate({
            ignore: [],
            rules: {
                VersionName: {
                    required: true
                },
                SelectedVersionr: {
                    required:true
                }
            },
            //errorPlacement: function (error, element) {
            //    if (element.attr("name") == "SelectedVersionr")
            //        error.insertAfter(".select2-container");
            //    else
            //        error.insertAfter(element);
            //},
            messages: {
                VersionName: {
                    required: "Version Name is Required"
                },
                SelectedVersionr: {
                /* To force a user to select an option from a select box, provide an empty options like<option value = "">Choose...</option>*/
                    required: "Select Auto Versione Name"
                }
            }
        });

        if ($(autoVersion.autoVersionForm).valid()) {
            autoVersion.saveAutoVersion();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadAutoVersionPanel: function () {
        var params = autoSolutionService.ajaxParams('', autoVersion.autoVersionBaseURL + 'AutoVersionSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
            AutoSolutionUtility.appendHTML(autoVersion.autoVersionPanelContainer, response);
            //AutoSolutionUtility.select2DropDown("SelectedVersionr");
            AutoSolutionUtility.showPanel(autoVersion.autoVersionPanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoVersion: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'EditAutoVersion', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
            AutoSolutionUtility.appendHTML(autoVersion.autoVersionPanelContainer, response);
            $("#" + autoVersion.autoVersionPanel + " .modal-title").text(autoVersion.autoVersionPanelUpdateTitle);
            $("#" + autoVersion.autoVersionPanel + " #btnAutoVersion").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(autoVersion.autoVersionPanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoVersion: function () {
        var params = autoSolutionService.ajaxParams($(autoVersion.autoVersionForm).serialize(), autoVersion.autoVersionBaseURL + 'AutoVersionSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    autoVersion.getAutoVersion();
                    AutoSolutionUtility.hidePanel(autoVersion.autoVersionPanelContainer);
                    AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    autoVersion.getAutoVersion();
                    AutoSolutionUtility.hidePanel(autoVersion.autoVersionPanelContainer);
                    AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
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

    getAutoVersion: function (data) {
        if (data) {
            data['PageSize'] = $('#pageSize').val();
        }
        var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'GetAutoVersion', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoVersion.autoVersionGetPanel);
            AutoSolutionUtility.appendHTML(autoVersion.autoVersionGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            $('#' + autoVersion.autoVersionGetPanel + ' Table').DataTable({
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
    deleteAutoVersion: function (id) {
        console.log(id);
        data = { Id: id }
        AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
            if (result.value) {
                var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'DeleteAutoVersion', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        autoVersion.getAutoVersion(data);
                    }
                });
            }
        });
    },

    searchAutoVersion: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormDat(autoVersion.autoVersioneSearchForm);
        autoVersion.getAutoVersion(data);
    },
}

/*
 * -------------------------------------------------------
 *                    End Auto Version                     *
 * -------------------------------------------------------
 */