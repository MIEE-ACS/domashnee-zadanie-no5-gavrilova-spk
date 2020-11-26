using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hw_5
{
    public class Time
    {
        public int day;
        public int month;
        public int year;
        
        /*
        public Time() : this(0)
        {
        }

        public Time (int d) : this(d, 0)
        {
        }

        public Time(int d, int m) : this(d, m, 0)
        {
        }
        */
        
        public Time(int d, int m, int y) 
        {
            //проверка дня
            if (m == 1 || m == 4 || m == 6 || m == 9 || m == 11)
            {
                if (d > 0 && d < 31)
                    this.day = d;
            }
            else if (m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
            {
                if (d > 0 && d < 32)
                    this.day = d;
            }
            else if (m == 2)
            {
                if (y % 4 == 0 && d > 0 && d < 30)
                    this.day = d;
                else if (y % 4 != 0 && d > 0 && d < 29)
                    this.day = d;
            }
           if (day == 0)
            {
                MessageBox.Show("Проверьте корректность данных!!! Введенное число не совпадает с количеством дней в данном месяце.");
                this.day = 0;
            }

            this.month = m;

            if (y > 0)
            this.year = y;
            else
                MessageBox.Show("Проверьте корректность данных!!! Год не может быть отрицательным.");
        }
        
        public override string ToString()
        {
            string name_month;

            switch (month)
            {
                case 1:
                    name_month = "Январь";
                    break;
                case 2:
                    name_month = "Февраль";
                    break;
                case 3:
                    name_month = "Март";
                    break;
                case 4:
                    name_month = "Апрель";
                    break;
                case 5:
                    name_month = "Май";
                    break;
                case 6:
                    name_month = "Июнь";
                    break;
                case 7:
                    name_month = "Июль";
                    break;
                case 8:
                    name_month = "Август";
                    break;
                case 9:
                    name_month = "Сентябрь";
                    break;
                case 10:
                    name_month = "Октябрь";
                    break;
                case 11:
                    name_month = "Ноябрь";
                    break;
                case 12:
                    name_month = "Декабрь";
                    break;
                default:
                    name_month = "\\/(-_-)\\/";
                    break;
            }
                    return $"{day}  {name_month}  {year}";
        }
    }





    public partial class MainWindow : Window
    {
        DateTime today = DateTime.Now;
        Time date;

        static int Check(string str, ref int k)  //Проверка на число
            {
                int num;

                if (!int.TryParse(str, out num))
                {
                    if ( k == 0)
                        MessageBox.Show("Необходимо целое число.");
                    k = 1; 
                    num = 0;
                }
                return num;
            }

      
        public MainWindow()
        {
            InitializeComponent();
            
            date = new Time (today.Day, today.Month, today.Year);
            txt_OutPut.Text = date.ToString();
            txt_OutPut.IsReadOnly = true;
            ch_month.SelectedIndex = today.Month - 1;
            ch_day.Text = $"{today.Day}";
            ch_year.Text = $"{today.Year}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_OutPut.Visibility = Visibility.Hidden;
            ch_month.Visibility = Visibility.Visible;
            ch_day.Visibility = Visibility.Visible;
            ch_year.Visibility = Visibility.Visible;
            
            btm_ch.IsEnabled = false;
            btm_save.IsEnabled = true;
            btm_ch.Visibility = Visibility.Hidden;
            btm_save.Visibility = Visibility.Visible;

            ch_day.Text = $"{date.day}";
            ch_year.Text = $"{date.year}";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str_d = ch_day.Text, 
                      str_y = ch_year.Text;
            int k = 0, 
                d = Check(str_d, ref k), 
                y = Check(str_y, ref k),
                m = ch_month.SelectedIndex + 1;
            
              date = new Time(d, m, y);
            if(date.day == 0)
                date.day = today.Day;
            if (date.year == 0)
                date.year = today.Year;
            
                txt_OutPut.Visibility = Visibility.Visible;
                ch_month.Visibility = Visibility.Hidden;
                ch_day.Visibility = Visibility.Hidden;
                ch_year.Visibility = Visibility.Hidden;
                txt_OutPut.Text = date.ToString();

            btm_ch.IsEnabled = true;
            btm_save.IsEnabled = false;
            btm_save.Visibility = Visibility.Hidden;
            btm_ch.Visibility = Visibility.Visible;
        }
        
    }
}
