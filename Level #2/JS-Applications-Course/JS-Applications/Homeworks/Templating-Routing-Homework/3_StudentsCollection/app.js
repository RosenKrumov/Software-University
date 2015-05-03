(function(){
    var array = [
        {"gender":"Male","firstName":"Joe","lastName":"Riley","age":22,"country":"Russia"},
        {"gender":"Female","firstName":"Lois","lastName":"Morgan","age":41,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Roy","lastName":"Wood","age":33,"country":"Russia"},
        {"gender":"Female","firstName":"Diana","lastName":"Freeman","age":40,"country":"Argentina"},
        {"gender":"Female","firstName":"Bonnie","lastName":"Hunter","age":23,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Joe","lastName":"Young","age":16,"country":"Bulgaria"},
        {"gender":"Female","firstName":"Kathryn","lastName":"Murray","age":22,"country":"Indonesia"},
        {"gender":"Male","firstName":"Dennis","lastName":"Woods","age":37,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Billy","lastName":"Patterson","age":24,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Willie","lastName":"Gray","age":42,"country":"China"},
        {"gender":"Male","firstName":"Justin","lastName":"Lawson","age":38,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Ryan","lastName":"Foster","age":24,"country":"Indonesia"},
        {"gender":"Male","firstName":"Eugene","lastName":"Morris","age":37,"country":"Bulgaria"},
        {"gender":"Male","firstName":"Eugene","lastName":"Rivera","age":45,"country":"Philippines"},
        {"gender":"Female","firstName":"Kathleen","lastName":"Hunter","age":28,"country":"Bulgaria"}
    ];

    //Get all students with age between 18 and 24;
    console.log(_.filter(array, function(person){
        return (person.age >= 18 && person.age <= 24);
    }));

    //Get all students whose first name is alphabetically before their last name
    console.log(_.filter(array, function(person){
        return (person.firstName < person.lastName);
    }));

    //Get only the names of all students from Bulgaria
    var fromBulgaria = _.filter(array, function(person){
        return person.country === "Bulgaria";
    });
    console.log(_.map(fromBulgaria, function(person){
        return person.firstName + ' ' + person.lastName;
    }));

    //Get the last five students
    console.log(_.takeRight(array, 5));

    //Get the first three students who are not from Bulgaria and are male
    var filtered = _.filter(array, function(person) {
        return person.country !== "Bulgaria" && person.gender === "Male";
    });

    console.log(_.take(filtered, 3));
}());