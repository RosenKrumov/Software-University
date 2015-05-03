/**
 * Created by Rosen on 23.11.2014 г..
 */
function results(arr) {

    var teams = { };

    for (var i = 0; i < arr.length; i++) {
        var currentLine = arr[i].match(/[\w ]+/g);
        var firstTeam = currentLine[0].trim();
        var opponent = currentLine[1].trim();
        var goalsScored = parseInt(currentLine[2].trim());
        var goalsConceded = parseInt(currentLine[3].trim());

        if(!teams[firstTeam]) {
            teams[firstTeam] = {
                'goalsScored' : 0,
                'goalsConceded' : 0,
                'matchesPlayedWith' : []
            };
        }

        if(!teams[opponent]) {
            teams[opponent] = {
                'goalsScored' : 0,
                'goalsConceded' : 0,
                'matchesPlayedWith' : []
            };
        }

        teams[firstTeam].goalsScored += goalsScored;
        teams[opponent].goalsConceded += goalsScored;
        teams[firstTeam].goalsConceded += goalsConceded;
        teams[opponent].goalsScored += goalsConceded;

        if(teams[firstTeam].matchesPlayedWith.indexOf(opponent) == -1) {
            teams[firstTeam].matchesPlayedWith.push(opponent);
        }

        if(teams[opponent].matchesPlayedWith.indexOf(firstTeam) == -1) {
            teams[opponent].matchesPlayedWith.push(firstTeam);
        }

    }

    var teamsKeys = Object.keys(teams).sort();
    var output = { };

    for (var j = 0; j < teamsKeys.length; j++) {
        var currTeam = teamsKeys[j];
        output[currTeam] = teams[currTeam];
        output[currTeam].matchesPlayedWith.sort();
    }

    console.log(JSON.stringify(output));
}

results([
    'Germany / Argentina: 1-0',
    'Brazil / Netherlands: 0-3',
    'Netherlands / Argentina: 0-0',
    'Brazil / Germany: 1-7',
    'Argentina / Belgium: 1-0',
    'Netherlands / Costa Rica: 0-0',
    'France / Germany: 0-1',
    'Brazil / Colombia: 2-1'
])

