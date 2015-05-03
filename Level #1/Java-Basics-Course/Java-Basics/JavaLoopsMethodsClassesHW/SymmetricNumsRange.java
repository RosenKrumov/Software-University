import java.util.Scanner;

public class SymmetricNumsRange {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int start = input.nextInt();
		int end = input.nextInt();
		printNums(start, end);

	}

	static void printNums(int start, int end) {
		for (int i = start; i <= end; i++) {
			if (i < end) {
				if (i < 10) {
					System.out.print(i + " ");
				} else if (i >= 10 && i < 100) {
					if (i / 10 == i % 10) {
						System.out.print(i + " ");
					}
				} else if (i >= 100) {
					if (i % 10 == i / 100) {
						System.out.print(i + " ");
					}
				}
			} else {
				if (i < 10) {
					System.out.print(i);
				} else if (i >= 10 && i < 100) {
					if (i / 10 == i % 10) {
						System.out.print(i);
					}
				} else if (i >= 100) {
					if (i % 10 == i / 100) {
						System.out.print(i);
					}
				}
			}

		}

	}

}
