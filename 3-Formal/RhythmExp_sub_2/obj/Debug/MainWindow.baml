   M S B A M L   `   `   `  ����J  FRhythmExp_sub_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:RhythmExp_sub_2RhythmExp_sub_2  5   	        RhythmExp_sub_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:RhythmExp_sub_2     5   	     � Title$  Libet Clock��5   	   $��632.423��6   $��803.254��6.    � Icon$ Images/Clock.png��6>    � WindowState$ 	Maximized=�5	   	    � 
ResizeMode$ CanMinimize=�6!   .��5      � -   5         �Name$ MyGrid��5      $��0,0,0,0q�6   .+�5   
   �� -   5         ��Name$ timeinterval��5      $y�Hidden=�6&   $��Center=�6:   $��15(�6W   $	��778��6e   6s   �� 5   
   -   5        $ taskInstruction��5      $�� ��6*   $��20(�65   $��Center=�6C   $��Center=�6g   $��Center=�6�   $y�Hidden=�5      $��
0,96,0,437q�6$   $	��800��68   6F   %   RhythmExp_sub_2.PreferredRhythm  5   
   -   5          Name$ Preferred_Rhythm��5       $y�Visible=�6:   $��Center=�6P   $��Center=�6k   6�       RhythmExp_sub_2.LibetClock  5   
   -   5          Name$ Libet_Clock��5      $y�Hidden=�60   6G   #   RhythmExp_sub_2.EstimateClock  5   
   -   5          Name$ Estimate_Clock��5      $y�Hidden=�66   6L       RhythmExp_sub_2.TaskRating  5   
   -   5        	  Name$	 Task_Rating��5      $y�Hidden=�60   6F   �� 5   
   -   5        
 ��Name$
 Task1Btn��5      $y�Hidden=�6#   $��Task 1��67   $��20(�6H   $��40��6V   $��80��6b   $��150,248,479,250q�6m   6�   �� 5   
   -	   5        $
 Task2Btn��5      $y�Hidden=�6#   $��Task 2��67   $��20(�6H   $��40��6V   $��80��6b   $��262,248,367,250q�6m   6�   �� 5   
   -
   5        $
 Task3Btn��5      $y�Hidden=�6#   $��Task 3��67   $��20(�6H   $��40��6V   $��80��6b   $��366,248,263,250q�6m   6�   �� 5   
   -   5        $
 Task4Btn��5      $y�Hidden=�6#   $��Task 4��67   $��20(�6H   $��40��6V   $��80��6b   $��479,248,150,250q�6m   6�   �� 5   
   -   5         ��Name$ Cover��5      
����� � J� Opacity$	 0.3Q�6/   $	��700��6=   $	��120��6I   
����  �$��3��6h   $��48,238,47,239q�6|   �� 5   
   -   5        $
 Wait��5      $h��bPlease wait for the experimenter to set up the experiment according to your preferred beep rhythm.��6   $��30��6�   $	��800��6�   $��Center=�5      $��Center=�64   $��Center=�6V   $��16(�6s   $��-19,161,-19,315q�6�   $y�Hidden=�6�   6�   �� 5   
   -   5        $
 DoneSetting��5      $��Done!��6&   $��80��66   $��50��6A   $��18(�6M   $��341,357,341,99q�6[   $y�Hidden=�6�   6�   5(      5)      