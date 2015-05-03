var shapes = shapes || {};

var triangle = (function (shapes) {
    function Triangle(pointAx, pointAy, pointBx, pointBy, pointCx, pointCy, color) {
        this._aX = pointAx;
        this._aY = pointAy;
        this._bX = pointBx;
        this._bY = pointBy;
        this._cX = pointCx;
        this._cY = pointCy;
        shapes.Shape.call(this, color);
    }

    Triangle.extends(shapes.Shape);

    Triangle.prototype.toString = function () {
        var result = "Triangle: ";
        result += "A(" + this._aX + ", " + this._aY + "), ";
        result += "B(" + this._bX + ", " + this._bY + "), ";
        result += "C(" + this._cX + ", " + this._cY + "), ";
        result += shapes.Shape.prototype.toString.call(this);
        
        return result;
    }

    shapes.Triangle = Triangle;
})(shapes);