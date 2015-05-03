var app = app || {};

app.productViews = (function() {
    function ProductViews() {
        this.listProducts = {
            loadProductsView: loadProductsView
        };

        this.addProduct = {
            addProductView: addProductView
        };

        this.editProduct = {
            editProductView: editProductView
        };

        this.deleteProduct = {
            deleteProductView: deleteProductView
        }
    }

    function loadProductsView (selector, data) {
        $.get('templates/list-products.html', function (template) {
            var products = data.results,
                categories = [],
                userId = sessionStorage['userId'];

            products.forEach(function(pr) {
                if (pr.ACL[userId]) {
                    pr.showButtons = true;
                }

                categories[pr.category] = pr.category;
            });

            data.categories = Object.keys(categories)
                .map(function(value, index) { return value; });
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function(){
            $('#clear-filters').click(function(){
                $('#search-bar').val('');
                $('#min-price').val('');
                $('#max-price').val('');
                $('#category').val('All');
            });

            $('#filter').click(function() {
                var keyword = $('#search-bar').val(),
                    minPrice = parseFloat($('#min-price').val()),
                    maxPrice = parseFloat($('#max-price').val()),
                    category = $('#category').val();

                $('#products-list').children()
                    .each(function(index) {
                        var self = $(this),
                            productName = self.attr('data-name'),
                            productPrice = parseFloat(self.attr('data-price')),
                            productCategory = self.attr('data-category');

                        if (productName.contains(keyword) &&
                            minPrice <= productPrice && maxPrice >= productPrice &&
                            (category === "All" || category === productCategory))
                        {
                            $(this).show();
                        } else {
                            $(this).hide();
                        }
                    });
            });
        });
    }

    function addProductView (selector) {
        $.get('templates/add-product.html', function (template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        }).then(function() {
            $('#add-product-button').click(function() {
                var name = $('#name').val();
                var category = $('#category').val();
                var price = $('#price').val();

                //Triggering an event in the application so that we
                //bypass any dependencies with the controller. We pass
                //data object to the event handler that we call the needed controller
                $.sammy(function() {
                    this.trigger('addProduct', {name: name, category: category, price: price});
                });

                /*Old way of calling the addPhone function
                 * but this method needs a dependency with controller*/
                //return controller.addProduct(person, number);

                //The eventListener returns 'false' in order for our a:href
                //link to work correctly
                return false;
            })
        }).done();
    }

    function editProductView (selector, data) {
        $.get('templates/edit-product.html', function (template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#edit-product-button').click(function() {
                var name = $('#item-name').val();
                var category = $('#category').val();
                var price = $('#price').val();

                //Triggering an event in the application so that we
                //bypass any dependencies with the controller. We pass
                //data object to the event handler that we call the needed controller
                $.sammy(function() {
                    this.trigger('editProduct', {id:data.id, name: name, category: category, price: price});
                });

                /*Old way of calling the editPhone function
                 * but this method needs a dependency with controller*/
                //return controller.editProduct(data.id, person, number);

                //The eventListener returns 'false' in order for our a:href
                //link to work correctly
                return false;
            })
        }).done();
    }

    function deleteProductView (selector, data) {
        $.get('templates/delete-product.html', function (template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#delete-product-button').click(function() {
                //Triggering an event in the application so that we
                //bypass any dependencies with the controller. We pass
                //data object to the event handler that we call the needed controller
                $.sammy(function() {
                    this.trigger('deleteProduct', {id: data.id});
                });

                /*Old way of calling the deletePhone function
                 * but this method needs a dependency with controller*/
                //return controller.deleteProduct(data.id);

                //The eventListener returns 'false' in order for our a:href
                //link to work correctly
                return false;
            })
        }).done();
    }

    String.prototype.contains = function(needle) {
        return this.toLowerCase().indexOf(needle.toLowerCase()) !== -1;
    };

    return {
        load: function() {
            return new ProductViews();
        }
    }
}());