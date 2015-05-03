import java.util.Scanner;

public class LongestOddEvenSeq {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		String line = input.nextLine();
		String[] lineArr = line.split("[^0-9\\-]+");
		
		int[] lineInt = new int[lineArr.length - 1];
		int oddEvenSum = 0;

		for (int i = 0; i < lineInt.length; i++) {
			lineInt[i] = Integer.parseInt(lineArr[i + 1]);
		}

		for (int i = 0, j = 1; i < lineInt.length - 2;) {
			if (lineInt[i] % 2 == 0 || lineInt[i] == 0) {
				while ((lineInt[i] % 2 == 0 || lineInt[i] == 0)
						&& (lineInt[j] % 2 != 0 || lineInt[j] == 0)) {
					oddEvenSum++;
					i+=2;
					j+=2;
				}
			} else {
				while ((lineInt[i] % 2 != 0 || lineInt[i] == 0)
						&& (lineInt[j] % 2 == 0 || lineInt[j] == 0)) {
					oddEvenSum++;
					i+=2;
					j+=2;
				}
			}
		}
		
		System.out.println(oddEvenSum);

	}

}
