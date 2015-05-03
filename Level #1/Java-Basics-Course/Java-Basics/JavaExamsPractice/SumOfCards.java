import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class SumOfCards {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String[] cards = input.nextLine().split("[SCHD ]+");
		int sum = 0;

		for (int i = 0; i < cards.length; i++) {
			switch (cards[i]) {
			case "J":
				cards[i] = "12";
				break;
			case "Q":
				cards[i] = "13";
				break;
			case "K":
				cards[i] = "14";
				break;
			case "A":
				cards[i] = "15";
				break;
			default:
				break;
			}
		}
		int tempSum = 0;
		for (int i = 0; i < cards.length;) {
			if (i < cards.length - 1) {
				if (cards[i].equals(cards[i + 1])) {
					while (i < cards.length - 1 && (cards[i].equals(cards[i + 1])
							|| cards[i].equals(cards[i - 1]))) {
						tempSum += Integer.parseInt(cards[i]);
						i++;
					}
					tempSum *= 2;
					sum += tempSum;
					tempSum = 0;
				} else {
					sum += Integer.parseInt(cards[i]);
					i++;
				}
			} else {
				if (cards.length == 1) {
					sum += Integer.parseInt(cards[i]);
					i++;
				}
				else if (cards[i].equals(cards[i - 1])) {
					sum += 2*Integer.parseInt(cards[i]);
					i++;
				} else {
					sum += Integer.parseInt(cards[i]);
					i++;
				}
			}
			
		}
		System.out.println(sum);

	}

}
