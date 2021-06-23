$(document).ready(function () {
    //AutoLookUpType.getAutoLookUpType();
   });



/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto Manufacturer            *
 * -------------------------------------------------------
 */



var AutoLookUpType = {
    AutoLookUpTypeBaseURL: "/AutoLookUpType/",

    //Penal buttons section
    AutoLookUpTypePanelbtn: "_AutoLookUpTypePanelbtn",

    //Panel container section
    AutoLookUpTypePanelContainer: "_AutoLookUpTypePanelContainer",

    //panel section (modal id)
    AutoLookUpTypePanel: "_AutoLookUpTypePanel",
    AutoLookUpTypePanelUpdateTitle: "Update Vehicle Manufacturer",

    //form Name
    AutoLookUpTypeForm: "#AutoLookUpType",
    autoManufactuereSearchForm: "#AutoLookUpTypeSearchForm",

    AutoLookUpTypeGetPanel: "_GetAutoLookUpType",

    validdateAutoLookUpType: function (event) {
        event.preventDefault();
        $(AutoLookUpType.AutoLookUpTypeForm).validate({
            rules: {
                LookUpTypeName: {
                    required: true
                }
            },
            messages: {
                LookUpTypeName: {
                    required: "Type is Required"
                }
            },
        }); 

        if ($(AutoLookUpType.AutoLookUpTypeForm).valid()) {
            AutoLookUpType.saveAutoLookUpTypeCopy();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadAutoLookUpTypePanel: function () {
        var params = autoSolutionService.ajaxParams('', AutoLookUpType.AutoLookUpTypeBaseURL + 'AutoLookUpTypeSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypePanelContainer);
            AutoSolutionUtility.appendHTML(AutoLookUpType.AutoLookUpTypePanelContainer, response);
            AutoSolutionUtility.showPanel(AutoLookUpType.AutoLookUpTypePanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoLookUpType: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, AutoLookUpType.AutoLookUpTypeBaseURL + 'EditAutoLookUpType', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypePanelContainer);
            AutoSolutionUtility.appendHTML(AutoLookUpType.AutoLookUpTypePanelContainer, response);
            $("#" + AutoLookUpType.AutoLookUpTypePanel + " .modal-title").text(AutoLookUpType.AutoLookUpTypePanelUpdateTitle);
            $("#" + AutoLookUpType.AutoLookUpTypePanel + " #btnAutoLookUpType").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(AutoLookUpType.AutoLookUpTypePanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoLookUpType: function () {
        var params = autoSolutionService.ajaxParams($(AutoLookUpType.AutoLookUpTypeForm).serialize(), AutoLookUpType.AutoLookUpTypeBaseURL + 'AutoLookUpTypeSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    AutoLookUpType.getAutoLookUpType();
                    AutoSolutionUtility.hidePanel(AutoLookUpType.AutoLookUpTypePanelContainer);
                    AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypePanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    AutoLookUpType.getAutoLookUpType();
                    AutoSolutionUtility.hidePanel(AutoLookUpType.AutoLookUpTypePanelContainer);
                    AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypePanelContainer);
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

    getAutoLookUpType: function (data) {

        var params = autoSolutionService.ajaxParams(data, AutoLookUpType.AutoLookUpTypeBaseURL + 'GetAutoLookUpType', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypeGetPanel);
            AutoSolutionUtility.appendHTML(AutoLookUpType.AutoLookUpTypeGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            else {
                $('#pageSize').val(10);
            }
            $('#' + AutoLookUpType.AutoLookUpTypeGetPanel + ' Table').DataTable({
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

    deleteAutoLookUpType: function (id, element) {
        
        console.log(id);
        data = { Id: id }
        AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
            if (result.value) {
                var params = autoSolutionService.ajaxParams(data, AutoLookUpType.AutoLookUpTypeBaseURL + 'DeleteAutoLookUpType', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        //for future use tested
                        //$(element).closest('tr').remove();
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        AutoLookUpType.getAutoLookUpType(data);
                    }
                });
            }
        });
    },

    searchAutoManufacture: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormData(AutoLookUpType.autoManufactuereSearchForm);
        var pageSize = $('#pageSize').val();
        if (pageSize == null || pageSize == undefined) {
            data['PageSize'] = 10;
        } else {
            data['PageSize'] = pageSize;
        }
        AutoLookUpType.getAutoLookUpType(data);
    },



    previewImage: function (element, imageHolder) {
        AutoSolutionUtility.fileReader(element, imageHolder);
    },

    saveAutoLookUpTypeCopy: function () {
        var data = AutoSolutionUtility.getFormDataWithFile(AutoLookUpType.AutoLookUpTypeForm);
        var params = autoSolutionService.ajaxParamsForFileUpload(data, AutoLookUpType.AutoLookUpTypeBaseURL + 'AutoLookUpTypeSave', 'post', true, false, false);
        autoSolutionService.defaultServiceWithFile(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    AutoLookUpType.getAutoLookUpType();
                    AutoSolutionUtility.hidePanel(AutoLookUpType.AutoLookUpTypePanelContainer);
                    AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypePanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    AutoLookUpType.getAutoLookUpType();
                    AutoSolutionUtility.hidePanel(AutoLookUpType.AutoLookUpTypePanelContainer);
                    AutoSolutionUtility.clearHTML(AutoLookUpType.AutoLookUpTypePanelContainer);
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
}

/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */