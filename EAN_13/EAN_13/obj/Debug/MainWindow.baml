   M S B A M L   `   `   `  ����A  =EAN_13, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EAN_13EAN_13  5   	       EAN_13.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:EAN_13     5   	     � Title$  Barcode Gen EAN-13��5   	   $	��450��6$   $	��800��61   
���   �
���   �
������� � WindowStartupLocation$ Manual=�6w    � 
ResizeMode$ CanMinimize=�6�   .��5	      � .+�5
   
   �� -   5         ��Name$ Start_Button��5
      $��Genera��6'   $
��Left=�68   $��
558,10,0,0q�6S   $	��Top=�6g   $	��124��6   $��42��6�   $��20(�6�   
���   �6�   �� 5   
   -   5         ��Name$ boxCodiceIniziale��5      $
��Left=�6-   $��34��6H   $��
191,15,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��189��6�    �� 	MaxLength$ 12��6�   $��20(�6�   �� 5   
   -   5        $ 	boxLimite��5      $
��Left=�6%   $��36��6@   $��
191,66,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��189��6�   $��20(�6�   $ 5��6�   �� 5   
   -   5         ��Name$ Lista��5      $
��Left=�6!   $	��211��6<   $��
86,117,0,0q�6I   $	��Top=�6]   $	��610��6u   $��20(�6�   �� 5   
   -   5        $��	lblCodice��5      $��Codice Iniziale: *��6!   $
��Left=�6>   $��	32,15,0,0q�6Y   $	��Top=�6l   $	��154��6�   $��36��6�   $��20(�6�   �� 5   
   -   5        $��	lblLimite��5      $��	Limite: *��6!   $
��Left=�65   $��
100,61,0,0q�6P   $	��Top=�6d   $��86��6|   $��20(�6�   $��40��6�   �� 5   
   -   5        $ Salva_Button��5      $��Salva su File��6'   $
��Left=�6?   $��
401,66,0,0q�6Z   $	��Top=�6n   $	��139��6�   $��42��6�   $��20(�6�   6�   �� 5   
   -   5        $ Pulisci_Button��5      $��Pulisci��6)   $
��Left=�6;   $��
401,10,0,0q�6V   $	��Top=�6j   $	��139��6�   $��44��6�   $��20(�6�   6�   � 5   
   -	   5         �Name$ Barra��5      $
��Left=�6%   $��46��6@   $��
86,346,0,0q�6L   $	��Top=�6`   $	��610��6x   �� 5   
   -
   5        $ Ferma��5      $��Ferma salvataggio��6    $
��Left=�6<   $��
558,66,0,0q�6W   $	��Top=�6k   $	��124��6�   $��42��6�   $��14(�6�   {�.  6�   �� 5   
   -   5        	 ��Name$	 percentuale��5      $��360,346,362,29q�6)   $��20(�6A   
 �� TextAlignment$
 Center=�6O   $��0%��6f   5      5      