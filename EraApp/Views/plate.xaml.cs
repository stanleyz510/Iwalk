using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Era.Core;

namespace EraApp
{
    public partial class plate : UserControl
    {
        public plate()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            txtOut.Text = "";
            Destiny destiny = EnvironmentHelper.Parser(txtInput.Text);
            //txtOut.Text += destiny.ToString();
            //txtOut.Text += "\n";

            //1.计算生克总量
            //CalcAmountHelper calcAmount = new CalcAmountHelper();
            //txtOut.Text += calcAmount.GetWuxingAmount(destiny);

            //2.静态关系图
            DestinyRelationView ctv = new DestinyRelationView(destiny);
            txtOut.Text += outText(ctv);

            DrawWuxing2(destiny);
            DrawWuxing(ctv);

            //3.从自身中提取五行
            CalcAmountHelper.FillStemsAmount(destiny);
            txtOut.Text += CalcAmountHelper.GetEraAmountReport(destiny);


            //4.从自身中提取天干
            CalcAmountHelper.FillStemsAmount(destiny);
            txtOut.Text += CalcAmountHelper.GetStemsAmountReport(destiny);
        }

        private void btnCalc2_Click(object sender, RoutedEventArgs e)
        {

        }
        public void DrawWuxing2(Destiny des)
        {
            textBlock1.Text = des.Year.Stems.ToString();
            textBlock2.Text = des.Year.Branch.ToString();
            textBlock3.Text = des.Month.Stems.ToString();
            textBlock4.Text = des.Month.Branch.ToString();
            textBlock5.Text = des.Day.Stems.ToString();
            textBlock6.Text = des.Day.Branch.ToString();
            textBlock7.Text = des.Hour.Stems.ToString();
            textBlock8.Text = des.Hour.Branch.ToString();

            ellipse1.Fill = GetBrush(des.Year.Stems.EraType);
            ellipse2.Fill = GetBrush(des.Year.Branch.HideStems[0].EraType);
            ellipse3.Fill = GetBrush(des.Month.Stems.EraType);
            ellipse4.Fill = GetBrush(des.Month.Branch.HideStems[0].EraType);
            ellipse5.Fill = GetBrush(des.Day.Stems.EraType);
            ellipse6.Fill = GetBrush(des.Day.Branch.HideStems[0].EraType);
            ellipse7.Fill = GetBrush(des.Hour.Stems.EraType);
            ellipse8.Fill = GetBrush(des.Hour.Branch.HideStems[0].EraType);
           
            
        }

