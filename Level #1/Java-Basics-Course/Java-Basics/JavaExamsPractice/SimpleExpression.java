import java.util.Locale;
import java.util.Scanner;
import java.math.BigDecimal;

public class SimpleExpression {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		Locale.setDefault(Locale.ROOT);
		String line = input.nextLine();
		line = line.trim();
		line = line.replaceAll(" ", "");
		String[] numbers = line.split("[+-]");
		BigDecimal[] numbersFinal = new BigDecimal[numbers.length];
		for (int i = 0; i < numbers.length; i++) {
			numbersFinal[i] = new BigDecimal(numbers[i]);
		}
		String[] chars = line.split("[0-9.]+");
		BigDecimal sum = new BigDecimal(0);

		if (chars[0].equals("")) {
			if (numbersFinal[0].equals("")) {
				sum = sum.add(numbersFinal[1]);
				for (int j = 1, i = 2; j < chars.length; j++, i++) {
					if (chars[j].equals("+")) {
						sum = sum.add(numbersFinal[i]);
					} else {
						sum = sum.subtract(numbersFinal[i]);
					}

				}
			} else {
				sum = sum.add(numbersFinal[0]);
				for (int j = 1, i = 1; j < chars.length; j++, i++) {
					if (chars[j].equals("+")) {
						sum = sum.add(numbersFinal[i]);
					} else {
						sum = sum.subtract(numbersFinal[i]);
					}

				}
			}

		} else {
			if (numbersFinal[0].equals("")) {
				sum = sum
						.subtract(numbersFinal[1]);
				for (int j = 1, i = 2; j < chars.length; j++, i++) {
					if (chars[j].equals("+")) {
						sum = sum.add(numbersFinal[i]);
					} else {
						sum = sum.subtract(numbersFinal[i]);
					}

				}
			} else {
				sum = sum
						.subtract(numbersFinal[0]);
				for (int j = 1, i = 1; j < chars.length; j++, i++) {
					if (chars[j].equals("+")) {
						sum = sum.add(numbersFinal[i]);
					} else {
						sum = sum.subtract(numbersFinal[i]);
					}

				}
			}
		}

		System.out.println(sum);

	}

}