(function(){
    $.get('template.html', function (template) {
        var json = {
            "info": [
                {
                    "name": 'Garry Finch',
                    "job": 'Front End Technical Lead',
                    "website": "http://website.com"
                },
                {
                    "name": 'Bob McFray',
                    "job": 'Photographer',
                    "website": "http://goo.gle"
                },
                {
                    "name": "Jenny O'Sullivan",
                    "job": "LEGO Geek",
                    "website": "http://stackoverflow.com"
                }
            ]
        };
        var outp = Mustache.render(template, json);
        $('#wrapper').html(outp);
    });
}());
