   M S B A M L   `   `   `  ����`  \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart  5      Q MManagement Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Management_Application.ViewStatistic$Management_Application.ViewStatistic 5      l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5
      E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5      5   /Management_Application.ViewStatistic.Statistics   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5      _	 [MindFusion.Charting.Wpf, Version=2.2.0.40, Culture=neutral, PublicKeyToken=305cd0896f327431-chart!http://mindfusion.eu/charting/wpf 	 5      >local2clr-namespace:Management_Application.ViewStatistic 	 5      ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5	      �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit  5
      7dragablz(clr-namespace:Dragablz;assembly=Dragablz  5      V
 RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 
 5      -   5        $��StatisticUserControl��5         MaterialDesignBody#���   5      $��Regular"�5      $��18(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Filter: ��6   $��Center=�6(   $��	20,0,20,0q�6C   6X   �� 5      -   5        $��comboboxSelection��5       $
��Left=�5!      $��Center=�5"      $��10,0,0,0q�5#      $	��150��5$      5&      5'      � 5+   
   -   5        $��gridDate��5+      $��1��6     5,      �� 5-      $��50 �6    6.   �� 5.      6"   .+�51      �� $ 
Horizontal=�6   .+�52      (  "System.Windows.Controls.DatePicker  -   5        $��datepickerDate��53      $
��Left=�54      $��Center=�55      $��	10,0,20,0q�56      $	��150��57      59      �� 5;      -   5        $��
buttonDate��5;      
������ 
������ .��5<      ' 
 !MaterialDesignThemes.Wpf.PackIcon  � 
 �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 
ArrowRight=�6.   6B   5=        5?      -   5        $��datepickerDateTo��5@      {�.  $
��Left=�5B      $��Center=�5C      $��	10,0,20,0q�5D      $	��150��5E      5G      5H      � 5J      $��0,10,0,0q�6   $��1��6%    � 	Resources 5K       �� 
TargetType �� Property �� Value��%�   '��       �� 5L      " ��6   .�5M      ��  � ��$ 40��63   6@   �� 5N       � ��$ Center=�6>   6O   5O      5P      .+�5Q      �� .��5R      �� .+�5S      � $	��530��5T      $��Center=�5U      $��Center=�5V      	 � ColumnDefinitions	 5W      �� 5X   "   $��3* �63   6@   �� 5Y   "   $��2* �63   6@   �� 5Z   "   65   .+�5\      �� .+�5]   "   �� $
��Bold"�6,   $"��Number of imported products:��6>   6d   �� 5^   "   $
��Bold"�6,   $��Number of sold products:��6>   6`   �� 5_   "   $
��Bold"�6,   $��Revenue:��6>   6P   5`      �� 5a      $��1��6)   .+�5b   "   �� -   5        $��txtblocimportkDate��5b   ,   $��Right=�6F   $��0,0,10,0q�6b   $��0��6t   6   �� 5c   "   -   5        $��txtblocsoldkDate��5c   ,   $��Right=�6D   $��0,0,10,0q�6`   $��0��6r   6}   �� 5d   "   -	   5        $��txtblocrevenuekDate��5d   ,   $��Right=�6G   $��0,0,10,0q�6c   $��0��6u   6�   5e      �� 5f      $��2��6)   .+�5g   "   �� $��products��6,   6>   �� 5h   "   $��products��6,   6>   �� 5i   "   $
��VNĐ��6,   69   5j      5k      9   3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  5m      -
   5        $��amountDateChartColumn��5m   :   
�������.   (De.TorstenMandelkow.MetroChart.ChartBase
   
ChartTitle$
 NUMBER OF PRODUCTS SOLD��6j      ChartSubTitle$ Unknown��6�   $	��500��6�   
������    Series 5o   "   0   *De.TorstenMandelkow.MetroChart.ChartSeries  -   5        $��amountDateChart��5p   %      DisplayMember$
 Name��5q   %      SeriesTitle$ Product��5r   %      ValueMember$ Amount��5s   %   5t   #   5v      -   'De.TorstenMandelkow.MetroChart.PieChart  5x      -   5        $��revenueDateChartPieChart��5x   .   
�������$
 REVENUE��6a   $ Unknown��6v   $	��500��6�   
������  5z   "     -   5        $��revenueDateChart��5{   %   $ IDOrder��5|   %   $ Orders��5}   %   $ 	TotalItem��5~   %   5   #   5�      >	  8System.Windows.Controls.DataVisualization.Charting.Chart	  5�      -   5        $��amountDateChartLine��5�   0   
������� 	  Title$ NUMBER OF PRODUCTS SOLD��6^   $	��500��6~   
������  	  Series 5�   "   C
  =System.Windows.Controls.DataVisualization.Charting.LineSeries
  -   5        $��amountDateChart1��5�   %   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValuePath$ DateSale��5�   %      DependentValuePath$ Amount��5�   %   ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$  ��5�   %   5�   #   5�        5�      -   5        $��revenueDateChartColumn��5�   :   
�������$
 REVENUE��6k   $ Unknown��6�   $	��500��6�   
������  5�   "     -   5        $��revenueDateChart1��5�   %   $ DateSale��5�   %   $ Orders��5�   %   $ 	TotalItem��5�   %   5�   #   5�      5�      5�      5�      5�      � 5�   
   -   5        $��	gridMonth��5�   &   $y�	Collapsed=�6   $��1��67    5�      �� 5�      $��50 �6    6.   �� 5�      6"   .+�5�      �� $ 
Horizontal=�6   .+�5�      �� -   5        $��month1��5�      $
��Left=�5�      $��Center=�5�      $��	10,0,20,0q�5�      $��80��5�      5�      �� 5�      -   5        $��year1��5�      $
��Left=�5�      $��Center=�5�      $��	10,0,20,0q�5�      $��80��5�      5�      �� 5�      -   5        $��buttonMonth��5�      
������ 
������ .��5�        $ 
ArrowRight=�6.   6B   5�      �� 5�      -   5        $��month2��5�      {�.  $
��Left=�5�      $��Center=�5�      $��	10,0,20,0q�5�      $��80��5�      5�      �� 5�      -   5        $��year2��5�      {�.  $
��Left=�5�      $��Center=�5�      $��	10,0,20,0q�5�      $��80��5�      5�      5�      � 5�      $��0,10,0,0q�6   $��1��6%    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � ��$ 40��63   6@   �� 5�       � ��$ Center=�6>   6O   5�      5�      .+�5�      �� .��5�      �� .+�5�      � $	��530��5�      $��Center=�5�      $��Center=�5�      	 5�      �� 5�   "   $��3* �63   6@   �� 5�   "   $��2* �63   6@   �� 5�   "   65   .+�5�      �� .+�5�   "   �� $
��Bold"�6,   $"��Number of imported products:��6>   6d   �� 5�   "   $
��Bold"�6,   $��Number of sold products:��6>   6`   �� 5�   "   $
��Bold"�6,   $��Revenue:��6>   6P   5�      �� 5�      $��1��6)   .+�5�   "   �� -   5        $��txtblocimportkMonth��5�   ,   $��Right=�6G   $��0,0,10,0q�6c   $��0��6u   6�   �� 5�   "   -   5        $��txtblocsoldkMonth��5�   ,   $��Right=�6E   $��0,0,10,0q�6a   $��0��6s   6~   �� 5�   "   -   5        $��txtblocrevenuekMonth��5�   ,   $��Right=�6H   $��0,0,10,0q�6d   $��0��6v   6�   5�      �� 5�      $��2��6)   .+�5�   "   �� $��products��6,   6>   �� 5�   "   $��products��6,   6>   �� 5�   "   $
��VNĐ��6,   69   5�      5�        5�      -   5        $��amountMonthChartColumn��5�   :   
�������$
 NUMBER OF PRODUCTS SOLD��6k   $ Unknown��6�   $	��500��6�   
������  5�   "     -   5        $��amountMonthChart��5�   %   $
 Name��5�   %   $ Product��5�   %   $ Amount��5�   %   5�   #   5       5     -   5        $��revenueMonthChartPieChart��5  .   
�������$
 REVENUE��6b   $ Unknown��6w   $	��500��6�   
������  5  "     -   5        $��revenueMonthChart��5  %   $ IDOrder��5  %   $ Orders��5  %   $ 	TotalItem��5	  %   5
  #   5     	  5     -   5        $��amountMonthChartLine��5  0   
�������$ NUMBER OF PRODUCTS SOLD��6_   $	��500��6   
������  5  "   
  -    5        $��amountMonthChart1��5  %   $ DateSale��5  %   $ Amount��5  %   $  ��5  %   5  #   5       5     -!   5        $��revenueMonthChartColumn��5  :   
�������$
 REVENUE��6l   $ Unknown��6�   $	��500��6�   
������  5  "     -"   5        $��revenueMonthChart1��5  %   $ IDOrder��5  %   $ Orders��5  %   $ 	TotalItem��5  %   5   #   5"     5%     5'     5(     5*     � 5-  
   -#   5        $��gridYear��5-  &   $y�	Collapsed=�6   $��1��66    5.     �� 5/     $��50 �6    6.   �� 50     6"   .+�53     �� $ 
Horizontal=�6   .+�54     �� -$   5        $��Year1��55     $
��Left=�56     $��Center=�57     $��	10,0,20,0q�58     $��80��59     5;     �� 5=     -%   5        $��
buttonYear��5=     
������ 
������ .��5>       $ 
ArrowRight=�6.   6B   5?     �� 5A     -&   5        $��Year2��5B     {�.  $
��Left=�5D     $��Center=�5E     $��	10,0,20,0q�5F     $��80��5G     5I     5L     � 5N     $��0,10,0,0q�6   $��1��6%    5O     ��%�   '��       �� 5P     " ��6   .�5Q     ��  � ��$ 40��63   6@   �� 5R      � ��$ Center=�6>   6O   5S     5T     .+�5U     �� .��5V     �� .+�5W     � $	��530��5X     $��Center=�5Y     $��Center=�5Z     	 5[     �� 5\  "   $��3* �63   6@   �� 5]  "   $��2* �63   6@   �� 5^  "   65   .+�5`     �� .+�5a  "   �� $
��Bold"�6,   $"��Number of imported products:��6>   6d   �� 5b  "   $
��Bold"�6,   $��Number of sold products:��6>   6`   �� 5c  "   $
��Bold"�6,   $��Revenue:��6>   6P   5d     �� 5e     $��1��6)   .+�5f  "   �� -'   5        $��txtblocimportkYear��5f  ,   $��Right=�6F   $��0,0,10,0q�6b   $��0��6t   6   �� 5g  "   -(   5        $��txtblocsoldkYear��5g  ,   $��Right=�6D   $��0,0,10,0q�6`   $��0��6r   6}   �� 5h  "   -)   5        $��txtblocrevenuekYear��5h  ,   $��Right=�6G   $��0,0,10,0q�6c   $��0��6u   6�   5i     �� 5j     $��2��6)   .+�5k  "   �� $��products��6,   6>   �� 5l  "   $��products��6,   6>   �� 5m  "   $
��VNĐ��6,   69   5n     5o       5q     -*   5        $��amountYearChartColumn��5q  :   
�������$
 NUMBER OF PRODUCTS SOLD��6j   $ Unknown��6�   $	��500��6�   
������  5s  "     -+   5        $��amountYearChart��5t  %   $
 Name��5u  %   $ Product��5v  %   $ Amount��5w  %   5x  #   5z       5|     -,   5        $��revenueYearChartPieChart��5|  .   
�������$
 REVENUE��6a   $ Unknown��6v   $	��500��6�   
������  5~  "     --   5        $��revenueYearChart��5  %   $ IDOrder��5�  %   $ Orders��5�  %   $ 	TotalItem��5�  %   5�  #   5�     	  5�     -.   5        $��amountYearChartLine��5�  0   
�������$ NUMBER OF PRODUCTS SOLD��6^   $	��500��6~   
������  5�  "   
  -/   5        $��amountYearChart1��5�  %   $ DateSale��5�  %   $ Amount��5�  %   $  ��5�  %   5�  #   5�       5�     -0   5        $��revenueYearChartColumn��5�  :   
�������$
 REVENUE��6k   $ Unknown��6�   $	��500��6�   
������  5�  "     -1   5        $��revenueYearChart1��5�  %   $ IDOrder��5�  %   $ Orders��5�  %   $ 	TotalItem��5�  %   5�  #   5�     5�     5�     5�     5�     5�     5�     