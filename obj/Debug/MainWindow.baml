   M S B A M L   `   `   `  ����H  DCA2_S00189001, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CA2_S00189001CA2_S00189001  5   	       CA2_S00189001.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CA2_S00189001     5   	   -   5          � Title$  Activity Planner��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   �� $��Activity Panner��6   $
��Left=�6*   $��
111,10,0,0q�6E   $	��Top=�6Y   ���	#FF1CB4C3$��25(�6�   �� 5   
   $��
Total Cost��6   $
��Left=�6%   $��
501,24,0,0q�6@   $	��Top=�6T   �� 5   
   -   5         ��Name$ 	totalCost��5      $
��Left=�6'   $��
685,29,0,0q�6B   $
��Wrap=�6V   $��	TotalCost��6j   $	��Top=�6{   $��Italic$�6�   	� 5   
   -   5         	�Name$ rbtnAll��5      $	��All��6'   $
��Left=�65   $��
30,123,0,0q�6P   $	��Top=�6d    d� 	IsChecked$
 TrueY�6�    	� 	GroupName$ 
rbtnChecks��6�   	� 5   
   -   5        $ rbtnLand��5      $
��Land��6(   $
��Left=�67   $��
30,152,0,0q�6R   $	��Top=�6f   $ 
rbtnChecks��6�   	� 5   
   -   5        $ 	rbtnWater��5      $��Water��6)   $
��Left=�69   $��
30,182,0,0q�6T   $	��Top=�6h   $ 
rbtnChecks��6�   	� 5   
   -   5        $ rbtnAir��5      $	��Air��6'   $
��Left=�65   $��
30,211,0,0q�6P   $	��Top=�6d   $ 
rbtnChecks��6�   �� 5   
   $��All Activities��6   $
��Left=�6)   $��
100,97,0,0q�6D   $	��Top=�6X   �� 5   
   -   5         ��Name$ listboxActivities��5      $
��Left=�6-   $	��183��6H   $��100,123,0,0q�6U   $	��Top=�6j   $	��228��6�   6�   �� 5   
   -   5        $ listboxSelectedActivities��5      $
��Left=�65   $	��183��6P   $��476,123,0,0q�6]   $	��Top=�6r   $	��228��6�   6�   �� 5   
   $��Selected Activities��6   $
��Left=�6.   $��
476,97,0,0q�6I   $	��Top=�6]   �� 5   
   -	   5         ��Name$ btnAddRight��5      $	��Add��6&   $
��Left=�64   $��367,152,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -
   5        $ btnRemoveLeft��5      $��Remove��6(   $
��Left=�69   $��367,206,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5   
   $��Description��6   $
��Left=�6&   $��100,322,0,0q�6A   $	��Top=�6V   �� 5   
   -   5        $ txtbDescription��5      $
��Left=�6-   $��100,348,0,0q�6H   $
��Wrap=�6]   $��Description here��6q   $	��Top=�6�   $	��604��6�   $��51��6�   5      5      