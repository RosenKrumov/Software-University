package org.softuni;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;

import javax.swing.ImageIcon;


public class GreenLine extends Entity{

	public GreenLine(int x, int y) {
		super(x, y);
	}
	
	public void draw(Graphics g) {
		Graphics2D g2d = (Graphics2D) g;
		g2d.drawImage(getLineImg(), x, y, null);
	}
	
	public static Image getLineImg(){
		ImageIcon ic = new ImageIcon("verticalPipe.png");
		Image i = ic.getImage();
		return i;
	}
	
	public void lineMove() {
		if (x >= - 26 - getLineImg().getWidth(null)) {
			x -= Main.PIPE_SPEED;
		} else {
			x += 2*getLineImg().getWidth(null) - 2;
		}
	}
}
