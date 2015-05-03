import java.util.Scanner;

public class Largest3Rect {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		String[] line = input.nextLine().split("[\\D]+");
		int[] numbers = new int[line.length - 1];

		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(line[i + 1]);
		}

		int largestSum = 0;

		for (int i = 0; i < numbers.length - 5; i += 2) {
			int tempSum = numbers[i] * numbers[i + 1] + numbers[i + 2]
					* numbers[i + 3] + numbers[i + 4] * numbers[i + 5];
			if (largestSum < tempSum) {
				largestSum = tempSum;
			}
		}
		
		System.out.println(largestSum);

	}

}
