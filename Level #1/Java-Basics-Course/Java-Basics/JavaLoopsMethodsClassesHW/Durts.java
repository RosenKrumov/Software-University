import java.util.Scanner;

public class Durts {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int cX = input.nextInt();
		int cY = input.nextInt();
		double r = input.nextDouble();
		int count = input.nextInt();
		int[] points = new int[2 * count];

		for (int i = 0; i < 2 * count; i++) {
			points[i] = input.nextInt();
		}

		checkPoints(cX, cY, r, points, count);

	}
	
	static void checkPoints(int cX, int cY, double r, int[] points, int count) {
		for (int i = 0, j = 1; i < points.length; i += 2, j+=2) {
			if (points[i] >= cX - r && points[i] <= cX + r
					&& points[j] >= cY - r / 2.0 && points[j] <= cY + r / 2.0) {
				System.out.println("yes");
			} else if (points[i] >= cX - r / 2.0 && points[i] <= cX + r / 2.0
					&& points[j] >= cY - r && points[j] <= cY + r) {
				System.out.println("yes");
			} else {
				System.out.println("no");
			}
		}
	}

}
