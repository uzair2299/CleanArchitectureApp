$(document).ready(function () {
   // AutoSpecification.getAutoSpecification();
});
    


/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto Model            *
 * -------------------------------------------------------
 */



var AutoSpecification = {
    AutoSpecificationBaseURL: "/AutoSpecification/",

    //Penal buttons section
    AutoSpecificationPanelbtn: "_AutoSpecificationPanelbtn",

    //Panel container section
    AutoSpecificationPanelContainer: "_AutoSpecificationPanelContainer",

    //panel section (modal id)
    AutoSpecificationPanel: "_AutoSpecificationPanel",
    AutoSpecificationPanelUpdateTitle: "Update Vehicle Model",

    //form Name
    AutoSpecificationForm: "#AutoSpecification",
    autoManufactuereSearchForm: "#AutoSpecificationSearchForm",

    AutoSpecificationGetPanel: "_GetAutoSpecification",

    validdateAutoSpecification: function (event) {
        event.preventDefault();
        $(AutoSpecification.AutoSpecificationForm).validate({
            ignore: [],
            rules: {
                SpecificationParameter: {
                    required: true
                },
                SpecificationType:{
            required: true
        }
            },
            messages: {
                SpecificationParameter: {
                    required: "Name is Required"
                },

                SpecificationType: {
                /* To force a user to select an option from a select box, provide an empty options like<option value = "">Choose...</option>*/
                    required: "Select Specification Type"
                }
            }
        });

        if ($(AutoSpecification.AutoSpecificationForm).valid()) {
            AutoSpecification.saveAutoSpecification();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadAutoSpecificationPanel: function () {
        var params = autoSolutionService.ajaxParams('', AutoSpecification.AutoSpecificationBaseURL + 'AutoSpecificationSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoSpecification.AutoSpecificationPanelContainer);
            AutoSolutionUtility.appendHTML(AutoSpecification.AutoSpecificationPanelContainer, response);
            //AutoSolutionUtility.select2DropDown("SelectedManufacturer");
            AutoSolutionUtility.showPanel(AutoSpecification.AutoSpecificationPanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoManufactuer: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, AutoSpecification.AutoSpecificationBaseURL + 'EditAutoSpecification', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoSpecification.AutoSpecificationPanelContainer);
            AutoSolutionUtility.appendHTML(AutoSpecification.AutoSpecificationPanelContainer, response);
            $("#" + AutoSpecification.AutoSpecificationPanel + " .modal-title").text(AutoSpecification.AutoSpecificationPanelUpdateTitle);
            $("#" + AutoSpecification.AutoSpecificationPanel + " #btnAutoSpecification").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(AutoSpecification.AutoSpecificationPanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoSpecification: function () {
        var params = autoSolutionService.ajaxParams($(AutoSpecification.AutoSpecificationForm).serialize(), AutoSpecification.AutoSpecificationBaseURL + 'AutoSpecificationSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    AutoSpecification.getAutoSpecification();
                    AutoSolutionUtility.hidePanel(AutoSpecification.AutoSpecificationPanelContainer);
                    AutoSolutionUtility.clearHTML(AutoSpecification.AutoSpecificationPanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    AutoSpecification.getAutoSpecification();
                    AutoSolutionUtility.hidePanel(AutoSpecification.AutoSpecificationPanelContainer);
                    AutoSolutionUtility.clearHTML(AutoSpecification.AutoSpecificationPanelContainer);
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

    getAutoSpecification: function (data) {
        if (data) {
            data['PageSize'] = $('#pageSize').val();
        }
        var params = autoSolutionService.ajaxParams(data, AutoSpecification.AutoSpecificationBaseURL + 'GetAutoSpecification', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoSpecification.AutoSpecificationGetPanel);
            AutoSolutionUtility.appendHTML(AutoSpecification.AutoSpecificationGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            $('#' + AutoSpecification.AutoSpecificationGetPanel + ' Table').DataTable({
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
    deleteAutoManufactuer: function (id) {
        console.log(id);
        data = { Id: id }
        AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
            if (result.value) {
                var params = autoSolutionService.ajaxParams(data, AutoSpecification.AutoSpecificationBaseURL + 'DeleteAutoSpecification', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        AutoSpecification.getAutoSpecification(data);
                    }
                });
            }
        });
    },

    searchAutoManufacture: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormDat(AutoSpecification.autoManufactuereSearchForm);
        AutoSpecification.getAutoSpecification(data);
    },
}

/*
 * -------------------------------------------------------
 *                    End Auto Model                     *
 * -------------------------------------------------------
 */