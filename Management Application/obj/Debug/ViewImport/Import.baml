   M S B A M L   `   `   `  ����Q  MManagement Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Management_Application.ViewImport!Management_Application.ViewImport  5      E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5
      .    (Management_Application.ViewImport.Import   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Management_Application.ViewImport     5      =dragablz(clr-namespace:Dragablz;assembly=Dragablz     5
      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��ImporttUserControl��5         MaterialDesignBody#���   5      $��Regular"�5      $��10(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6    � 	Resources 5   
     MyDataGridCell �� 
TargetType*  $System.Windows.Controls.DataGridCell �� BasedOn �� Property �� Value��%�   &	       7 �� 5      "  6+   8   .�5      -   5        �� 5       � ��
 ���� 6/   �� 5       � ��$ Center=�6=   �� 5       � ��$ Center=�6?   6P   5      5       .+�5#   
   �� -   5        $��txtboxSearch��5$      $
��Left=�5&      $��20,0,0,0q�5'      $	��200��5(      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$( "Search by product Name/ID/Category��5)      $��Center=�5*      .��6(   5+      �� 5-   
   -   5        $��buttonSearch��5.      $��	180,0,0,0q�50      $
��Left=�51      $��50��52      
������ 
������ .��55      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��
iconSearch��55   &   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]	   Kind$	 Search=�68   6H   56      �� 59   
   
 �� Orientation$
 
Horizontal=�5:      $��Right=�5;      $��Center=�5<      .+�5>      �� -   5        $��buttonFilter��5B      $��Stretch=�5?      $��Stretch=�5@      $��50��5A      
���   �.��5E        $��Center=�6*   $��Center=�6G   $	 Filter=�6b   6r   5F      �� 5H      -   5        $��buttonCloseFilter��5M      $y�	Collapsed=�5I      $��Stretch=�5J      $��Stretch=�5K      $��50��5L      
���  ��.��5P        $��Center=�6*   $��Center=�6G   $	 Close=�6b   6q   5Q      �� 5U      -   5        $��buttonReload��5Y      $��Stretch=�5V      $��Stretch=�5W      $��50��5X      
���   �.��5\        $��Center=�6*   $��Center=�6G   $	 Reload=�6b   6r   5]      �� 5_      -	   5        $��buttonDelete��5c      $��Stretch=�5`      $��Stretch=�5a      $��50��5b      
���   �.��5f        -
   5        $��
iconDelete��5f   *   $	 Delete=�6=   6M   5g      �� 5i      -   5        $��closeDelete��5n      $y�	Collapsed=�5j      $��Stretch=�5k      $��Stretch=�5l      $��50��5m      
���  ��.��5q        $	 Close=�6*   69   5r      5t      &   System.Windows.Controls.DataGrid  5x   
   -   5        $��dataGridInput��5y      $��1��5z      $��Stretch=�5{      $��Stretch=�5|         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5}         CanUserSortColumns .    CanUserAddRows .    AutoGenerateColumns .     
IsReadOnly . ��.     	CellStyle# [ 5�         ColumnHeaderStyle 5�      �� 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5�      ��  � ��$ Center=�6C   �� 5�       � ��
 ���� 6I   �� 5�       � ��$ 40��6/   6<   5�         Columns 5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn 
  Width$ 80 5�       
  
Visibility$ 	Collapsed=�5�       
  HeaderTemplate 5�      �� 5�      .R�5�      �� $��checkBoxDeleteAll��5�   !   -   5        $��Center=�5�   !   5�       	  CellTemplate 5�      �� 5�      .R�5�      ��  ��Name$ checkBoxDelete��5�   !   -   5        $��Center=�5�   !    d� 	IsChecked 5�   !   �� *
isSelected+ �� Mode$ TwoWay=�5�   !   5�      5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $	 100 5�       
  Header$ ID��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *	IDProduct+5�        5�      $	 100 5�      $ Category��5�       5�      �� *Category.NameCategory+5�        5�      $	 100 5�      $
 Name��5�       5�      �� *Name+5�        5�      $ 80 5�      $ Amount��5�       5�      �� *Amount+5�        5�      $	 120 5�      $ Price��5�       5�      �� *Price+5�        5�      $
 Date��5�       5�      �� *	DateEntry+5�      5�      5�      5�      