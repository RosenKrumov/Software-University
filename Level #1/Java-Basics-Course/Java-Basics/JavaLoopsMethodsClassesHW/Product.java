import java.math.BigDecimal;

public class Product {
	private String name;
	private BigDecimal price;
	
	public Product(String inputName, BigDecimal inputPrice){
		this.name = inputName;
		this.price = inputPrice;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public BigDecimal getPrice() {
		return price;
	}
	
	public void setPrice(BigDecimal price) {
		this.price = price;
	}
	
	public String getInfo(){		
		return name + " " + price;
	}
}
