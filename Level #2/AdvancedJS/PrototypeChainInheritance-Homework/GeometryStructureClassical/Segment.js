var shapes = shapes || {};

(function (shapes) {
    function Segment(aX, aY, bX, bY, color) {
        shapes.Line.call(this, aX, aY, bX, bY, color);
    }
    
    Segment.extends(shapes.Line);
    
    Segment.prototype.toString = function () {
        var result = "Segment: ";
        result += "A(" + this._aX + ", " + this._aY + "), B(" + this._bX + ", " + this._bY + "), ";
        result += shapes.Shape.prototype.toString.call(this);
        
        return result;
    }
        
    shapes.Segment = Segment;
})(shapes);