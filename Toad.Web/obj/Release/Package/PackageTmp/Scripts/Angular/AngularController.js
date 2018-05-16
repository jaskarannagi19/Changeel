angular.module("myApp", ['textAngular','flow'])

    .config(['flowFactoryProvider', appConfig])

    .controller('uploadController', ["$scope", "$filter", "$http", "$interval", "$q", function ($scope, $filter, $http, $interval, $q) {


    angular.element(document).ready(function () {
        $scope.heartbeat();
    });

    $scope.heartbeat = function () {
       // alert("called")
        $http({
            method: 'GET',
            url: "/User/HeartBeat",
        }).then(function (data) {
            console.log(data);
            $interval(function () { $scope.heartbeat(); }, 1140000);
        }
        )
    };
  
    $scope.submit = function () {
        debugger;
        $http({
            method: 'POST',
            url: "/Blog/WriteBlog",
            data: {
                Title: $scope.title,
                SmallDescription: $scope.smallDescription,
                BaseImage: $scope.baseImage,
                Content: $scope.htmlcontent
            },

        }).then(function (data) {
            console.log(data);
            if (data.data.Success == true) {
                alert("Data Saved");
                location.reload();
            }
        }).error(function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            return;
        });
    };


    $scope.$on('flow::complete', function (event, $flow, flowFile) {
        var date = new Date();
        var m = date.getMonth();
        var d = date.getDate();
        console.log($flow);
        $scope.accesspath = window.location.hostname + "/images/" + m + "/" + d + "/" + $flow.files[0].relativePath;
    });
}]);





function appConfig(flowFactoryProvider) {

    var myCustomData = {
        requestVerificationToken: 'xsrf',
        blueElephant: '42'
    };

    flowFactoryProvider.defaults = {
        target: '/api/Upload',
        permanentErrors: [404, 500, 501],
        maxChunkRetries: 1,
        chunkRetryInterval: 5000,
        simultaneousUploads: 4,
        query: myCustomData
    };
    //var relativePath;
    //flowFactoryProvider.on('catchAll', function (event) {
        
    //    if (arguments[0] == "fileAdded") {
    //        relativePath = arguments[1].relativePath;
    //    };
    //    if (arguments[0] == "complete")
    //    {
    //        var date = new Date();
    //        var m = date.getMonth();
    //        var d = date.getDate();
    //        var accesspath = window.location.hostname + "/images/" + m + "/" + d + "/" + relativePath;
    //    };

    //});
    // Can be used with different implementations of Flow.js
    // flowFactoryProvider.factory = fustyFlowFactory;
}

