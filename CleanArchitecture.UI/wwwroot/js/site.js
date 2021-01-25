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
                console.log("hello");
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
                console.log("Hello")
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerPanelContainer, response);
                AutoSolutionUtility.showPanel(autoManufacturer.autoManufacturerPanel);
            })
        },

        saveAutoManufacturer: function () {
            var params = autoSolutionService.ajaxParams($(autoManufacturer.autoManufacturerForm).serialize(), autoManufacturer.autoManufacturerBaseURL + 'AutoManufacturerSave', 'post', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(autoManufacturer.autoManufacturerPanelContainer);
                console.log("OKK")
                AutoSolutionUtility.appendHTML(autoManufacturer.autoManufacturerPanelContainer, response);
                AutoSolutionUtility.showPanel(autoManufacturer.autoManufacturerPanel);
            });
        }
    }




/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */