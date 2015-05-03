import java.util.Locale;
import java.util.Scanner;

public class PointsInsideHouse {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);

		double pointX = input.nextDouble();
		double pointY = input.nextFloat();
		double roofAX = 12.5;
		double roofAY = 8.5;
		double roofBX = 22.5;
		double roofBY = 8.5;
		double roofCX = 17.5;
		double roofCY = 3.5;
		if ((pointX >= 12.5 && pointX <= 17.5 && pointY >= 8.5 && pointY <= 13.5)
				|| (pointX >= 20 && pointX <= 22.5 && pointY >= 8.5 && pointY <= 13.5)
				|| isInTriangle(pointX, pointY, roofAX, roofAY, roofBX, roofBY,
						roofCX, roofCY)) {
			System.out.println("Inside");
		}

		else {
			System.out.println("Outside");
		}
	}

	public static boolean isInTriangle(double pointX, double pointY,
			double roofAX, double roofAY, double roofBX, double roofBY,
			double roofCX, double roofCY) {

		double ABC = Math.abs(roofAX * (roofBY - roofCY) + roofBX
				* (roofCY - roofAY) + roofCX * (roofAY - roofBY));
		double APB = Math.abs(roofAX * (roofBY - pointY) + roofBX
				* (pointY - roofAY) + pointX * (roofAY - roofBY));
		double APC = Math.abs(roofAX * (pointY - roofCY) + pointX
				* (roofCY - roofAY) + roofCX * (roofAY - pointY));
		double BPC = Math.abs(pointX * (roofBY - roofCY) + roofBX
				* (roofCY - pointY) + roofCY * (pointY - roofBY));

		boolean inside = (ABC == APB + APC + BPC);
		return inside;
	}

}
