$(document).ready(function () {
    User.getUser();
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



    var User = {
         UserBaseURL: "/Users/",

        //Penal buttons section
         UserPanelbtn: "_UserPanelbtn",

        //Panel container section
         UserPanelContainer: "_UserPanelContainer",

        //panel section (modal id)
        UserPanel: "_UserPanel",
        UserPanelUpdateTitle:"Update User  ",

        //form Name
        UserForm: "#User ",
        UsereSearchForm:"#UserSearchForm",

        UserGetPanel: "_GetUser",

        validdateUser: function (event) {
            event.preventDefault();
            $(User.UserForm).validate({
                rules: {
                    UserName: {
                        required: true
                    }
                },
                messages: {
                    UserName: {
                        required: "Name is Required"
                    }
                }
            });

            if ($(User.UserForm).valid()) {
                User.saveUser();
            }
            else {
                console.log("fuck");
            }
            return false;
        },

        loadUserPanel: function () {
            var params = autoSolutionService.ajaxParams('', User.UserBaseURL + 'UserSave', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(User.UserPanelContainer);
                AutoSolutionUtility.appendHTML(User.UserPanelContainer, response);
                AutoSolutionUtility.showPanel(User.UserPanel);
                AutoSolutionUtility.hideLoader();
            })
        },

        editUser: function (id) {
            data = { Id: id }
            var params = autoSolutionService.ajaxParams(data, User.UserBaseURL + 'EditUser', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(User.UserPanelContainer);
                AutoSolutionUtility.appendHTML(User.UserPanelContainer, response);
                $("#" + User.UserPanel + " .modal-title").text(User.UserPanelUpdateTitle);
                $("#" + User.UserPanel + " #btnUser").html(htmlTemplate.UPDATE_BTN);
                AutoSolutionUtility.showPanel(User.UserPanel);
                AutoSolutionUtility.hideLoader()
            });
        },

        saveUser: function () {
            var params = autoSolutionService.ajaxParams($(User.UserForm).serialize(), User.UserBaseURL + 'UserSave', 'post', false);
            autoSolutionService.defaultService(params).done(function (response) {
                switch (response.status) {
                    case statusCode.UPDATE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.UPDATE);
                        User.getUser();
                        AutoSolutionUtility.hidePanel(User.UserPanelContainer);
                        AutoSolutionUtility.clearHTML(User.UserPanelContainer);
                        break;
                    case statusCode.SAVE:
                        AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.SAVE);
                        User.getUser();
                        AutoSolutionUtility.hidePanel(User.UserPanelContainer);
                        AutoSolutionUtility.clearHTML(User.UserPanelContainer);
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

        getUser: function (data) {
            
            var params = autoSolutionService.ajaxParams(data, User.UserBaseURL + 'GetUser', 'get', true);
            autoSolutionService.defaultService(params).done(function (response) {
                AutoSolutionUtility.clearHTML(User.UserGetPanel);
                AutoSolutionUtility.appendHTML(User.UserGetPanel, response);
                if (data) {
                    $('#pageSize').val(data.PageSize);
                }
                else {
                    $('#pageSize').val(10);
                }
                $('#' + User.UserGetPanel + ' Table').DataTable({
                    "searching": false,
                    "autoWidth": false,
                    "info": false,
                    "lengthChange": false,
                    "paging": false,
                    "columnDefs": [{
                        "targets": -1,
                        "orderable": false
                    }]
                });
                AutoSolutionUtility.hideLoader();
            })
        },
        deleteUser: function (id) {
            console.log(id);
            data = { Id: id }
            AutoSolutionUtility.deleteConfirmationBox().then(function (result) {
                if (result.value) {
                    var params = autoSolutionService.ajaxParams(data, User.UserBaseURL + 'DeleteUser', 'delete', false);
                    autoSolutionService.defaultService(params).done(function(response){
                        if (response.status) {
                            AutoSolutionUtility.toastNotifiy(toastType.SUCCESS, toastMessage.DELETE);
                            var pageNo = $('.kt-pagination__link--active').find('a').attr('data-pageNo');
                            var pageSize = $('#pageSize').val();
                            data = {
                                PageNo: pageNo,
                                PageSize: pageSize
                            }
                            User.getUser(data);
                        }
                    });
                }
            });
        },

        searchUser: function (event) {
            event.preventDefault();
            var data = AutoSolutionUtility.getFormData(User.UsereSearchForm);
            var pageSize = $('#pageSize').val();
            if (pageSize == null || pageSize == undefined) {
                data['PageSize'] = 10;
            } else {
                data['PageSize'] = pageSize;
            }
            User.getUser(data);
        },
    }

/*
 * -------------------------------------------------------
 *                    End Auto                *
 * -------------------------------------------------------
 */