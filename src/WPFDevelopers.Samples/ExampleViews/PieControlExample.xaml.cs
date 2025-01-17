﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDevelopers.Controls;

namespace WPFDevelopers.Samples.ExampleViews
{
    /// <summary>
    /// PieControlExample.xaml 的交互逻辑
    /// </summary>
    public partial class PieControlExample : UserControl
    {
        public ObservableCollection<PieSegmentModel> PieSegmentModels
        {
            get { return (ObservableCollection<PieSegmentModel>)GetValue(PieSegmentModelsProperty); }
            set { SetValue(PieSegmentModelsProperty, value); }
        }

        public static readonly DependencyProperty PieSegmentModelsProperty =
            DependencyProperty.Register("PieSegmentModels", typeof(ObservableCollection<PieSegmentModel>), typeof(PieControlExample), new PropertyMetadata(null));

        List<ObservableCollection<PieSegmentModel>> collectionList = new List<ObservableCollection<PieSegmentModel>>();
        public PieControlExample()
        {
            InitializeComponent();

            PieSegmentModels = new ObservableCollection<PieSegmentModel>();
            var collection1 = new ObservableCollection<PieSegmentModel>();
            collection1.Add(new PieSegmentModel { Name = "一", Value = 10 });
            collection1.Add(new PieSegmentModel { Name = "二", Value = 20 });
            collection1.Add(new PieSegmentModel { Name = "三", Value = 25 });
            collection1.Add(new PieSegmentModel { Name = "四", Value = 45 });
            var collection2 = new ObservableCollection<PieSegmentModel>();
            collection2.Add(new PieSegmentModel { Name = "一", Value = 30 });
            collection2.Add(new PieSegmentModel { Name = "二", Value = 15 });
            collection2.Add(new PieSegmentModel { Name = "三", Value = 10 });
            collection2.Add(new PieSegmentModel { Name = "四", Value = 55 });
            collectionList.AddRange(new[] { collection1, collection2 });

            PieSegmentModels = collectionList[0];
        }
        bool isRefresh = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isRefresh)
                PieSegmentModels = collectionList[1];
            else
                PieSegmentModels = collectionList[0];
            isRefresh = !isRefresh;

        }
    }
}
