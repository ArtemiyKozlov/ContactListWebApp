contactListApp.service("jobService",
    [
        "$http",
        "jobUrls",
        function ($http, jobUrls) {
            this.getAllJobs = function () {
                return $http(
                {
                    method: "GET",
                    url: jobUrls.getAllJobs
                });
            };
        }
    ]
);