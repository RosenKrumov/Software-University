import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class StuckNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		boolean hasStuckNums = false;
		Set<String> numbers = new LinkedHashSet<>();

		for (int i = 0; i < n; i++) {
			numbers.add(input.next());
		}
		
		Object[] numbersObj = numbers.toArray();
		String[] numberStr = new String[numbersObj.length];

		for (int i = 0; i < numbersObj.length; i++) {
			numberStr[i] = (String) numbersObj[i];
		}
		
		for (int i = 0; i < numberStr.length; i++) {
			for (int j = 0; j < numberStr.length; j++) {
				for (int j2 = 0; j2 < numberStr.length; j2++) {
					for (int k = 0; k < numberStr.length; k++) {
						if ((numberStr[i] + numberStr[j]).equals(numberStr[j2]
								+ numberStr[k])) {
							if (numberStr[i] != numberStr[j] &&
								numberStr[i] != numberStr[j2] &&
								numberStr[i] != numberStr[k] &&
								numberStr[j] != numberStr[j2] &&
								numberStr[j] != numberStr[k] &&
								numberStr[j2] != numberStr[k]) {
								
								hasStuckNums = true;
								System.out.printf("%s|%s==%s|%s%n", numberStr[i],
										numberStr[j], numberStr[j2], numberStr[k]);
							}

						}
					}
				}
			}
		}

		if (!hasStuckNums) {
			System.out.println("No");
		}

	}
}
