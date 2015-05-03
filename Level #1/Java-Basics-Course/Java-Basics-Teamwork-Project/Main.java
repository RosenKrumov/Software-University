package org.softuni;

import javax.swing.JFrame;

public class Main {

	// basic config
	public static final String PLAYER_IMAGE_NAME1 = "playerUp.png";
	public static final String PLAYER_IMAGE_NAME2 = "playerMiddle.png";
	public static final String PLAYER_IMAGE_NAME3 = "playerDown.png";
	public static final String BACKGROUND_IMAGE_NAME = "Background.gif";
	public static final int PLAYER_ANIMATION_TIMING = 30;
	public static final int GAME_FLOOR = 543; // sets the game floor
	public static final int SCREEN_WIDTH = 600;
	public static final int SCREEN_HEIGHT = 800;
	public static final int PLAYER_START_X = 150;
	public static final int PLAYER_START_Y = 300;
	public static final int GAME_SPEED = 15; // smaller - faster
	public static final int JUMP_SPEED = 10;
	public static final int MAX_VERTICAL_SPEED = 5;
	public static final int GRAVITY = 1;
	public static final int MAX_PIPE_HEIGHT = 300;
	public static final int MIN_PIPE_HEIGHT = 10;
	public static final int PIPE_WIDTH = 29;
	public static final int HAT_HEIGHT = 50;
	public static final int HAT_WIDTH = 53;
	public static final int PIPE_SPACING = 175;
	public static final int PIPE_SPEED = 2;
	public static final int PIPE_DISTANCE = 235;
	public static final int GREEN_LINE_Y = Main.GAME_FLOOR
			+ Player.getPlayerImg(Main.PLAYER_IMAGE_NAME1).getHeight(null) - 13;

	public static void main(String[] args) {
		JFrame frame = new JFrame("SuperFlappyNakov by Dark Blue Team");

		frame.setSize(SCREEN_WIDTH, SCREEN_HEIGHT);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setFocusable(false);
		frame.setLocationRelativeTo(null);
		frame.add(new GameFrame()); // this is panel not frame
		frame.setResizable(false);
		frame.setVisible(true);

	}

}
