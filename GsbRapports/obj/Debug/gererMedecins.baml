   M S B A M L   `   `   `  ����F  BGsbRapports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GsbRapportsGsbRapports  5   	       GsbRapports.gererMedecins   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GsbRapports     5   	     � Title$  gererMedecins��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5   
   �� -   5         ��Name$ txtnom��5      $
��Left=�6"   $��	18,24,0,0q�6=    �� TextWrapping$
 Wrap=�6P   $	��Top=�6e   $	��120��6}   �� 5   
   -   5        $��Valider��5      $
��Left=�6#   $��
159,23,0,0q�6>   $	��Top=�6R   6j   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgmedecins��5      $��18,61,456,32q�6(   �� 5   
   $
��Left=�6   $��
489,87,0,0q�6/   $
��Wrap=�6C   $	��id:��6W   $	��Top=�6b   $y�	Collapsed=�6z   �� 5   
   -   5        $ txtid��5      $
��Left=�6!   $��
507,85,0,0q�6<   $
 Wrap=�6P   $	��Top=�6e   $��59��6}   $y�	Collapsed=�6�   ��6�   �� *SelectedItem.id+ �� ElementName$ dtgmedecins��6�   �� 5   
   $
��Left=�6   $��458,115,0,0q�6/   $
��Wrap=�6D   $��adresse:��6X   $	��Top=�6h   �� 5   
   -   5        $ txtadr��5      $
��Left=�6"   $��505,114,0,0q�6=   $
 Wrap=�6R   $	��Top=�6g   $	��274��6   ��6�   �� *SelectedItem.adresse+$ dtgmedecins���� 5   
   $
��Left=�6   $��430,148,0,0q�6/   $
��Wrap=�6D   $��département:��6X   $	��Top=�6l   �� 5   
   -   5        $ txtdep��5      $
��Left=�6"   $��505,148,0,0q�6=   $
 Wrap=�6R   $	��Top=�6g   $	��274��6   ��6�   �� *SelectedItem.departement+$ dtgmedecins���� 5   
   -   5         ��Name$ 	erreurDep��5   9   $��Center=�6   $�� ��61   
���  ��6L   �� 5   
   $
��Left=�6   $��444,207,0,0q�6/   $
��Wrap=�6D   $��téléphone:��6X   $	��Top=�6j   �� 5   
   -   5        $ txttel��5      $
��Left=�6"   $��505,206,0,0q�6=   $
 Wrap=�6R   $	��Top=�6g   $	��274��6   ��6�   �� *SelectedItem.tel+$ dtgmedecins���� 5   
   $
��Left=�6   $��359,266,0,0q�6/   $
��Wrap=�6D   $#��spécialité complémentaire:��6X   $	��Top=�6z   �� 5   
   -	   5        $ txtspc��5      $
��Left=�6"   $��505,266,0,0q�6=   $
 Wrap=�6R   $	��Top=�6g   $	��274��6   ��6�   �� *'%SelectedItem.specialiteComplementaire+$ dtgmedecins���� 5   
   -
   5        $��Modifier��5      $
��Left=�6$   $��717,344,0,0q�6?   $	��Top=�6T   $��62��6�   5       5!      