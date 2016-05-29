contactListApp.factory('filterModel',
[
    function () {
        return function FilterModel() {
            this.gender = '';
            this.firstName = '';
            this.lastName = '';
            this.pageNumber = 1;
            this.pageSize = 15;
        };
    }
]);