var account = {
    accountBaseURL: "/Account/",
    loginForm: "#Login",
    validateAccount: function (event) {
        //event.preventDefault();
        $(account.loginForm).validate({
            rules: {
                UserName: {
                    required: true
                },
                Password: {
                    required: true
                }
            },
            messages: {
                UserName: {
                    required: "User name is required"
                },
                Password: {
                    required: "Password is required"
                }
            }
        });

        if ($(account.loginForm).valid()) {
            console.log("ok");
            
            //account.login();
        }
        else {
            console.log("fuck");
            return false;
        }
        return false;
    },
    login: function () {
        var data = AutoSolutionUtility.getFormDataByName(account.loginForm);
        var params = autoSolutionService.ajaxParams(data, account.accountBaseURL + 'Index', 'post', true);
        autoSolutionService.defaultService(params).done(function (response) {
            console.log(data);
        });
    }

};