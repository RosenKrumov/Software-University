import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class SequencesEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().split(" ");
		Map<String, Integer> wordsMap = new LinkedHashMap<String, Integer>();
		for (String word : words) {
			Integer count = wordsMap.get(word);
			if (count == null) {
				count = 0;
			}
			wordsMap.put(word, count + 1);
		}
		for (String string : wordsMap.keySet()) {
			for (int i = 0; i < wordsMap.get(string); i++) {
				System.out.print(string + " ");
			}
			System.out.println();
		}
	}

}
