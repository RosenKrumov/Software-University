import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ExtractEmails {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine();
		Pattern p = Pattern
				.compile(
						"([a-zA-Z0-9\\+\\.\\_\\%\\-\\+]{1,256}\\@[a-zA-Z0-9][a-zA-Z0-9\\-]{0,64}(\\.[a-zA-Z0-9][a-zA-Z0-9\\-]{0,25})+)",
						Pattern.CASE_INSENSITIVE);
		Matcher matcher = p.matcher(text);
		ArrayList<String> email = new ArrayList<>();

		while (matcher.find()) {
			email.add(matcher.group());
		}

		for (String string : email) {
			System.out.println(string);
		}
	}

}
