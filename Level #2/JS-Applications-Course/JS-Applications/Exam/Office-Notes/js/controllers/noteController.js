var app = app || {};

app.noteController = (function () {
    function NoteController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    NoteController.prototype.loadAddNoteView = function(selector) {
        this.viewBag.addNote.addNoteView(selector);
    };

    NoteController.prototype.loadNoteView = function(selector, urlParams, action) {
        var data = urlParams.split('&');
        var outData = {
            id : data[0].split('id=')[1],
            title: data[1].split('title=')[1],
            text: data[2].split('text=')[1],
            deadline: data[3].split('deadline=')[1]
        };

        if(action === 'delete') {
            this.viewBag.deleteNote.deleteNoteView(selector, outData);
        } else {
            this.viewBag.editNote.editNoteView(selector, outData);
        }
    };

    NoteController.prototype.listNotes = function (selector, condition, currentPage) {
        var _this = this;
        var skip = (currentPage - 1) * 10;
        if(condition === "My notes") {
            var author = sessionStorage['fullName'];
            return this.model.listMyNotes(author, skip)
                .then(function (data) {
                    _this.viewBag.listNotes.loadNotesView(condition, selector, data)
                        .then(function() {
                            $('#pagination').pagination({
                                items: data.count,
                                itemsOnPage: 10,
                                cssStyle: 'light-theme',
                                hrefTextPrefix: '#/myNotes/'
                            }).pagination('selectPage', currentPage);
                        })
                }, function () {
                    Noty.error('An error occurred while listing the notes');
                })
        } else {
            var today = getCurrentDate();

            return this.model.listAllTodayNotes(today, skip)
                .then(function (data) {
                    _this.viewBag.listNotes.loadNotesView(condition, selector, data)
                        .then(function() {
                            $('#pagination').pagination({
                                items: data.count,
                                itemsOnPage: 10,
                                cssStyle: 'light-theme',
                                hrefTextPrefix: '#/office/'
                            }).pagination('selectPage', currentPage);
                        });
                }, function () {
                    Noty.error('An error occurred while listing the notes');
                })
        }
    };

    NoteController.prototype.addNote = function (title, text, deadline) {
        var author = sessionStorage['fullName'];
        return this.model.addNote(author, title, text, deadline)
            .then(function() {
                window.location.replace('#/myNotes/');
                Noty.success('Note added successfully');
            }, function() {
                Noty.error('Error adding note');
            })
    };

    NoteController.prototype.editNote = function (phoneId, title, text, deadline) {
        return this.model.editNote(phoneId, title, text, deadline)
            .then(function() {
                window.location.replace('#/myNotes/');
                Noty.success('Note edited successfully');
            }, function() {
                Noty.error('Error editing note');
            })
    };

    NoteController.prototype.deleteNote = function (phoneId) {
        return this.model.deleteNote(phoneId)
            .then(function() {
                window.location.replace('#/myNotes/');
                Noty.success('Note deleted successfully');
            }, function() {
                Noty.error('Error deleting note');
            })
    };

    function getCurrentDate() {
        var today = new Date();
        var day = today.getDate();
        var month = today.getMonth()+1;
        var year = today.getFullYear();

        if(day<10) {
            day='0'+day
        }

        if(month<10) {
            month='0'+month
        }

        today = year + '-' + month + '-' + day;

        return today;
    }

    return {
        load: function (model, views) {
            return new NoteController(model, views);
        }
    }
}());