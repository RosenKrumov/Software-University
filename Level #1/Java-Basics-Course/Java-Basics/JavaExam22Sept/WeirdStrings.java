import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class WeirdStrings {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		String[] sequence = input.nextLine().split("[\\/)(| ]+");
		String splittedLine = "";
		
		for (int i = 0; i < sequence.length; i++) {
			splittedLine += sequence[i];
		}
		
		
		String[] finalSequence = splittedLine.split("[^a-zA-Z]+");
		
		ArrayList<Integer> wordSumsList = new ArrayList<>();
		
		for (int i = 0; i < finalSequence.length; i++) {
			String currWord = finalSequence[i].toLowerCase();
			int currWordSum = 0;
			for (int j = 0; j < currWord.length(); j++) {
				int currCharWeight = currWord.charAt(j) - 96;
				currWordSum += currCharWeight;
			}
			wordSumsList.add(currWordSum);
		}
		
		ArrayList<Integer> sumsList = new ArrayList<>();
		int biggestSum = 0;
		for (int i = 0; i < wordSumsList.size() - 1; i++) {
			int currSum = wordSumsList.get(i) + wordSumsList.get(i + 1);
			sumsList.add(currSum);
		}
		
		int index = sumsList.indexOf(Collections.max(sumsList));
		if (sumsList.get(index) != sumsList.get(sumsList.size() - 1)) {
			while (sumsList.get(index).intValue() == sumsList.get(index+1).intValue()) {
				index++;
			}
		}
		
		System.out.println(finalSequence[index]);
		System.out.println(finalSequence[index + 1]);
	}

}
