$(document).ready(function () {
    SelectedManufacturer = "#SelectedManufacturer";
    SelectedModel = "#SelectedModel";
    SelectedVersion = "#SelectedVersion";
        $(SelectedManufacturer).on('change', function () {
            var SelectedManufacturerId = $(SelectedManufacturer).val();
            console.log(SelectedManufacturerId);
            if (SelectedManufacturerId > 0) {
                PriceCalculator.getAutoModel(SelectedManufacturerId);
            }
            else {
                AutoSolutionUtility.showLoader();
                AutoSolutionUtility.addAttribute(SelectedModel, "disabled", true);
                AutoSolutionUtility.addCssClass(SelectedModel, "disabled");
                AutoSolutionUtility.clearHTML("SelectedModel")
                SelectedModel.append($('<option/> ', {
                    value: "",
                    text: "Select Model"
                }));
                AutoSolutionUtility.addAttribute(SelectedVersion, "disabled", true);
                AutoSolutionUtility.addCssClass(SelectedVersion, "disabled");
                AutoSolutionUtility.clearHTML("SelectedVersion")
                AutoSolutionUtility.appendDefaultSelectOption(SelectedVersion, "", "Select Version");
                AutoSolutionUtility.hideLoader();
            }
        })

    $(SelectedModel).on('change', function () {
        var SelectedModelId = $(SelectedModel).val();
        console.log(SelectedModelId);
        if (SelectedModelId > 0) {
            PriceCalculator.getAutoVersion(SelectedModelId);
        }
        else {
            AutoSolutionUtility.addAttribute(SelectedVersion, "disabled", true);
            AutoSolutionUtility.addCssClass(SelectedVersion, "disabled");
            AutoSolutionUtility.clearHTML("SelectedVersion")
            AutoSolutionUtility.appendDefaultSelectOption(SelectedVersion, "", "Select Version");
        }


    })
});


/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto              *
 * -------------------------------------------------------
 */



    var PriceCalculator = {
        PriceCalculatorBaseURL: "/PriceCalCulator/",


        //Penal buttons section
         PriceCalculatorPanelbtn: "_PriceCalculatorPanelbtn",

        //Panel container section
         PriceCalculatorPanelContainer: "_PriceCalculatorPanelContainer",

        //panel section (modal id)
        PriceCalculatorPanel: "_PriceCalculatorPanel",
        PriceCalculatorPanelUpdateTitle:"Update PriceCalculator  ",

        //form Name
        PriceCalculatorForm: "#PriceCalculator ",
        PriceCalculatoreSearchForm:"#PriceCalculatorSearchForm",

        //LookUp Ids
        SelectedManufacturer : "#SelectedManufacturer",
        SelectedModel: "#SelectedModel",
        SelectedVersion: "#SelectedVersion",

        PriceCalculatorGetPanel: "_GetPriceCalculator",

        validdatePriceCalculator: function (event) {
            event.preventDefault();
            $(PriceCalculator.PriceCalculatorForm).validate({
                rules: {
                    PriceCalculatorName: {
                        required: true
                    }
                },
                messages: {
                    PriceCalculatorName: {
                        required: "Name is Required"
                    }
                }
            });

            if ($(PriceCalculator.PriceCalculatorForm).valid()) {
                PriceCalculator.savePriceCalculator();
            }
            else {
                console.log("fuck");
            }
            return false;
        },

        editPriceCalculator: function (id) {
            data = { Id: id }
            var params = autoSolutionService.ajaxParams(data, PriceCalculator.PriceCalculatorBaseURL + 'EditPriceCalculator', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(PriceCalculator.PriceCalculatorPanelContainer);
                AutoSolutionUtility.appendHTML(PriceCalculator.PriceCalculatorPanelContainer, response);
                $("#" + PriceCalculator.PriceCalculatorPanel + " .modal-title").text(PriceCalculator.PriceCalculatorPanelUpdateTitle);
                $("#" + PriceCalculator.PriceCalculatorPanel + " #btnPriceCalculator").html(htmlTemplate.UPDATE_BTN);
                AutoSolutionUtility.showPanel(PriceCalculator.PriceCalculatorPanel);
                AutoSolutionUtility.hideLoader()
            });
        },

        savePriceCalculator: function () {
            var data = AutoSolutionUtility.getFormData(PriceCalculator.PriceCalculatorForm);
            var params = autoSolutionService.ajaxParams(data, PriceCalculator.PriceCalculatorBaseURL + 'PriceCalculatorSave', 'post', false);
            autoSolutionService.defaultService(params).done(function (response) {
                switch (response.status) {
                    case statusCode.UPDATE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                        PriceCalculator.getPriceCalculator();
                        AutoSolutionUtility.hidePanel(PriceCalculator.PriceCalculatorPanelContainer);
                        AutoSolutionUtility.clearHTML(PriceCalculator.PriceCalculatorPanelContainer);
                        break;
                    case statusCode.SAVE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                        PriceCalculator.getPriceCalculator();
                        AutoSolutionUtility.hidePanel(PriceCalculator.PriceCalculatorPanelContainer);
                        AutoSolutionUtility.clearHTML(PriceCalculator.PriceCalculatorPanelContainer);
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

        getAutoModel: function (id) {

            autoSolutionService.getJsonDataById(id, PriceCalculator.PriceCalculatorBaseURL + "GetAutoModelLookUp").done(function (response) {

                console.log(response.data);
                SelectedModel = $(PriceCalculator.SelectedModel);
                SelectedModel.empty();
                AutoSolutionUtility.removeAttribute(SelectedModel, "disabled");
                AutoSolutionUtility.removeCssClass(SelectedModel, "disabled");
                if (response != null && !jQuery.isEmptyObject(response)) {
                    $.each(response.data, function (index, model) {
                        SelectedModel.append($('<option/> ', {
                            value: model.value,
                            text: model.text
                        }));
                    });
                } else {
                    //
                }
            })
        },

        getAutoVersion: function (id) {
            
            autoSolutionService.getJsonDataById(id, PriceCalculator.PriceCalculatorBaseURL + "GetAutoVersionLookUp").done(function (response) {

                console.log(response.data);
                SelectedVersion = $(PriceCalculator.SelectedVersion);
                SelectedVersion.empty();
                AutoSolutionUtility.removeAttribute(SelectedVersion, "disabled");
                AutoSolutionUtility.removeCssClass(SelectedVersion, "disabled");
                if (response != null && !jQuery.isEmptyObject(response)) {
                    $.each(response.data, function (index, version) {
                        SelectedModel.append($('<option/> ', {
                            value: version.value,
                            text: version.text
                        }));
                    });
                } else {
                    //
                }
            })
        },

        Reset: function () {
            AutoSolutionUtility.clearHTML("SelectedModel");
            AutoSolutionUtility.appendDefaultSelectOption(PriceCalculator.SelectedModel, "", "Select Model")
            AutoSolutionUtility.addAttribute(PriceCalculator.SelectedModel, "disabled", true);
            AutoSolutionUtility.addCssClass(PriceCalculator.SelectedModel, "disabled");

            AutoSolutionUtility.clearHTML("SelectedVersion");
            AutoSolutionUtility.appendDefaultSelectOption(PriceCalculator.SelectedVersion, "", "Select Version")
            AutoSolutionUtility.addAttribute(PriceCalculator.SelectedVersion, "disabled", true);
            AutoSolutionUtility.addCssClass(PriceCalculator.SelectedVersion, "disabled");
}


}


/*
 * -------------------------------------------------------
 *                    End Auto                *
 * -------------------------------------------------------
 */