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

        saveAutoManufacturer: function () {
            var params = autoSolutionService.ajaxParams($(autoManufacturer.autoManufacturerForm).serialize(), autoManufacturer.autoManufacturerBaseURL + 'AutoManufacturerSave', 'post', false);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                AutoSolutionUtility.hidePanel(autoManufacturer.autoManufacturerPanelContainer);
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerPanelContainer);
                AutoSolutionUtility.hideLoader();
                //AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerPanelContainer, response);
                //AutoSolutionUtility.showPanel(autoManufacturer.autoManufacturerPanel);
            });
        },

        getAutoManufacturer: function () {
            var params = autoSolutionService.ajaxParams('', autoManufacturer.autoManufacturerBaseURL + 'GetAutoManufacturer', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerGetPanel);
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerGetPanel, response);
                AutoSolutionUtility.hideLoader();
            })
        }
    }




/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */