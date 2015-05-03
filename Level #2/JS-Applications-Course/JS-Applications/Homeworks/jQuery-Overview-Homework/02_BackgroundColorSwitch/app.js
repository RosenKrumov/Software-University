$('#button').click(function() {
    var classInput = $('#classInput').val();
    classInput = '.' + classInput;
    var colorInput = $('#colorInput').val();
    $(classInput).css('background', colorInput);
});