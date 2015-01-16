/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 19.11.2014
 * Время: 13:24
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Threading.Tasks;
namespace Tetris
{

	public enum GameStatus
	{
		Running,
		Stopped,
		Paused
	}
	
	public class Game
	{
		Field _f;
		int _refreshTime=50;
		Task _t;
		GameStatus _gs=GameStatus.Stopped;
		int _keyValueDown;
		
		public GameStatus Status
		{
			get{ return _gs;}
		}
		
		public int KeyValueDown
		{
			get{ return _keyValueDown;}
			set
			{
				_keyValueDown=value;
			}
		}
		
		public event Action<int> UpdateScore;
		public event Action<BlockData[,]> UpdateView;
		
		
		public Game()
		{

		}
		
		public void Run(int modelWidth,int modelHeight,int gameSpeed)
		{
			if(_gs!=GameStatus.Stopped)
				return;
			else
				_gs=GameStatus.Running;
		
			
			_f = new Field(this,modelWidth,modelHeight,gameSpeed);
			
			_t=new Task(new Action(Background));
			_t.Start();
		}
		
		public void Stop()
		{
			_gs=GameStatus.Stopped;
			if(_t!=null)
				_t.Wait(1000);
		}
		
		public void Paused()
		{
			_gs=GameStatus.Paused;
		}
		
		public void Resume()
		{
			if(_t!=null && _t.Status== TaskStatus.Running && _gs==GameStatus.Paused)
				_gs=GameStatus.Running;
		}
		
		
		private void Background()
		{
			while(_gs!=GameStatus.Stopped)
			{
				if(_gs!=GameStatus.Paused)
				{
				
					_f.update(_refreshTime);
					BlockData[,] toView = _f.present();
					OnUpdateView(toView);
					OnUpdateScore();
				}
				System.Threading.Thread.Sleep(_refreshTime);
			}
		}
		
		private void OnUpdateScore()
		{
			if(UpdateScore!=null)
			{
				UpdateScore(_f.scores);
			}
		}
		
		private void OnUpdateView(BlockData[,] arr)
		{
			if(UpdateView!=null)
			{
				UpdateView(arr);
			}
		}
		
		
	}
}
