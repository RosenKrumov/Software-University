import java.util.Scanner;

public class LongestIncreasingSeq {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split(" ");
		int[] numbers = new int[input.length];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(input[i]);
		}
		
		int counter = 1;
		int sequenceLength = 1;
		int endPosition = 0;		//Where in the array the sequence ends
		
		System.out.printf("%d ", numbers[0]);
		for (int i = 1; i < numbers.length; i++) {
			
			if(numbers[i] > numbers[i - 1]){
				counter++;
				System.out.printf("%d ", numbers[i]);
			} else {
				counter = 1;
				System.out.printf("\n%d ", numbers[i]);
			}
			
			if(counter > sequenceLength){
				sequenceLength = counter;
				endPosition = i;
			}
		}
		
		int startPosition = endPosition - sequenceLength + 1; //Where in the array the sequence starts
		System.out.println();
		
		System.out.print("Longest: ");
		for (int i = startPosition; i <= endPosition; i++) {
			System.out.printf("%d ", numbers[i]);
		}


	}

}
