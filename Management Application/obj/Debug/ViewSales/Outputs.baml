   M S B A M L   `   `   `  ����Q  MManagement Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Management_Application.ViewSales Management_Application.ViewSales  5   	   E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5
   	   .    (Management_Application.ViewSales.Outputs   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Management_Application.ViewSales     5   	   =dragablz(clr-namespace:Dragablz;assembly=Dragablz     5
   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Outputs��5   	   $	��400��5	   	   $	��830��6      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��10(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   
 � Top$	 150��5   	    � Left$	 150��6   .��5      � .+�5   
   �� -   5        $��groupbox��5      $��Order��5        MaterialDesignCardGroupBox#���  5      $��16q�5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�5      .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$
 Cart=�5       $��32��5!      $��32��5"      $��Center=�5#      �� 5$      $��8,0,0,0q�5%      $��Center=�5&       % !MaterialDesignSubheadingTextBlock#��[ 5'      ��5(      �� 5)      5*      .��5,      �  � RowDefinitions 5-      �� 5.      $��40 �6$   62   �� 5/      6&    � 	Resources 51        MyDataGridCell	 �� 
TargetType*  $System.Windows.Controls.DataGridCell
 �� BasedOn �� Property �� Value��%�   &	       7 �� 52      "	  63   8
   .�53      -   5        �� 54       � ��
 ���� 67   �� 55       � ��$ Center=�6E   �� 56       � ��$ Center=�6G   6X   57      58      .+�5;      �� -   5        $��txtboxSearch��5<      $
��Left=�5>      $��20,0,0,0q�5?      $	��200��5@      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$&  Search by Order Name/ID/Category��5A      $��Center=�5B      .��6(   5C      �� 5D      -   5        $��buttonSearch��5E      $��	180,0,0,0q�5G      $
��Left=�5H      $��50��5I      
������ 
������ .��5L        -   5        $��
iconSearch��5L   .   $ Search=�6@   6P   5M      �� 5P      $ 
Horizontal=�5Q      $��Right=�5R      $��Center=�5S      .+�5U      �� -   5        $��buttonFilter��5Z      $y�	Collapsed=�5V      $��Stretch=�5W      $��Stretch=�5X      $��50��5Y      
���   �.��5]        $��Center=�62   $��Center=�6O   $ Filter=�6j   6z   5^      �� 5`      -   5        $��buttonCloseFilter��5e      $y�	Collapsed=�5a      $��Stretch=�5b      $��Stretch=�5c      $��50��5d      
���  ��.��5h        $��Center=�62   $��Center=�6O   $ Close=�6j   6y   5i      �� 5m      -   5        $��buttonReload��5q      $��Stretch=�5n      $��Stretch=�5o      $��50��5p      
���   �.��5t        $��Center=�62   $��Center=�6O   $ Reload=�6j   6z   5u      �� 5x      -	   5        $��buttonDelete��5}      $y�	Collapsed=�5y      $��Stretch=�5z      $��Stretch=�5{      $��50��5|      
���   �.��5�        -
   5        $��
iconDelete��5�   2   $ Delete=�6E   6U   5�      �� 5�      -   5        $��closeDelete��5�      $y�	Collapsed=�5�      $��Stretch=�5�      $��Stretch=�5�      $��50��5�      
���  ��.��5�        $ Close=�62   6A   5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5        $��dataGridOutput��5�      $��1��5�      $��Stretch=�5�      $��Stretch=�5�         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5�         CanUserSortColumns .    CanUserAddRows .    AutoGenerateColumns .     
IsReadOnly . ��.     	CellStyle# [ 5�         ColumnHeaderStyle 5�      �� 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6    .�5�      ��  � ��$ Center=�6K   �� 5�       � ��
 ���� 6Q   �� 5�       � ��$ 40��67   6D   5�         Columns 5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn 
  Width$ 80 5�       
  
Visibility$ 	Collapsed=�5�       
  HeaderTemplate 5�      �� 5�   "   .R�5�   &   �� $��checkBoxDeleteAll��5�   !   -   5        $��Center=�5�   !   5�   #    	  CellTemplate 5�      �� 5�   "   .R�5�   &   ��  ��Name$ checkBoxDelete��5�   !   -   5        $��Center=�5�   !    d� 	IsChecked 5�   !   �� *
isSelected+ �� Mode$ TwoWay=�5�   !   5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $ 50 5�       
  Header$ ID��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *	IDProduct+5�        5�      $	 100 5�      $
 Name��5�       5�      �� *Name+5�        5�      $ 50 5�      $ ID Order��5�       5�      �� *	IDOrder+5�        5�      $	 150 5�      $ Category��5�       5�      �� *Category.NameCategory+5�        5�      $	 120 5�      $ Amount��5�       5�      �� *Amount+5�        5�      $	 120 5�      $ Discount (%)��5�       5�      �� *
Discount+5�        5�      $	 120 5�      $ Price (VNĐ)��5�       5�      �� *Price+5�      5�      5�      5�      �� 5�   
   -   5        $��
buttonDone��5�      $	��100��5�      $��Right=�5�      $��Bottom=�5�      $��	0,0,40,40q�5�        MaterialDesignRaisedButton#���  5�      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�5�      .��6>   DONE5�      5�      5�      