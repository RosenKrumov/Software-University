import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Locale;

public class OrderOfProducts {

	public static void main(String[] args) throws IOException {
		Locale.setDefault(Locale.ROOT);

		BigDecimal totalPrice = new BigDecimal(0);

		PrintWriter out = new PrintWriter(new FileWriter("output.txt"));

		ArrayList<Product> products = new ArrayList<>();

		try (BufferedReader fileReader = new BufferedReader(new FileReader(
				"products.txt"));) {
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

		try (BufferedReader fileReader = new BufferedReader(new FileReader(
				"order.txt"));) {
			while (true) {
				String line = fileReader.readLine();
				if (line == null) {
					break;
				}
				String[] data = line.split(" ");

				BigDecimal quant = new BigDecimal(data[0]);
				for (Product product : products) {
					if (product.getName().equals(data[1])) {
						BigDecimal currentPrice = quant.multiply(product
								.getPrice());
						totalPrice = totalPrice.add(currentPrice);
					}
				}

			}

		} catch (Exception ex) {
			System.out.println("Error");
		}

		DecimalFormat df = new DecimalFormat("##.0");

		out.printf(df.format(totalPrice));
		out.close();
	}

}
