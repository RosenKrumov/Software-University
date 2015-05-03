import java.util.Scanner;


public class CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] text = input.nextLine().toLowerCase().split("[^a-zA-Z]+");
		String word = input.nextLine();
		int matchings = 0;
		
		for (int i = 0; i < text.length; i++) {
			if (text[i].equals(word)) {
				matchings++;
			}
		}
		
		System.out.println(matchings);

	}

}
