using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Utgiftshantering.UserControls.Graph
{
    public abstract class GraphHelper
    {
        #region Public

        public static double CalculateTimeValuesInterval(double axisLength, int numberOfTimes)
        {
            return axisLength / (numberOfTimes + 1);
        }

        public static void CalculateScaleValues(List<GraphLineEntity> graphLines, double yAxisLength, out double scaleTopValue, out double scaleBottomValue, out double scaleIntervalValue, out double scaleSingleValue)
        {
            double tmpTopValue = CalculateTopValue(graphLines);
            double tmpBottomValue = CalculateBottomValue(graphLines);
            double tmpScaleIntervalValue = CalculateScaleIntervalValue(tmpTopValue, tmpBottomValue);

            scaleTopValue = CalculateScaleTopValue(tmpTopValue, tmpScaleIntervalValue);
            scaleBottomValue = CalculateScaleBottomValue(tmpBottomValue, tmpScaleIntervalValue);
            scaleIntervalValue = CalculateScaleIntervalValue(tmpTopValue, tmpBottomValue);
            scaleSingleValue = CalculateSingleValueSize(yAxisLength, scaleTopValue, scaleBottomValue);
        }

        public static Label CreateLabel<T>(T content, double width, double height, System.Windows.HorizontalAlignment horizontalContentAlignement, Brush textColor, double left, double top)
        {
            var label = new Label
                            {
                                Background = Brushes.Transparent,
                                Content = content,
                                Width = width,
                                Height = height,
                                HorizontalContentAlignment = horizontalContentAlignement,
                                VerticalContentAlignment = VerticalAlignment.Center,
                                Foreground = textColor
                            };

            label.SetValue(Canvas.LeftProperty, left);
            label.SetValue(Canvas.TopProperty, top);

            return label;
        }

        public static Line CreateAxisLine(Point startPosition, Point endPosition)
        {
            var line = new Line
                           {
                               StrokeThickness = 2,
                               Opacity = 1,
                               Stroke = Brushes.White,
                               X1 = startPosition.X,
                               X2 = endPosition.X,
                               Y1 = startPosition.Y,
                               Y2 = endPosition.Y
                           };

            return line;
        }

        public static Line CreateGuideLine(Point startPosition, Point endPosition, Brush lineColor, double lineThickness, double lineOpacity)
        {
            var line = new Line();

            var dashes = new DoubleCollection {1, 1};

            line.StrokeThickness = lineThickness;
            line.Opacity = lineOpacity;
            line.Stroke = lineColor;
            line.X1 = startPosition.X;
            line.X2 = endPosition.X;
            line.Y1 = startPosition.Y;
            line.Y2 = endPosition.Y;
            line.StrokeDashArray = dashes;

            return line;
        }

        public static Ellipse CreateGraphDot<T>(T value, double left, double top)
        {
            var dot = new Ellipse
                          {Height = 8, Width = 8, Stroke = Brushes.Black, StrokeThickness = 0.5, Fill = Brushes.White};


            var tt = new ToolTip {Content = value};
            dot.ToolTip = tt;

            dot.SetValue(Canvas.LeftProperty, left - 4);
            dot.SetValue(Canvas.TopProperty, top - 4);

            return dot;
        }

        public static Line CreateGraphLine(Point startPosition, Point endPosition, Brush lineColor)
        {
            var line = new Line
                           {
                               StrokeThickness = 1,
                               Opacity = 1,
                               Stroke = lineColor,
                               X1 = startPosition.X,
                               X2 = endPosition.X,
                               Y1 = startPosition.Y,
                               Y2 = endPosition.Y
                           };


            return line;
        }

        #endregion

        #region private

        private static double CalculateSingleValueSize(double yAxisLength, double scaleTopValue, double scaleBottomValue)
        {
            return yAxisLength / (scaleTopValue - scaleBottomValue);
        }

        private static double CalculateTopValue(List<GraphLineEntity> graphLines)
        {
            if (graphLines.Count > 0)
            {
                return graphLines.Aggregate(0.0, (current, gle) => gle.Values.Concat(new[] {current}).Max());
            }

            throw new Exception("No values are available.");
        }

        private static double CalculateBottomValue(List<GraphLineEntity> graphLines)
        {
            if (graphLines.Count > 0)
            {
                return graphLines.SelectMany(gle => gle.Values).Concat(new double[] {0xFFFFFFFFFFFFFFFF}).Min();
            }

            throw new Exception("No values are available.");
        }

        private static double CalculateScaleIntervalValue(double topValue, double bottomValue)
        {
            var diff = (topValue - bottomValue);

            var roughInterval = diff / 8.0;

            double valueSize = 1;

            while (roughInterval >= 10)
            {
                roughInterval /= 10;
                valueSize *= 10;
            }

            var exactInterval = 1.0;

            if (roughInterval < 1)
            {
                exactInterval = 1;
            }
            else if (roughInterval >= 1 && roughInterval < 2)
            {
                exactInterval = 2;
            }
            else if (roughInterval >= 2 && roughInterval < 5)
            {
                exactInterval = 5;
            }
            else if (roughInterval >= 5 && roughInterval < 10)
            {
                exactInterval = 10;
            }

            exactInterval *= valueSize;

            return exactInterval;
        }

        private static double CalculateScaleTopValue(double topValue, double scaleIntervalValue)
        {
            var scaleTopValue = 0.0;

            while (scaleTopValue < topValue)
            {
                scaleTopValue += scaleIntervalValue;
            }

            if (scaleTopValue == topValue)
            {
                scaleTopValue += scaleIntervalValue;
            }

            return scaleTopValue;
        }

        private static double CalculateScaleBottomValue(double bottomValue, double scaleIntervalValue)
        {
            var scaleBottomValue = 0.0;

            if (scaleBottomValue < bottomValue)
            {
                while (scaleBottomValue + scaleIntervalValue < bottomValue)
                {
                    scaleBottomValue += scaleIntervalValue;
                }
            }
            else
            {
                while (scaleBottomValue >= bottomValue)
                {
                    scaleBottomValue -= scaleIntervalValue;
                }
            }

            return scaleBottomValue;
        }

        #endregion
    }
}
