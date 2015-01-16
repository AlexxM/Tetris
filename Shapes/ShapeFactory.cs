/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.11.2014
 * Время: 9:57
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	/// Description of ShapeFactory.
	/// </summary>
	public static class ShapeFactory
	{
		
		static Color[] _colorArr= new Color[]{Color.Red,Color.Blue,Color.Green,
											 Color.Blue,Color.Brown,Color.YellowGreen,Color.Violet};
		static int _shapeTypeCount = 7;
		
		static Random rnd = new Random();
		public static Shape CreateShape()
		{
			
			Shape shape;
			int color = rnd.Next(_colorArr.Length);
			int shapeType = rnd.Next(_shapeTypeCount);
			switch(shapeType)
			{
				case 0 : shape = new ShapeType1(_colorArr[color]); break;
				case 1 : shape = new ShapeType2(_colorArr[color]); break;
				case 2 : shape = new ShapeType3(_colorArr[color]); break;
				case 3 : shape = new ShapeType4(_colorArr[color]); break;
				case 4 : shape = new ShapeType5(_colorArr[color]); break;
				case 5 : shape = new ShapeType6(_colorArr[color]); break;
				case 6 : shape = new ShapeType7(_colorArr[color]); break;
				default : shape = new ShapeType1(_colorArr[color]); break;
			}
			
			return shape;
			
		}
		
		
	}
}
