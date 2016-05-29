contactListApp.controller('ContactListController',
[
    '$uibModal',
    'contactModel',
    'companyModel',
    'jobModel',
    'filterModel',
    'contactService',
    'jobService',
    'companyService',
    function ($uibModal,
              ContactModel,
              CompanyModel,
              JobModel,
              FilterModel,
              contactService,
              jobService,
              companyService) {

        var self = this;

        self.contactList = [];
        self.filter = new FilterModel();

        self.updateContactFilter = function() {
            self.filter.pageNumber = 1;
            getFilteredContacts();
        };

        function getFilteredContacts() {
            contactService.getFilteredContacts(self.filter).then(function (response) {
                self.contactList = response.data;
            });
            contactService.getNumberOfFilteredContacts(self.filter).then(function (response) {
                self.numberOfFilteredContacts = response.data;
            });
            self.gridIsReady = true;
        }

        function initController() {
            getFilteredContacts();
            jobService.getAllJobs().then(function(response) {
                self.jobList = response.data;
            });
            companyService.getAllCompanies().then(function (response) {
                self.companyList = response.data;
            });

        }

        self.viewContact = function (contact) {

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '\\Scripts\\ContactListApp\\Templates\\contactModalTemplate.html',
                controller: 'ContactModalController',
                size: 'md',
                resolve: {contact : contact}
            });

            modalInstance.result.then(function (toUpdateContactList) {
                if (toUpdateContactList) {
                    getFilteredContacts();
                }
            });
        };

        self.addContact = function () {

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "\\Scripts\\ContactListApp\\Templates\\contactAddModalTemplate.html",
                controller: "ContactAddModalController",
                size: "md",
                resolve:
                {
                    data:
                    {
                        jobList: self.jobList,
                        companyList: self.companyList
                    }
                }
            });

            modalInstance.result.then(function (toUpdateContactList) {
                if (toUpdateContactList) {
                    getFilteredContacts();
                }
            });
        };

        self.pageChanged = function () {
            getFilteredContacts();
        };
        initController();
    }
]);