var shapes = shapes || {};

(function (shapes) {
    function Rectangle(topLeftX, topLeftY, width, height, color) {
        this._topLeftX = topLeftX;
        this._topleftY = topLeftY;
        this._width = width;
        this._height = height;
        shapes.Shape.call(this, color);
    }

    Rectangle.extends(shapes.Shape);

    Rectangle.prototype.toString = function () {
        var result = "Rectangle: ";
        result += "Top-left corner: A(" + this._topLeftX + ", " + this._topleftY + "), ";
        result += "Width: " + this._width + ", ";
        result += "Height: " + this._height + ", ";
        result += shapes.Shape.prototype.toString.call(this);
        
        return result;
    }

    shapes.Rectangle = Rectangle;
})(shapes);