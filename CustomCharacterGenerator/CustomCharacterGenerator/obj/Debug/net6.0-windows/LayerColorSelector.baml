   M S B A M L   `   `   `  ����S  OCustomCharacterGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CustomCharacterGeneratorCustomCharacterGenerator  5   	   1    +CustomCharacterGenerator.LayerColorSelector   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:CustomCharacterGenerator     5   	     � Title$  ColorShemeSelector��5	   	   $	��450��6$   $	��800��61   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   ]� $��Center=�6   $��10q�6/   $��0��6;   $��1��6H   .+�5      �� $
��Left=�6   $
��Bold"�6*   .��6<   R:6@   �� 5      $��Right=�6h    �� TextAlignment$ Right=�6   $��40��6�   ��6   ��  �� ElementName$	 Red�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $	��Red��5   l    � Maximum$	 255Q�6    �� TickPlacement$ BottomRight=�6#   	 �� TickFrequency$	 5Q�6?   
 �� IsSnapToTickEnabled$

 True��6Q   6w   5      ]� 5   
   $��Center=�6   $��10q�6/   $��1��6;   $��1��6H   .+�5      �� $
��Left=�6   $
��Bold"�6*   .��6<   G:6@   �� 5      $��Right=�6j   $ Right=�6�   $��40��6�   ��6   �� $ Green��$ Value�$ PropertyChanged=�6�   �� 5       -   5        $��Green��5    l   $	 255Q�6   $ BottomRight=�6#   $	 5Q�6?   $

 True��6Q   6y   5!      ]� 5#   
   $��Center=�6   $��10q�6/   $��2��6;   $��1��6H   .+�5$      �� $
��Left=�6   $
��Bold"�6*   .��6<   B:6@   �� 5%      $��Right=�6i   $ Right=�6�   $��40��6�   ��6   �� $
 Blue��$ Value�$ PropertyChanged=�6�   �� 5&      -   5        $
��Blue��5&   l   $	 255Q�6   $ BottomRight=�6#   $	 5Q�6?   $

 True��6Q   6x   5'      �� 5(   
   -   5        $��3��5(      $��1��6   $��OK��6/   $��50,20,50,20q�6<   6Q   5)      5*      