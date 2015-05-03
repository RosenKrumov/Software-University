import java.io.BufferedReader;
import java.io.FileReader;

public class SumNumsTxt {

	public static void main(String[] args) {
		int sum = 0;
		try(
				BufferedReader fileReader = new BufferedReader(new FileReader("input.txt"));
		){
			while(true){
				String line = fileReader.readLine();
				if (line == null) {
					break;
				}
				int lineInt = Integer.parseInt(line);
				sum += lineInt;
			}	
			System.out.println(sum);
		}
		catch(Exception ex){
			System.out.println("Error");
		}
	}
}
