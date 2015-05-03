import java.util.LinkedHashMap;
import java.util.Scanner;


public class CouplesFrequency {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String input = scanner.nextLine();
		String[] numbers = input.split(" ");
		int totalPairs = 0;
		LinkedHashMap<String, Integer> pairsCount = new LinkedHashMap<>();
		for (int i = 0; i < numbers.length - 1; i++) {
			if (numbers[i].equals("")) {
				continue;
			}
			String pair = numbers[i] + " " + numbers[i+1];
			if (pairsCount.containsKey(pair)) {
				int count = pairsCount.get(pair);
				pairsCount.put(pair, count + 1);
			} else {
			pairsCount.put(pair,1);
			}
			totalPairs++;
		}
		
		for (String pair : pairsCount.keySet()) {
			int count = pairsCount.get(pair);
			double percent = (double)count / totalPairs * 100;
			System.out.printf("%s -> %.2f%%%n", pair, percent);
		}

	}

}