        private Brush GetBrush(emEra emEra)
        {
            switch(emEra)
            {
                case emEra.水:
                    return new SolidColorBrush(Colors.DarkGray);
                case emEra.木:
                    return new SolidColorBrush(Colors.Cyan);
                case emEra.火:
                    return new SolidColorBrush(Colors.Red);
                case emEra.土:
                    return new SolidColorBrush(Color.FromArgb(0xff,0xde,0xb8,0x87));//DEB887
                case emEra.金:
                    return new SolidColorBrush(Colors.White);
            }
            return new SolidColorBrush(Colors.Orange);
        }
        public void DrawWuxing(DestinyRelationView ctv)
        {
            #region
            //canvas1.Children.Clear();
            //Ellipse ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.White);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 60);
            //Canvas.SetTop(ellipse, 60);


            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.Green);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 150);
            //Canvas.SetTop(ellipse, 60);

            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.LightGray);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 60);
            //Canvas.SetTop(ellipse, 60 + 80 * 1);

            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.Cyan);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 150);
            //Canvas.SetTop(ellipse, 60 + 80 * 1);

            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.Brown);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 60);
            //Canvas.SetTop(ellipse, 60 + 80 * 2);

            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.Black);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 150);
            //Canvas.SetTop(ellipse, 60 + 80 * 2);

            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.DarkGray);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 60);
            //Canvas.SetTop(ellipse, 60 + 80 * 3);

            //ellipse = new Ellipse();
            //ellipse.Width = 60;
            //ellipse.Height = 60;
            //ellipse.Fill = new SolidColorBrush(Colors.Brown);
            //canvas1.Children.Add(ellipse);

            //Canvas.SetLeft(ellipse, 150);
            //Canvas.SetTop(ellipse, 60 + 80 * 3);
            #endregion

            txtSR1.Text = ctv.YearStems.ToString();
            txtSR2.Text = ctv.MouthStems.ToString();
            txtSR3.Text = ctv.DayStems.ToString();
            txtSR4.Text = ctv.HourStems.ToString();

            txtBRY1.Text = string.Empty;
            txtBRY2.Text = string.Empty;
            txtBRY3.Text = string.Empty;
            txtBRM1.Text = string.Empty;
            txtBRM2.Text = string.Empty;
            txtBRM3.Text = string.Empty;
            txtBRD1.Text = string.Empty;
            txtBRD2.Text = string.Empty;
            txtBRD3.Text = string.Empty;
            txtBRH1.Text = string.Empty;
            txtBRH2.Text = string.Empty;
            txtBRH3.Text = string.Empty;
            //地址关系
            txtBRY1.Text =ctv.YearBranchs[0].Foreign+" "+ ctv.YearBranchs[0].ToString();
            if(ctv.YearBranchs.Count>1)
                txtBRY2.Text = ctv.YearBranchs[1].Foreign + " " + ctv.YearBranchs[1].ToString();
            if (ctv.YearBranchs.Count > 2)
                txtBRY3.Text = ctv.YearBranchs[2].Foreign + " " + ctv.YearBranchs[2].ToString();

            //地址关系
            txtBRM1.Text = ctv.MouthBranchs[0].Foreign + " " + ctv.MouthBranchs[0].ToString();
            if (ctv.MouthBranchs.Count > 1)
                txtBRM2.Text = ctv.MouthBranchs[1].Foreign + " " + ctv.MouthBranchs[1].ToString();
            if (ctv.MouthBranchs.Count > 2)
                txtBRM3.Text = ctv.MouthBranchs[2].Foreign + " " + ctv.MouthBranchs[2].ToString();

            //地址关系
            txtBRD1.Text = ctv.DayBranchs[0].Foreign + " " + ctv.DayBranchs[0].ToString();
            if (ctv.DayBranchs.Count > 1)
                txtBRD2.Text = ctv.DayBranchs[1].Foreign + " " + ctv.DayBranchs[1].ToString();
            if (ctv.DayBranchs.Count > 2)
                txtBRD3.Text = ctv.DayBranchs[2].Foreign + " " + ctv.DayBranchs[2].ToString();

            //地址关系
            txtBRH1.Text = ctv.DayBranchs[0].Foreign + " " + ctv.DayBranchs[0].ToString();
            if (ctv.DayBranchs.Count > 1)
                txtBRH2.Text = ctv.DayBranchs[1].Foreign + " " + ctv.DayBranchs[1].ToString();
            if (ctv.DayBranchs.Count > 2)
                txtBRH3.Text = ctv.DayBranchs[2].Foreign + " " + ctv.DayBranchs[2].ToString();
            //旬空
            txtEmptyBranch.Text = ctv.EmptyBranch[0].ToString() + ctv.EmptyBranch[1].ToString() + "空";
        }
        string outText(DestinyRelationView ctv)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ctv.YearStems);
            sb.Append('\t');
            sb.Append(ctv.Year);
            sb.Append('\t');
            Action<EraRelation> show = delegate(EraRelation e)
            {
                sb.Append(e.Foreign);
                sb.Append(e.ToString());
                sb.Append('|');
            };
            ctv.YearBranchs.ForEach(show);
            sb.AppendLine();

            sb.Append(ctv.MouthStems);
            sb.Append('\t');
            sb.Append(ctv.Month);
            sb.Append('\t');
            ctv.MouthBranchs.ForEach(show);
            sb.AppendLine();



            sb.Append(ctv.DayStems);
            sb.Append('\t');
            sb.Append(ctv.Day);
            sb.Append('\t');
            ctv.DayBranchs.ForEach(show);
            sb.AppendLine();


            sb.Append(ctv.HourStems);
            sb.Append('\t');
            sb.Append(ctv.Hour);
            sb.Append('\t');
            ctv.HourBranchs.ForEach(show);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
