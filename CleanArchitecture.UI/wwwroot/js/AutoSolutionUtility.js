//global variable
//Variable and function names written as camelCase
//Global variables written in UPPERCASE

//var singleImage = [];
//var gallaryImages = [];

const IMAGECONTAINERTYPE = {
    singleContainer: 'singlecontainer',
    gallaryImages: 'GallaryImages'
}


const toastType = {
    Error: 'error',
    INFO: 'info',
    WARNING: 'warning',
    SUCCESS: 'success',
};

const statusCode = {
    UPDATE: 'Update',
    FAIL: 'fail',
    SAVE: 'save',
    DELETE: 'delete',
    ALREADY: 'exist'
}

const toastMessage = {
    SAVE: 'Save Successfully',
    ERROR: 'Opps...Some Thing Went Wrong',
    UPDATE: 'Update Successfully',
    DELETE: 'Delete Successfully',
    ALREADYEXIST: 'Record Already Exist'
};

const htmlTemplate = {
    UPDATE_BTN: '<i class="fa fa-pencil-alt"></i> Update'
}


var AutoSolutionUtility = {

    clearHTML_: function (containerId) {
        $("#" + containerId).html("");
    },

    clearHTML: function (containerId) {
        $(containerId).html("");
    },

    appendHTML: function (containerId, response) {
        $("#" + containerId).append(response);
    },

    showPanel: function (containerId) {
        $("#" + containerId).modal('show');
    },

    hidePanel: function (containerId) {
        $("#" + containerId).modal('hide');
        $('.modal-backdrop').remove();
    },


    //loader show/hide
    showLoader: function () {
        $("#loaderdiv").show();
    },

    hideLoader: function () {
        $("#loaderdiv").hide();
    },


    //toast notification
    toastNotifiy: function (type, message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        toastr[type](message);
    },

    deleteConfirmationBox: function () {
        return swal.fire({
            title: 'Are you sure?',
            width: 600,
            heightAuto: false,
            confirmButtonColor: '#282a3c',
            cancelButtonColor: '#fd397a',
            showCancelButton: true,
            showCloseButton: true,
            allowOutsideClick: false,
            scrollbarPadding: false,
            confirmButtonText: '<i class="mr-2 fa fa-times"></i>Yes, delete it!',
            cancelButtonText: '<i class="mr-2 fa fa-trash-alt"></i>Cancel'
        })
    },


    //get form data
    getFormData: function (formId) {
        var data = {};
        var SelectedItems = [];
        $(formId).find('input[type=text],input[type=number],input[type=password],input[type=hidden]').each(function () {
            if (this.id) {
                data[this.id] = this.value.trim();
            }
        });
        $(formId).find('input[type=checkbox]').each(function () {
            if ($(this).prop("checked") == true) {
                SelectedItems.push(this.value)
                console.log(this.value);
            }
            data['SelectedItems'] = SelectedItems;
            console.log(data);
        });
        $(formId).find('select').each(function (i, list) {
            //console.log(this.id);
            //console.log(list);
            //console.log($(list).find('option:selected').val());
            data[this.id] = $(list).find('option:selected').val()
            data[this.id + "Text"] = $(list).find('option:selected').text();
        });
        console.log(data);
        return data;
    },
    getFormDataWithFile: function (formId) {
        var data = {};
        var dataWithFile = new FormData();

        $(formId).find('input[type=text],input[type=password],input[type=hidden]').each(function () {
            if (this.id) {
                //data[this.id] = this.value.trim();
                dataWithFile.append(this.id, this.value.trim());
            }
        });
        var checkbox = $(formId).find("input[type=checkbox]")
        if (checkbox.length > 1) {

        }
        else {
            dataWithFile.append(checkbox[0].id, checkbox[0].checked);
        }
        //var files = $('#fileUpload').get(0);
        var file = document.getElementById("fileUpload").files[0];
        if (file) {
            dataWithFile.append('ImageFile', file);
            //return dataWithFile;
        }
        //else {
        //    //return data;
        //}
        //display only values
        //for (var key of dataWithFile.keys()) {
        //    console.log(value);
        //}

        //display only key
        //for (var key of dataWithFile.values()) {
        //    console.log(value);
        //}

        //display key+values
        for (var pair of dataWithFile.entries()) {
            console.log(pair);
        }

        return dataWithFile;
    },

    getFormDataByName: function (formId) {
        var data = {};
        $(formId).find('input[type=text],input[type=password],input[type=hidden]').each(function () {
            if (this.name) {
                data[this.name] = this.value.trim();
            }
        });
        return data;
    },


    fileReader: function (element, imageHolder) {

        if (element && element.files && element.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                AutoSolutionUtility.css(imageHolder, 'background-image', 'url(' + e.target.result + ')');
            }
            reader.readAsDataURL(element.files[0]);

            // KTUtil.addClass(the.element, 'kt-avatar--changed');
        }
    },

    //select2 dropdown
    select2DropDown: function (controlId, modelId) {
        $('#' + controlId).select2({
            placeholder: "Select a Auto Manufacturer",
            dropdownParent: $('#_AutoModelPanel')
        });

        /*
          
         Note : if Placeholder not working in select2 Just put <option></option> in select on first place:
          
         Note : There can be two ways to make select2 search input work inside pop - up
         1.By removing the "tabindex" attribute from the modal.This will allow moving around in the Select2 box, but you lose the ability to close the modal using "Esc" button. (Tested and worked)
         2.use the below jQuery code

         */

        //$('#' + controlId).selectpicker();
    },

    //css Utility
    css: function (element, styleProp, value) {
        element.css(styleProp, value);
    },

    removeAttribute: function (selector, attribute) {
        $(selector).removeAttr(attribute);
    },

    addAttribute: function (selector, attribute, value) {
        $(selector).attr(attribute, value);
    },
    removeCssClass: function (selector, className) {
        $(selector).removeClass(className);
    },
    addCssClass: function (selector, className) {
        $(selector).addClass(className);
    },

    appendDefaultSelectOption: function (selector, _value, _text) {
        $(selector).append($('<option/> ', {
            value: _value,
            text: _text
        }));
    },

    setSelectOptionValue: function (selector, value) {
        $(selector).val(value);
    },

    defaultValidation: function (selector) {
        var isValid = true;
        $(selector).find('input[type=text],input[type=password],input[type=file],input[type=hidden],input[type=month]').filter(".required").not(":disabled").each(function (i,item) {
            var value = $(this).val();
            var selectorId = "#" + this.id;
            if (value == "") {
                AutoSolutionUtility.addCssClass(selectorId, "is-invalid");
                $(this).siblings(".invalid-feedback").html("");
                $(this).siblings(".invalid-feedback").append("Required");
                isValid = false;
            }
        });
        $(selector).find('select').filter(".required").not(":disabled").each(function (i, item) {
            //console.log("#" + this.id);
            //console.log($(this).find('option:selected').val() + $(this).find('option:selected').text());
            var selectorId = "#" + this.id;
            var value = $(this).find('option:selected').val();
            if (value == "") {
                AutoSolutionUtility.addCssClass(selectorId, "is-invalid");
                $(this).siblings(".invalid-feedback").html("");
                $(this).siblings(".invalid-feedback").append("Required");
                isValid = false;
            }
        })
        return isValid;
    },


    onCangeValidation: function (element) {
        var isValid = true;
        if ($(element).is("select")) {
            var value = $(element).find('option:selected').val();
            if (value == "") {
                AutoSolutionUtility.addCssClass("#" + element.id, "is-invalid");
                $(element).siblings(".invalid-feedback").html("");
                $(element).siblings(".invalid-feedback").append("Required");
                isValid = false;
            }
            else {
                AutoSolutionUtility.removeCssClass("#" + element.id, "is-invalid");
                $(element).siblings(".invalid-feedback").html("");
                return isValid;
            }
        }

        if ($(element).is("input")) {
            var value = $(element).val();
            if (value == "") {
                AutoSolutionUtility.addCssClass("#" + element.id, "is-invalid");
                $(element).siblings(".invalid-feedback").html("");
                $(element).siblings(".invalid-feedback").append("Required");
                isValid = false;
            }
            else {
                AutoSolutionUtility.removeCssClass("#" + element.id, "is-invalid");
                $(element).siblings(".invalid-feedback").html("");
                return isValid;
            }
        }


        
        return isValid;


        //$(selector).find('input[type=text],input[type=password],input[type=file],input[type=hidden]').each(function () {
        //    var value = this.val();
        //    if (value=="") {
        //    }
        //});


        //$(selector).find('select').not(":disabled").each(function (i, item) {
        //    //console.log("#" + this.id);
        //    //console.log($(this).find('option:selected').val() + $(this).find('option:selected').text());
        //    var selectorId = "#" + this.id;
        //    var value = $(this).find('option:selected').val();
        //    if (value == "") {
        //        AutoSolutionUtility.addCssClass(selectorId, "is-invalid");
        //        $(this).siblings(".invalid-feedback").html("");
        //        $(this).siblings(".invalid-feedback").append("Required");
        //        isValid = false;
        //    }
        //    else {
        //        AutoSolutionUtility.removeCssClass(selectorId, "is-invalid");
        //        $(this).siblings(".invalid-feedback").html("");
        //        return isValid;
        //    }
        //})
        //return isValid;
    },

    //images and files
    image_select: function (e, element) {
        let images = []
        console.log("e :", e);
        console.log("image selected");
        var image = document.getElementById(element).files;

        console.log("image:", image);

        for (i = 0; i < image.length; i++) {
            images.push({
                "name": image[i].name,
                "url": URL.createObjectURL(image[i]),
                "file": image[i],
            })
        }
        return images

    },
    image_show: function (images, imageContainer) {
        var image = "";
        images.forEach((i) => {
            image += '<div class="image_container d-flex justify-content-center position-relative">' +
                '<img src= ' + i.url + ' alt="Image">' +
                '<span class="position-absolute" onclick="autoVersion.deleteImage(' + images.indexOf(i) + ')" > <i class="fa fa-trash-alt"></i></span ></div>'


            //image += `<div class="image_container d-flex justify-content-center position-relative">
            //	  <img src="`+ i.url + `" alt="Image">
            //	  <span class="position-absolute" onclick="autoVersion.deleteImage("${imageContainer}")"><i class="fa fa-trash-alt"></i></span>
            //</div>`;
        })
        return image;
    },


    deleteImage: function (index, images) {
        images.splice(index, 1)
    }
}


