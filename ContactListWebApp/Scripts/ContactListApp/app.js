var contactListApp = angular.module('contactListApp', ['ui.bootstrap', 'ngTagsInput']);

contactListApp.config(function (tagsInputConfigProvider) {
    tagsInputConfigProvider.setDefaults('tagsInput', {
        placeholder: ''
    });
});

contactListApp.constant('contactUrls',
{
    root: 'http://localhost:52155/api/Contacts/',
    addContact: 'http://localhost:52155/api/Contacts/AddContact',
    getFilteredContacts: 'http://localhost:52155/api/Contacts/GetFilteredContacts',
    deleteContact: 'http://localhost:52155/api/Contacts/DeleteContact',
    updateContact: 'http://localhost:52155/api/Contacts/UpdateContact',
    getNumberOfFilteredContacts: 'http://localhost:52155/api/Contacts/GetNumberOfFilteredContacts'
});

contactListApp.constant('jobUrls',
{
    getAllJobs: 'http://localhost:52155/api/Jobs/GetAllJobs'
});

contactListApp.constant('companyUrls',
{
    getAllCompanies: 'http://localhost:52155/api/Companies/GetAllCompanies'
});

