/**
 * Created by Rosen on 11.11.2014 г..
 */
function variablesTypes(arr) {
    var name = arr[0];
    var age = arr[1];
    var isMale = arr[2];
    var obj = arr[3];
    console.log("My name: " + name + " //type is " + typeof(name));
    console.log("My age: " + age + " //type is " + typeof(age));
    console.log("I am male: " + isMale + " //type is " + typeof(age));
    console.log("My favourite foods are: " + obj + " //type is " + typeof(obj));
}

variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);