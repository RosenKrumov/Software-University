import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		String[] array = new String[n];
		
		for(int i = 0; i < array.length; i++)
		{
			array[i] = input.next();
		}
		
		Arrays.sort(array);
		
		for(int i = 0; i < array.length; i++)
		{
			System.out.println(array[i]);
		}

	}

}
