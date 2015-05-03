package org.softuni;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Toolkit;
import java.awt.event.KeyEvent;

import javax.swing.ImageIcon;



public class Player extends Entity {

	private boolean isJump = false;
	private int speed = 0;
	int velY = 0;
	private int counter = 0;
	private int animationCounter = 0;
	
	public Player(int x, int y) {
		super(x, y);
	}

	// Player moving
	public void update() {
		if(isJump){
			speed = -Main.JUMP_SPEED;
			isJump = false;
		}
		speed += Main.GRAVITY;
		if(speed < Main.MAX_VERTICAL_SPEED){
			y += speed;
			//System.out.println("increesing"); //debug
		}else if (counter < 50){
			counter++;
			y += Main.MAX_VERTICAL_SPEED;
			//System.out.println("steady"); //debug
		} else{
			y += speed / 10;
			//System.out.println("more acceleration"); //debug
		}
		
		if (y >= Main.GAME_FLOOR) {
			y = Main.GAME_FLOOR;
		}
	}

	public void draw(Graphics2D g2d) {
		g2d.drawImage(getPlayerImg(getPlayerName()), x, y,
				getPlayerImg(getPlayerName()).getWidth(null) / 2,
				getPlayerImg(getPlayerName()).getHeight(null), null);
				Toolkit.getDefaultToolkit().sync();
		// player bounds debug
		// g2d.setColor(Color.white);
		// g2d.draw(getBounds());
	}

	public static Image getPlayerImg(String name) {
		ImageIcon ic = new ImageIcon(name);
		Image i = ic.getImage();
		return i;
	}

	// Key action
	public void keyPressed(KeyEvent e) {
		int key = e.getKeyCode();
		if (key == KeyEvent.VK_SPACE) {
			counter = 0;
			isJump = true;
		}
		if (key == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}

	public void keyReleased(KeyEvent e) {
		int key = e.getKeyCode();
		if (key == KeyEvent.VK_SPACE) {
			velY = 0;
		}
		if (key == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}

	public Rectangle getBounds() {
		return new Rectangle(x+10, y+10, (getPlayerImg(Main.PLAYER_IMAGE_NAME1).getWidth(
				null) / 2) - 20, getPlayerImg(Main.PLAYER_IMAGE_NAME1).getHeight(null)-20);
	}
	
	public String getPlayerName(){
		
		if(this.animationCounter >= 0 && animationCounter <= Main.PLAYER_ANIMATION_TIMING  ){
			animationCounter++;
			return Main.PLAYER_IMAGE_NAME1;
		}else if (animationCounter < 2*Main.PLAYER_ANIMATION_TIMING){
			animationCounter++;
			return Main.PLAYER_IMAGE_NAME2;
		}else if(animationCounter < 3*Main.PLAYER_ANIMATION_TIMING){
			animationCounter++;
			return Main.PLAYER_IMAGE_NAME3;
		}else{
			animationCounter = 0;
			return Main.PLAYER_IMAGE_NAME1;
		}
	}
}
