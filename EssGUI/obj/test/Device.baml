   M S B A M L   `   `   `  ���� A  =EssGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EssGUIEssGUI      EssGUI.Device   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:EssGUI       � Title$  	ESService�� � WindowState$ Normal=� � 
ResizeMode$ CanMinimize=�.��� $��0,0,4,0q�.+��� -   $��16(�.@��� -   $��device������  �� Orientation$ 
Horizontal=�.+��� $��Sprzęt��
���   �.���  � RowDefinitions �� $��35 ��� $��* ��� $��70 � � ColumnDefinitions �� .+�� $��0�� �� $	��110 ��� �� .+�� $��0��.+��� $��	Szukaj po��$
��Left=�$��
0,10,0,-14q�$	��Top=�$��39��� $��1��.+��� -    ��Name$ 	filterBox��$��-25,10,150,0q�.@���  �� 
IsSelected . .��nazwa�� .��numer seryjny�� .��model�� .��id�� .��	producent� $��2���� -    ��Name$ filter��$��25��$��
176,10,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$��18(�$��1��$��2��� $��1��$��0,16,0,0q� �� $	��99* ��� $
��277* �.+�&   System.Windows.Controls.DataGrid  -   
  Name$
 
deviceinfo��   AutoGenerateColumns .     SelectionUnit$ FullRow=�   
IsReadOnly .    SelectionMode$ Single=�$��2��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Nazwa�� . $
 Auto  �� *Name+  $ 	Producent�� . $
 Auto  �� *Brand+  $ Model�� . $
 Auto  �� *Model+  $ Numer seryjny�� . $
 Auto  �� *SerialNumber+� $��3�� �� �� �� .+�� $��0��.+��� -    ��Name$ editBt��$��10q�$��45��$��Edytuj��$��20(�� $��1��.+��� -   $��10q�$��45��$��Wybierz��$��20(�� $��2��.+��� -   $��10q�$��45��$��	Odśwież��$��20(��� ���� $ 
Horizontal=�.+��� 
���   �$��Nowy sprzęt��.���  �� $��* � �� $	��250 ��� .+�� $��0��.+��� .+��� $��Nazwa��$��5q�$��30���� $��Model��$��5q�$��30���� $��
Nr seryjny��$��5q�$��30���� $��	Producent��$��5q�$��30��� $��1�� �� $	��28* ��� $
��258* ��� $
��107* �.+��� $��3��$��10,0,0,0q�.+��� -	   $��TextBox1��$��5q�$��30���� -
   $��TextBox2��$��5q�$��30���� -   $��TextBox3��$��5q�$��30���� -   $��TextBox5��$��5q�$��30���� -   $��Zapisz��$��5q�$��45��$��20(�� $
��Left=�$	��100��$��-75,354,0,-33q�$	��Top=�$	��100��