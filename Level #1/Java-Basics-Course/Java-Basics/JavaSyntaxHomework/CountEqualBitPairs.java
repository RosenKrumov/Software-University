import java.util.Scanner;

public class CountEqualBitPairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int count = 0;
		String nBin = Integer.toBinaryString(n);
		for (int i = 0; i < nBin.length() - 1; i++) {
			if (nBin.charAt(i) == nBin.charAt(i + 1)) {
				count++;
			}
		}
		System.out.println(count);
	}

}
