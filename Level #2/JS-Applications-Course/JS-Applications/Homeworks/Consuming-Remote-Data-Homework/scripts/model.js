var app = app || {};

app.models = (function() {
    function Models(baseUrl) {
        this.baseUrl = baseUrl;
        this.books = new Books(this.baseUrl);
    }

    var Requester = (function() {
        function makeRequest(method, url, data, success, error) {
            $.ajax({
                method: method,
                headers: {
                    'X-Parse-Application-Id':'Z98UHx0gbKblbZKPBR8WTHopkzR0wqn9217nedIb',
                    'X-Parse-REST-API-Key':'4invh6LFpdrQK6qhHvaki5Y5oA1cNCs0FAHahHUx'
                },
                url: url,
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: success,
                error: error
            })
        }

        function getRequest(url, success, error) {
            makeRequest('GET', url, null, success, error);
        }

        function postRequest(url, data, success, error) {
            makeRequest('POST', url, data, success, error);
        }

        function deleteRequest(url, success, error) {
            makeRequest('DELETE', url, null, success, error);
        }

        function updateRequest(url, data, success, error) {
            makeRequest('PUT', url, data, success, error);
        }

        return {
            getRequest: getRequest,
            postRequest: postRequest,
            deleteRequest: deleteRequest,
            updateRequest: updateRequest
        }
    }());

    var Books = (function() {
        function Books(baseUrl) {
            this.serviceUrl = baseUrl + 'Book/';
        }

        Books.prototype.getAllBooks = function(success, error) {
            return Requester.getRequest(this.serviceUrl, success, error);
        };

        Books.prototype.postBook = function(book, success, error) {
            return Requester.postRequest(this.serviceUrl, book, success, error);
        };

        Books.prototype.removeBook = function(id, success, error) {
            return Requester.deleteRequest(this.serviceUrl + id, success, error);
        };

        Books.prototype.updateBook = function(id, newData, success, error) {
            return Requester.updateRequest(this.serviceUrl + id, newData, success, error);
        };

        return Books;
    }());

    return {
        loadModels: function(baseUrl) {
            return new Models(baseUrl);
        }
    }
}());