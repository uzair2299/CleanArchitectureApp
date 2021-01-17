var AutoSolutionUtility = {
    clearHTML: function (containerId) {
        $("#" + containerId).html("");
    },

    appendHTML: function (containerId, response) {
        $("#" + containerId).append(response);
    },

    showPanel: function (containerId) {
        $("#" + containerId).modal('show');
    }
}