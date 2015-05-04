var app = app || {};

(function() {
    var appId= 'kZftfBuXyIANVrykmNsftFJdlASpuWU2qLaQK5vh';
    var restAPI = '9Z6qLMbJhknJqml8I2hRCk1frRMKl5AOqJVYb3bX';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(appId, restAPI);
    var requester = app.requester.load();
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var noteModel = app.noteModel.load(baseUrl, requester, headers);

    var homeViews = app.homeViews.load();
    var userViews = app.userViews.load();
    var noteViews = app.noteViews.load();

    var userController = app.userController.load(userModel, userViews);
    var noteController = app.noteController.load(noteModel, noteViews);
    var homeController = app.homeController.load(homeViews);


    app.router = Sammy(function () {
        var selector = '#container';

        this.before(function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                var welcomeText = 'Welcome, ' + sessionStorage.username;
                $('#welcomeMenu').text(welcomeText);
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.before('#/home/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                Noty.error('You should be logged first');
                return false;
            }
        });

        this.before('#/office/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                Noty.error('You should be logged first');
                return false;
            }
        });

        this.before('#/myNotes/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                Noty.error('You should be logged first');
                return false;
            }
        });

        this.before('#/addNote/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                Noty.error('You should be logged first');
                return false;
            }
        });

        this.before('#/logout/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                Noty.error('You should be logged first');
                return false;
            }
        });

        this.get('#/', function () {
            homeController.welcomeScreen(selector);
        });

        this.get('#/login/', function() {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function() {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/office/', function() {
            window.location.replace('#/office/1')
        });

        this.get('#/home/', function () {
            homeController.homeScreen(selector);
        });

        this.get('#/myNotes/', function() {
            window.location.replace('#/myNotes/1')
        });

        this.get('#/addNote/', function() {
            noteController.loadAddNoteView(selector);
        });

        this.get('#/myNotes/:pageNumber', function() {
            var currentPage = this.params['pageNumber'];
            noteController.listNotes(selector, 'My notes', currentPage);
        });

        this.get('#/office/:pageNumber', function () {
            var currentPage = this.params['pageNumber'];
            noteController.listNotes(selector, 'Office notes', currentPage);
        });

        this.get('#/editNote/:data', function() {
            noteController.loadNoteView(selector, this.params['data'], 'edit');
        });

        this.get('#/deleteNote/:data', function() {
            noteController.loadNoteView(selector, this.params['data'], 'delete');
        });

        //Declaring a login event listener that calls
        //the appropriate controller function for login
        this.bind('login', function(e, data) {
            userController.login(data.username, data.password);
        });

        //Declaring a register event listener that calls
        //the appropriate controller function for registration
        this.bind('register', function(e, data) {
            userController.register(data.username, data.password, data.fullName);
        });

        //Declaring an add phone event listener that calls
        //the appropriate controller function for adding a new phone entry
        this.bind('addNote', function(e, data) {
            noteController.addNote(data.title, data.text, data.deadline);
        });

        //Declaring an edit phone event listener that calls
        //the appropriate controller function for editing phone entries
        this.bind('editNote', function(e, data) {
            noteController.editNote(data.id, data.title, data.text, data.deadline);
        });

        //Declaring a delete phone event listener that calls
        //the appropriate controller function for deleting phone entries
        this.bind('deleteNote', function(e, data) {
            noteController.deleteNote(data.id);
        });
    });

    app.router.run('#/');
}());