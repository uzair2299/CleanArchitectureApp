const toastType = {
    Error: 'error',
    INFO: 'info',
    WARNING: 'warning',
    SUCCESS: 'success',
};

const statusCode = {
    UPDATE : 'Update',
    FAIL: 'fail',
    SAVE:'save'
}

const toastMessage = {
    SAVE: 'Save Successfully',
    ERROR: 'Opps...Some Thing Went Wrong',
    UPDATE:'Update Successfully'
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

    toastNotifiy: function (type,message) {
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
        return  swal.fire({
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
            cancelButtonText:'<i class="mr-2 fa fa-trash-alt"></i>Cancel'
        })
    }
}
