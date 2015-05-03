import java.util.Scanner;

public class SumTwoNums {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.print("Please enter a number: ");
		int a = input.nextInt();
		System.out.print("Please enter a number: ");
		int b = input.nextInt();
		System.out.printf("%d + %d = %d%n",a, b, a + b);

	}

}
