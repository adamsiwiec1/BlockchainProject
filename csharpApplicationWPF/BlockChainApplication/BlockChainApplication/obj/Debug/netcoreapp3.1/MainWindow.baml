   M S B A M L   `   `   `  ����P  LBlockChainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BlockChainApplicationBlockChainApplication  5   	   &     BlockChainApplication.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:BlockChainApplication     5   	     � Title$  Blockchain Project��5   	   $	��329��6$   $	��724��61   .��5	      � $��0,0,0,-6q�6   .+�5
   
   �� -   5         ��Name$ 	lbl_title��5
      $
��Bold"�6#   $[��UHello, thank you for choosing Adam coin. Please enter your transaction details below.��65   $
��Left=�6�   $��0,0,0,0q�6�   $	��Top=�6�   $��27��6�   $	��505��6�   �� 5   
   $��Sender:��6   $��100,95,560,200q�6"   �� 5   
   $��
Recipient:��6   $��100,145,560,145q�6%   �� 5   
   $��Amount:��6   $��200,187,460,105q�6"   �� 5   
   -   5         ��Name$ 	tb_sender��5      $�� ��6%    �� TextWrapping$
 Wrap=�6-   $��170,100,100,200q�6A   �� 5   
   -   5        $ tb_recipient��5      $�� ��6(   $
 Wrap=�60   $��170,150,100,150q�6D   �� 5   
   -   5        $ 	tb_amount��5      $�� ��6%   $
 Wrap=�6-   $��275,190,275,110q�6A   �� 5   
   -   5         ��Name$ btn_send��5      $
��Send��6#   $��320,240,320,50q�62   6J   �� 5   
   -   5        $ 
lbl_sucess��5      $0��*Transaction complete! Here is your recipt:��6$   $y�Hidden=�6Y   $��20,230,460,64q�6m   �� 5   
   -   5        $ 
lbl_recipt��5      $��(recipt)��6$   $y�Hidden=�67   $��20,260,460,34q�6K   5      5      