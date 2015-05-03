import java.util.Scanner;

public class CountBeers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int beersCount = 0;

		while (true) {
			String line = input.nextLine();
			String[] splittedInput = line.split(" ");
			
			if (line.equals("End")) {
				break;
			}

			if (splittedInput[1].equals("beers")) {
				beersCount += Integer.parseInt(splittedInput[0]);
			} else {
				beersCount += 20 * Integer.parseInt(splittedInput[0]);
			}
		}

		int stacks = beersCount / 20;
		int beers = beersCount % 20;

		System.out.printf("%d stacks + %d beers", stacks, beers);

	}

}
