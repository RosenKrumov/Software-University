import java.util.ArrayList;
import java.util.Scanner;

public class CombineListLetters {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		String[] firstLine = input.nextLine().split(" ");
		String[] secondLine = input.nextLine().split(" ");

		ArrayList<String> firstLineList = new ArrayList<>();
		for (String string : firstLine) {
			firstLineList.add(string);
		}
		String neededLetters = "";
		for (String stringSecond : secondLine) {
			if (!firstLineList.contains(stringSecond)) {
				neededLetters += stringSecond + " ";
			}
		}
		firstLineList.add(neededLetters);
		for (String string : firstLineList) {
			System.out.print(string + " ");
		}

	}

}
