import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class LargestSequenceEqualStrings {

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
		int maxNum = 0;
		String maxNumWord = "";
		for (String word : wordsMap.keySet()) {
			int currentNum = wordsMap.get(word);
			if (currentNum > maxNum) {
				maxNum = currentNum;
				maxNumWord = word;
			}
		}
		for (int i = 0; i < maxNum; i++) {
			System.out.print(maxNumWord + " ");
		}
	}

}
