   M S B A M L   `   `   `  ����Q  MManagement Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Management_Application.ViewSales Management_Application.ViewSales  5      E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5
      ,    &Management_Application.ViewSales.Sales   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Management_Application.ViewSales     5      =dragablz(clr-namespace:Dragablz;assembly=Dragablz     5
      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��SalesUserControl��5         MaterialDesignBody#���   5      $��Regular"�5      $��10(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��4* �6   6,   �� 5      $��3* �6   6,    � 	Resources 5   
     MyDataGridCell �� 
TargetType*  $System.Windows.Controls.DataGridCell �� BasedOn �� Property �� Value��%�   &	       7 �� 5       "  6+   8   .�5!      -   5        �� 5"       � ��
 ���� 6/   �� 5#       � ��$ Center=�6=   �� 5$       � ��$ Center=�6?   6P   5%      5&      .+�5)   
   �� -   5        $��txtboxSearch��5*      $
��Left=�5,      $��20,0,0,0q�5-      $	��200��5.      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$(	 "Search by product Name/ID/Category��5/      $��Center=�50      .��6(   51      �� 52   
   -   5        $��buttonSearch��53      $��	180,0,0,0q�55      $
��Left=�56      $��50��57      
������ 
������ .��5:      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��
iconSearch��5:   &   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Search=�68   6H   5;      &   System.Windows.Controls.DataGrid  5?   
   -   5        $��dataGridProduct��5A      {�.  $��1��5B      $��Stretch=�5C      $��Stretch=�5D         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5E         CanUserSortColumns .    CanUserAddRows .    AutoGenerateColumns .     
IsReadOnly . ��.     	CellStyle# [ 5K         ColumnHeaderStyle 5N      �� 5O      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5P      ��  � ��$ Center=�6C   �� 5Q       � ��
 ���� 6I   �� 5R       � ��$ 40��6/   6<   5S         Columns 5V      0	  *System.Windows.Controls.DataGridTextColumn	  5X      ,
  &System.Windows.Controls.DataGridColumn 
  Width$	 100 5Y       
  Header$ ID��5Z      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5[      �� *	IDProduct+5\      	  5^      $ Category��5_       5`      �� *Category.NameCategory+5a      	  5c      $
 Name��5d       5e      �� *Name+5f      	  5h      $ 80 5i      $ Amount��5j       5k      �� *Amount+5l      	  5n      $	 120 5o      $ Price��5p       5q      �� *Price+5r      5t      '  !MaterialDesignThemes.Wpf.Snackbar  5v   
   $y�	Collapsed=�5w      $��Bottom=�5x      $��Right=�6(   $��1��6D   $��1��6Q      IsActive .    Message. 5z      .  (MaterialDesignThemes.Wpf.SnackbarMessage  $��Default - accent��5{         ActionContent$ ACCENT��5|      5}      �� 5      $��1��5�      $��2��6!   $��Order��5�        MaterialDesignCardGroupBox#���  5�      ��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�5�      .+�5�        $

 Cart=�5�      $��32��5�      $��32��5�      $��Center=�5�      5�      �� 5�      $��8,0,0,0q�5�      $��20(�5�      $��Center=�5�       % !MaterialDesignSubheadingTextBlock#��[ 5�      ��5�      �� 5�      5�      .��5�      �  5�      �� 5�      $��40 �6$   62   �� 5�      6&   .+�5�      �� $ 
Horizontal=�6   .+�5�      �� -   5        $��txtblockCustomer��5�       $��15(�68   $��
Customer: ��6F   $��Center=�6X   $��0,0,10,0q�6s   6�   �� 5�      -   5        $��comboboxCustomer��5�      $	��100��5�      $��Center=�5�      $��1��5�       �� DisplayMemberPath$ NameCustomer��5�      5�      #  MaterialDesignThemes.Wpf.Chip  5�      -	   5        $��chipCustomerName��5�      $��Center=�5�      $y�	Collapsed=�5�      $��Customer Name��5�        PrimaryHueDarkBrush   IconBackground# �  5�       ! PrimaryHueDarkForegroundBrush   IconForeground# �  5�         IsDeletable .    Icon 5�        5�      $
 Account=�5�   !   5�      5�      5�      �� 5�      -
   5        $��listViewOrder��5�      $��1��60   ��5�      �� 5�      " ��6    .�5�      -   5        5�       �� View 5�      �� 5�      .P�5�      �� $��ID��6-     �� DisplayMemberBinding  69   �� *	IDProduct+6f   �� 5�      $
��Name��6-     6;   �� *Name+6c   �� 5�      $��Category��6-     6?   �� *Category.NameCategory+6x   �� 5�      $��Price��6-     6<   �� *Price+6e   �� 5�      $��Amount��6-   ! �� CellTemplate! 5�   "   �� 5�   &   .R�5�   *   �� $��40��62   $��Center=�6=   $��Center=�6X   ��6u   �� *Amount+" �� Mode$" TwoWay=�6�   5�   '   5�      5�      5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $��	0,0,10,30q�6.   $��1��6A   $��1��6Q   $��Right=�6^   $��Bottom=�6z   .+�5�      �� -   5        $��
buttonCart��5�      {�.  $��0,0,10,0q�5�      $��40��5�      $��40��5�       & "MaterialDesignFloatingActionButton#��[ 5�      # � ToolTip$(# "MaterialDesignFloatingActionButton��5�      .��5�        $

 Cart=�5�      $��24��5�      $��24��5�      5�      �� 5�      -   5        $��buttonClear��5�      {�.  $��40��5�      $��40��5�      #��[ 5�      $(# "MaterialDesignFloatingActionButton��5�      .��5�        $
 Clear=�5�      $��24��5�      $��24��5�      5�      5�      �� 5�   
   $��	10,0,0,10q�5�      $ 
Horizontal=�5�      $��1��5�      $
��Left=�5�      $��Bottom=�5�      .+�5�      �� -   5        $��0,0,10,0q�5�      .��5�        $
 FormatListBulleted=�6*   6F   5�      �� 5�      -   5        .��5        $
 Reload=�6*   6:   5     5     5     5     