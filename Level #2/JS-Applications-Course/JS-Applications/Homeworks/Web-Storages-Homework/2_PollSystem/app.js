(function(){
    var questions = [],
        trueAnswerIds = ['q1a4', 'q2a4', 'q3a4'],
        timer = new Timer(300, '#timer', showResults);

    function loadQuestions(selector, trueAnswerIds){
        $(selector).each(function (index, $question) {
            var question = new Question($question.id);
            question.setTrueAnswer(trueAnswerIds[index]);
            question.loadUserAnswer();
            questions[$question.id] = question;
        });
    }

    function showResults(){
        timer.stop();
        $('#submitButton').hide();
        var key;
        for(key in questions){
            questions[key].showTrueAnswer();
            questions[key].emptyStorage();
        }
    }

    loadQuestions('ul li', trueAnswerIds);
    $('ul').on('click', 'input[type=radio]', function (e) {
        var id = $(e.target).parent().attr('id'),
            answerId = $(e.target).attr('id');
        questions[id].saveUserAnswer(answerId);
    });
    $('#submitButton').on('click', showResults);
    timer.start();

})();