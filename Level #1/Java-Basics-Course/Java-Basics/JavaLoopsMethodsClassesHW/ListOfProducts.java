import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collections;
import java.util.LinkedList;

public class ListOfProducts {

	public static void main(String[] args) throws IOException {
		PrintWriter out = new PrintWriter(new FileWriter("output.txt"));

		ArrayList<Product> products = new ArrayList<>();
		ArrayList<BigDecimal> prices = new ArrayList<>();
		LinkedList<String> output = new LinkedList<>();

		try (BufferedReader fileReader = new BufferedReader(new FileReader(
				"input.txt"));) {
			while (true) {
				String line = fileReader.readLine();
				if (line == null) {
					break;
				}
				String[] data = line.split(" ");

				products.add(new Product(data[0], new BigDecimal(data[1])));

			}

		} catch (Exception ex) {
			System.out.println("Error");
		}
		for (Product product : products) {
			prices.add(product.getPrice());
		}

		Collections.sort(prices);

		for (BigDecimal price : prices) {
			for (int i = 0; i < products.size(); i++) {
				if (price == products.get(i).getPrice()) {
					output.add(products.get(i).getPrice() + " "
							+ products.get(i).getName());
				}
			}
		}

		for (String line : output) {
			out.println(line);
		}

		out.close();
	}

}
