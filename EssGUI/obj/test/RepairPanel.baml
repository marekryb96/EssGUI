   M S B A M L   `   `   `  ���� A  =EssGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EssGUIEssGUI      EssGUI.RepairPanel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:EssGUI       � Title$  Naprawa�� � WindowState$ Normal=� � 
ResizeMode$ CanMinimize=�$��676.6��$��816.8��.��� $��0,0,4,0q�.+��� $��16(�.@��� ����  �� Orientation$ 
Horizontal=�.+��� 
���   �$��Bieżąca naprawa��.���  � RowDefinitions �� $��* � � ColumnDefinitions �� $	��150 ��� .+�� $��0�� �� $	��31* ��� $	��44* �.+��� $��2��$��	0,0,-20,0q�.+��� $��Id��$��5q�$��30��$��16(��� $��Status��$��5q�$��30��$��16(��� $��Problem��$��5q�$��30��$��16(��� $��Model��$��5q�$��30��$��16(��� $��Numer seryjny��$��5q�$��30��$��16(��� $��Telefon��$��5q�$��30��$��16(��� $��Opis naprawy��$��	5,5,5.4,5q�$��95��$��16(��� $��Koszty��$��5q�$��30��$��16(��� $��Wymienione części��$��5q�$��30��$��16(��� $��Usługi��$��5q�$��30��$��16(��� $��Nowy status��$��5q�$��30��$��16(��� $��Pobrane z magazynu��$��5q�$��30��$��16(�� $��1��$��32,0,5,0q� �� $	��41* ��� $
��322* ��� $
��219* ��� $��0* �.+��� $��3��$��10,0,0,0q�.+��� -   $��idLabel��$��id��$��5q�$��30���� -   $��statusLabel��$��id��$��5q�$��30���� -   $��problemLabel��$��id��$��5q�$��30���� -   $��
modelLabel��$��5q�$��25���� -   $��serialLabel��$��5q�$��30���� -    ��Name$ 
phoneLabel��$��id��$��5q�$��30���� -    ��Name$ opisBox��$��5q�$	��100���� $�� ��$��5q�$��30���� -   $��TextBox2��$��0��$��5q�$��30���� -	   $��TextBox3��$��0��$��5q�$��30���� -
    ��Name$ 	statusBox��$��5q�$��30��.@��� 	 �� 
IsSelected	 . .��w trakcie realizacji�� .��oczekiwanie na część�� .��oczekiwanie na gwarancję�� .��zakończone�� .��	anulowane�� -   $��
stockLabel��$��5q�$��30��$��16(��� -   $��Zapisz��$��	5,5,5,106q�$��50��$��20(��� -   $��devices������ $ 
Horizontal=�.+��� $��Magazyn��
���   �.���  �� $��35 ��� $��* ��� $��70 � �� .+�� $��0�� �� $	��110 ��� �� .+�� $��0��.+��� $��	Szukaj po��$
��Left=�$��
15,5,0,-10q�$	��Top=�$��16(�$��35��� $��1�� �� $
��131* ��� $
��190* �.+��� -   $ 	filterBox��$��-15,10,119,0q�$��16(�$��2��.@��� 	 . .��id�� .��nazwa�� .��	producent�� .��model� $��2���� -   $ filter4��$��25��$��
232,10,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$��18(�$��1��$��2��� $��1��$��0,16,0,0q� �� $	��99* ��� $
��277* �.+�&   System.Windows.Controls.DataGrid  -     Name$ 	stockinfo��   AutoGenerateColumns .     SelectionUnit$ FullRow=�   
IsReadOnly . $��2��$��16(�   SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Nazwa�� . $
 Auto  �� *Name+  $ 	Producent�� . $
 Auto  �� *Brand+  $ Model�� . $
 Auto  �� *Model+  $
 Opis�� . $
 Auto  �� *Description+  $ Ilość�� . $
 Auto  �� *
Quantity+� $��3�� �� �� �� .+�� $��0��.+��� -   $��refreshDevice��$��10q�$��45��$��	Odśwież��$��20(�� $��1��.+��� -   $��quantity��$
��0,10q�$��1��$��30(�� $��2��.+��� -   $��	addDevice��$��10q�$��45��$��Pobierz��$��20(�� $
��Left=�$	��100��$��-75,354,0,-33q�$	��Top=�$	��100��