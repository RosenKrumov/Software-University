var app = app || {};

app.noteModel = (function() {
    function NoteModel(baseUrl, requester, headers) {
        this.serviceUrl = baseUrl + 'classes/Note';
        this.requester = requester;
        this.headers = headers;
    }

    NoteModel.prototype.listAllTodayNotes = function(dateStr, skip) {
        var requestUrl = this.serviceUrl + '?where={"deadline":"' + dateStr + '"}&count=1&limit=10' + '&skip=' + skip;
        return this.requester.get(requestUrl, this.headers.getHeaders(true));
    };

    NoteModel.prototype.listMyNotes = function(author, skip) {
        var requestUrl = this.serviceUrl + '?where={"author":"' + author + '"}&count=1&limit=10' + '&skip=' + skip;
        return this.requester.get(requestUrl, this.headers.getHeaders(true));
    };

    NoteModel.prototype.addNote = function(author, title, text, deadline) {
        var userId = sessionStorage['userId'];
        var data = {
            author: author,
            title: title,
            text: text,
            deadline: deadline,
            ACL : {}
        };

        data.ACL[userId] = {"read":true, "write":true};
        data.ACL["*"] = {"read":true };

        return this.requester.post(this.serviceUrl + '/', this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.editNote = function(noteId, title, text, deadline) {
        var data = {
            title: title,
            text: text,
            deadline: deadline
        };

        return this.requester.put(this.serviceUrl + '/' + noteId, this.headers.getHeaders(true), data);
    };

    NoteModel.prototype.deleteNote = function(noteId) {
        return this.requester.remove(this.serviceUrl + '/' + noteId, this.headers.getHeaders(true));
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new NoteModel(baseUrl, requester, headers);
        }
    }
}());