/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */

var baseURL = "/AutoManufacturer/";

//Penal buttons section
var _AutoManufacturerPanelbtn = "_AutoManufacturerPanelbtn"

//Panel container section
var _AutoManufacturerPanelContainer = "_AutoManufacturerPanelContainer";

//panel section (modal id)
var _AutoManufacturerPanel = "_AutoManufacturerPanel"


/*
 * -------------------------------------------------------
 *                    Start Auto Manufacturer            *
 * -------------------------------------------------------
 */
$(document).ready(function () {

    $("#" + _AutoManufacturerPanelbtn).on("click", function () {
        var params = autoSolutionService.ajaxParams('', baseURL + 'AutoManufacturerSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(_AutoManufacturerPanelContainer);
            console.log("Hello")
            AutoSolutionUtility.appendHTML(_AutoManufacturerPanelContainer, response);
            AutoSolutionUtility.showPanel(_AutoManufacturerPanel);
        })
    });
});




/*
 * -------------------------------------------------------
 *                    End Auto Manufacturer              *
 * -------------------------------------------------------
 */