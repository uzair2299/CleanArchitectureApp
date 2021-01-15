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
            type: params.httpMethod,
            url: params.url,
            data: params.data
        });
    }
}