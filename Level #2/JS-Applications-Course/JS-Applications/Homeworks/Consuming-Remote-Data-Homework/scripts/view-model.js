var app = app || {};

app.viewModel = (function(){
    function ViewModel(model) {
        this.model = model;
        this.attachEventListeners(this);
    }

    ViewModel.prototype.showAllBooks = function() {
        var _this = this;
        this.model.books.getAllBooks(
            function(booksData) {
                booksData.results.forEach(function(book) {
                   _this.addBookToDOM(book.title, book.author, book.isbn, book.objectId);
                });
            },
            function(error) {
                console.log(error.responseText);
            }
        );
    };

    ViewModel.prototype.addBook = function(viewModel) {
        var bookName = $('#book-name').val();
        var bookAuthor = $('#book-author').val();
        var bookIsbn = $('#book-isbn').val();

        viewModel.model.books.postBook(
            {
                title: bookName,
                author: bookAuthor,
                isbn: bookIsbn
            },
            function(data) {
                viewModel.addBookToDOM(bookName, bookAuthor, bookIsbn, data.objectId);
            },
            function(error) {
                console.log(error.responseText);
            }
        );
    };

    ViewModel.prototype.deleteBook = function(bookId) {
        this.model.books.removeBook(bookId,
            function(data) {
                $('#' + bookId).remove();
            },
            function(error) {
                console.log(error.responseText);
            }
        );
    };

    ViewModel.prototype.attachEventListeners = function(viewModel) {
        $('#add-book').click(function() {
           viewModel.addBook(viewModel);
            $('#book-name').val('');
            $('#book-author').val('');
            $('#book-isbn').val('');
        });
    };

    ViewModel.prototype.editBook = function(bookId, bookTitle, bookAuthor, bookIsbn) {
        this.model.books.updateBook(
            bookId,
            {
                title: bookTitle,
                author: bookAuthor,
                isbn: bookIsbn
            },
            function() {
                $('#' + bookId).find('p:first').text(bookTitle);
                $('#' + bookId).find('p:nth-child(2)').text(bookAuthor);
                $('#' + bookId).find('p:nth-child(3)').text(bookIsbn);

            },
            function(error) {
                console.log(error.responseText);
            }
        )
    };

    ViewModel.prototype.addBookToDOM = function(bookName, bookAuthor, bookIsbn, bookId) {
        var _this = this;

        var bookDiv = $('<div>').addClass('book-list');
        bookDiv.attr('id', bookId);

        var bookNameP = $('<p>').text(bookName);
        var bookAuthorP = $('<p>').text(bookAuthor);
        var bookIsbnP = $('<p>').text(bookIsbn);

        var deleteButton = $('<button>')
            .addClass('delete-book')
            .text('Delete')
            .click(function() {
                _this.deleteBook(bookId);
            });

        var header = $('<h5>Edit</h5>');

        var nameInput = $('<input><br>')
            .attr('type', 'text')
            .attr('placeholder', 'Title');

        var authorInput = $('<input><br>')
            .attr('type', 'text')
            .attr('placeholder', 'Author');

        var isbnInput = $('<input><br>')
            .attr('type', 'text')
            .attr('placeholder', 'Isbn');

        var submitButton = $('<button>')
            .addClass('edit-submit')
            .text('Edit')
            .click(function() {
                _this.editBook(bookId, nameInput.val(), authorInput.val(), isbnInput.val());
                nameInput.val('');
                authorInput.val('');
                isbnInput.val('');
            });


        var editForm = $('<div>')
            .append(header)
            .append(nameInput)
            .append(authorInput)
            .append(isbnInput)
            .append(submitButton);

        bookDiv
            .append(bookNameP)
            .append(bookAuthorP)
            .append(bookIsbnP)
            .append(deleteButton)
            .append(editForm);

        $('#books-container').append(bookDiv);
    };

    return {
        loadViewModel : function(model) {
            return new ViewModel(model);
        }
    };
}());