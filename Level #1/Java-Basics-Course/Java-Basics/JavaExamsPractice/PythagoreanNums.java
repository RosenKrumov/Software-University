import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;


public class PythagoreanNums {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int[] numbers = new int[n];
		boolean hasPythagoreanNums = false;
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = input.nextInt();
		}
		
		
		for (int i = 0; i < numbers.length; i++) {
			for (int j = 0; j < numbers.length; j++) {
				for (int j2 = 0; j2 < numbers.length; j2++) {
					int a = numbers[i];
					int b = numbers[j];
					int c = numbers[j2];
					if ((a*a + b*b == c*c) && a <= b) {
						System.out.printf("%d*%d + %d*%d = %d*%d%n", a, a, b, b, c, c);
						hasPythagoreanNums = true;
					}
				}
			}
		}
		
		if (!hasPythagoreanNums) {
			System.out.println("No");
		}

	}

}
