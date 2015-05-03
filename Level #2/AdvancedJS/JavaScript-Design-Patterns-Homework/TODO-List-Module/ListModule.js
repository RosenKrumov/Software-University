var ListModule = (function () {

    Function.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

    Object.prototype.validateNullOrEmpty = function (string, nameOfVariable) {
        if (string === null || string === undefined || string == "") {
            throw new TypeError(nameOfVariable + " cannot be null, undefined or empty.")
        }
    }

    var ListElement = (function () {
        function ListElement(title) {
            this.validateNullOrEmpty(title, "title");
            this._title = title;
        }

        return ListElement;
    }());

    var Container = (function () {
        function Container(title, sections) {
            ListElement.call(this, title);
            this._sections = sections;
        }
        
        Container.extends(ListElement);

        Container.prototype.addSection = function (section) {
            this._sections.push(section);
        }

        Container.prototype.addToDOM = function () {
            var target = document.getElementById("wrapper");
            var newElement = document.createElement("div");
            newElement.innerHTML =
                '<div id="container">' +
                '<h1>' + this._title + '</h1>' +
                '<div id="sectionContainer">' +
                '</div>' +
                '<input type="text" id="newSectionField" placeholder="Title..." />' +
                '<button class="addNewSection" onclick="addNewSection()">New Section</button>' +
                '</div>';
            target.appendChild(newElement);
        }

        return Container;
    }());


    var Section = (function () {
        var counter = 0;
        function Section(title, items) {
            ListElement.call(this, title);
            this._items = items;
            counter++;
        }
        Section.extends(ListElement);

        Section.prototype.addToDOM = function () {
            var target = document.getElementById("sectionContainer");
            var newElement = document.createElement("div");
            newElement.innerHTML =
                '<section class="clearfix" id="section' + counter +'">' +
                '<h2>' + this._title + '</h2>' +
                '</section>' +
                '<div class="addItem clearfix">' +
                '<input type="text" id="newitemfield' + counter +'" placeholder="Add item..." />' +
                '<button href="#" class="addNewItem" onclick="addNewItem(\'section' + counter +'\', \'newitemfield' + counter +'\')" >+</button>' +
                '</div>';
            target.appendChild(newElement);
        }

        Section.prototype.addItem = function (item) {
            this._items.push(item);
        }

        return Section;
    }());


    var Item = (function () {
        var counter = 0;

        function Item(title) {
            ListElement.call(this, title);
            counter++;
        }

        Item.extends(ListElement);

        Item.prototype.addToDOM = function (target) {
            var target = document.getElementById(target);
            var newElement = document.createElement("DIV");
            newElement.innerHTML =
                '<div class="contentBox">' +
                '<input onclick="changeStatus(content' + counter + ')" type="checkbox"  />'+
                '<div class="content" id="content' + counter + '">' + this._title +'</div>' +
                '</div>';
            target.appendChild(newElement);
        }
        return Item;
    }());

    return{
        ListElement: ListElement,
        Item: Item,
        Container: Container,
        Section: Section
    };
}());