$(document).ready(function () {
   // AutoSpecificationSub.getAutoSpecificationSub();
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



var AutoSpecificationSub = {
    AutoSpecificationSubBaseURL: "/AutoSpecificationSub/",

    SelectedpecificationType : "#SelectedpecificationType",
    SelectedSpecificationParameter: "#SelectedSpecificationParameter",
    
    //Penal buttons section
    AutoSpecificationSubPanelbtn: "_AutoSpecificationSubPanelbtn",

    //Panel container section
    AutoSpecificationSubPanelContainer: "_AutoSpecificationSubPanelContainer",

    //panel section (modal id)
    AutoSpecificationSubPanel: "_AutoSpecificationSubPanel",
    AutoSpecificationSubPanelUpdateTitle: "Update Vehicle Model",

    //form Name
    AutoSpecificationSubForm: "#AutoSpecificationSub",
    autoManufactuereSearchForm: "#AutoSpecificationSubSearchForm",

    AutoSpecificationSubGetPanel: "_GetAutoSpecificationSub",

    validdateAutoSpecificationSub: function (event) {
        event.preventDefault();
        $(AutoSpecificationSub.AutoSpecificationSubForm).validate({
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

        if ($(AutoSpecificationSub.AutoSpecificationSubForm).valid()) {
            AutoSpecificationSub.saveAutoSpecificationSub();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadAutoSpecificationSubPanel: function () {
        var params = autoSolutionService.ajaxParams('', AutoSpecificationSub.AutoSpecificationSubBaseURL + 'AutoSpecificationSubSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoSpecificationSub.AutoSpecificationSubPanelContainer);
            AutoSolutionUtility.appendHTML(AutoSpecificationSub.AutoSpecificationSubPanelContainer, response);
            //AutoSolutionUtility.select2DropDown("SelectedManufacturer");
            AutoSolutionUtility.showPanel(AutoSpecificationSub.AutoSpecificationSubPanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoManufactuer: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, AutoSpecificationSub.AutoSpecificationSubBaseURL + 'EditAutoSpecificationSub', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoSpecificationSub.AutoSpecificationSubPanelContainer);
            AutoSolutionUtility.appendHTML(AutoSpecificationSub.AutoSpecificationSubPanelContainer, response);
            $("#" + AutoSpecificationSub.AutoSpecificationSubPanel + " .modal-title").text(AutoSpecificationSub.AutoSpecificationSubPanelUpdateTitle);
            $("#" + AutoSpecificationSub.AutoSpecificationSubPanel + " #btnAutoSpecificationSub").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(AutoSpecificationSub.AutoSpecificationSubPanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoSpecificationSub: function () {
        var data = AutoSolutionUtility.getFormData(AutoSpecificationSub.AutoSpecificationSubForm);
        var params = autoSolutionService.ajaxParams(data, AutoSpecificationSub.AutoSpecificationSubBaseURL + 'AutoSpecificationSubSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    AutoSpecificationSub.getAutoSpecificationSub();
                    AutoSolutionUtility.hidePanel(AutoSpecificationSub.AutoSpecificationSubPanelContainer);
                    AutoSolutionUtility.clearHTML(AutoSpecificationSub.AutoSpecificationSubPanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    AutoSpecificationSub.getAutoSpecificationSub();
                    AutoSolutionUtility.hidePanel(AutoSpecificationSub.AutoSpecificationSubPanelContainer);
                    AutoSolutionUtility.clearHTML(AutoSpecificationSub.AutoSpecificationSubPanelContainer);
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

    getAutoSpecificationSub: function (data) {
        if (data) {
            data['PageSize'] = $('#pageSize').val();
        }
        var params = autoSolutionService.ajaxParams(data, AutoSpecificationSub.AutoSpecificationSubBaseURL + 'GetAutoSpecificationSub', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoSpecificationSub.AutoSpecificationSubGetPanel);
            AutoSolutionUtility.appendHTML(AutoSpecificationSub.AutoSpecificationSubGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            $('#' + AutoSpecificationSub.AutoSpecificationSubGetPanel + ' Table').DataTable({
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
                var params = autoSolutionService.ajaxParams(data, AutoSpecificationSub.AutoSpecificationSubBaseURL + 'DeleteAutoSpecificationSub', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        AutoSpecificationSub.getAutoSpecificationSub(data);
                    }
                });
            }
        });
    },

    searchAutoManufacture: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormDat(AutoSpecificationSub.autoManufactuereSearchForm);
        AutoSpecificationSub.getAutoSpecificationSub(data);
    },

    getSpecficationParameterLookup: function (element) {
        console.log(element.value);
        var id = element.value
        autoSolutionService.getJsonDataById(id, AutoSpecificationSub.AutoSpecificationSubBaseURL + "GetSpecficationParameterLookup").done(function (response) {

            console.log(response.data);
            SelectedSpecificationParameter = $(AutoSpecificationSub.SelectedSpecificationParameter);
            SelectedSpecificationParameter.empty();
            AutoSolutionUtility.removeAttribute(SelectedSpecificationParameter, "disabled");
            AutoSolutionUtility.removeCssClass(SelectedSpecificationParameter, "disabled");

            if (response != null && !jQuery.isEmptyObject(response)) {
                AutoSolutionUtility.appendDefaultSelectOption(AutoSpecificationSub.SelectedSpecificationParameter, "", "Select Specification Parameter");
                $.each(response.data, function (index, model) {
                    $(AutoSpecificationSub.SelectedSpecificationParameter).append($('<option/> ', {
                            value: model.value,
                            text: model.text
                        }));
                    })
            } 
        })
    },
}

/*
 * -------------------------------------------------------
 *                    End Auto Model                     *
 * -------------------------------------------------------
 */