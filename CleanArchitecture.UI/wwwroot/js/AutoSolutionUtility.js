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
    clearHTML: function (containerId) {
        $("#" + containerId).html("");
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
            data[this.id+"Text"] = $(list).find('option:selected').text();
        });

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
            dataWithFile.append(checkbox[0].id, this.value);
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
        //$(selector).find('input[type=text],input[type=password],input[type=file],input[type=hidden]').each(function () {
        //    var value = this.val();
        //    if (value=="") {
        //    }
        //});
        $(selector).find('select').not(":disabled").each(function (i, item) {
            //console.log("#" + this.id);
            //console.log($(this).find('option:selected').val() + $(this).find('option:selected').text());
            var selectorId = "#" + this.id;
             var value = $(this).find('option:selected').val();
            if (value == "") {
                AutoSolutionUtility.addCssClass(selectorId, "is-invalid");
                $(this).siblings(".invalid-feedback").append("Required");
                isValid = false;
            }
        })
        return isValid;
    }
}
