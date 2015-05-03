var app = app || {};

(function () {
    'use strict';
    var rootUrl = 'https://api.parse.com/1/';
    var model = app.model.loadModel(rootUrl);
    var selector = '#main';
    var controller = app.controller.loadController(model);
    controller.attachHandlers();

    app.router = Sammy(function () {
        this.get('#/', function() {
            controller.getHomePage(selector);
        });

        this.get('#/Login', function(){
            controller.getLoginPage(selector);
        });

        this.get('#/Register', function(){
            controller.getRegisterPage(selector);
        });

        this.get('#/Registered', function(){
            controller.registerUser();
        });

        this.get('#/Logged', function(){
            controller.loginUser();
        });

        this.get('#/Home', function(){
            controller.getLoggedHomePage(selector);
        });

        this.get('#/EditProfile', function() {
            controller.getEditProfilePage(selector);
        });

        this.get('#/Post', function() {
            controller.getAddPostPage(selector);
        });

        this.get('#/Edited', function() {
            controller.editUserInfo();
        });

        this.get('#/Posted', function() {
            controller.addPost();
        });

        this.get('#/Logout', function() {
            controller.logoutUser();
        });
    });

    app.router.run('#/');
}());