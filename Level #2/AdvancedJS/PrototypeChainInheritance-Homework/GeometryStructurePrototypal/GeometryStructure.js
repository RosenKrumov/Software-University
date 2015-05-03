Object.prototype.extends = function (properties) {
    function f() { }    ;
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
}

var Shapes = (function () {
    var shape = {
        init: function (color) {
            this._color = color;
        },
        toString: function () {
            return "Color: " + this._color + "\n";
        }
    }
    
    var circle = shape.extends({
        init: function (centerX, centerY, radius, color) {
            this._super.init(color);
            this._centerX = centerX;
            this._centerY = centerY;
            this._radius = radius;
        },
        toString: function () {
            var result = "Circle: \n";
            result += "O(" + this._centerX + ", " + this._centerY + ")\n";
            result += "Radius: " + this._radius + "\n";
            result += this._super.toString();
            
            return result;
        }
    });
    
    var rectangle = shape.extends({
        init: function (topLeftX, topLeftY, width, height, color) {
            this._super.init(color);
            this._topLeftX = topLeftX;
            this._topleftY = topLeftY;
            this._width = width;
            this._height = height;
        },
        toString: function () {
            var result = "Rectangle: ";
            result += "Top-Left(" + this._topLeftX + ", " + this._topleftY + ")\n";
            result += "Width: " + this._width + "\n";
            result += "Height: " + this._height + "\n";
            result += this._super.toString();
            
            return result;
        }
    });
    
    var triangle = shape.extends({
        init: function (aX, aY, bX, bY, cX, cY, color) {
            this._super.init(color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            this._cX = cX;
            this._cY = cY;
        },
        toString: function () {
            var result = "Triangle: ";
            result += "A(" + this._aX + ", " + this._aY + ")\n";
            result += "B(" + this._bX + ", " + this._bY + ")\n";
            result += "C(" + this._cX + ", " + this._cY + ")\n";
            result += this._super.toString();
            
            return result;
        }
    });
    
    var line = shape.extends({
        init: function (aX, aY, bX, bY, color) {
            this._super.init(color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
        },
        toString: function () {
            var result = "Line: ";
            result += "A(" + this._aX + ", " + this._aY + ")\n";
            result += "B(" + this._bX + ", " + this._bY + ")\n";
            result += this._super.toString();
            
            return result;
        }
    });
    
    var segment = line.extends({
        init: function (aX, aY, bX, bY, color) {
            this._super.init(aX, aY, bX, bY, color);
        },
        toString: function () {
            var result = "Segment: ";
            result += "A(" + this._aX + ", " + this._aY + ")\n";
            result += "B(" + this._bX + ", " + this._bY + ")\n";
            result += this._super._super.toString();
            
            return result;
        }
    });
    
    return {
        Circle: circle,
        Rectangle: rectangle,
        Triangle: triangle,
        Line: line,
        Segment: segment
    }
})();

var circle = Object.create(Shapes.Circle);
circle.init(1, 1, 10, "#000000");
console.log(circle.toString());

var rectangle = Object.create(Shapes.Rectangle);
rectangle.init(2, 2, 3, 3, "#FFFFFF");
console.log(rectangle.toString());

var triangle = Object.create(Shapes.Triangle);
triangle.init(4, 4, 5, 5, 6, 6, "#00FF00");
console.log(triangle.toString());

var line = Object.create(Shapes.Line);
line.init(7, 7, 8, 8, "#FF0000");
console.log(line.toString());

var segment = Object.create(Shapes.Segment);
segment.init(9, 9, 10, 10, "#0000FF");
console.log(segment.toString());