   M S B A M L   `   `   `  ����X  TLab_5_Graphic_redactor_Korbut, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Lab_5_Graphic_redactor_KorbutLab_5_Graphic_redactor_Korbut  5   	   3    -Lab_5_Graphic_redactor_Korbut.LineColorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Lab_5_Graphic_redactor_Korbut     5   	     � Title$  	LineColor��5   	   $	��250��6   $	��820��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��Center=�6!   $��1q�6<   $��40��6G   .+�5      �� $��Right=�6   $��30��6/    �� TextAlignment$ Right=�6�   $��18(�6�   $��Center=�6�   ��6:   ��  �� ElementName$ 	redSlider�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��R:��6   $��30��6!   $
��Left=�6,   $��18(�6B   $��Center=�6P   �� 5      -   5        $��	redSlider��5       � Minimum$ 0Q�6'    � Maximum$	 255Q�63   $
��Left=�6A    �� TickPlacement$ BottomRight=�6W   	 �� TickFrequency$	 1Q�6s   
 �� IsSnapToTickEnabled
 . 6�   5      ]� 5   
   $��1��6   $��Center=�6!   $��1q�6<   $��40��6G   .+�5      �� $��Right=�6   $��30��6/   $ Right=�6�   $��18(�6�   $��Center=�6�   ��6:   �� $ greenSlider��$ Value�$ PropertyChanged=�6�   �� 5      $��G:��6   $��30��6!   $
��Left=�6,   $��18(�6B   $��Center=�6P   �� 5      -   5        $��greenSlider��5      $ 0Q�6)   $	 255Q�65   $
��Left=�6C   $ BottomRight=�6Y   $	 1Q�6u   
 . 6�   5      ]� 5   
   $��2��6   $��Center=�6!   $��1q�6<   $��40��6G   .+�5      �� $��Right=�6   $��30��6/   $ Right=�6�   $��18(�6�   $��Center=�6�   ��6:   �� $ 
blueSlider��$ Value�$ PropertyChanged=�6�   �� 5      $��B:��6   $��30��6!   $
��Left=�6,   $��18(�6B   $��Center=�6P   �� 5      -   5        $��
blueSlider��5      $ 0Q�6(   $	 255Q�64   $
��Left=�6B   $ BottomRight=�6X   $	 1Q�6t   
 . 6�   5      �� 5   
   -   5        
�������$��Apply��5   '   $��3��67   $��25��6D   $��75��6P   5       5!      5#      