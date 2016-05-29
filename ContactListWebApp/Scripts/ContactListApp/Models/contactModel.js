contactListApp.factory('contactModel',
[
    'companyModel',
    'jobModel',
    function(CompanyModel, JobModel) {
        return function ContactModel() {
            this.id = 1;
            this.firstName = '';
            this.lastName = '';
            this.email = '';
            this.phone = null;
            this.gender = null;
            this.avatar = null;
            this.company = new CompanyModel();
            this.job = new JobModel();
        };
    }
]); 