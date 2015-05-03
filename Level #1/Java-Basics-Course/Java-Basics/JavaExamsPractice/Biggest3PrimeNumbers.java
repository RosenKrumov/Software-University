import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class Biggest3PrimeNumbers {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		String[] numbers = input.nextLine().split("[( )]+");
		Set<Integer> primeNums = new TreeSet<>();
		int[] numbersInt = new int[numbers.length];
		int[] biggestNums = new int[3];
		boolean prime = true;
		int sum = 0;
		boolean empty = true;
		for (int i = 1; i < numbers.length; i++) {
			numbersInt[i] = Integer.parseInt(numbers[i]);
		}
		
		for (int i : numbersInt) {
			for (int j = 2; j <= Math.sqrt(i); j++) {
				
			}
			primeNums.add(i);
		}

			for (int i = 0; i < 3; i++) {
				sum += ((TreeSet<Integer>) primeNums).last();
				primeNums.remove(((TreeSet<Integer>) primeNums).last());
			}

		System.out.println(sum);

	}
}