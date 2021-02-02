var autoSolutionService = {
    ajaxParams:function (data, url, httpMethod, isBackgroundLoader) {
        return {
            data: data,
            url: url,
            httpMethod: httpMethod.toUpperCase(),
            isBackgroundLoader: isBackgroundLoader
        }
    },

    defaultService: function (params) {
        if (params.isBackgroundLoader) {

        }
        return $.ajax({

            beforeSend: function () {

                $("#loaderdiv").show();
                
            },
            type: params.httpMethod,
            url: params.url,
            data: params.data,
        });
    }
}