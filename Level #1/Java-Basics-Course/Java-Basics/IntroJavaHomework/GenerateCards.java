import java.io.FileOutputStream;
import java.io.IOException;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfWriter;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;

public class GenerateCards {

	public static final String RESULT
		= "GenerateCards.pdf";
	
	public static void main(String[] args) 
		throws DocumentException, IOException {
		new GenerateCards().createPdf(RESULT);
	}
		
	public void createPdf(String filename)
		throws DocumentException, IOException {
		Document document = new Document();
		PdfWriter.getInstance(document, new FileOutputStream(filename));
		document.open();
		PdfPTable table = new PdfPTable(4);
		table.setWidthPercentage(30);
		table.getDefaultCell().setFixedHeight(50);
	    table.getDefaultCell().setHorizontalAlignment(Element.ALIGN_CENTER);
	    table.getDefaultCell().setVerticalAlignment(Element.ALIGN_TOP);
		BaseFont baseFont = BaseFont.createFont("C:/Windows/Fonts/times.ttf", BaseFont.IDENTITY_H, true);
		Font black = new Font(baseFont, 25f, 0,  BaseColor.BLACK);
		Font red = new Font(baseFont, 25f, 0, BaseColor.RED);
		String card = "";
		char suit = ' ';
		for (int i = 2; i < 15; i++)
        {
			switch(i) {
			case 11: 
				card = "J";
				break;
			case 12: 
				card = "Q";
				break;
			case 13: 
				card = "K";
				break;
			case 14: 
				card = "A";
				break;
			default:
				card = i + "";
				break;
			}
			for (int j = 1; j < 5; j++){
				switch(j) {
				case 1: 
					suit = '\u2663';
					table.addCell(new Paragraph(card + suit, black)); 
					break;
				case 2:
					suit = '\u2666';
					table.addCell(new Paragraph(card + suit, red)); 
					break;
				case 3:
					suit = '\u2665';
					table.addCell(new Paragraph(card + suit, red)); 
					break;
				case 4:
					suit = '\u2660';
					table.addCell(new Paragraph(card + suit, black));
					break;
				}
			}
        }
		document.add(table);
		document.close();
		}
	}


