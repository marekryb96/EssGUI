   M S B A M L   `   `   `  ����A  =EssGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EssGUIEssGUI  5   	       EssGUI.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:EssGUI     5   	     � Title$  	Logowanie��5   	   $��532.255��6   $��385.612��6,    � WindowStartupLocation$ CenterScreen=�6<   .��5	      � $��0,0,2,0q�6   .+�5   
   �� $��0,0,-12,253q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF89EA93��6#   � 5      $ 	#FF887FBF��6#    � Offset$ 1Q�65   � 5      $ 	#FF77B5D3��6#   $ 0.484Q�65   5      5      �� 5   
   $��10,161,10,134q�6    �� RadiusY$ 10��6+    �� RadiusX$ 10��68   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 15Q�6#   
   	Direction$
 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      �� 5   
   -   5         ��Name$	 log��5      $
��Left=�6   $��39��6:   $��
32,205,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��306��6�   $��20(�6�   �� 5   
   -   5        $��logOn��5      $��ZALOGUJ��6   $
��Left=�60   $��
32,398,0,0q�6K   $	��Top=�6_   $	��306��6w   $��41��6�   $��22(�6�   $
��Bold"�6�   6�   G� 5   
   -   5         G�Name$
 pass��5      $
��Left=�6$   $��
32,288,0,0q�6?   $	��Top=�6S   $��39��6k   $	��306��6w   $��20(�6�   �� 5   
   $��LOGIN��6   $
��Left=�6    $��
32,161,0,0q�6;   $	��Top=�6O   $��22(�6g    J� RenderTransformOrigin$ 0.743,0.487&�6u   �� 5   
   $��HASŁO��6   $
��Left=�6    $��
32,249,0,0q�6;   $	��Top=�6O   $��22(�6g   $ 0.506,1.834&�6u   �� 5    
   $	��ESS��6   $��Center=�6   $��
10,26,10,0q�6B   $	��Top=�6V   $��82��6n   $��60(�6z   
�������6�   �� 5!   
   -   5         ��Name$ 
forgotPass��5!      $��nie pamiętam hasła��6%   $
��Left=�6B   $��
32,461,0,0q�6]   $	��Top=�6q   $	��306��6�   $��23��6�   $��16(�6�   6�   5#      5$      