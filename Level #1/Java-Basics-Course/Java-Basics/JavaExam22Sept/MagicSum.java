import java.util.ArrayList;
import java.util.Iterator;
import java.util.Scanner;

public class MagicSum {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		int D = Integer.parseInt(input.nextLine());
		ArrayList<Integer> numbers = new ArrayList<>();

		while (true) {

			String line = input.nextLine();

			if (line.equals("End")) {
				break;
			}

			numbers.add(Integer.parseInt(line));
		}

		int[] numbersArr = new int[numbers.size()];

		for (int i = 0; i < numbers.size(); i++) {
			numbersArr[i] = numbers.get(i);
		}

		boolean hasMagicNums = false;
		int biggIntSum = 0;
		int bigA = 0;
		int bigB = 0;
		int bigC = 0;

		for (int i = 0; i < numbersArr.length; i++) {
			for (int j = 0; j < numbersArr.length; j++) {
				for (int j2 = 0; j2 < numbersArr.length; j2++) {
					int a = numbersArr[i];
					int b = numbersArr[j];
					int c = numbersArr[j2];
					int tempSum = 0;
					if ((a + b + c) % D == 0 && (i != j && i != j2 && j != j2)) {
						tempSum = a + b + c;
						hasMagicNums = true;
						if (biggIntSum < tempSum) {
							biggIntSum = tempSum;
							bigA = a;
							bigB = b;
							bigC = c;
						}
					}
				}
			}
		}

		if (!hasMagicNums) {
			System.out.println("No");
		} else {
			System.out.printf("(%d + %d + %d) %% %d = 0", bigA, bigB, bigC, D);
		}

	}

}
