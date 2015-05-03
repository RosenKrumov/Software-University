import java.util.Scanner;

public class TimeSpan {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String[] startTime = input.nextLine().split(":");
		String[] endTime = input.nextLine().split(":");

		int startHours = Integer.parseInt(startTime[0]);
		int startMinutes = Integer.parseInt(startTime[1]);
		int startSeconds = Integer.parseInt(startTime[2]);

		int endHours = Integer.parseInt(endTime[0]);
		int endMinutes = Integer.parseInt(endTime[1]);
		int endSeconds = Integer.parseInt(endTime[2]);

		int outputHours = 0;
		int outputMinutes = 0;
		int outputSeconds = 0;

		outputSeconds = startSeconds - endSeconds;
		outputMinutes = startMinutes - endMinutes;
		outputHours = startHours - endHours;

		if (outputSeconds < 0) {
			outputSeconds += 60;
			outputMinutes--;
		}
		if (outputMinutes < 0) {
			outputMinutes += 60;
			outputHours--;
		}

		System.out
				.printf("%d:%02d:%02d", outputHours, outputMinutes, outputSeconds);

	}

}
