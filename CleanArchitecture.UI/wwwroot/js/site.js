$(document).ready(function () {
    autoManufacturer.getAutoManufacturer();
    autoManufacturer.loadGird();
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



    var autoManufacturer = {
         autoManufacturerBaseURL: "/AutoManufacturer/",

        //Penal buttons section
         autoManufacturerPanelbtn: "_AutoManufacturerPanelbtn",

        //Panel container section
         autoManufacturerPanelContainer: "_AutoManufacturerPanelContainer",

        //panel section (modal id)
        autoManufacturerPanel: "_AutoManufacturerPanel",
        autoManufacturerPanelUpdateTitle:"Update Vehicle Manufacturer",

        //form Name
        autoManufacturerForm: "#VehicleManufacturer",

        autoManufacturerGetPanel: "_GetAutoManufacturer",

        validdateAutoManufacturer: function (event) {
            event.preventDefault();
            $(autoManufacturer.autoManufacturerForm).validate({
                rules: {
                    AutoManufacturerName: {
                        required: true
                    }
                },
                messages: {
                    AutoManufacturerName: {
                        required: "Manufacturer Name is Required"
                    }
                }
            });

            if ($(autoManufacturer.autoManufacturerForm).valid()) {
                autoManufacturer.saveAutoManufacturer();
            }
            else {
                console.log("fuck");
            }
            return false;
        },

        loadAutoManufacturerPanel: function () {
            var params = autoSolutionService.ajaxParams('', autoManufacturer.autoManufacturerBaseURL + 'AutoManufacturerSave', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerPanelContainer);
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerPanelContainer, response);
                AutoSolutionUtility.showPanel(autoManufacturer.autoManufacturerPanel);
                AutoSolutionUtility.hideLoader();
            })
        },

        editAutoManufactuer: function (id) {
            data = { Id: id }
            var params = autoSolutionService.ajaxParams(data, autoManufacturer.autoManufacturerBaseURL + 'EditAutoManufacturer', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerPanelContainer);
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerPanelContainer, response);
                $("#" + autoManufacturer.autoManufacturerPanel + " .modal-title").text(autoManufacturer.autoManufacturerPanelUpdateTitle);
                $("#" + autoManufacturer.autoManufacturerPanel + " #btnAutoManufacturer").html(htmlTemplate.UPDATE_BTN);
                AutoSolutionUtility.showPanel(autoManufacturer.autoManufacturerPanel);
                AutoSolutionUtility.hideLoader()
            });
        },

        saveAutoManufacturer: function () {
            var params = autoSolutionService.ajaxParams($(autoManufacturer.autoManufacturerForm).serialize(), autoManufacturer.autoManufacturerBaseURL + 'AutoManufacturerSave', 'post', false);
            autoSolutionService.defaultService(params).done(function (response) {
                switch (response.status) {
                    case statusCode.UPDATE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                        autoManufacturer.getAutoManufacturer();
                        AutoSolutionUtility.hidePanel(autoManufacturer.autoManufacturerPanelContainer);
                        AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerPanelContainer);
                        break;
                    case statusCode.SAVE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                        autoManufacturer.getAutoManufacturer();
                        AutoSolutionUtility.hidePanel(autoManufacturer.autoManufacturerPanelContainer);
                        AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerPanelContainer);
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

        getAutoManufacturer: function (data) {
            var params = autoSolutionService.ajaxParams(data, autoManufacturer.autoManufacturerBaseURL + 'GetAutoManufacturer', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerGetPanel);
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerGetPanel, response);
                $('#' + autoManufacturer.autoManufacturerGetPanel + ' Table').DataTable({
                    "searching": false,
                    "autoWidth": false,
                    "info": false,
                    "lengthChange": false,
                    "paging": false,
                });
                AutoSolutionUtility.hideLoader();
            })
        },
        deleteAutoManufactuer: function (id) {
            console.log(id);
            data = { Id: id }
            AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
                if (result.value) {
                    var params = autoSolutionService.ajaxParams(data, autoManufacturer.autoManufacturerBaseURL + 'DeleteAutoManufacturer', 'delete', false);
                    autoSolutionService.defaultService(params).done(function(response){
                        if (response.status) {
                            AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                            var table = autoManufacturer.loadGird();
                            table.ajax.reload();
                        }
                    });
                    
                    //console.log(table);

                }
            });
        },


        loadGird :function () {
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
						url: '/Auto/GetAutoManufacturerU',
						type: 'POST',

						data: {
							// parameters for custom backend script demo
							columnsDef: [
								'autoManufacturerName', 'Actions'],
						},
						dataSrc: function (response) {
							return response.result;
						}
					},
					columns: [
						{ data: 'autoManufacturerName' },
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
								return '<button title="View Details" type="button" class="btnView btn btn-outline-hover-dark btn-sm btn-icon"  data-id="@item.Id"><i class="la la-eye"></i></button><button title="Edit" type="button" class="btnEdit btn btn-outline-hover-dark btn-sm btn-icon" onclick=autoManufacturer.editAutoManufactuer(' + data + ')><i class="la la-edit"></i></button><button title="Delete" type="button" class="btnDelete btn btn-outline-hover-danger btn-sm btn-icon" onclick= autoManufacturer.deleteAutoManufactuer(' + data + ')><i class="la la-trash"></i></button>';
							},
						},
					],
				});			
        }
    }

/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */