import java.util.Arrays;
import java.util.Scanner;

public class SmallestOf3Nums {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] numbers = input.nextLine().split(" ");
		double[] numbersD = new double[numbers.length];
		for (int i = 0; i < numbers.length; i++) {
			numbersD[i] = Double.parseDouble(numbers[i]);
		}
		Arrays.sort(numbersD);
		System.out.println(numbersD[0]);
	}

}
