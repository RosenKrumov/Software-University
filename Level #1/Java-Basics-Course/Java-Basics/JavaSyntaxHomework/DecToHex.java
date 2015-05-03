import java.util.Scanner;


public class DecToHex {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int number = input.nextInt();
		String numberHex = Integer.toHexString(number);
		System.out.println(numberHex.toUpperCase());

	}

}
