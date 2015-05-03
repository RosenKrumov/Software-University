import java.util.Scanner;


public class DozenEggs {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		
		int eggsCount = 0;
		
		for (int i = 0; i < 7; i++) {
			String line = input.nextLine();
			String[] splittedInput = line.split(" ");
			
			if (splittedInput[1].equals("eggs")) {
				eggsCount += Integer.parseInt(splittedInput[0]);
			} else {
				eggsCount += 12 * Integer.parseInt(splittedInput[0]);
			}
		}
		
		int dozens = eggsCount / 12;
		int eggs = eggsCount % 12;
		
		System.out.printf("%d dozens + %d eggs", dozens, eggs);
	}

}
