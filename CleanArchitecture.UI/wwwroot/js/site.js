$(document).ready(function () {
    autoManufacturer.getAutoManufacturer();
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
                    default:
                        AutoSolutionUtility.toastNotifiy(toastType.WARNING, toastMessage.ERROR);
                }
                AutoSolutionUtility.hideLoader();
            });
        },

        getAutoManufacturer: function () {
            var params = autoSolutionService.ajaxParams('', autoManufacturer.autoManufacturerBaseURL + 'GetAutoManufacturer', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerGetPanel);
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerGetPanel, response);
                AutoSolutionUtility.hideLoader();
            })
        },
        deleteAutoManufactuer: function (id) {
            console.log(id);
            AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
                if (result.value) {
                    swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                }
            });
        }
    }

/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */