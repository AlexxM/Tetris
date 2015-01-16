/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 11/18/2014
 * Время: 15:30
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Tetris
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Game g;
		BlockData[,] data;
		int curScore = 0;
		
		int boxSize=15;
		int offsetTop=20;
		
		int fieldWidth;
		int fieldHeight;
		
		Font f;
		public MainForm()
		{
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(g!=null)
			{
				g.Stop();
			
				int gameSpeed;
				switch(selectSpeed.SelectedIndex)
				{
					case 1: gameSpeed=300;break;
					case 2: gameSpeed=200;break;
					default : gameSpeed=400;break;
				}
			
				if(selectFieldSize.SelectedIndex==0 || selectFieldSize.SelectedIndex==-1)
				{
					fieldWidth=120;
					fieldHeight=225;
					pictureBox1.Width=fieldWidth;
					pictureBox1.Height=fieldHeight+offsetTop;
				}
				else if(selectFieldSize.SelectedIndex==1)
				{
					fieldWidth=120;
					fieldHeight=255;
					pictureBox1.Width=fieldWidth;
					pictureBox1.Height=fieldHeight+offsetTop;
				}
				
				g.Run(fieldWidth/boxSize,fieldHeight/boxSize,gameSpeed);
				SwitchResumeBtnText();
				ShowGameStatus();
			}
		}

		void g_UpdateView(BlockData[,] obj)
		{
			data=obj;
			pictureBox1.Invalidate();
		}
		
		
		void CreatePathBrush()
		{
			
		}
		
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			if(data!=null)
			{
				Color c;
				foreach(var v in data)
				{
					if(v!=null)
					{
						
						
						Rectangle rec =new Rectangle(v.x*boxSize,v.y*boxSize+offsetTop,boxSize-1,boxSize-1);
						
				
						if(v.removing)
						{
							c= Color.FromArgb(120,v.c);
						}
						else
						{
							c=v.c;
						}
						
						e.Graphics.FillRectangle(new SolidBrush(c),rec);
					}
				}
			}
			
			if(f!=null)
				e.Graphics.DrawString(curScore.ToString(),f,Brushes.Green,5,5);
			ShowGameStatus();
			
		}
	
		
		
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
				g.KeyValueDown=e.KeyValue;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			f=new Font("Arial",10,FontStyle.Bold);
			g=new Game();
			g.UpdateScore+= new Action<int>(g_UpdateScore);
			g.UpdateView+= new Action<BlockData[,]>(g_UpdateView);
		}

		void g_UpdateScore(int score)
		{
			curScore=score;
		}
		
		void ShowGameStatus()
		{
			if(g.Status==GameStatus.Stopped)
			{
				lblStatus.Text="Игра остановлена";
				lblStatus.ForeColor=Color.Red;
			}
			else if(g.Status==GameStatus.Running)
			{
				lblStatus.Text="Игра запущена";
				lblStatus.ForeColor=Color.Green;
			}
			else if(g.Status==GameStatus.Paused)
			{
				lblStatus.Text="Пауза";
				lblStatus.ForeColor=Color.Blue;
			}	
		}
		
		void SwitchResumeBtnText()
		{
			if(g.Status==GameStatus.Paused)
			{
				btnResume.Text="Возобновить";
			}
			else if(g.Status==GameStatus.Running)
			{
				btnResume.Text="Пауза";
			}
		}
		
		void BtnResumeClick(object sender, EventArgs e)
		{
	
			if(g.Status==GameStatus.Running)
			{
				g.Paused();
			}
			else if(g.Status==GameStatus.Paused)
			{
				g.Resume();
			}
			SwitchResumeBtnText();
			ShowGameStatus();
		}
		
	}
}
