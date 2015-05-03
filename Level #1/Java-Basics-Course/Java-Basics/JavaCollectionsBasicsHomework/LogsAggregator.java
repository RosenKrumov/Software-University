import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.TreeSet;


public class LogsAggregator {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		TreeMap<String, Integer> logsDurationMap = new TreeMap<>();
		LinkedHashMap<String, TreeSet<String>> logsIPsMap = new LinkedHashMap<>();
		TreeSet<String> IPs;
		
		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().split(" ");
			
			String IP = line[0];
			String name = line[1];
			int duration = Integer.parseInt(line[2]);
			
			if (logsDurationMap.containsKey(name)) {
				duration += logsDurationMap.get(name);
				logsDurationMap.put(name, duration);
			} else {
				logsDurationMap.put(name, duration);
			}
			
			IPs = logsIPsMap.get(name);
			
			if (IPs == null) {
				IPs = new TreeSet<>();
			}
			
			IPs.add(IP);
			logsIPsMap.put(name, IPs);
		}
		
		for (String string : logsDurationMap.keySet()) {
			System.out.printf("%s: %d %s%n", string, logsDurationMap.get(string), logsIPsMap.get(string));
		}
	}
}
