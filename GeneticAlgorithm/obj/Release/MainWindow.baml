   M S B A M L   `   `   `  ����   GeneticAlgorithm!    GeneticAlgorithm.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Genetic "Hello, World!"��$	��420��$	��525��$	��420��$	��300��.���  � ColumnDefinitions �� $��* ��� $��170px �.+��� -    ��Name$ 
tbMainText��$��0�� �� IsReadOnlyCaretVisible . $ �� HorizontalScrollBarVisibility$ Visible=���. " �� VerticalScrollBarVisibility$ Visible=�� $��1��.+���  �� Orientation$ Vertical=����	#FFF3F3F3.+��� $��
Текст�� �� TextAlignment$
 Left=�$��Center=�$��5 0 5 0q��� -   $ tbGeneticText��$��Hello, world!��$��	15 5 15 5q��� $-��'Размер популяции (> 128)��$
 Left=�$��Center=�$��5 0 5 0q��� -   $ 	tbPopSize��$
��2048��$��	15 5 15 5q��� $"��Макс. интераций��$
 Left=�$��Center=�$��5 0 5 0q��� -   $ tbMaxInterations��$��16384��$��	15 5 15 5q��� $,��&Коэффициент мутации ��$
 Left=�$��Center=�$��5 0 5 0q��� -   $ tbMutationRate��$
��0.25��$��	15 5 15 5q��� $��Элитарность ��$
 Left=�$��Center=�$��5 0 5 0q��� -   $ 
tbElitRate��$
��0.10��$��	15 5 15 5q��� $ ��Мутация (Read Only)��$
 Left=�$��Center=�$��5 0 5 0q��� -   $ 
tbMutation��$��RAND_MAX * MUTATIONRATE��$��	15 5 15 5q� �� 
IsReadOnly . �� -   	 ��Name$	 btnStart��$��Начать��$	��100��$��	0 10 0 10q��� -	   $	 btnStop��$��Остановить��$	��100��$��0 0 0 0q��� $(��"Николай Матюшин 2014��$��Bottom=�$��Center=�$��10q����	#FF008BFF