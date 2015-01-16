/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 11/18/2014
 * Время: 15:42
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Tetris
{

	public class Field
	{
		//массив в котором хранится информация о цвете и позиции блоков
		//структура массива позволяет быстро проверять положение падающей фигуры относительно других блоков
		private BlockData[,] _mField;
		
		//падающая фигура
		private Shape _s;
	
		private int _modelWidth;
		private int _modelHeight;
		
		//интервал времени между перемещением фигуры вниз
		private int _timeToMoveDown;
		private int _time;
		
		private Game _g;
		
		public int scores;
		
		private const int SCORE_LINE=10;
		
		//после обнаружения 'заполненной' вертикальной линии, она подсвечивается и уст флаг
		private bool _needRemove=false;
		
		public Field(Game g,int width,int height,int gameSpeed) 
		{
			_g = g;
			
			_modelWidth=width;
			_modelHeight=height;
			_timeToMoveDown=gameSpeed;

			_mField = new BlockData[_modelWidth,_modelHeight];
		}
		
		public Field(Game g,int width,int height) : this(g,width,height,500)
		{
		
		}
		
		//добавить падающую фигуру на поле
		public void addShape(Shape s)
		{
			this._s=s;
			
			
			Random rnd = new Random();
			int startFallingPoint=rnd.Next(_modelWidth-this._s.GetShapeWidth());
			moveShape(new Point(startFallingPoint,0));
			
		}
		
		//движение фигуры
		private void moveShape(Point direction)
		{
			if(_s!=null){
				for(int i=0;i<_s.p.Length;i++)
				{
					_s.p[i].X+=direction.X;
					_s.p[i].Y+=direction.Y;
				}
			
				if(_s.pivot!=null)
				{
					_s.pivot.X+=direction.X;
					_s.pivot.Y+=direction.Y;
				}
			}
			
		}
		
		//анализ нажатой клавиши
		//w-вращение по часовой,d-перемещение вправо,a-перемещение влево,s-ускоренное перемещение вниз
		private void ProcessKey()
		{
			Shape copyShape;
			
			if(_g.KeyValueDown==65 && _s!=null)
			{
				copyShape = _s.Clone();
				moveShape(new Point(-1,0));
				if(!TestShapePosition(_s))
				{
					_s=copyShape;
				}
				
			}
			else if(_g.KeyValueDown==68 && _s!=null)
			{
				copyShape = _s.Clone();
				moveShape(new Point(1,0));

				if(!TestShapePosition(_s))
				{
					_s=copyShape;
				}
			}
			else if(_g.KeyValueDown==83 && _s!=null)
			{
				copyShape = _s.Clone();
				moveShape(new Point(0,1));
				if(!TestShapePosition(_s))
				{
					_s=copyShape;
				}
			
			}
			else if(_g.KeyValueDown==87 && _s!=null)
			{
				copyShape=_s.Clone();
				_s.ShapeRotate();
				if(!TestShapePosition(_s))
				{
					_s=copyShape;
				}
			}
			
			_g.KeyValueDown=0;
		}
		
		//проверка положения фигуры относительно других блоков и границ поля
		private bool TestShapePosition(Shape testShape)
		{
			foreach(Point p in testShape.p)
			{
				if(p.X==-1 || p.X==_modelWidth)
				{
					return false;
				}
				
				if(p.Y==-1 || p.Y==_modelHeight)
				{
					return false;
				}
				
				if(_mField[p.X,p.Y]!=null)
				{
					return false;
				}
			}
			
			return true;
		}
		
		
		public void update(int delta)
		{
			
			_time+=delta;
			
			ProcessKey();
			//время для перемещения фигуры
			if(_time>=_timeToMoveDown)
			{
				_time=0;
				
				//необходимо удалить 'заполненные линии'
				if(_needRemove)
				{
					RemoveLines();
					_needRemove=false;
				}
				
				//фигура коснулась нижней границы поля или блока
				if(TestTouching(_s))
				{
					foreach(Point p in _s.p)
					{
						_mField[p.X,p.Y]=new BlockData(p.X,p.Y,_s.c);
					}
					ComputeScores();
					
					
					this._s=null;
				}
				
				//если фигура не определена, то добавить
				if(this._s==null)
				{
					addShape(ShapeFactory.CreateShape());
					
					//проверка на проигрыш
					if(!TestShapePosition(_s))
					{
						_g.Stop();
					}
					
				}
				//переместить вниз
				else
				{
					moveShape(new Point(0,1));
					foreach(var v in this._s.p)
					{
						if(v.Y==_modelHeight)
						{
							this._s=null;
							return;
						}
					}
				}
			}
		}
		
		
		private void ComputeScores()
		{
			for(int i=0;i<_modelHeight;i++)
			{
				int lineWidth=0;
				for(int j=0;j<_modelWidth;j++)
				{
					if(_mField[j,i]!=null)
					{
						lineWidth+=1;
					}
				}
				
				if(lineWidth==_modelWidth)
				{
					scores+=SCORE_LINE;
					_needRemove=true;
					for(int j=0;j<_modelWidth;j++)
					{
						_mField[j,i].removing=true;
					}
				}
			}	
		}
		
		private void RemoveLines()
		{
			for(int i=0;i<_modelWidth;i++)
			{
				for(int j=0;j<_modelHeight;j++)
				{
					if(_mField[i,j]!=null && _mField[i,j].removing)
					{
						_mField[i,j]=null;
						
						for(int k=j-1;k>=0;k--)
						{
							if(_mField[i,k]!=null && _mField[i,k+1]==null)
							{
								var temp = _mField[i,k].Clone();
								temp.y=k+1;

								_mField[i,k]=null;
								_mField[i,k+1]=temp;
							}
						}
					}
				}
			}	
		}
		
		private bool TestTouching(Shape s)
		{

			if(s!=null)
			{
				foreach(Point p in s.p)
				{
					int X=p.X;
					int Y=p.Y;
					for(int i=0;i<_modelWidth;i++)
					{
						if(Y+1==_modelHeight || _mField[X,Y+1]!=null)
						{
							return true;
						}
					}
				}	
			}
			
				
			
			return false;
		}
		
		//формирование массива для передачи на отрисовку
		public BlockData[,] present()
		{
				
				BlockData[,] outputData = new BlockData[_modelWidth,_modelHeight];
				
				if(_s!=null)
				{
					foreach(Point p in _s.p)
					{
						outputData[p.X,p.Y]=new BlockData(p.X,p.Y,_s.c);
					}
				}
					
				foreach(BlockData bd in _mField)
				{
					if(bd!=null)
					{
						outputData[bd.x,bd.y]=bd;
					}
				}
					
				
				return outputData;
			}

		}
		
	
}
