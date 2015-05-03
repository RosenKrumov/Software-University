var app = app || {};

app.model = (function(){
    function Model(baseUrl){
        this._baseUrl = baseUrl;
        this.users = new User(baseUrl);
        this.posts = new Post(baseUrl);
    }

    var Credentials = (function () {

        function getHeaders() {
            var headers = {
                    "X-Parse-Application-Id": "lqA4ZABCQc2s8OOB9qZLKpocAUgKNh3FwqoXLMcm",
                    "X-Parse-REST-API-Key": "JBZ8JzyuisXLFr0auEWy7GRzW3DzjJAd28L1g4QJ"
                },
                currentUser = getSessionToken();

            if (currentUser) {
                headers['X-Parse-Session-Token'] = currentUser;
            }
            return headers;
        }

        function getSessionToken() {
            return sessionStorage.getItem('sessionToken');
        }

        function setSessionToken(sessionToken) {
            sessionStorage.setItem('sessionToken', sessionToken);
        }

        function getUserId() {
            return sessionStorage.getItem('userId');
        }

        function setUserId(userId) {
            return sessionStorage.setItem('userId', userId);
        }

        function getUsername() {
            return sessionStorage.getItem('username');
        }

        function setUsername(username) {
            sessionStorage.setItem('username', username);
        }

        function setFullName(fullName) {
            sessionStorage.setItem('name', fullName);
        }

        function getFullName() {
            return sessionStorage.getItem('name');
        }

        function clearLocalStorage() {
            sessionStorage.clear();
        }

        return {
            getSessionToken: getSessionToken,
            setSessionToken: setSessionToken,
            getUsername: getUsername,
            setUsername: setUsername,
            getFullName: getFullName,
            setFullName: setFullName,
            getUserId: getUserId,
            setUserId: setUserId,
            getHeaders: getHeaders,
            clearLocalStorage: clearLocalStorage
        }
    }());

    var User = (function(){
        function User(baseUrl){
            this._serviceUrl = baseUrl;
            this._headers = Credentials.getHeaders();
        }

        User.prototype.login = function (username, password) {
            var defer = Q.defer();
            var url = this._serviceUrl + 'login?username=' + username + '&password=' + password;

            app.ajaxRequester.getRequest(url, Credentials.getHeaders(), 'application/json')
                .then(function (data) {
                    defer.resolve(data);
                    Credentials.setSessionToken(data.sessionToken);
                    Credentials.setUsername(data.username);
                    Credentials.setFullName(data.name);
                    Credentials.setUserId(data.objectId);
                    return data;
                }, function(error) {
                    console.log(error);
                    defer.reject(error);
                }).done();
            return defer.promise;
        };

        User.prototype.register = function (userRegData) {
            var defer = Q.defer();
            var url = this._serviceUrl + 'users';

            app.ajaxRequester.postRequest(url, Credentials.getHeaders(), JSON.stringify(userRegData), 'application/json')
                .then(function (data) {
                    defer.resolve(data);
                    return data;
                }, function(error) {
                    console.log(error);
                    defer.reject(error);
                }).done();
            return defer.promise;
        };

        User.prototype.editProfile = function (userId, userProfileData) {
            var defer = Q.defer();
            var url = this._serviceUrl + 'users/' + userId ;

            app.ajaxRequester.putRequest(url, Credentials.getHeaders(), JSON.stringify(userProfileData), 'application/json')
                .then(function (data) {
                    defer.resolve(data);
                    return data;
                }, function(error) {
                    console.log(error);
                    defer.reject(error)
                }).done();
            return defer.promise;
        };

        User.prototype.getById = function (userId) {
            var defer = Q.defer();
            var url = this._serviceUrl + 'users/' + userId;

            app.ajaxRequester.getRequest(url, Credentials.getHeaders(), 'application/json')
                .then(function(data) {
                    defer.resolve(data);
                    return data;
                }, function(error) {
                    console.log(error);
                    defer.reject(error);
                }).done();
            return defer.promise;
        };

        User.prototype.isLogged = function() {
            return Credentials.getSessionToken();
        };

        User.prototype.validateToken = function () {
            var url = this._serviceUrl + 'users/me';
            return app.ajaxRequester.getRequest(url, Credentials.getHeaders(), 'application/json');
        };

        User.prototype.getUserData = function () {
            return {
                userId: Credentials.getUserId(),
                username: Credentials.getUsername(),
                name: Credentials.getFullName(),
                sessionToken: Credentials.getSessionToken()
            }
        };

        User.prototype.logout = function() {
            Credentials.clearLocalStorage();
        };

        return User;
    }());

    var Post = (function(){
        function Post(baseUrl) {
            this._serviceUrl = baseUrl + 'classes/Post';
            this._headers = Credentials.getHeaders();
        }

        Post.prototype.getPosts = function() {
            var deffer = Q.defer();
            var requestUrl = this._serviceUrl + '?include=createdBy';
            var headers = this._headers;
            headers['X-Parse-Session-Token'] = null;
            app.ajaxRequester.getRequest(requestUrl, headers, 'application/json')
                .then(function(data){
                    console.log(data);
                    deffer.resolve(data);
                    return data;
                }, function(error){
                    console.log(error.responseText);
                    deffer.reject(error);
                });
            return deffer.promise;
        };

        Post.prototype.editPost = function(id, data) {
            var deffer = Q.defer();
            var requestUrl = this._serviceUrl + id;

            app.ajaxRequester.putRequest(requestUrl, this._headers, data, 'application/json')
                .then(function(data){
                    console.log(data);
                    deffer.resolve(data);
                    return data;
                }, function(error){
                    console.log(error.responseText);
                    deffer.reject(error);
                });
            return deffer.promise;
        };

        Post.prototype.addPost = function(data) {
            var deffer = Q.defer();
            var requestUrl = this._serviceUrl;
            data = JSON.stringify(data);
            app.ajaxRequester.postRequest(requestUrl, this._headers, data, 'application/json')
                .then(function(data){
                    console.log(data);
                    deffer.resolve(data);
                    return data;
                }, function(error){
                    console.log(error.responseText);
                    deffer.reject(error);
                });
            return deffer.promise;
        };

        return Post;
    }());

    return {
        loadModel: function(baseUrl) {
            return new Model(baseUrl);
        }
    }
}());