(function () {
    'use strict';
    app.controller("fileController", fileController);
    fileController.$inject = ["$scope"];

    function fileController($scope) {
        $scope.text = "Hello Angular 8";


        $scope.uploadForm = function (file, name) {
            $scope.isSuccess = false;
            //reset form state
            angular.element('form[name=WordFileUpload] input[type=file]').val('');
            $scope.fileUploadForm.$setPristine();
            $scope.fileModel = {};

            $scope.fileModel.type = file.type;
            $scope.fileModel.fileType = name;
            //$scope.fileModel.month = (new Date().getMonth() + 1).toString();
            //$scope.fileModel.year = (new Date().getFullYear()).toString();
            //$('#uploadFile').modal({
            //    backdrop: 'static'
            //});
        };
        $scope.post = function (path, params, method) {
            method = method || "post"; // Set method to post by default if not specified.

            // The rest of this code assumes you are not using a library.
            // It can be made less wordy if you use one.
            var form = document.createElement("form");
            form.setAttribute("method", method);
            form.setAttribute("action", path);
            form.id = "_formPost";

            for (var key in params) {
                if (params.hasOwnProperty(key)) {
                    var hiddenField = document.createElement("input");
                    hiddenField.setAttribute("type", "hidden");
                    hiddenField.setAttribute("name", key);
                    hiddenField.setAttribute("value", (params[key] == null || undefined) ? '' : params[key]);

                    form.appendChild(hiddenField);
                }
            }

            document.body.appendChild(form);
            form.submit();
            document.querySelector('#_formPost').remove();
        };
    }
})();