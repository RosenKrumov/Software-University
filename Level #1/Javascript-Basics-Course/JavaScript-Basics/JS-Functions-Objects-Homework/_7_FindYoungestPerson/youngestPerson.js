function findYoungestPerson(persons) {

    var minAge = 9999;
    var minAgeIndex = 0;

    for (var i = 0; i < arguments.length; i++) {
        if (persons[i].age < minAge) {
            minAge = persons[i].age;
            minAgeIndex = i;
        }
        return "The youngest person is " + persons[minAgeIndex].firstname + " " + persons[minAgeIndex].lastname;
    }
}

var persons = [
    {firstname: 'George', lastname: 'Kolev', age: 32},
    {firstname: 'Bay', lastname: 'Ivan', age: 81},
    {firstname: 'Baba', lastname: 'Ginka', age: 40}];

console.log(findYoungestPerson(persons));