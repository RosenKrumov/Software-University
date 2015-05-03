var shapes = shapes || {};

(function (shapes) {
	function Shape(color) {
        this._color = color;
    }
        
    Shape.prototype.toString = function () {
        return "Color: " + this._color;
    }

    shapes.Shape = Shape;
})(shapes);