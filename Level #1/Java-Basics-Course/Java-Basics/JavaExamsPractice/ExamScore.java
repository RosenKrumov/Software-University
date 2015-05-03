import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.TreeSet;


public class ExamScore {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		for (int i = 0; i < 3; i++) {
			input.nextLine();
		}
		
		TreeMap<Integer, TreeSet<String>> scoreMap = new TreeMap<>();
		TreeMap<String, Double> gradeMap = new TreeMap<>();
		TreeSet<String> names;
		
		while (true) {
			String line = input.nextLine();
			if (line.contains("-")) {
				break;
			}
			String[] lineArr = line.split("[ |]+");
			String name = lineArr[1] + " " + lineArr[2];
			Integer score = Integer.parseInt(lineArr[3]);
			Double grade = Double.parseDouble(lineArr[4]);
			
			gradeMap.put(name, grade);
			
			names = scoreMap.get(score);
			
			if (names == null) {
				names = new TreeSet<>();
			}
			
			names.add(name);
			scoreMap.put(score, names);
			
		}
		
		for (Integer score : scoreMap.keySet()) {
			Object[] namesE = scoreMap.get(score).toArray();
			
			double sum = 0;
			for (int i = 0; i < namesE.length; i++) {
				sum += gradeMap.get(namesE[i]);
			}
			double avg = sum / namesE.length;
			System.out.printf("%d -> %s; avg=%.2f%n", score, scoreMap.get(score), avg);
		}
	}

}
