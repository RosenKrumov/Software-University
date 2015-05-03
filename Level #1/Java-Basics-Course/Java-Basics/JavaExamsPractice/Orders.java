import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;


public class Orders {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		
		LinkedHashMap<String, TreeMap<String, Integer>> ordersMap = new LinkedHashMap<>();
		
		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().split(" ");
			
			String name = line[0];
			int count = Integer.parseInt(line[1]);
			String product = line[2];
			
			if (ordersMap.containsKey(product)) {
				if (ordersMap.get(product).containsKey(name)) {
					count += ordersMap.get(product).get(name);
				}
				ordersMap.get(product).put(name, count);
			} else {
				TreeMap<String, Integer> orders = new TreeMap<>();
				orders.put(name, count);
				ordersMap.put(product, orders);
			}
		}
		
		for (String product : ordersMap.keySet()) {
			System.out.print(product + ": ");
			TreeMap<String, Integer> orders = ordersMap.get(product);
			int count = 1;
			for (String name : orders.keySet()) {
				if (count < orders.keySet().size()) {

					System.out.printf("%s %d, ", name, orders.get(name));
				} else {

					System.out.printf("%s %d", name, orders.get(name));
				}
				count++;
			}
			System.out.println();
		}

	}

}
