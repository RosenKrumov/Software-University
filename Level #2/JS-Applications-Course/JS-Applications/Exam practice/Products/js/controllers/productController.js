var app = app || {};

app.productController = (function () {
    function ProductController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    ProductController.prototype.loadAddProductView = function(selector) {
        this.viewBag.addProduct.addProductView(selector);
    };

    ProductController.prototype.loadProductView = function(selector, urlParams, action) {
        var data = urlParams.split('&');
        var outData = {
            id : data[0].split('id=')[1],
            name: data[1].split('name=')[1],
            category: data[2].split('category=')[1],
            price: data[3].split('price=')[1]
        };

        if(action === 'delete') {
            this.viewBag.deleteProduct.deleteProductView(selector, outData);
        } else {
            this.viewBag.editProduct.editProductView(selector, outData);
        }
    };

    ProductController.prototype.listAllProducts = function (selector) {
        var _this = this;

        return this.model.listAllProducts()
            .then(function (data) {
                _this.viewBag.listProducts.loadProductsView(selector, data);
            }, function (error) {
                console.log(error);
            })
    };

    ProductController.prototype.addProduct = function (name, category, price) {
        return this.model.addProduct(name, category, price)
            .then(function() {
                window.location.replace('#/products/');
            }, function(error) {
                console.log(error);
            }).done();
    };

    ProductController.prototype.editProduct = function (productId, name, category, price) {
        return this.model.editProduct(productId, name, category, price)
            .then(function() {
                window.location.replace('#/products/');
            }, function(error) {
                console.log(error);
            })
    };

    ProductController.prototype.deleteProduct = function (productId) {
        return this.model.deleteProduct(productId)
            .then(function() {
                window.location.replace('#/products/');
            }, function(error) {
                console.log(error);
            })
    };

    return {
        load: function (model, views) {
            return new ProductController(model, views);
        }
    }
}());