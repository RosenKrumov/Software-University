import java.util.Scanner;


public class CountBitsOne {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String nBin = Integer.toBinaryString(n);
		int count = 0;
		for (int i = 0; i < nBin.length(); i++) {
			if (nBin.charAt(i) == '1') {
				count++;
			}
		}
		System.out.println(count);
	}

}
