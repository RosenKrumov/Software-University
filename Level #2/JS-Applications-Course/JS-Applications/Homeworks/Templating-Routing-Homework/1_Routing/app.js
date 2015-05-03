var app = app || {};

(function(){
    app.router = Sammy(function() {
        var selector = '#wrapper';
        this.get('#/', function() {
            $(selector).empty();
        });

        this.get('#/Pesho', function(){
            $(selector).html('<h2>Hello, Pesho</h2>');
        });

        this.get('#/Gosho', function(){
            $(selector).html('<h2>Hello, Gosho</h2>');
        });

        this.get('#/Maria', function(){
            $(selector).html('<h2>Hello, Maria</h2>');
        });

        this.get('#/Ginka', function(){
            $(selector).html('<h2>Hello, Ginka</h2>');
        });
    });

    app.router.run('#/');
}());