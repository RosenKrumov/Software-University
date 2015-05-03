import java.util.Locale;
import java.util.Scanner;


public class DegreesToRadians {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		for (int i = 0; i < n; i++) {
			double number = input.nextDouble();
			String measure = input.next();
			if (measure.equals("deg")) {
				System.out.printf("%.6f rad\n", toRad(number));
			}
			else {
				System.out.printf("%.6f deg\n", toDeg(number));
			}
		}
	}
	
	static double toRad (double number){
		double radians = Math.toRadians(number);
		return radians;
	}
	
	static double toDeg (double number){
		double degrees = Math.toDegrees(number);
		return degrees;
	}

}
