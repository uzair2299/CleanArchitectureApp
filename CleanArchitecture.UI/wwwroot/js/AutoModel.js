$(document).ready(function () {
    autoModel.getAutoModel();
    //autoModel.loadGird();
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



var autoModel = {
    autoModelBaseURL: "/AutoModel/",

    //Penal buttons section
    autoModelPanelbtn: "_AutoModelPanelbtn",

    //Panel container section
    autoModelPanelContainer: "_AutoModelPanelContainer",

    //panel section (modal id)
    autoModelPanel: "_AutoModelPanel",
    autoModelPanelUpdateTitle: "Update Vehicle Model",

    //form Name
    autoModelForm: "#VehicleModel",
    autoManufactuereSearchForm: "#AutoModelSearchForm",

    autoModelGetPanel: "_GetAutoModel",

    validdateAutoModel: function (event) {
        event.preventDefault();
        $(autoModel.autoModelForm).validate({
            ignore: [],
            rules: {
                AutoModelName: {
                    required: true
                },
                SelectedManufacturer: {
                    required:true
                }
            },
            //errorPlacement: function (error, element) {
            //    if (element.attr("name") == "SelectedManufacturer")
            //        error.insertAfter(".select2-container");
            //    else
            //        error.insertAfter(element);
            //},
            messages: {
                AutoModelName: {
                    required: "Model Name is Required"
                },
                SelectedManufacturer: {
                /* To force a user to select an option from a select box, provide an empty options like<option value = "">Choose...</option>*/
                    required: "Select Auto Manufactuere Name"
                }
            }
        });

        if ($(autoModel.autoModelForm).valid()) {
            autoModel.saveAutoModel();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadAutoModelPanel: function () {
        var params = autoSolutionService.ajaxParams('', autoModel.autoModelBaseURL + 'AutoModelSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoModel.autoModelPanelContainer);
            AutoSolutionUtility.appendHTML(autoModel.autoModelPanelContainer, response);
            //AutoSolutionUtility.select2DropDown("SelectedManufacturer");
            AutoSolutionUtility.showPanel(autoModel.autoModelPanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoManufactuer: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, autoModel.autoModelBaseURL + 'EditAutoModel', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoModel.autoModelPanelContainer);
            AutoSolutionUtility.appendHTML(autoModel.autoModelPanelContainer, response);
            $("#" + autoModel.autoModelPanel + " .modal-title").text(autoModel.autoModelPanelUpdateTitle);
            $("#" + autoModel.autoModelPanel + " #btnAutoModel").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(autoModel.autoModelPanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoModel: function () {
        var params = autoSolutionService.ajaxParams($(autoModel.autoModelForm).serialize(), autoModel.autoModelBaseURL + 'AutoModelSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    autoModel.getAutoModel();
                    AutoSolutionUtility.hidePanel(autoModel.autoModelPanelContainer);
                    AutoSolutionUtility.clearHTML(autoModel.autoModelPanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    autoModel.getAutoModel();
                    AutoSolutionUtility.hidePanel(autoModel.autoModelPanelContainer);
                    AutoSolutionUtility.clearHTML(autoModel.autoModelPanelContainer);
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

    getAutoModel: function (data) {
        if (data) {
            data['PageSize'] = $('#pageSize').val();
        }
        var params = autoSolutionService.ajaxParams(data, autoModel.autoModelBaseURL + 'GetAutoModel', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoModel.autoModelGetPanel);
            AutoSolutionUtility.appendHTML(autoModel.autoModelGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            $('#' + autoModel.autoModelGetPanel + ' Table').DataTable({
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
                var params = autoSolutionService.ajaxParams(data, autoModel.autoModelBaseURL + 'DeleteAutoModel', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        autoModel.getAutoModel(data);
                    }
                });
            }
        });
    },

    searchAutoManufacture: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormDat(autoModel.autoManufactuereSearchForm);
        autoModel.getAutoModel(data);
    },
}

/*
 * -------------------------------------------------------
 *                    End Auto Model                     *
 * -------------------------------------------------------
 */