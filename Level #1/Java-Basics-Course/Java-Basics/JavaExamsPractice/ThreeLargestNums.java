import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;


public class ThreeLargestNums {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		BigDecimal[] numbers = new BigDecimal[n];
		
		if (n >= 3) {
			
			for (int i = 0; i < numbers.length; i++) {
				numbers[i] = input.nextBigDecimal();
			}
			
			Arrays.sort(numbers);
			
			for (int i = numbers.length - 1; i > numbers.length - 4; i--) {
				System.out.println(numbers[i].toPlainString());
			}
			
		} else {
			
			for (int i = 0; i < numbers.length; i++) {
				numbers[i] = input.nextBigDecimal();
			}
			
			Arrays.sort(numbers);
			
			for (int i = numbers.length - 1; i >= 0; i--) {
				System.out.println(numbers[i].toPlainString());
			
			}
		}
		
		

	}

}
