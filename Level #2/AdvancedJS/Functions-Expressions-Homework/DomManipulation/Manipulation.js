var domModule = function () {
    function retrieveElements(element) {
        if (element.nodeType !== document.ELEMENT_NODE) {
            var domElement = document.querySelectorAll(element);
            return domElement;
        }
        return element;
    }

    function createElement(element) {
        if (element.nodeType !== document.ELEMENT_NODE) {
            var newElement = document.createElement(element);
            
            return newElement;
        }
        return element;
    }

    function appendChild(child, parent) {
        this.parent = retrieveElements(parent);
        this.child = createElement(child);
        
        if (this.parent !== null) {
            for (var i = 0, len = this.parent.length; i < len; i += 1) {
                this.parent[i].appendChild(this.child.cloneNode(true));
            }
        }
    }

    function getChildren(parent, selector) {
        var children = parent.querySelectorAll(":scope > " + selector);
        return children;
    }

    function removeChild(parent, selector) {
        this.parent = retrieveElements(parent);
        
        if (this.parent !== null) {
            for (var i = 0, len = this.parent.length; i < len; i += 1) {
                this.children = getChildren(this.parent[i], selector);
                for (var j = 0, childrenLen = this.children.length; j < childrenLen; j += 1) {
                    this.parent[i].removeChild(this.children[j]);
                }
            }
        }
    }
    
    function addHandler(element, chileventType, eventHandler) {
        this.parent = retrieveElements(element);
        if (this.parent !== null) {
            for (var i = 0, len = this.parent.length; i < len; i += 1) {
                this.parent[i].addEventListener(chileventType, eventHandler);
            }
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
}();

var liElement = document.createElement("li");
liElement.innerHTML = "New LI element added with javascript";
liElement.style.color = "red";
//domModule.appendChild(liElement, ".birds-list");

//domModule.removeChild("ul.birds-list", "li:first-child");

//var elements = domModule.retrieveElements(".bird");

//domModule.addHandler("li.bird", 'click', function () { alert("I'm a bird!") });

// I couldn't imagine how to test this ... I hope it works ...