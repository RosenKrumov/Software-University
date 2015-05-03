import java.util.Scanner;
import org.joda.time.DateTime;
import org.joda.time.Days;
import org.joda.time.LocalDate;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;

public class DaysBetweenDates {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String firstDate = input.nextLine();
		String secondDate = input.nextLine();
		System.out.println(numberOfDays(firstDate, secondDate));
	}

	static int numberOfDays(String firstDate, String secondDate) {
		DateTimeFormatter dateStringFormat = DateTimeFormat
				.forPattern("dd-MM-yyyy");
		DateTime firstTime = dateStringFormat.parseDateTime(firstDate);
		DateTime secondTime = dateStringFormat.parseDateTime(secondDate);
		int days = Days.daysBetween(new LocalDate(firstTime),
				new LocalDate(secondTime)).getDays();
		return days;
	}

}
