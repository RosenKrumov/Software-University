import java.util.ArrayList;
import java.util.Scanner;


public class MagicSumNew {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		int D = Integer.parseInt(input.nextLine());
		ArrayList<Integer> numbers = new ArrayList<>();
		
		while (true) {
			String line = input.nextLine();
			
			if (line.equals("End")) {
				break;
			}
			
			numbers.add(Integer.parseInt(line));
		}
		
		int biggestSum = Integer.MIN_VALUE;
		int biggestA = 0;
		int biggestB = 0;
		int biggestC = 0;
		boolean hasMagicNums = false;
		
		for (int i = 0; i < numbers.size(); i++) {
			for (int j = i + 1; j < numbers.size(); j++) {
				for (int j2 = j + 1; j2 < numbers.size(); j2++) {
					int a = numbers.get(i).intValue();
					int b = numbers.get(j).intValue();
					int c = numbers.get(j2).intValue();
					int tempSum = 0;
					if ((a + b + c) % D == 0) {
						tempSum = a + b + c;
						hasMagicNums = true;
						if (tempSum > biggestSum) {
							biggestA = a;
							biggestB = b;
							biggestC = c;
							biggestSum = tempSum;
						}
						
					}
				}
			}
		}
		
		if (!hasMagicNums) {
			System.out.println("No");
		} else {
			System.out.printf("(%d + %d + %d) %% %d = 0", biggestA, biggestB, biggestC, D);
		}

	}

}
