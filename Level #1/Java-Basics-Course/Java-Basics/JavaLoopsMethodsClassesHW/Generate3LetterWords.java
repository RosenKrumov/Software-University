import java.util.Scanner;

public class Generate3LetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String chars = input.nextLine();
		for (int i = 0; i < chars.length(); i++) {
			for (int j = 0; j < chars.length(); j++) {
				for (int k = 0; k < chars.length(); k++) {
					System.out.print(chars.charAt(i));
					System.out.print(chars.charAt(j));
					System.out.print(chars.charAt(k));
					System.out.print(" ");

				}
			}
		}

	}

}
