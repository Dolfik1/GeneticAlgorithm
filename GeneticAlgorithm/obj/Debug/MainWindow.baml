   M S B A M L   `   `   `  ����  GeneticAlgorithm!    GeneticAlgorithm.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Genetic "Hello, World!"��5   	   $	��400��63   $	��525��6@   $	��400��6L   $	��300��6\   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��170px �6   .+�5
   
   �� -   5         ��Name$ 
tbMainText��5
      $��0��6&    �� IsReadOnlyCaretVisible . $ �� HorizontalScrollBarVisibility$ Visible=�6T   ��. " �� VerticalScrollBarVisibility$ Visible=�6�   � 5   
   $��1��6   .+�5      ��  �� Orientation$ Vertical=�6   ���	#FFF3F3F3.+�5      �� $��
Текст��6    �� TextAlignment$
 Left=�6)   $��Center=�6>   $��5 0 5 0q�6Y   �� 5      -   5        $ tbGeneticText��5      $��Hello, world!��61   $��	15 5 15 5q�6F   �� 5      $-��'Размер популяции (> 128)��6   $
 Left=�6<   $��Center=�6Q   $��5 0 5 0q�6l   �� 5      -   5        $ 	tbPopSize��5      $
��2048��6-   $��	15 5 15 5q�69   �� 5      $"��Макс. интераций��6   $
 Left=�63   $��Center=�6H   $��5 0 5 0q�6c   �� 5      -   5        $ tbMaxInterations��5      $��16384��64   $��	15 5 15 5q�6A   �� 5      $,��&Коэффициент мутации ��6   $
 Left=�68   $��Center=�6M   $��5 0 5 0q�6h   �� 5      -   5        $ tbMutationRate��5      $
��0.25��62   $��	15 5 15 5q�6>   �� 5      $��Элитарность ��6   $
 Left=�60   $��Center=�6E   $��5 0 5 0q�6`   �� 5      -   5        $ 
tbElitRate��5      $
��0.10��6.   $��	15 5 15 5q�6:   �� 5      $ ��Мутация (Read Only)��6   $
 Left=�67   $��Center=�6L   $��5 0 5 0q�6g   �� 5      -   5        $ 
tbMutation��5      $��RAND_MAX * MUTATIONRATE��6.   $��	15 5 15 5q�6M    �� 
IsReadOnly . 6`   �� 5      -   5        	 ��Name$	 btnStart��5      $��Начать��6+   $	��100��6<   $��	0 10 0 10q�6H   6[   �� 5      -	   5        $	 btnStop��5      $��Остановить��6*   $	��100��6?   $��0 0 0 0q�6K   6\   5      �� 5      $(��"Николай Матюшин 2014��6   $��Bottom=�64   $��Center=�6O   $��10q�6l   ���	#FF008BFF6x   5      5      5      