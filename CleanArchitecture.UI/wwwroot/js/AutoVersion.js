$(document).ready(function () {
    autoVersion.getAutoVersion();
});



/*
 * -------------------------------------------------------
 *                    Global Variables                   *
 * -------------------------------------------------------
 */






/*
 * -------------------------------------------------------
 *                    Start Auto Version            *
 * -------------------------------------------------------
 */


let singleImage = []
let multipleImage = []

var autoVersion = {

    autoVersionBaseURL: "/AutoVersion/",

    //Penal buttons section
    autoVersionPanelbtn: "_AutoVersionPanelbtn",

    //Panel container section
    autoVersionPanelContainer: "_AutoVersionPanelContainer",

    //panel section (modal id)
    autoVersionPanel: "_AutoVersionPanel",
    autoVersionPanelUpdateTitle: "Update Auto Version",

    //form Name
    autoVersionForm: "#AutoVersion",
    autoVersioneSearchForm: "#AutoVersionSearchForm",

    //select
    selectedAutoModel: "#SelectedAutoModel",

    autoVersionGetPanel: "_GetAutoVersion",

    validdateAutoVersion: function () {


        var result = AutoSolutionUtility.defaultValidation(autoVersion.autoVersionForm);
        return result ? true : false
        //event.preventDefault();
        //        $(autoVersion.autoVersionForm).validate({
        //            ignore: [],
        //            rules: {
        //                SelectedManufacturer: {
        //                    required: true
        //                },
        //                SelectedAutoModel: {
        //                    required: true
        //                },
        //                AutoVersionName: {
        //                    required: true
        //                }
        //            },
        //    //errorPlacement: function (error, element) {
        //    //    if (element.attr("name") == "SelectedVersionr")
        //    //        error.insertAfter(".select2-container");
        //    //    else
        //    //        error.insertAfter(element);
        //    //},
        //    messages: {
        //        SelectedManufacturer: {
        //            required: "Required"
        //        },
        //        SelectedAutoModel: {
        //            /* To force a user to select an option from a select box, provide an empty options like<option value = "">Choose...</option>*/
        //            required: "Required"
        //        },
        //        AutoVersionName: {
        //            required: true
        //        }
        //    }
        //});

        //if ($(autoVersion.autoVersionForm).valid()) {
        //    return true;
        //}
        //else {
        //    return false;
        //}
        //return false;
    },

    loadAutoVersionPanel: function () {
        data = { isQuickAdd: true }
        var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'AutoVersionSave', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
            AutoSolutionUtility.appendHTML(autoVersion.autoVersionPanelContainer, response);
            var today = new Date();
            //var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0 so need to add 1 to make it 1!
            var yyyy = today.getFullYear();
            var minYear = yyyy - 50;
            //if (dd < 10) {
            //    dd = '0' + dd
            //}
            if (mm < 10) {
                mm = '0' + mm
            }
            today = yyyy + '-' + mm;
            $("#startMonth").val(today);
            $('#startMonth').attr('min', "1950-01");
            $('#startMonth').attr('max', today);
            //document.getElementById("startMonth").setAttribute("min", today);

            //AutoSolutionUtility.select2DropDown("SelectedVersionr");
            //$('body .kt_datepicker_1_modal').datepicker({
            //    rtl: KTUtil.isRTL(),
            //    todayHighlight: true,
            //    orientation: "bottom left",

            //});
            $('#test').inputmask('a9[99]/9[9]R99.99');
            AutoSolutionUtility.showPanel(autoVersion.autoVersionPanel);
            AutoSolutionUtility.hideLoader();
        })
    },

    editAutoVersion: function (id) {
        data = { Id: id }
        var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'EditAutoVersion', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
            AutoSolutionUtility.appendHTML(autoVersion.autoVersionPanelContainer, response);
            $("#" + autoVersion.autoVersionPanel + " .modal-title").text(autoVersion.autoVersionPanelUpdateTitle);
            $("#" + autoVersion.autoVersionPanel + " #btnAutoVersion").html(htmlTemplate.UPDATE_BTN);
            AutoSolutionUtility.showPanel(autoVersion.autoVersionPanel);
            AutoSolutionUtility.hideLoader()
        });
    },

    saveAutoVersion: function () {
        var data = AutoSolutionUtility.getFormData(autoVersion.autoVersionForm);
        var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'AutoVersionSave', 'post', false);
        autoSolutionService.defaultService(params).done(function (response) {
            switch (response.status) {
                case statusCode.UPDATE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                    autoVersion.getAutoVersion();
                    AutoSolutionUtility.hidePanel(autoVersion.autoVersionPanelContainer);
                    AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
                    break;
                case statusCode.SAVE:
                    AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                    autoVersion.getAutoVersion();
                    AutoSolutionUtility.hidePanel(autoVersion.autoVersionPanelContainer);
                    AutoSolutionUtility.clearHTML(autoVersion.autoVersionPanelContainer);
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

    getAutoVersion: function (data) {
        if (data) {
            data['PageSize'] = $('#pageSize').val();
        }
        var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'GetAutoVersion', 'get', true);
        autoSolutionService.defaultService(params).done(function (response) {
            AutoSolutionUtility.clearHTML(autoVersion.autoVersionGetPanel);
            AutoSolutionUtility.appendHTML(autoVersion.autoVersionGetPanel, response);
            if (data) {
                $('#pageSize').val(data.PageSize);
            }
            $('#' + autoVersion.autoVersionGetPanel + ' Table').DataTable({
                responsive: false,
                "searching": false,
                "autoWidth": false,
                "info": false,
                "lengthChange": false,
                "paging": false,
                "columnDefs": [{
                    "targets": [0, -1],
                    "orderable": false
                }],
                "order": []
            });
            /*Note
             * By default order is [0, 'asc'].use order: [] if you not want any default order at all
             */
            AutoSolutionUtility.hideLoader();
        })
    },

    deleteAutoVersion: function (id) {
        console.log(id);
        data = { Id: id }
        AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
            if (result.value) {
                var params = autoSolutionService.ajaxParams(data, autoVersion.autoVersionBaseURL + 'DeleteAutoVersion', 'delete', false);
                autoSolutionService.defaultService(params).done(function (response) {
                    if (response.status) {
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                        var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                        var pageSize = $('#pageSize').val();
                        data = {
                            PageNo: pageNo,
                            PageSize: pageSize
                        }
                        autoVersion.getAutoVersion(data);
                    }
                });
            }
        });
    },

    searchAutoVersion: function (event) {
        event.preventDefault();
        var data = AutoSolutionUtility.getFormDat(autoVersion.autoVersioneSearchForm);
        autoVersion.getAutoVersion(data);
    },

    getAutoModelLookup: function (element) {
        AutoSolutionUtility.onCangeValidation(element)
        console.log(element.value);
        var id = element.value
        autoSolutionService.getJsonDataById(id, autoVersion.autoVersionBaseURL + "GetAutoModelLookUp").done(function (response) {

            console.log(response.data);
            SelectedModel = $(autoVersion.selectedAutoModel);
            SelectedModel.empty();

            //if (response != null && !jQuery.isEmptyObject(response)) {
            //    $.each(response.data, function (index, version) {
            //        SelectedModel.append($('<option/> ', {
            //            value: version.value,
            //            text: version.text
            //        }));
            //    });
            //}

            if (response.data.length > 1 && !jQuery.isEmptyObject(response.data)) {
                var otherOptGroup = $("<optgroup label='Other Models' id='Other'>");
                var popularOptGroup = $("<optgroup label='Popular Models' id='Popular'>");

                AutoSolutionUtility.clearHTML(SelectedModel);
                AutoSolutionUtility.appendDefaultSelectOption(autoVersion.selectedAutoModel, "", "Select Model");
                AutoSolutionUtility.removeAttribute(SelectedModel, "disabled");
                AutoSolutionUtility.removeCssClass(SelectedModel, "disabled");


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
                $(document).on('change', autoVersion.selectedAutoModel, AutoSolutionUtility.onCangeValidation)
                $(autoVersion.selectedAutoModel).select2();
            } else {
                $(SelectedModel).siblings('div').html("");
                AutoSolutionUtility.appendDefaultSelectOption(autoVersion.selectedAutoModel, "", "Select Model");
                $(autoVersion.selectedAutoModel).select2();
                AutoSolutionUtility.addAttribute(SelectedModel, "disabled", true);
                AutoSolutionUtility.addCssClass(SelectedModel, "disabled");

            }
        })
    },

    defaultImage: function (event, element, imageContainer) {
        singleImage = AutoSolutionUtility.image_select(event, element);
        document.getElementById(imageContainer).innerHTML = autoVersion.showDefaultImage(singleImage, imageContainer);
    },

    gallaryImage: function (event, element, imageContainer) {
        multipleImage = AutoSolutionUtility.image_select(event, element);
        document.getElementById(imageContainer).innerHTML = autoVersion.showGallaryImage(multipleImage, imageContainer);
    },


    showDefaultImage: function (images) {
        var image = "";
        images.forEach((i) => {
            image += '<div class="image_container d-flex justify-content-center position-relative">' +
                '<img src= ' + i.url + ' alt="Image">' +
                '<span class="position-absolute" onclick="autoVersion.deleteDefaultImage(' + images.indexOf(i) + ')" > <i class="fa fa-trash-alt"></i></span ></div>'
        })

        return image;
    },

    showGallaryImage: function (images) {
        var image = "";
        images.forEach((i) => {
            image += '<div class="image_container d-flex justify-content-center position-relative">' +
                '<img src= ' + i.url + ' alt="Image">' +
                '<span class="position-absolute" onclick="autoVersion.deleteGallaryImage(' + images.indexOf(i) + ')" > <i class="fa fa-trash-alt"></i></span ></div>'
        })

        return image;
    },
    deleteDefaultImage: function (index) {
        AutoSolutionUtility.deleteImage(event, singleImage);
        document.getElementById('singlecontainer').innerHTML = autoVersion.showDefaultImage(singleImage);
    },

    deleteGallaryImage: function (index) {
        AutoSolutionUtility.deleteImage(event, multipleImage);
        document.getElementById('MultipleImageContainer').innerHTML = autoVersion.showGallaryImage(multipleImage);
    },
}

/*
 * -------------------------------------------------------
 *                    End Auto Version                     *
 * -------------------------------------------------------
 */