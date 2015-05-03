var app = app || {};

app.controller = (function () {
    'use strict';

    function Controller(model) {
        this._model = model;
    }

    Controller.prototype.getHomePage = function (selector) {
        app.homeView.load(selector);
    };

    Controller.prototype.getLoginPage = function (selector) {
        app.loginView.load(selector);
    };

    Controller.prototype.getRegisterPage = function (selector) {
        app.registerView.load(selector);
    };

    Controller.prototype.getEditProfilePage = function(selector) {
        var userData;
        if (!this._model.users.isLogged()) {
            location.href = '#/';
            return;
        }
        userData = this._model.users.getUserData();
        userData.picture = sessionStorage.picture;
        this._model.users.getById(userData.userId)
            .then(function(data) {
                app.editProfileView.load(selector, data);
            }, function(error) {
                console.log(error);
            }).done();
    };

    Controller.prototype.editUserInfo = function() {
        var username = $('#username').val();
        if($('#password').val()) {
            var password = $('#password').val();
        }
        var name = $('#name').val();
        var about = $('#about').val();
        var gender = $('input[type=\'radio\'][name=\'gender-radio\']:checked').val();
        var id = sessionStorage.userId;
        var userProfileData = {
            username: username,
            password: password,
            name: name,
            about: about,
            gender: gender
        };
        this._model.users.editProfile(id, userProfileData)
            .then(function (data) {
                console.log(data);
                console.log('Successfully edited!');
                location.href = '#/Home';
            }, function (error) {
                console.log(error);
            }).done();
    };

    Controller.prototype.getAddPostPage = function(selector) {
        app.addPostView.load(selector);
    };

    Controller.prototype.addPost = function() {
        var content = $('#post-content').val();
        var data = {
            content: content,
            createdBy: {
                "__type": "Pointer",
                "className": "_User",
                "objectId": sessionStorage.userId
            }
        };
        this._model.posts.addPost(data)
            .then(function(data) {
                console.log(data);
                location.href = '#/Home';
            }, function(error) {
                console.log(error);
            }).done();
    };

    Controller.prototype.getLoggedHomePage = function(selector) {
        var data = this._model.users.getUserData();
        data.picture = sessionStorage.picture;
        app.loggedInHomeView.load('#header', data);
        this.getPosts(selector);
    };

    Controller.prototype.getPosts = function(selector) {
        this._model.posts.getPosts()
            .then(function(data) {
                console.log(data);
                var results = [];
                data.results.forEach(function(result) {
                    var resultToPush = {
                        'content': result.content,
                        'createdAt': result.createdAt,
                        'createdBy': result.createdBy.name,
                        'id': result.createdBy.objectId,
                        'picture': result.createdBy.picture
                    };
                    results.push(resultToPush);
                });
                var postData = {
                    'results': results
                };
                app.postsView.load(selector, postData);
            }, function(error) {
                console.log(error);
            }).done();
    };

    Controller.prototype.registerUser = function() {
        var userRegData = {
            username: $('#reg-username').val(),
            password: $('#reg-password').val(),
            name: $('#reg-name').val(),
            about: $('#reg-about').val(),
            gender: $('input[name="gender-radio"]:checked').val(),
            picture: $('#picture').attr('data-picture-data')
        };

        this._model.users.register(userRegData)
            .then(function (data) {
                //Noty.success("Registration successful.");
                location.href='#/Login';
                console.log(data)
            },
            function (error) {
                //Noty.error("Your registration has encountered an error.");
                console.log(error);
            }).done();
    };

    Controller.prototype.loginUser = function() {
        var username = $('#login-username').val(),
            password = $('#login-password').val();

        this._model.users.login(username, password)
            .then(function (data) {
                sessionStorage.picture = data.picture;
                location.href = '#/Home';
                //Noty.success("Successfully logged in.");
                console.log(data);
            },
            function (error) {
                //Noty.error("Incorrect username/password.");
                console.log(error);
            }
        );
    };

    Controller.prototype.logoutUser = function() {
        this._model.users.logout();
        location.href = '#/';
    };

    Controller.prototype.attachHandlers = function() {
        var selector = '#main';
        attachHoverHandler.call(this, selector);
    };

    var attachHoverHandler = function (selector) {
        var that = this;
        $(selector).on('mouseenter', '.profile-link', function() {
            var thisPerson = this,
                id = $(thisPerson).attr('data-user-id');

            var offset = $(thisPerson).offset();
            $('.hover-box')
                .css({
                    top: offset.top + 30,
                    left: offset.left + 10
                })
                .show();
            that._model.users.getById(id)
                .then(function(data) {
                        app.hoverBoxView.load(data);
                    },
                    function(error) {
                        console.log(error);
                        //Noty.error("Error retrieving data.");
                    }
                )
        });

        $(selector).on('mouseleave', '.profile-link', function() {
            $('.hover-box').html("<p>Loading...</p>");
            $('.hover-box').hide();
        });
    };

    return {
        loadController: function (model) {
            return new Controller(model);
        }
    }
}());