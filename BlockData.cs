/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 19.11.2014
 * Время: 15:15
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	/// Description of BlockData.
	/// </summary>
	public class BlockData
	{
		public Color c;
		public int x;
		public int y;
		public bool removing;
		
		public BlockData()
		{
		}
		
		public BlockData(int x,int y,Color c)
		{
			this.x=x;
			this.y=y;
			this.c=c;
			this.removing=false;
		}
		
		public BlockData Clone()
		{
			return (BlockData)this.MemberwiseClone();
		}
	}
}
