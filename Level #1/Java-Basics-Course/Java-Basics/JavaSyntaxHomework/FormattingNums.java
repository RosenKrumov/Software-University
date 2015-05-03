import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class FormattingNums {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		int a = input.nextInt();
		String aHex = Integer.toHexString(a);
		String aBin = Integer.toBinaryString(a);
		aBin = String.format("%010d", Integer.parseInt(aBin));
		double b = input.nextDouble();
		double c = input.nextDouble();
		DecimalFormat formatB = new DecimalFormat("0.00");
		DecimalFormat formatC = new DecimalFormat("0.000");
		System.out.printf("|%-10s|%s|%10s|%-10s|", aHex.toUpperCase(), aBin,
				formatB.format(b), formatC.format(c));

	}

}
