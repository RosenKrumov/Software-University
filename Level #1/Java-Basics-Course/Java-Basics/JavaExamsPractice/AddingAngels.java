import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class AddingAngels {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		int count = input.nextInt();
		int[] degrees = new int[count];
		boolean hasMatches = false;

		for (int i = 0; i < count; i++) {
			degrees[i] = input.nextInt();
		}

		for (int i = 0; i < degrees.length; i++) {
			for (int j = i + 1; j < degrees.length; j++) {
				for (int k = j + 1; k < degrees.length; k++) {
					int sum = degrees[i] + degrees[j] + degrees[k];
					if (sum % 360 == 0) {
						System.out.printf("%d + %d + %d = %d degrees%n",
								degrees[i], degrees[j], degrees[k], sum);
						hasMatches = true;
					}
				}
			}
		}
		if (!hasMatches) {
			System.out.println("No");
		}

	}
}
