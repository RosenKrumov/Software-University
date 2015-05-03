import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class CognateWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String line = input.nextLine();
		
		ArrayList<String> array = new ArrayList<>();
		Pattern pat = Pattern.compile("[a-zA-Z]+");
		Matcher matcher = pat.matcher(line);
		
		while(matcher.find()){
			array.add(matcher.group());
		}
		
		
		HashSet<String> matches = new HashSet<>();
		int matchings = 0;
		for (int i = 0; i < array.size(); i++) {
			for (int j = 0; j < array.size(); j++) {
				for (int j2 = 0; j2 < array.size(); j2++) {
					String concat = array.get(i) + array.get(j);
					if (concat.equals(array.get(j2))) {
						String str = array.get(i)+ "|" + array.get(j) + "=" + array.get(j2);
						matches.add(str);
						matchings++;
					}
				}
			}
		}
		for (String match : matches) {
			System.out.println(match);
		}
		if (matchings == 0) {
			System.out.println("No");
		}
	}

}
