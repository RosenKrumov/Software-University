import java.util.Scanner;


public class CountAllWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().split("[^a-zA-Z]+");
		System.out.println(words.length);

	}

}
