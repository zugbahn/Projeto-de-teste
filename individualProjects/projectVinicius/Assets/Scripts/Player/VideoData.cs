﻿using UnityEngine;
using System.Collections;

public class VideoData {

	/// <summary>
	/// The total number of videos.
	/// </summary>
	public static int numVideos = 0;

	/// <summary>
	/// The total number of views.
	/// </summary>
	public static int totalViews = 0;

	/// <summary>
	/// The total number of fans.
	/// </summary>
	public static int totalFans = 0;



	/// <summary>
	/// Roberto Injustus current hype.
	/// </summary>
	public static int hype = 0;

	private int viewsVideo = 0;
	private int fansVideo = 0;
	private int moneyVideo = 0;

	int score = 0;

	public VideoData(int score)
	{
		this.score = score;
	}

	private int Hype () {
		int sum = PlayerData.scoreLastVideo + (PlayerData.scoreLastVideo - PlayerData.scoreVideoBefore);
		return sum;
	}

	private int Fans () {
		int sum = (viewsVideo / (10 * numVideos)) + totalFans;
		totalFans += sum;
		return sum;
	}

	private int View (int marketingVideo) {
		int sum1 = (Hype() + marketingVideo);	
		int sum2 = (sum1 * PlayerData.scoreLastVideo) + totalFans;
		
		if (sum2 >= 0 && sum2 < int.MaxValue) {
			totalViews += sum2;
			return sum2;
		} else {
			Debug.Log("Integer overflow");
			return 0;
		}
	}

	private int Money () {
		int sum = ((totalViews * totalViews) / (10000 * (numVideos + 1)));
		PlayerData.totalMoney += sum;
		return sum;
	}

	/// <summary>
	/// Calculate all the info about the last video.
	/// </summary>
	/// <param name="marketing">Marketing.</param>
	public void DoTheMath (int marketing) {
		numVideos++;
		hype = Hype ();
		viewsVideo = View (marketing);
		fansVideo = Fans ();
		moneyVideo = Money ();
		Debug.Log("Hype "+hype+", Views "+viewsVideo+", Fans "+fansVideo+ ", Money "+moneyVideo);
	}

	/// <summary>
	/// Views generated by the current video.
	/// </summary>
	/// <returns>The video.</returns>
	public int ViewsVideo () {
		return viewsVideo;
	}

	/// <summary>
	/// Number of fans generated by this video.
	/// </summary>
	/// <returns>The video.</returns>
	public int FansVideo () {
		return fansVideo;
	}

	/// <summary>
	/// Money generated by this video.
	/// </summary>
	/// <returns>The video.</returns>
	public int MoneyVideo () {
		return moneyVideo;
	}

	public int Score()
	{
		return score;
	}
}