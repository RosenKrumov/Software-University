import java.util.Scanner;


public class VideoDurations {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int sumHours = 0;
		int sumMinutes = 0;
		while(true){
			String line = input.nextLine();
			if (line.equals("End")) {
				break;
			}
			
			String[] parts = line.split(":");
			sumHours += Integer.parseInt(parts[0]);
			sumMinutes += Integer.parseInt(parts[1]);
			if (sumMinutes > 59) {
				sumHours++;
				sumMinutes -= 60;
			}
		}
		
		System.out.printf("%d:%02d", sumHours, sumMinutes);

	}

}
