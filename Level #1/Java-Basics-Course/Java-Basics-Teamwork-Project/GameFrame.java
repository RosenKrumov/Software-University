package org.softuni;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.ImageIcon;
import javax.swing.JPanel;
import javax.swing.Timer;

public class GameFrame extends JPanel implements ActionListener {

	/**
	 * something needed for jPanel
	 */
	private static final long serialVersionUID = 1L;
	Player player;
	GreenLine greenLine;
	GreenLine secondGreenLine;
	Timer mainTimer;
	Pipe[] pipes = new Pipe[3];
	private boolean gameOver = false;
	public Score score;

	// setting up the game frame
	public GameFrame() {
		setFocusable(true);
		requestFocus();
		requestFocusInWindow();
		player = new Player(Main.PLAYER_START_X, Main.PLAYER_START_Y);
		score = new Score();
		pipes[0] = (new Pipe(Main.SCREEN_WIDTH, 450, player, score));
		pipes[1] = (new Pipe(Main.SCREEN_WIDTH + Main.PIPE_DISTANCE, 450,
				player, score));
		pipes[2] = (new Pipe(Main.SCREEN_WIDTH + Main.PIPE_DISTANCE * 2, 450,
				player, score));
		greenLine = new GreenLine(0, Main.GREEN_LINE_Y);
		secondGreenLine = new GreenLine(GreenLine.getLineImg().getWidth(null),
				Main.GREEN_LINE_Y);
		addKeyListener(new KeyAdapt(player));
		mainTimer = new Timer(Main.GAME_SPEED, this);
		mainTimer.start();
		Sound.play("birds1.wav");
	}
@Override
	// parameter of repaint()
	public void paint(Graphics g) {
		super.paint(g);
		Graphics2D g2d = (Graphics2D) g;
		ImageIcon ic = new ImageIcon(Main.BACKGROUND_IMAGE_NAME);
		g2d.drawImage(ic.getImage(), 0, 0, null);
		player.draw(g2d);
		for (Pipe pipe : pipes) {
			pipe.draw(g2d);
			pipe.pipeMove();
			pipe.updateScore();
		}
		greenLine.draw(g2d);
		secondGreenLine.draw(g2d);
		greenLine.lineMove();
		secondGreenLine.lineMove();
		printScore(g2d);
		if (gameOver) {
			gameOver(g2d);
		}

	}

	public void gameOver(Graphics2D g2d) {
		g2d.setColor(Color.white);
		// g2d.setFont(new Font("TimesRoman", Font.BOLD, 30));
		Font font = new Font("Arial", Font.BOLD, 50);
		g2d.setFont(font);
		g2d.drawString("Game over ! ", (Main.SCREEN_WIDTH / 2) - 150, 200);
		Sound.play("gameOver.wav");
	}

	public void printScore(Graphics2D g2d) {
		g2d.setColor(Color.white);
		// g2d.setFont(new Font("TimesRoman", Font.BOLD, 30));
		Font font = new Font("Arial", Font.BOLD, 50);
		g2d.setFont(font);
		g2d.drawString(score.getScore(), (Main.SCREEN_WIDTH / 2) - 20, 120);
	}

	@Override
	// Game movement
	public void actionPerformed(ActionEvent e) {
		player.update();
		checkCollision();
		repaint(); // repainting after every update
	}

	private void checkCollision() {
		for (Pipe pipe : pipes) {
			Rectangle[] enemyBoundaries = pipe.getEnemyBounds();
			for (Rectangle rectangle : enemyBoundaries) {
				if (player.getBounds().intersects(rectangle)
				 || player.y >= Main.GAME_FLOOR ) {
					gameOver = true;
					mainTimer.stop();
				}
			}
		}
	}
}
