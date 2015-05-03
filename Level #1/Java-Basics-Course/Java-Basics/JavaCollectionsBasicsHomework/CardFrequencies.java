import java.util.LinkedHashMap;
import java.util.Scanner;


public class CardFrequencies {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		String[] cards = input.nextLine().split("[♥♣♦♠ ]+");
		LinkedHashMap<String, Integer> cardsFrequencies = new LinkedHashMap<>();
		int totalCards = 0;
		for (int i = 0; i < cards.length; i++) {
			if (cardsFrequencies.containsKey(cards[i])) {
				int count = cardsFrequencies.get(cards[i]);
				cardsFrequencies.put(cards[i], count + 1);
			} else {
			cardsFrequencies.put(cards[i], 1);
			}
			totalCards++;
		}
		
		for (String card : cardsFrequencies.keySet()) {
			int count = cardsFrequencies.get(card);
			double percent = (double)count / totalCards * 100;
			System.out.printf("%s -> %.2f%%%n", card, percent);
		}

	}

}
