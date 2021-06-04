var autoSolutionService = {
    ajaxParams:function (data, url, httpMethod, isBackgroundLoader) {
        return {
            data: data,
            url: url,
            httpMethod: httpMethod.toUpperCase(),
            isBackgroundLoader: isBackgroundLoader,
        }
    },

    ajaxParamsForFileUpload: function (data, url, httpMethod, isBackgroundLoader, _processData, _contentType) {
        return {
            data: data,
            url: url,
            httpMethod: httpMethod.toUpperCase(),
            isBackgroundLoader: isBackgroundLoader,
            processData: _processData,
            contentType: _contentType,
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
    },
    defaultServiceWithFile: function (params) {
        return $.ajax({
            beforeSend: function () {
                if (params.isBackgroundLoader) {
                    AutoSolutionUtility.showLoader();
                }
            },
            processData: params.processData,
            contentType: params.contentType,
            type: params.httpMethod,
            url: params.url,
            data: params.data,
            dataType:"Json"
        });
    },
    getJsonDataById: function (id,url) {
      return $.getJSON(url, { Id: id });
    }
}