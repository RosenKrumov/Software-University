package org.softuni;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.util.Random;

import javax.swing.ImageIcon;

public class Pipe extends Entity {
	Random r = new Random();
	private int pipeHeight;
	private int pipeY; 
	private int hatUpY;
	private int hatDownY;
	private int pipeUpHeight;
	private Player player;
	private Score score;
	private boolean scoreAdded = false;
	
	public Pipe(int x, int y, Player player, Score score) {
		super(x, y);
		this.player = player;
		this.score = score;
		
		pipeHeight = Main.MIN_PIPE_HEIGHT + r.nextInt(Main.MAX_PIPE_HEIGHT);
	}

	//Pipe and hat drawing
	public void draw(Graphics g) {
		pipeY = Main.GAME_FLOOR + Player.getPlayerImg(Main.PLAYER_IMAGE_NAME1).getHeight(null)
				- pipeHeight;
		hatUpY = pipeY - Main.HAT_HEIGHT;
		hatDownY = hatUpY - Main.PIPE_SPACING - Main.HAT_HEIGHT;
		pipeUpHeight = hatDownY;

		Graphics2D g2d = (Graphics2D) g;

		//debugging
		//g2d.setColor(Color.white);
		//g2d.draw(getEnemyBounds()[1]);
		//g2d.draw(getEnemyBounds()[2]);
		
		g2d.drawImage(getPipeImgs("hoodMiddle.png"), x, pipeY, Main.PIPE_WIDTH,
				pipeHeight, null);
		g2d.drawImage(getPipeImgs("hoodUp.png"), x - 12, hatUpY,
				Main.HAT_WIDTH, Main.HAT_HEIGHT, null);
		g2d.drawImage(getPipeImgs("hatDown.png"), x - 12, hatDownY,
				Main.HAT_WIDTH, Main.HAT_HEIGHT, null);
		g2d.drawImage(getPipeImgs("hoodMiddle.png"), x, 0, Main.PIPE_WIDTH,
				pipeUpHeight, null);
		
	}

	public Image getPipeImgs(String name) {
		ImageIcon ic = new ImageIcon(name);
		Image i = ic.getImage();
		return i;
	}
	
	public void pipeMove(){
		if (x >= - Main.HAT_WIDTH) {
			x -= Main.PIPE_SPEED;
		} else {
			x = Main.SCREEN_WIDTH + 40;
			pipeHeight = Main.MIN_PIPE_HEIGHT + r.nextInt(Main.MAX_PIPE_HEIGHT);
			scoreAdded = false;
		}
	}
	
	private Rectangle getBounds(int x, int y, int height, int width) {
		return new Rectangle(x, y, height, width);
	}
	
	
	public Rectangle[] getEnemyBounds() {
		Rectangle[] enemyBounds = new Rectangle[4];
		enemyBounds[0] = getBounds(x, pipeY, Main.PIPE_WIDTH, pipeHeight);
		enemyBounds[1] = getBounds(x - 6, hatUpY + 3, Main.HAT_WIDTH-12, Main.HAT_HEIGHT-3);
		enemyBounds[2] = getBounds(x - 6, hatDownY + 3, Main.HAT_WIDTH-12, Main.HAT_HEIGHT-3);
		enemyBounds[3] = getBounds(x, 0, Main.PIPE_WIDTH, pipeUpHeight);
		return enemyBounds;
	}
	public void updateScore(){
		if(this.x < player.x && scoreAdded == false){
			score.increaseScore(1);
			Sound.play("scoreSound.wav");
			scoreAdded = true;
		}
	}
}
