import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;


public class Nuts {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		
		TreeMap<String, LinkedHashMap<String, Integer>> ordersMap = new TreeMap<>();
		
		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().split(" ");
			
			String company = line[0];
			String product = line[1];
			String amount = line[2];
			String amountDigit = "";
			for (int j = 0; j < amount.length() - 2; j++) {
				amountDigit += amount.charAt(j);
			}
			
			int amountDigitInt = Integer.parseInt(amountDigit);
			
			if (ordersMap.containsKey(company)) {
				if (ordersMap.get(company).containsKey(product)) {
					amountDigitInt += ordersMap.get(company).get(product);
				}
				ordersMap.get(company).put(product, amountDigitInt);
			} else {
				LinkedHashMap<String, Integer> products = new LinkedHashMap<>();
				products.put(product, amountDigitInt);
				ordersMap.put(company, products);
			}
		}
		
		for (String company : ordersMap.keySet()) {
			System.out.print(company + ": ");
			LinkedHashMap<String, Integer> products = ordersMap.get(company);
			int count = 1;
			for (String product : products.keySet()) {
				if (count < products.keySet().size()) {
					System.out.printf("%s-%dkg, ", product, products.get(product));
				} else {
					System.out.printf("%s-%dkg", product, products.get(product));
				}
				count++;
			}
			System.out.println();
		}

	}

}
