   M S B A M L   `   `   `  ����J  FRhythmExp_sub_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:RhythmExp_sub_2_tryRhythmExp_sub_2_try  5      '    !RhythmExp_sub_2_try.EstimateClock   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:RhythmExp_sub_2_try     5      .��5	      � .+�5
   
   �� -   5          ��Name$  Scale_Vertical��5
      
���   �$��90��69   $��1��6E   $��Center=�6O   $��Center=�6l   6�   �� 5   
   -   5        $  Scale_Horizontal��5      
���   �$��1��6;   $��90��6F   $��Center=�6Q   $��Center=�6n   6�   �� 5   
   -   5        $  Scale_Tilt1��5      
���   �$��1��66   $��90��6A   $��Center=�6L   $��Center=�6i    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 30Q�6&   T� 5      5      5      �� 5   
   -   5        $  Scale_Tilt2��5      
���   �$��1��66   $��90��6A   $��Center=�6L   $��Center=�6i   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5      $ 60Q�6&   T� 5      5      5      �� 5    
   -   5        $  Scale_Tilt3��5       
���   �$��1��66   $��90��6A   $��Center=�6L   $��Center=�6i   $ 0.5,0.5&�6�   z�5!      V� 5"      .~�5#      �� �� 5$      �� 5%      $	 -30Q�6&   T� 5&      5'      5)      �� 5*   
   -   5        $  Scale_Tilt4��5*      
���   �$��1��66   $��90��6A   $��Center=�6L   $��Center=�6i   $ 0.5,0.5&�6�   z�5+      V� 5,      .~�5-      �� �� 5.      �� 5/      $	 -60Q�6&   T� 50      51      53      A� 54   
   -   5         A�Name$ Clock_circle��54      
�������
���   �$��80��6D   $��80��6O   $��Center=�6[   $��Center=�6v   �� 55   
   -   5         ��Name$ Clock_Canvas��55      $	��301��6'   $	��300��63   $��0,0,0,0q�6@   .+�57      ��  �� Left$	 124��6Q   
 �� Top$	 222��6c    +� FocusedElement 6   ��  �� ElementName$	 Box��.+�58      �� -	   5        	 ��Name$	 	UserInput��58      $��53��6-   $��30��68   $��20(�59      
 �� TextAlignment$
 Center=�5:      6&   5;      �� 5=      -
   5         ��Name$ 
Scale_t_60��5=      $��60��6(   $��14(�65   $��Center=�6C   $	 138��6`   $ 81��6r   �� 5>      -   5        $ 
Scale_t_30��5>      $��30��6(   $��14(�65   $��Center=�6C   $	 137��6`   $	 189��6r   �� 5@      -   5        $ 
Scale_t_15��5@      $��15��6(   $��14(�65   $��Center=�6C   $��193,136,83,136q�6^   6x   �� 5A      -   5        $ 
Scale_t_45��5A      $��45��6(   $��14(�65   $��Center=�6C   $��83,136,193,136q�6^   6x   �� 5C      -   5        $ 
Scale_t_55��5C      $��55��6(   $��14(�65   $��Center=�6C   $��111,88,165,184q�6^   6x   �� 5D      -   5        $ 
Scale_t_35��5D      $��35��6(   $��14(�65   $��Center=�6C   $��111,183,165,89q�6^   6x   �� 5F      -   5        $ 	Scale_t_5��5F      $��5��6'   $��14(�63   $��Center=�6A   $��167,88,109,184q�6\   6v   �� 5G      -   5        $ 
Scale_t_25��5G      $��25��6(   $��14(�65   $��Center=�6C   $	 166��6^   $	 183��6p   �� 5I      -   5        $ 
Scale_t_40��5I      $��40��6(   $��14(�65   $��Center=�6C   $��89,162,187,110q�6^   6x   �� 5J      -   5        $ 
Scale_t_20��5J      $��20��6(   $��14(�65   $��Center=�6C   $��187,162,89,110q�6^   6x   �� 5L      -   5        $ 
Scale_t_50��5L      $��50��6(   $��14(�65   $��Center=�6C   $ 89��6^   $	 107��6o   �� 5M      -   5        $ 
Scale_t_10��5M      $��10��6(   $��14(�65   $��Center=�6C   $	 187��6^   $	 107��6p   �� 5O      -   5        $ Mouse_Position��5O      $�� ��6,   $y�Hidden=�67   6N   5S      A� 5U   
   -   5        $ Clock_centre��5U      
���   �$��5��65   $��5��6?   $��Center=�6J   $��Center=�6e   �� 5V   
   -   5        $��doneButton_t1��5V      {�. $
��NEXT��68   $��50��6G   $��25��6R   $��125,260,125,15q�6{   �� 5W   
   -   5        $��doneButton_t2��5W      {�. $
��NEXT��68   $��50��6G   $��25��6R   $��125,260,125,15q�6{   �� 5X   
   -   5        $��doneButton_t3��5X      {�. $
��NEXT��68   $��50��6G   $��25��6R   $��125,260,125,15q�6{   �� 5Y   
   -   5        $��doneButton_t4��5Y      {�. $
��NEXT��68   $��50��6G   $��25��6R   $��125,260,125,15q�6{   5Z      5[      