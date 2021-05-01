$(document).ready(function () {
    autoEngineType.getAutoEngineType();
    autoEngineType.loadGird();
});



/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto EngineType            *
 * -------------------------------------------------------
 */



var autoEngineType = {
    autoEngineTypeBaseURL: "/AutoEngineType/",

    //Penal buttons section
    autoEngineTypePanelbtn: "_AutoEngineTypePanelbtn",

    //Panel container section
    autoEngineTypePanelContainer: "_AutoEngineTypePanelContainer",

    //panel section (modal id)
    autoEngineTypePanel: "_AutoEngineTypePanel",
    autoEngineTypePanelUpdateTitle: "Update Vehicle EngineType",

    //form Name
    autoEngineTypeForm: "#VehicleEngineType",
    autoManufactuereSearchForm: "#AutoEngineTypeSearchForm",

    autoEngineTypeGetPanel: "_GetAutoEngineType",

    validdateAutoEngineType: function (event) {
        event.preventDefault();
        $(autoEngineType.autoEngineTypeForm).validate({
            rules: {
                AutoEngineTypeName: {
                    required: true
                },
            },
            messages: {
                AutoEngineTypeName: {
                    required: "EngineType Name is Required"
                }
            },
        }); 

        if ($(autoEngineType.autoEngineTypeForm).valid()) {
            autoEngineType.saveAutoEngineTypeCopy();
        }
        else {
            console.log("fuck");
        }
        return false;
    },

    loadAutoEngineTypePanel: function () {
        var params = autoSolutionService.ajaxParams('', autoEngineType.autoEngineTypeBaseURL + 'AutoEngineTypeSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypePanelContainer);
            AutoSolutionUtility.appendHTML(autoEngineType.autoEngineTypePanelContainer, response);
            AutoSolutionUtility.showPanel(autoEngineType.autoEngineTypePanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoManufactuer: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, autoEngineType.autoEngineTypeBaseURL + 'EditAutoEngineType', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypePanelContainer);
            AutoSolutionUtility.appendHTML(autoEngineType.autoEngineTypePanelContainer, response);
            $("#" + autoEngineType.autoEngineTypePanel + " .modal-title").text(autoEngineType.autoEngineTypePanelUpdateTitle);
            $("#" + autoEngineType.autoEngineTypePanel + " #btnAutoEngineType").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(autoEngineType.autoEngineTypePanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoEngineType: function () {
        var params = autoSolutionService.ajaxParams($(autoEngineType.autoEngineTypeForm).serialize(), autoEngineType.autoEngineTypeBaseURL + 'AutoEngineTypeSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    autoEngineType.getAutoEngineType();
                    AutoSolutionUtility.hidePanel(autoEngineType.autoEngineTypePanelContainer);
                    AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypePanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    autoEngineType.getAutoEngineType();
                    AutoSolutionUtility.hidePanel(autoEngineType.autoEngineTypePanelContainer);
                    AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypePanelContainer);
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

    getAutoEngineType: function (data) {

        var params = autoSolutionService.ajaxParams(data, autoEngineType.autoEngineTypeBaseURL + 'GetAutoEngineType', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypeGetPanel);
            AutoSolutionUtility.appendHTML(autoEngineType.autoEngineTypeGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            else {
                $('#pageSize').val(10);
            }
            $('#' + autoEngineType.autoEngineTypeGetPanel + ' Table').DataTable({
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

    deleteAutoManufactuer: function (id, element) {
        
        console.log(id);
        data = { Id: id }
        AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
            if (result.value) {
                var params = autoSolutionService.ajaxParams(data, autoEngineType.autoEngineTypeBaseURL + 'DeleteAutoEngineType', 'delete', false);
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
                        autoEngineType.getAutoEngineType(data);
                    }
                });
            }
        });
    },

    searchAutoManufacture: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormData(autoEngineType.autoManufactuereSearchForm);
        var pageSize = $('#pageSize').val();
        if (pageSize == null || pageSize == undefined) {
            data['PageSize'] = 10;
        } else {
            data['PageSize'] = pageSize;
        }
        autoEngineType.getAutoEngineType(data);
    },


    loadGird: function () {
        // begin first table
        return $('#kt_table_1').DataTable({
            retrieve: true,
            responsive: true,
            // Pagination settings
            dom: `<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
            // read more: https://datatables.net/examples/basic_init/dom.html

            lengthMenu: [5, 10, 25, 50],

            pageLength: 10,

            language: {
                'lengthMenu': 'Display _MENU_',
            },

            searchDelay: 500,
            processing: true,
            serverSide: true,
            ajax: {
                url: '/Auto/GetAutoEngineTypeU',
                type: 'POST',

                data: {
                    // parameters for custom backend script demo
                    columnsDef: [
                        'autoEngineTypeName', 'Actions'],
                },
                dataSrc: function (response) {
                    return response.result;
                }
            },
            columns: [
                { data: 'autoEngineTypeName' },
                { data: 'id', responsivePriority: -1, width: 120 },
            ],

            initComplete: function () {
                this.api().columns().every(function () {
                    var column = this;
                });
            },

            columnDefs: [
                {
                    targets: -1,
                    title: 'Actions',
                    orderable: false,
                    render: function (data, type, full, meta) {
                        var id = data;
                        return '<button title="View Details" type="button" class="btnView btn btn-outline-hover-dark btn-sm btn-icon"  data-id="@item.Id"><i class="la la-eye"></i></button><button title="Edit" type="button" class="btnEdit btn btn-outline-hover-dark btn-sm btn-icon" onclick=autoEngineType.editAutoManufactuer(' + data + ')><i class="la la-edit"></i></button><button title="Delete" type="button" class="btnDelete btn btn-outline-hover-danger btn-sm btn-icon" onclick= autoEngineType.deleteAutoManufactuer(' + data + ')><i class="la la-trash"></i></button>';
                    },
                },
            ],
        });
    },

    previewImage: function (element, imageHolder) {
        AutoSolutionUtility.fileReader(element, imageHolder);
    },

    saveAutoEngineTypeCopy: function () {
        var data = AutoSolutionUtility.getFormDataWithFile(autoEngineType.autoEngineTypeForm);
        var params = autoSolutionService.ajaxParamsForFileUpload(data, autoEngineType.autoEngineTypeBaseURL + 'AutoEngineTypeSave', 'post', true, false, false);
        autoSolutionService.defaultServiceWithFile(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    autoEngineType.getAutoEngineType();
                    AutoSolutionUtility.hidePanel(autoEngineType.autoEngineTypePanelContainer);
                    AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypePanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    autoEngineType.getAutoEngineType();
                    AutoSolutionUtility.hidePanel(autoEngineType.autoEngineTypePanelContainer);
                    AutoSolutionUtility.clearHTML(autoEngineType.autoEngineTypePanelContainer);
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
 *                    End Auto EngineType              *
 * -------------------------------------------------------
 */