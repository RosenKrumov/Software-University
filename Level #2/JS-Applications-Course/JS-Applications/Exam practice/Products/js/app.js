var app = app || {};

(function() {
    var appId = 'pBnMqxKwhexBODFgcZIjquHpH90SeZoW6usTDCfa';
    var restAPI = '45MJWCO1SPh2HwkCvi9zMJzPCnRvVLfXGwSmWcbu';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(appId, restAPI);
    var requester = app.requester.load();
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var productModel = app.productModel.load(baseUrl, requester, headers);

    var homeViews = app.homeViews.load();
    var userViews = app.userViews.load();
    var productViews = app.productViews.load();

    var userController = app.userController.load(userModel, userViews);
    var productController = app.productController.load(productModel, productViews);
    var homeController = app.homeController.load(homeViews);

    app.router = Sammy(function () {
        var selector = '#main';

        this.before(function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                $('nav#menu ul:first-child').hide();
                $('nav#menu ul:nth-child(2)').show();
            } else {
                $('nav#menu ul:first-child').show();
                $('nav#menu ul:nth-child(2)').hide();
            }
        });

        this.before('#/home/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/products/(.*)', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/logout/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
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

        this.get('#/home/', function () {
            homeController.homeScreen(selector);
        });

        this.get('#/products/', function() {
            productController.listAllProducts(selector);
        });

        this.get('#/products/add/', function() {
            productController.loadAddProductView(selector, this.params['data'], 'add');
        });

        this.get('#/products/edit/:id', function() {
            productController.loadProductView(selector, this.params['id'], 'edit');
        });

        this.get('#/products/delete/:data', function() {
            productController.loadProductView(selector, this.params['data'], 'delete');
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
        this.bind('addProduct', function(e, data) {
            productController.addProduct(data.name, data.category, data.price);
        });

        //Declaring an edit phone event listener that calls
        //the appropriate controller function for editing phone entries
        this.bind('editProduct', function(e, data) {
            productController.editProduct(data.id, data.name, data.category, data.price);
        });

        //Declaring a delete phone event listener that calls
        //the appropriate controller function for deleting phone entries
        this.bind('deleteProduct', function(e, data) {
            productController.deleteProduct(data.id);
        });
    });

    app.router.run('#/');
}());