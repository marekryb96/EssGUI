   M S B A M L   `   `   `  ���� A  =EssGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EssGUIEssGUI      EssGUI.Customer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:EssGUI       � Title$  	ESService�� � WindowState$ Normal=� � 
ResizeMode$ CanMinimize=�$	��581��.��� $��0,0,4,0q�.+��� -   $��16(�.@��� -   $��client������  �� Orientation$ 
Horizontal=�.+��� 
���   ��� $�Klienci��.���  � RowDefinitions �� $��35 ��� $��* ��� $��70 � � ColumnDefinitions �� .+�� $��0�� �� $	��110 ��� �� .+�� $��0��.+��� $��	Szukaj po��$
��Left=�$��
0,10,0,-14q�$	��Top=�$��39��� $��1��.+��� -    ��Name$ 	filterBox�� �� 
IsReadOnly . $��-26,10,228,0q�.@��� .��imię��  �� 
IsSelected . .��
nazwisko�� .��	telefon�� .��e-mail�� .��ulica�� .��miejscowość�� .��id� $��2���� -   	 ��Name$	 filter��$��25��$��
101,10,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$��18(�$��1��$��2��� $��1��$��0,16,0,0q� �� $	��99* ��� $
��277* �.+�&   System.Windows.Controls.DataGrid  -   $��
clientinfo��   AutoGenerateColumns .     SelectionUnit$ FullRow=�   
IsReadOnly . $��2��   SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Imię��$
 Auto  �� *Name+  $ Nazwisko�� . $
 Auto  �� *	Surname+  $ Numer telefonu�� . $
 Auto  �� *PhoneNumber.Number+  $ E-mail�� . $
 Auto  �� *Email+  $ Ulica�� . $
 Auto  �� *Address.Street+  $ Nr domu�� . $
 Auto  �� *Address.HouseNumber+  $ Miejscowość�� . $
 Auto  �� *Address.City+  $ Kod pocztowy�� . $
 Auto  �� *Address.ZipCode+  $	 Typ�� . $
 Auto  �� *
ClientType+� $��3�� �� �� �� .+�� $��0�� �� $
��179* ��� $	��82* �.+��� -    ��Name$ editBt��$��10,12q�$��45��$��Edytuj��$��20(�$��2��� $��1��.+��� -   $��10q�$��45��$��Wybierz��$��20(�� $��2��.+��� -   $��10q�$��45��$��	Odśwież��$��20(��� ���� $ 
Horizontal=�.+��� 
���   �$��Nowy klient��.���  �� $��* � �� $	��150 ��� .+�� $��0�� �� $	��31* ��� $	��44* �.+��� $��2��.+��� $��Imię��$��5q�$��30���� $��Nazwisko��$��5q�$��30���� $��E-mail��$��5q�$��30���� $��Telefon��$��5q�$��30���� $�� ��$��5q�$��30���� $
��Kraj��$��5q�$��30���� $��Miasto��$��5q�$��30���� $��Kod pocztowy��$��5q�$��30���� $��Ulica��$��5q�$��30���� $��
Nr budynku��$��5q�$��30���� $��Typ klienta��$��5q�$��30���� $	��NIP��$��5q�$��30��� $��1�� �� $	��28* ��� $
��365* ��� $��0* �.+��� $��2��$��10,0,0,0q�.+��� -	   $��TextBox1��$��5q�$��30���� -
   $��TextBox2��$��5q�$��30���� -   $��TextBox3��$��5q�$��30���� -   $��TextBox4��$��5q�$��30���� -   $��TextBox9��$��5q�$��30���� -   $��	TextBox11��$��Polska��$��5q�$��30���� -   $��TextBox5��$��5q�$��30���� -   $��TextBox6��$��5q�$��30���� -   $��TextBox7��$��5q�$��30���� -   $��TextBox8��$��5q�$��30���� -   $ typeBox��$��5q�$��30��.@���  . .��indywidualny�� .��firma�� -   $��	TextBox10��$��5q�$��25���� -   $��Zapisz��$��	5,5,5,106q�$��30��$��20(�� $
��Left=�$	��100��$��-75,354,0,-33q�$	��Top=�$	��100��