contactListApp.service("contactService",
    [
        "$http",
        "contactUrls",
        function ($http, contactUrls) {
            this.addContact = function(contact) {
                return $http(
                {
                    method: "POST", 
                    url: contactUrls.addContact, 
                    headers: { 'Content-Type': "application/json" },
                    data: contact
                });
            };

            this.updateContact = function (contact) {
                return $http(
                {
                    method: "POST",
                    url: contactUrls.updateContact,
                    headers: { 'Content-Type': "application/json" },
                    data: contact
                });
            };

            this.deleteContact = function (id) {
                return $http(
                {
                    method: "POST",
                    url: contactUrls.deleteContact + "/" + id
                });
            };

            this.getFilteredContacts = function (filter) {
                return $http(
                {
                    method: "POST",
                    url: contactUrls.getFilteredContacts,
                    headers: { 'Content-Type': "application/json" },
                    data: filter
                });
            };

            this.getNumberOfFilteredContacts = function (filter) {
                return $http(
                {
                    method: "POST",
                    url: contactUrls.getNumberOfFilteredContacts,
                    headers: { 'Content-Type': "application/json" },
                    data: filter
                });
            };
        }
    ]
);