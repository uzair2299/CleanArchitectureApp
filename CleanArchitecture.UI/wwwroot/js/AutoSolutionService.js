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
        return $.ajax({
            beforeSend: function () {
                if (params.isBackgroundLoader) {
                    AutoSolutionUtility.showLoader();
                }
            },
            type: params.httpMethod,
            url: params.url,
            data: params.data,
        });
    }
}