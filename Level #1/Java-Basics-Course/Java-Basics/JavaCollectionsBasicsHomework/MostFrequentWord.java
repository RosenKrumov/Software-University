import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().toLowerCase().split("[^a-zA-Z]+");
		Map<String, Integer> wordsMap = new LinkedHashMap<>();
		for (String word : words) {
			Integer count = wordsMap.get(word);
			if (count == null) {
				count = 0;
			}
			wordsMap.put(word, count + 1);
		}
		int maxNum = 0;
		String maxNumWord = "";
		Map<String, Integer> outputMap = new TreeMap<>();
		for (String word : wordsMap.keySet()) {
			int currentNum = wordsMap.get(word);
			if (currentNum >= maxNum) {
				maxNum = currentNum;
				maxNumWord = word;
				outputMap.put(maxNumWord, maxNum);
				for (String string : outputMap.keySet()) {
					if (maxNum > outputMap.get(string)) {
						outputMap.clear();
						outputMap.put(maxNumWord, maxNum);
						break;
					} else {
						continue;
					}
				}
			}
		}
		
		for (String string : outputMap.keySet()) {
			System.out.printf("%s -> %d times%n", string, outputMap.get(string));
		}

	}

}
