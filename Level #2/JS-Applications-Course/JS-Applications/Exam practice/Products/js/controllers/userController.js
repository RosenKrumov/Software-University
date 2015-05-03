var app = app || {};

app.userController = (function() {
    function UserController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        /*After using events we do not need to pass
         * the controller to the view*/
        this.viewBag.loginView.loadLoginView(selector);
    };

    UserController.prototype.loadRegisterPage = function(selector) {
        /*After using events we do not need to pass
         * the controller to the view*/
        this.viewBag.registerView.loadRegisterView(selector);
    };

    UserController.prototype.login = function(username, password) {
        return this.model.login(username, password)
            .then(function(loginData) {
                setUserToStorage(loginData);
                window.location.replace('#/home/');
            }, function(error) {
                console.log(error);
            })
    };

    UserController.prototype.register = function(username, pass, repeatedPwrd) {
        if (pass !== repeatedPwrd) {
            console.error('Passwords must match');
            return;
        }
        return this.model.register(username, pass, repeatedPwrd)
            .then(function(registerData) {
                var data = {
                    username: username,
                    objectId: registerData.objectId,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(data);
                window.location.replace('#/home/');
            }, function(error) {
                console.log(error);
            })
    };

    UserController.prototype.logout = function() {
        return this.model.logout()
            .then(function() {
                clearUserFromStorage();
                window.location.replace('#/');
            }, function(error) {
                console.log(error);
            });

    };

    function setUserToStorage(data) {
        sessionStorage['username'] = data.username;
        sessionStorage['userId'] = data.objectId;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['username'];
        delete sessionStorage['userId'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load : function(model, views) {
            return new UserController(model, views);
        }
    }
}());