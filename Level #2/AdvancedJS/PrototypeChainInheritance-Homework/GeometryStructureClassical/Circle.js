var shapes = shapes || {};

(function (shapes) {
    function Circle(centerX, centerY, radius, color) {
        this._centerX = centerX;
        this._centerY = centerY;
        this._radius = radius;
        shapes.Shape.call(this, color);
    }
    
    Circle.extends(shapes.Shape);

    Circle.prototype.toString = function () {
        var result = "Circle: ";
        result += "Center: O(" + this._centerX + ", " + this._centerY + "), ";
        result += "Radius: " + this._radius + ", ";
        result += shapes.Shape.prototype.toString.call(this);
        
        return result;
    }

    shapes.Circle = Circle;
})(shapes);