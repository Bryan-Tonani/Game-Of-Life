   M S B A M L   `   `   `  ����E  AGameOfLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GameOfLife.UtiGameOfLife.Uti  5          GameOfLife.MainForm   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      *uticlr-namespace:GameOfLife.Uti    5        � Title$  MainForm��5      $
��auto��6   $
��auto��6$    � SizeToContent$ WidthAndHeight=�5       � WindowStyle$ 
ToolWindow=�6$    � 	Resources 5      &    GameOfLife.Uti.CellStatusToImage   CellStatusToImage%   GameOfLife.Uti.CommandReference  KeyDownCmdStart   Command  KeyDownCmdStop  KeyDownCmdRefresh  KeyDownCmdClose��%  &	        &	      &	 G     &	 |     &	 �       5   
   6      5	   
    67   �� *KeyDownEnterCommand+  5
   
    66   �� *KeyDownDeleteCommand+  5   
    69   �� *KeyDownF5Command+  5   
    67   �� *KeyDownAltF4Command+5       J� InputBindings 5      �� 5   
    �� Command# [ 6   
 �� Key$ Enter��6@   �� 5   
   # [ 6   $ Delete��6?   �� 5   
   # [ 6   $ F5��6B   �� 5   
   # [ 6    �� 	Modifiers$	 Altf�6@   $ F4��6P   .��5      �� .+�5   
   o� 	 �� IsTextSearchEnabled	 . .@�5      m� $��	_Settings��6   .@�5      m� $��
World Size��6   
 m� Command
 6/   �� *WorldSizeCmd+5      m� 5      $��_Help��6   .@�5      m� $��Enter - Run��6   
 60   �� *KeyDownEnterCommand+m� 5      $��Delete - Pause��6   
 63   �� *KeyDownDeleteCommand+m� 5      $��F5 - Refresh��6   
 61   �� *KeyDownF5Command+m� 5      $��Alt+F4 - Close��6   
 63   �� *KeyDownAltF4Command+5      5       �� 5!   
   $��Center=�6   $��Center=�60   $��0q�5"      $
��auto��6#   $
��auto��61   ��5!   K   ��  �� Path$ World���5#      �� 5$      .R�5%      �� $��LeftToRight=�6   $��0q�6S   ��6;   �� ��5&      �� 5'      .R�5(   "   �  � Orientation$ 
Horizontal=�6,   5)      ��5+      �� 5,      .R�5-   "   �� .+�5.   &   �� ��6,   �� *Status+ �� 	Converter# [  5/   #   50      52      53      55      56      57      