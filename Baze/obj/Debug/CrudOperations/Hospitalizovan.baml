   M S B A M L   `   `   `  ����?  ;Baze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Baze.CrudOperationsBaze.CrudOperations  5   	   (    "Baze.CrudOperations.Hospitalizovan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Baze.CrudOperations     5   	     � Title$  Hospitalizovan��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� $��	Dijagnoza��6   $
��Left=�6$   $��
47,107,0,0q�6?   $	��Top=�6S   $	��101��6k   �� 5   
   $��Jmbg pacijenta��6   $
��Left=�6)   $��
47,154,0,0q�6D   $	��Top=�6X   $	��101��6p   �� 5   
   $��Jmbg sestre��6   $
��Left=�6&   $��
47,199,0,0q�6A   $	��Top=�6U   $	��101��6m   �� 5   
   -   5         ��Name$ DijagnozaTextBox��5      $
��Left=�6,   $��23��6G   $��279,111,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ JmbgPacTextBox��5       �� DisplayMemberPath$ ImePac��6M    �� SelectedValuePath$ JmbgPac��6h   $
��Left=�6�   $��279,157,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6+   �� *	Pacijenti+6�   �� 5   
   -   5        $ JmbgSestreextBox��5      $ ImeZap��6L   $ JmbgZap��6g   $
��Left=�6�   $��279,199,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6-   �� *Sestre+6�   �� 5   
   -   5         ��Name$ 
SaveButton��5      $
��Save��6%   $
��Left=�64   $��
514,48,0,0q�6O   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $ CancelButton��5      $��Cancel��6'   $
��Left=�68   $��
633,47,0,0q�6S   $	��Top=�6g   $��75��6   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ HospitalizovaniList��5      $
��Left=�60   $	��141��6K   $��
85,261,0,0q�6X   $	��Top=�6l   $	��679��6�      AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	Dijagnoza��,  &System.Windows.Controls.DataGridColumn
   Header$
 	Dijagnoza��5   8      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *	Dijagnoza+6i     5      -   5        JmbgPacijenta��$
 Jmbg pacijenta��5   <   $	 120 6x    6T   �� *PacijentJmbgPac+6x     5      -	   5        
JmbgSestre��$
 Jmbg sestre��5   9   $	 120 6p    6N   �� *SestraJmbgZap+6p   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 80 6)      CellTemplate 5      �� 5      .R�5      �� $ 
ButtonEdit��64   -
   5        $
��EDIT��5   %   6H   5      5        5       $ 80 6)    5!      �� 5"      .R�5#      �� $ ButtonDelete��66   -   5        $��DELETE��5#   %   6L   5$      5&      5)      5,      5-      