import java.util.HashMap;
import java.util.Locale;
import java.io.File;
import java.io.IOException;

import jxl.*;
import jxl.read.biff.BiffException;

public class Excel {

	public static void main(String[] args) throws BiffException, IOException {
		Locale.setDefault(Locale.ROOT);
		HashMap<String, Double> incomes = new HashMap<>();
		Workbook workbook = Workbook.getWorkbook(new File("3. Incomes-Report.xls"));
		Sheet sheet = workbook.getSheet(0);
		for (int i = 0; i < sheet.getRows(); i++) {
			Cell city = sheet.getCell(0,i);
			Cell income  = sheet.getCell(5,i);
			if (incomes.containsKey(city)) {
				incomes.replace(city.getContents(), incomes.get(city), Double.parseDouble(income.getContents()));
			}
			incomes.put(city.getContents(), Double.parseDouble(income.getContents()));
		}
		for (String key : incomes.keySet()) {
			System.out.println("" + key + " -> " + incomes.get(key));
		}

	}

}
