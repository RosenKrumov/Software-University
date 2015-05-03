import java.util.Scanner;
import java.util.TreeSet;


public class ExtractUniqueWords {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		String[] text = input.nextLine().toLowerCase().split("[^a-zA-Z]+");
		TreeSet<String> output = new TreeSet<>();
		
		for (String string : text) {
			output.add(string);
		}

		for (String string : output) {
			System.out.print(string + " ");
		}
	}

}
