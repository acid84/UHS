using System;
using System.Collections.Generic;
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

namespace Utgiftshantering.UserControls.Graph
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph
    {
        private double _xAxisLength;
        private Point _xAxisStartPosition;
        private Point _xAxisEndPosition;

        private double _yAxisLength;
        private Point _yAxisStartPosition;
        private Point _yAxisEndPosition;

        private double _scaleSingleValue;
        private double _scaleBottomValue;
        private double _scaleTopValue;
        private double _scaleIntervalValue;

        private double _xAxisValueInterval;
        private double _xAxisValueIntervalOffset;

        private static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(GraphEntity), typeof(Graph), new PropertyMetadata(new PropertyChangedCallback(PropertyChanged)));

        public GraphEntity DataSource
        {
            get
            {
                return GetValue(DataSourceProperty) as GraphEntity;
            }
            set
            {
                SetValue(DataSourceProperty, value);
            }
        }

        public Graph()
        {
            InitializeComponent();
        }

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var graph = d as Graph;

            if (graph != null)
            {
                graph.UpdateGrid();
            }
        }

        private void UpdateGraphPositionsAndValues()
        {
            /* Positioning constants. */
            const double fromLeft = 40;
            const double fromRight = 40;
            const double fromTop = 40;
            const double fromBottom = 40;

            /* Save the length of the X axis. */
            _xAxisLength = graphCanvas.ActualWidth - fromRight - fromLeft;

            /* Save the X axis start position. */
            _xAxisStartPosition = new Point(fromLeft, graphCanvas.ActualHeight - fromBottom);

            /* Save the X axis end position. */
            _xAxisEndPosition = new Point(graphCanvas.ActualWidth - fromRight, graphCanvas.ActualHeight - fromBottom);

            /* Save the length of the Y axis. */
            _yAxisLength = graphCanvas.ActualHeight - fromBottom - fromTop;

            /* Save the Y axis start position. */
            _yAxisStartPosition = new Point(fromLeft, fromTop);

            /* Save the Y axis end position. */
            _yAxisEndPosition = new Point(fromLeft, graphCanvas.ActualHeight - fromBottom);

            /* Calculate the X axis interval values. */
            _xAxisValueInterval = GraphHelper.CalculateTimeValuesInterval(_xAxisLength, DataSource.XAxisValues.Count);  // Calculate the space between each X axis value.
            _xAxisValueIntervalOffset = _xAxisValueInterval + _xAxisStartPosition.X;                                    // Set the start position for the first X axis value.

            /* Calculate the Y axis scale values. */
            GraphHelper.CalculateScaleValues(DataSource.GraphLines, _yAxisLength, out _scaleTopValue, out _scaleBottomValue, out _scaleIntervalValue, out _scaleSingleValue);
        }

        private void GraphCanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateGrid();
        }

        public void UpdateGrid()
        {
            if (null != DataSource && null != DataSource.XAxisValues && null != DataSource.GraphLines && DataSource.XAxisValues.Count > 0 && DataSource.GraphLines.Count > 0)
            {
                graphCanvas.Children.Clear();

                UpdateGraphPositionsAndValues();

                DrawAxises();
                DrawXAxisTimeValues();
                DrawYAxisScaleValues();
                DrawGraphLines();
                DrawGraphLinesDescriptions();
            }
        }

        private void DrawAxises()
        {
            /* Add X axises to the canvas. */
            graphCanvas.Children.Add(GraphHelper.CreateAxisLine(new Point(_xAxisStartPosition.X, _xAxisStartPosition.Y), new Point(_xAxisEndPosition.X, _xAxisEndPosition.Y)));

            /* Add Y axises to the canvas. */
            graphCanvas.Children.Add(GraphHelper.CreateAxisLine(new Point(_yAxisStartPosition.X, _yAxisStartPosition.Y), new Point(_yAxisEndPosition.X, _yAxisEndPosition.Y)));
        }

        private void DrawXAxisTimeValues()
        {
            var tmpTimeValuesInterval = _xAxisValueInterval;
            var tmpTimeValuesIntervalOffset = _xAxisValueIntervalOffset;

            foreach (var xAxisValue in DataSource.XAxisValues)
            {
                /* Create, position and add the X axis description. */
                graphCanvas.Children.Add(GraphHelper.CreateLabel<string>(xAxisValue, 100, 40, HorizontalAlignment.Center, Brushes.Black, tmpTimeValuesIntervalOffset - 50, _yAxisEndPosition.Y));

                /* Create, position and add the X axis guide line. */
                graphCanvas.Children.Add(GraphHelper.CreateGuideLine(new Point(tmpTimeValuesIntervalOffset, _yAxisStartPosition.Y), new Point(tmpTimeValuesIntervalOffset, _yAxisEndPosition.Y), Brushes.White, 1, 0.6));

                /* Move the offset position to the next X axis value position. */
                tmpTimeValuesIntervalOffset += tmpTimeValuesInterval;
            }
        }

        private void DrawYAxisScaleValues()
        {
            var scaleOffset = _yAxisEndPosition.Y;   // Set the scale offset from the bottom.
            var scaleValue = _scaleBottomValue;      // Set the first scale value.

            while ((_scaleTopValue + _scaleIntervalValue) > scaleValue)
            {
                /* Create, position and add the Y axis scale values. */
                graphCanvas.Children.Add(GraphHelper.CreateLabel(scaleValue, _yAxisStartPosition.X, 40, System.Windows.HorizontalAlignment.Right, Brushes.Black, 0.0, scaleOffset - 20));

                /* 
                 * I want to try using lambda expressions, so why not for calculating the line thickness and line opacity?
                 * I want to have a thicker line and higher opacity when the scale value is 0.0.
                 * No need for an extra method when a lambda expression does the work anonymous. 
                 * It's fucking anoyingly hard to read but who cares? Thats why i write this comment right? 
                 * Micke, please do not complain. ;-)
                 */
                Func<double, double> calculateLineThickness = (tmpScaleValue) =>
                {
                    return tmpScaleValue == 0 ? 2 : 1;
                };
                Func<double, double> calculateLineOpacity = (tmpScaleValue) =>
                {
                    return tmpScaleValue == 0 ? 1 : 0.4;
                };

                /* Create, position and add the Y axis guide line. */
                graphCanvas.Children.Add(GraphHelper.CreateGuideLine(new Point(_xAxisStartPosition.X, scaleOffset), new Point(_xAxisEndPosition.X, scaleOffset), Brushes.White, calculateLineThickness(scaleValue), calculateLineOpacity(scaleValue)));

                /* Set next scale offset. */
                scaleOffset -= (_scaleSingleValue * _scaleIntervalValue);

                /* Set next scale value. */
                scaleValue += _scaleIntervalValue;
            }
        }

        private void DrawGraphLines()
        {
            /* Reset xAxisValueInterval. */
            var xAxisValueInterval = _xAxisValueInterval;

            /* We need to draw each graph line. */
            foreach (var gle in DataSource.GraphLines)
            {
                /* Reset xAxisValueIntervalOffset between each graph line. */
                var xAxisValueIntervalOffset = _xAxisValueIntervalOffset;

                /* We follow the X axis values. */
                for (var i = 0; i < DataSource.XAxisValues.Count && i < gle.Values.Count; i++)
                {
                    /* Store the value. */
                    var value = gle.Values[i];

                    if (i + 1 != DataSource.XAxisValues.Count && i + 1 < gle.Values.Count)
                    {
                        /* Store next value. */
                        var nextValue = gle.Values[i + 1];

                        /* Add the graph line. */
                        graphCanvas.Children.Add(GraphHelper.CreateGraphLine(new Point(xAxisValueIntervalOffset, _yAxisEndPosition.Y - (_scaleSingleValue * value) + (_scaleSingleValue * _scaleBottomValue)), new Point(xAxisValueIntervalOffset + xAxisValueInterval, _yAxisEndPosition.Y - (_scaleSingleValue * nextValue) + (_scaleSingleValue * _scaleBottomValue)), GetBrush(gle.LineColor)));
                    }

                    /* Add the position dot. */
                    graphCanvas.Children.Add(GraphHelper.CreateGraphDot(value, xAxisValueIntervalOffset, _yAxisEndPosition.Y - (_scaleSingleValue * value) + (_scaleSingleValue * _scaleBottomValue)));

                    /* Set next position. */
                    xAxisValueIntervalOffset += xAxisValueInterval;
                }
            }
        }

        private void DrawGraphLinesDescriptions()
        {
            for (var i = 0; i < DataSource.GraphLines.Count; i++)
            {
                graphCanvas.Children.Add(GraphHelper.CreateLabel(DataSource.GraphLines[i].Description, _xAxisValueInterval, 28, HorizontalAlignment.Center, GetBrush(DataSource.GraphLines[i].LineColor), _xAxisEndPosition.X - _xAxisValueInterval, _yAxisStartPosition.Y + (i * 28)));
            }
        }

        private Brush GetBrush(string color)
        {
            var conv = new BrushConverter();
            return conv.ConvertFromString(color) as SolidColorBrush;
        }
    }
}
