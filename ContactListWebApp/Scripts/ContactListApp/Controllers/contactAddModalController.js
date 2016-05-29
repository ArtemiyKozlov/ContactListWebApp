contactListApp.controller("ContactAddModalController",
[
    "$scope",
    "$uibModalInstance",
    "contactService",
    "contactModel",
    'data',
    '$filter',
    function($scope,
        $uibModalInstance,
        contactService,
        ContactModel,
        data,
        $filter) {

        $scope.genders = ["Male", "Female"];
        $scope.newContact = new ContactModel();
        $scope.jobArray = [];
        $scope.companyArray = [];

        var jobTags = data.jobList;
        var companyTags = data.companyList;

        $scope.addContact = function () {
            debugger;
            if (!$scope.form.$valid) return;

            $scope.newContact.company = $scope.companyArray[0];
            $scope.newContact.job = $scope.jobArray[0];
            contactService.addContact($scope.newContact).then(function() {
                $uibModalInstance.close(true);
            });
        };
        
        $scope.cancel = function() {
            $uibModalInstance.close(false);
        };

        $scope.loadCompanyTags = function (query) {
            var array = companyTags.filter(function(item) {

                return item.companyName.toUpperCase().indexOf(query.toUpperCase()) === 0;
            });
            return array;
        }

        $scope.loadJobTags = function (query) {
            var array = jobTags.filter(function (item) {

                return item.jobTitle.toUpperCase().indexOf(query.toUpperCase()) === 0;
            });
            return array;
        }
    }
]);