contactListApp.controller('ContactModalController',
[
    '$scope',
    '$uibModalInstance',
    'contactService',
    'contact',
    function ($scope, $uibModalInstance, contactService, contact) {

        $scope.contact = angular.copy(contact);
        $scope.genders = ["Male", "Female"];

        $scope.updateContact = function (contact) {
            if (!$scope.form.$valid) return;
            contactService.updateContact(contact).then(function () {
                $uibModalInstance.close(true);
            });
        }

        $scope.deleteContact = function (contact) {
            contactService.deleteContact(contact.id).then(function() {
                $uibModalInstance.close(true);
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.close(false);
        };
    }
]);