angular.module("myApp",[])



 .controller("indexController", ["$scope", "$http", "$q", function ($scope, $http, $q) {

     angular.element(document).ready(function () {
         $scope.GetBlog();
         $scope.GetList();
     });

     $scope.records = [
         {
             "Name": "Alfreds Futterkiste",
             "Country": "Germany"
         }, {
             "Name": "Berglunds snabbköp",
             "Country": "Sweden"
         }, {
             "Name": "Centro comercial Moctezuma",
             "Country": "Mexico"
         }, {
             "Name": "Ernst Handel",
             "Country": "Austria"
         }
     ]

     $scope.GetList = function () {
         $http.get("/Change/GetChanges")
             .then(function (data) {
                 $scope.ChangesList = data.data;
                 console.log($scope.ChangesList);
                 });
     };
     $scope.page = 0;

     $scope.GetBlog = function () {

         $http({
             method: 'POST',
             url: "/Blog/GetBlogs",
             data: {
                 pageNumber: $scope.page,
             },

         }).then(function (success) {
             $scope.BlogList = success.data;
             if (success.data.length == 10) {
                 $scope.page++;
             }
         });
     }
 }])

