/**
 * Created by Rosen on 23.11.2014 г..
 */
function students(arr) {

    var courses = { };
    for(var i = 0; i < arr.length; i++) {
        var currentLine = arr[i].split(/[\s]?\|[\s]?/g);
        var name = currentLine[0].trim();
        var course = currentLine[1].trim();
        var grade = Number(currentLine[2].trim());
        var visits = Number(currentLine[3].trim());

        if(!courses[course]){
            courses[course] = {
                'avgGrade':0,
                'avgVisits':0,
                'students':[],
                'countInputs':0
            };
        }

        courses[course]['avgGrade'] += grade;
        courses[course]['avgVisits'] += visits;

        if(courses[course]['students'].indexOf(name) == -1) {
            courses[course]['students'].push(name);
        }

        courses[course]['countInputs']++;

    }

    var courseKeys = Object.keys(courses).sort();

    var outputArray = {};

    for (var i = 0; i < courseKeys.length; i++) {
        var currCourse = courseKeys[i];
        outputArray[courseKeys[i]] = courses[courseKeys[i]];
        outputArray[currCourse]['students'].sort();
        outputArray[currCourse].avgGrade =
            Number((outputArray[currCourse].avgGrade/
            outputArray[currCourse].countInputs).toFixed(2));
        outputArray[currCourse].avgVisits =
            Number((outputArray[currCourse].avgVisits/
        outputArray[currCourse].countInputs).toFixed(2));

        delete outputArray[currCourse].countInputs;
    }

    console.log(JSON.stringify(outputArray));
}

students([
    'Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'

]);