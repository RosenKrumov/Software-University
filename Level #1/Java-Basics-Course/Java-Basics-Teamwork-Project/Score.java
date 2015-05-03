package org.softuni;

public class Score {
	private int score;
	public Score() {
		this.score = 0;
	}
	public String getScore() {
		return Integer.toString(score);
	}
	public void setScore(int score) {
		this.score = score;
	}
	public void increaseScore(int increment){
		this.score += increment;
	}

}
