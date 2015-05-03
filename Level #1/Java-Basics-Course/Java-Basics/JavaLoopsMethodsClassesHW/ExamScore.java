import java.util.ArrayList;
import java.util.Arrays;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class ExamScore {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		ArrayList<String> lines = new ArrayList<>();

		input.nextLine();
		input.nextLine();
		input.nextLine();

		TreeMap<Integer, TreeMap<String, Double>> entrys = new TreeMap<>();

		while (true) {
			String inputLine = input.nextLine();

			if (inputLine.startsWith("-")) {
				break;
			}

			String[] tokens = inputLine.split("[ |]+");
			System.out.println(Arrays.toString(tokens));

			String name = tokens[1] + " " + tokens[2];
			int score = Integer.parseInt(tokens[3]);
			String result = tokens[4];

			String[] entries = new String[3];
			entries[0] = name;
			entries[1] = result;

			if (!entrys.containsKey(score)) {
				TreeMap<String, Double> newMap = new TreeMap<>();
				entrys.put(score, newMap);
			}

			entrys.get(score).put(entries[0], Double.parseDouble(entries[1]));

		}
		
		for (Entry<Integer, TreeMap<String, Double>> entry : entrys.entrySet()) {
			
			Double average = 0.0;
			int count = entry.getValue().entrySet().size();
			
			for (Entry<String, Double> subentry : entry.getValue().entrySet()) {
				average += subentry.getValue();
				
			}
			
			average /= count;
		}
		
		
	}
}
