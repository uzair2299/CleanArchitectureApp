$(document).ready(function () {
    autoBodyType.getAutoBodyType();
   
});



/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto BodyType            *
 * -------------------------------------------------------
 */



    var autoBodyType = {
         autoBodyTypeBaseURL: "/AutoBodyType/",

        //Penal buttons section
         autoBodyTypePanelbtn: "_AutoBodyTypePanelbtn",

        //Panel container section
         autoBodyTypePanelContainer: "_AutoBodyTypePanelContainer",

        //panel section (modal id)
        autoBodyTypePanel: "_AutoBodyTypePanel",
        autoBodyTypePanelUpdateTitle:"Update BodyType BodyType",

        //form Name
        autoBodyTypeForm: "#BodyTypeBodyType",
        autoManufactuereSearchForm:"#AutoBodyTypeSearchForm",

        autoBodyTypeGetPanel: "_GetAutoBodyType",

        validdateAutoBodyType: function (event) {
            event.preventDefault();
            $(autoBodyType.autoBodyTypeForm).validate({
                rules: {
                    BodyType: {
                        required: true
                    }
                },
                messages: {
                    BodyType: {
                        required: "BodyType is Required"
                    }
                }
            });

            if ($(autoBodyType.autoBodyTypeForm).valid()) {
                autoBodyType.saveAutoBodyType();
            }
            else {
                console.log("fuck");
            }
            return false;
        },

        loadAutoBodyTypePanel: function () {
            var params = autoSolutionService.ajaxParams('', autoBodyType.autoBodyTypeBaseURL + 'AutoBodyTypeSave', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoBodyType.autoBodyTypePanelContainer);
                AutoSolutionUtility.appendHTML(autoBodyType.autoBodyTypePanelContainer, response);
                AutoSolutionUtility.showPanel(autoBodyType.autoBodyTypePanel);
                AutoSolutionUtility.hideLoader();
            })
        },

        editAutoManufactuer: function (id) {
            data = { Id: id }
            var params = autoSolutionService.ajaxParams(data, autoBodyType.autoBodyTypeBaseURL + 'EditAutoBodyType', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoBodyType.autoBodyTypePanelContainer);
                AutoSolutionUtility.appendHTML(autoBodyType.autoBodyTypePanelContainer, response);
                $("#" + autoBodyType.autoBodyTypePanel + " .modal-title").text(autoBodyType.autoBodyTypePanelUpdateTitle);
                $("#" + autoBodyType.autoBodyTypePanel + " #btnAutoBodyType").html(htmlTemplate.UPDATE_BTN);
                AutoSolutionUtility.showPanel(autoBodyType.autoBodyTypePanel);
                AutoSolutionUtility.hideLoader()
            });
        },

        saveAutoBodyType: function () {
            var params = autoSolutionService.ajaxParams($(autoBodyType.autoBodyTypeForm).serialize(), autoBodyType.autoBodyTypeBaseURL + 'AutoBodyTypeSave', 'post', false);
            autoSolutionService.defaultService(params).done(function (response) {
                switch (response.status) {
                    case statusCode.UPDATE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                        autoBodyType.getAutoBodyType();
                        AutoSolutionUtility.hidePanel(autoBodyType.autoBodyTypePanelContainer);
                        AutoSolutionUtility.clearHTML(autoBodyType.autoBodyTypePanelContainer);
                        break;
                    case statusCode.SAVE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                        autoBodyType.getAutoBodyType();
                        AutoSolutionUtility.hidePanel(autoBodyType.autoBodyTypePanelContainer);
                        AutoSolutionUtility.clearHTML(autoBodyType.autoBodyTypePanelContainer);
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

        getAutoBodyType: function (data) {
            
            var params = autoSolutionService.ajaxParams(data, autoBodyType.autoBodyTypeBaseURL + 'GetAutoBodyType', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoBodyType.autoBodyTypeGetPanel);
                AutoSolutionUtility.appendHTML(autoBodyType.autoBodyTypeGetPanel, response);
                if (data) {
                    $('#pageSize').val(data.PageSize);
                }
                else {
                    $('#pageSize').val(10);
                }
                $('#' + autoBodyType.autoBodyTypeGetPanel + ' Table').DataTable({
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
                    var params = autoSolutionService.ajaxParams(data, autoBodyType.autoBodyTypeBaseURL + 'DeleteAutoBodyType', 'delete', false);
                    autoSolutionService.defaultService(params).done(function(response){
                        if (response.status) {
                            AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                            var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                            var pageSize = $('#pageSize').val();
                            data = {
                                PageNo: pageNo,
                                PageSize: pageSize
                            }
                            autoBodyType.getAutoBodyType(data);
                        }
                    });
                }
            });
        },

        searchAutoManufacture: function (event) {
            event.preventDefault();
            var data = AutoSolutionUtility.getFormData(autoBodyType.autoManufactuereSearchForm);
            var pageSize = $('#pageSize').val();
            if (pageSize == null || pageSize == undefined) {
                data['PageSize'] = 10;
            } else {
                data['PageSize'] = pageSize;
            }
            autoBodyType.getAutoBodyType(data);
        },


    }

/*
 * -------------------------------------------------------
 *                    End Auto BodyType              *
 * -------------------------------------------------------
 */