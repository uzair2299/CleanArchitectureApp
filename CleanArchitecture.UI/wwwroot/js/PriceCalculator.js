﻿$(document).ready(function () {
    SelectedManufacturer = "#SelectedAutoManufacturer";
    SelectedModel = "#SelectedAutoModel";
    SelectedVersion = "#SelectedAutoVersion";
        $(SelectedManufacturer).on('change', function () {
            var SelectedManufacturerId = $(SelectedManufacturer).val();
            console.log(SelectedManufacturerId);
            if (SelectedManufacturerId > 0) {
                PriceCalculator.getAutoModel(SelectedManufacturerId);
            }
            else {
                AutoSolutionUtility.showLoader();
                //AutoSolutionUtility.addAttribute(SelectedModel, "disabled", true);
                //AutoSolutionUtility.addCssClass(SelectedModel, "disabled");
                AutoSolutionUtility.clearHTML("SelectedModel")
                SelectedModel.append($('<option/> ', {
                    value: "",
                    text: "Select Model"
                }));
                //AutoSolutionUtility.addAttribute(SelectedVersion, "disabled", true);
                //AutoSolutionUtility.addCssClass(SelectedVersion, "disabled");
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
            //AutoSolutionUtility.addAttribute(SelectedVersion, "disabled", true);
            //AutoSolutionUtility.addCssClass(SelectedVersion, "disabled");
            AutoSolutionUtility.clearHTML("SelectedVersion")
            AutoSolutionUtility.appendDefaultSelectOption(SelectedVersion, "", "Select Version");
        }
    })

    $(".ErrorRemove").on("change", function () {
        let val = $(this).val();
        if (val != null && val != "") {
            $(this).siblings(".invalid-feedback").html("");
            $(this).removeClass("is-invalid");
            //$(this).addClass("is-valid");
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
        SelectedManufacturer : "#SelectedAutoManufacturer",
        SelectedModel : "#SelectedAutoModel",
        SelectedVersion: "#SelectedAutoVersion",

        PriceCalculatorGetPanel: "_GetPriceCalculator",

        //validdatePriceCalculator: function (event) {

        //    event.preventDefault();
        //    AutoSolutionUtility.defaultValidation(PriceCalculator.PriceCalculatorForm);
        //    $(PriceCalculator.PriceCalculatorForm).validate({
        //        rules: {
        //            SelectedManufacturer: {
        //                required: true
        //            },
        //            SelectedModel: {
        //                required: true
        //            },
        //            SelectedVersion: {
        //                required: true
        //            }

        //        },
        //        messages: {
        //            SelectedManufacturer: {
        //                required: "Auto Manufacturer is Required"
        //            },
        //            SelectedModel: {
        //                required: "Auto Model is Required"
        //            },
        //            SelectedVersion: {
        //                required: "Auto Version is Required"
        //            }
        //        }
        //    });

        //    if ($(PriceCalculator.PriceCalculatorForm).valid()) {
        //        PriceCalculator.CalculatePrice();
        //    }
        //    else {
        //        console.log("fuck");
        //    }
        //    return false;
        //},
        
        CalculatePrice: function () {
            var result = AutoSolutionUtility.defaultValidation(PriceCalculator.PriceCalculatorForm);
            if (result) {
                AutoSolutionUtility.showLoader
                var data = AutoSolutionUtility.getFormData(PriceCalculator.PriceCalculatorForm);
                var params = autoSolutionService.ajaxParams(data, PriceCalculator.PriceCalculatorBaseURL + 'GetOnRoadPrice', 'get', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    AutoSolutionUtility.clearHTML(PriceCalculator.PriceCalculatorPanelContainer);
                    AutoSolutionUtility.appendHTML(PriceCalculator.PriceCalculatorPanelContainer, response);
                });
            } else {
                return false;
            }

        },

        getAutoModel: function (id) {

            autoSolutionService.getJsonDataById(id, PriceCalculator.PriceCalculatorBaseURL + "GetAutoModelLookUp").done(function (response) {

                console.log(response.data);
                SelectedModel = $(PriceCalculator.SelectedModel);
                SelectedModel.empty();
                AutoSolutionUtility.removeAttribute(SelectedModel, "disabled");
                AutoSolutionUtility.removeCssClass(SelectedModel, "disabled");
                var otherOptGroup = $("<optgroup label='Other Models' id='Other'>");
                var popularOptGroup = $("<optgroup label='Popular Models' id='Popular'>");
                if (response != null && !jQuery.isEmptyObject(response)) {
                    AutoSolutionUtility.appendDefaultSelectOption(PriceCalculator.SelectedModel, "", "Select Model");

                    //$(SelectedModel).append($('<option/> ', {
                    //    value: "",
                    //    text: "Select Model"
                    //}));
                    $.each(response.data, function (index, model) {
                        if (model.group.name == "Popular Models") {
                            $(popularOptGroup).append($('<option/> ', {
                                value: model.value,
                                text: model.text
                            }));
                        } else {
                            $(otherOptGroup).append($('<option/> ', {
                                value: model.value,
                                text: model.text
                            }));
                        }
                    });
                    SelectedModel.append(popularOptGroup);
                    SelectedModel.append(otherOptGroup);
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
                    //$(SelectedVersion).append($('<option/> ', {
                    //    value: "",
                    //    text: "Select Version"
                    //}));
                    AutoSolutionUtility.appendDefaultSelectOption(PriceCalculator.SelectedVersion, "", "Select Version");
                    $.each(response.data, function (index, version) {
                        SelectedVersion.append($('<option/> ', {
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
            AutoSolutionUtility.setSelectOptionValue(PriceCalculator.SelectedManufacturer, "");

            AutoSolutionUtility.clearHTML("SelectedAutoModel");
            AutoSolutionUtility.appendDefaultSelectOption(PriceCalculator.SelectedModel, "", "Select Model")
            AutoSolutionUtility.addAttribute(PriceCalculator.SelectedModel, "disabled", true);
            AutoSolutionUtility.addCssClass(PriceCalculator.SelectedModel, "disabled");

            AutoSolutionUtility.clearHTML("SelectedAutoVersion");
            AutoSolutionUtility.appendDefaultSelectOption(PriceCalculator.SelectedVersion, "", "Select Version")
            AutoSolutionUtility.addAttribute(PriceCalculator.SelectedVersion, "disabled", true);
            AutoSolutionUtility.addCssClass(PriceCalculator.SelectedVersion, "disabled");
            //var validator = $(PriceCalculator.PriceCalculatorForm).validate();
            //validator.resetForm();
}


}


/*
 * -------------------------------------------------------
 *                    End Auto                *
 * -------------------------------------------------------
 */