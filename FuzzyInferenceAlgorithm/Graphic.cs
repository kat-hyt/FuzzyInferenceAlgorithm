using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyInferenceAlgorithm
{
    public class Grafic
    {
        List<Function> _functions = new List<Function>();

        public Grafic(List<Function> functions)
        {
            _functions = functions;
        }

        /// <summary>
        /// ��������� �������� y(�) ��� �������� �������. ������� ������������� �����������
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// 
        public double GetValueY(double x)
        {
            //���� �������� � ���������� ������ (�����-�� �������)
            if (_functions[0].P1.X <= x && x <= _functions[_functions.Count - 1].P2.X)
            {
                //�������, ����� �� ����� ������ ���������� �������
                int funcNum = 0;
                for (int i = 0; i < _functions.Count; i++)

                    if (_functions[i].P1.X <= x && x <= _functions[i].P2.X)
                    {
                        funcNum = i;
                        break;
                    }
                return _functions[funcNum].A * x + _functions[funcNum].B;
            }
            else
                MessageBox.Show("� " + x + "�� �������� � ���������� �������� ��������"); 
                return 0;
        }


        public int GetCaseNumber(double y) //����������� ����� �������
        {
            //������ ������� �������
            //���� 1-�� ������� �� ���������� (���� ���������)
            if (_functions[0].P1.Y > y && _functions[0].P2.Y > y)
            {
                //���� 2-�� ������� ����������
                if (_functions[1].P1.Y >= y && _functions[1].P2.Y <= y)
                {
                    return 1;
                }
            }

            //������ ������� �������
            //���� 1-�� ������� ���������� 
            if (_functions[0].P1.Y <= y && _functions[0].P2.Y >= y)
            {
                //���� 2-�� ������� �� ���������� (���� ���������) � �����������
                if (_functions[1].P1.Y > y && _functions[1].P2.Y > y)
                {
                    return 2;
                }
            }

            //������ �������
            //���� 1-�� ������� ���������� 
            if (_functions[0].P1.Y <= y && _functions[0].P2.Y >= y)
            {
                //���� 2-�� ������� ����������
                if (_functions[1].P1.Y >= y && _functions[1].P2.Y <= y)
                {
                    return 3;
                }
            }

            return 0;
        }

        /// <summary>
        /// ����� ���������� �������������� ������ ���������� �� ���������� �������
        /// </summary>
        public Grafic MakeOtsech(double y)
        {
            //����� ��������� �� ������ �������:
            //1. ������� ����� ��� �������� ����� ������ �������.
            //2. ��������� ����� ��� ��������� �� ������������� (������� ������� ������������ � ����� ���������)
            //   �������: ���� ������� �� ����������, ������ ��� ��������������.
            //            ����������������� ��� �������� ������!

            //3. �������� � ������ ����� �������� ����� ��� ������� � ������ ���������.
            //4. ������������ ����� ������� �� ������ �����.
            //5. ������������ ����� ������ �� ����� ��������.
            //6. ������� ������.


            List<Point> points = new List<Point>();


            List<Function> funcsWithOtsech = new List<Function>();
            double xCrossY;

            //������ �������
            //���� 1-�� ������� ���������� 
            if (_functions[0].P1.Y < y && _functions[0].P2.Y >= y ||
                _functions[0].P1.Y <= y && _functions[0].P2.Y > y)
            {
                //���� 2-�� ������� ����������
                if (_functions[1].P1.Y > y && _functions[1].P2.Y <= y ||
                    _functions[1].P1.Y >= y && _functions[1].P2.Y < y)
                {
                    xCrossY = _functions[0].GetValueX(y);//�������� �������� � ��� y 1-�� �������

                    points.Add(new Point(_functions[0].P1.X, _functions[0].P1.Y));
                    points.Add(new Point(xCrossY, y));

                    xCrossY = _functions[1].GetValueX(y);//�������� �������� � ��� y 2-�� �������

                    points.Add(new Point(xCrossY, y));
                    points.Add(new Point(_functions[1].P2.X, _functions[1].P2.Y));
                }
            }

            //������ �������
            //���� 1-�� ������� ���������� 
            if (_functions[0].P1.Y <= y && _functions[0].P2.Y >= y)
            {
                //���� 2-�� ������� �� ���������� (���� ���������)
                if (_functions[1].P1.Y >= y && _functions[1].P2.Y >= y)
                {
                    xCrossY = _functions[0].GetValueX(y);//�������� �������� � ��� y 

                    points.Add(new Point(_functions[0].P1.X, _functions[0].P1.Y));
                    points.Add(new Point(xCrossY, y));
                    points.Add(new Point(_functions[1].P2.X, y));
                }
            }

            //������ �������
            //���� 1-�� ������� �� ���������� (���� ���������)
            if (_functions[0].P1.Y > y && _functions[0].P2.Y > y)
            {
                //���� 2-�� ������� ����������
                if (_functions[1].P1.Y >= y && _functions[1].P2.Y <= y)
                {
                    xCrossY = _functions[1].GetValueX(y);//�������� �������� � ��� y �������

                    points.Add(new Point(0, y));
                    points.Add(new Point(xCrossY, y));
                    points.Add(new Point(_functions[1].P2.X, _functions[1].P2.Y));

                }
            }



            //����������� ���� ������� �� �������
            for (int i = 0; i < points.Count - 1; i++)
            {
                funcsWithOtsech.Add(new Function(points[i], points[i + 1]));

                
            }

            //����������� ������ �������, ��������, ��� ������� ���������
            return new Grafic(funcsWithOtsech);
        }

    }
}