   M S B A M L   `   `   `  ����F  BTeamTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TeamTrackerTeamTracker  5   	       TeamTracker.PlayerInfo   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TeamTracker     5   	     � Icon$  Resources/favicon.ico��5   	    � Title$ 
PlayerInfo��5	   	   $	��500��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5
       �� 
TargetType �� Property �� Value��%  '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 3q�6'   �� 5       � ��$
 Left=�6;   �� 5       � ��$ Center=�62   �� 5       � ��$ 15(�6)   �� 5       � ��$ 10q�6(   5      5      .��5      � ���#1B262C � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      �� 5      �� 5      �� 5      �� 5       .+�5#   
   �� -   5        	 ��Name$	 spImage��5#      5%      �� 5,   
   -   5        
 ��Name$
 lblName��5.      $��1��5,      $��0��5-      5.      �� 50   
   $��0��6   $��1��51      $��/Resources/tshirt3.png��52      �� 53   
   -   5        $
 lblShirtNum��55      $��1��53      $��1��54      55      �� 56   
   $��0��6   $��2��57      $��/Resources/goal.png��58      �� 59   
   -   5        $
 lblGoals��5;      $��1��59      $��2��5:      5;      �� 5<   
   $��0��6   $��3��5=      $ ��/Resources/yellow-card.png��5>      �� 5?   
   -   5        $
 
lblCartons��5A      $��1��5?      $��3��5@      5A      �� 5B   
   $��0��6   $��4��5C      $.��(/Resources/Position-removebg-preview.png��5D      �� 5E   
   -   5        $
 lblRole��5G      $��1��5E      $��4��5F      5G      �� 5H   
   $��0��6   $��5��5I      $!��/Resources/captain-band.png��5J      �� 5K   
   -   5        $
 
lblCapitan��5M      $��1��5K      $��5��5L      5M      5O      5P      