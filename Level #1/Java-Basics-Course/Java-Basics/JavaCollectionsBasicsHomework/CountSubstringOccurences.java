import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class CountSubstringOccurences {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
	    String str = input.nextLine().toLowerCase();
	    String word = input.nextLine();
	    Pattern p = Pattern.compile(word);
	    Matcher m = p.matcher(str);
	    int count = 0;
	    
	    while (m.find()){
	    	count++;
	    }
	    
	    System.out.println(count);

	}

}
