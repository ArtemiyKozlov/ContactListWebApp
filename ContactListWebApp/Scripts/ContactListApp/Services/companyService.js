contactListApp.service("companyService",
    [
        "$http",
        "companyUrls",
        function ($http, companyUrls) {
            this.getAllCompanies = function () {
                return $http(
                {
                    method: "GET",
                    url: companyUrls.getAllCompanies
                });
            };
        }
    ]
);