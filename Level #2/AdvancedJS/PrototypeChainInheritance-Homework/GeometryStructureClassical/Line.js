var shapes = shapes || {};

(function (shapes) {
    function Line(aX, aY, bX, bY, color) {
        this._aX = aX;
        this._aY = aY;
        this._bX = bX;
        this._bY = bY;
        shapes.Shape.call(this, color);
    }
    
    Line.extends(shapes.Shape);
    
    Line.prototype.toString = function () {
        var result = "Line: ";
        result += "A(" + this._aX + ", " + this._aY + "), B(" + this._bX + ", " + this._bY + "), ";
        result += shapes.Shape.prototype.toString.call(this);
        
        return result;
    }
        
    shapes.Line = Line;
})(shapes);