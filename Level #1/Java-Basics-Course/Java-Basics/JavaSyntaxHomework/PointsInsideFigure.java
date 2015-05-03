import java.util.Locale;
import java.util.Scanner;

public class PointsInsideFigure {

	public static void main(String[] args) {

		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		double pointX = input.nextDouble();
		double pointY = input.nextDouble();

		if ((pointX >= 12.5 && pointX <= 17.5 && pointY >= 6 && pointY <= 13.5)
				|| (pointX >= 17.5 && pointX <= 20 && pointY >= 6 && pointY <= 8.5)
				|| (pointX >= 20 && pointX <= 22.5 && pointY >= 6 && pointY <= 13.5)) {
			System.out.println("Inside");
		}

		else {
			System.out.println("Outside");
		}
	}

}
