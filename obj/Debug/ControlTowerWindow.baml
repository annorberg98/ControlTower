   M S B A M L   `   `   `  ����G  CControlTower, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment5Assignment5  5   	       ControlTower.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment5     5   	     � Title$  Control Tower��5   	   $	��350��6   $	��525��6,   .��5	      � .+�5
   
   �� -   5        $"��Send next airplane to runway��5
      $
��Left=�68   $��276,266,0,0q�6S   $	��Top=�6h   $	��184��6�   $��25��6�   6�   �� 5   
   $��Next Flight��6   $
��Left=�6&   $��
25,263,0,0q�6A   $	��Top=�6U   �� 5   
   -   5         ��Name$ tbFlightNumber��5      $
��Left=�6*   $��23��6E   $��114,266,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $��TextBox��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 	lvFlights��5      $
��Left=�6&   $	��248��6A   $��	10,10,0,0q�6N   $	��Top=�6a   $	��477��6y    �� View 5      �� 5       �� AllowsColumnReorder .  .P�5      �� $��	Flight Nr��6%    �� DisplayMemberBinding 68   �� *
FlightCode+�� 5      $��Status��6%    65   �� *Status+�� 5      $
��Time��6%    63   �� *Time+�� 5      $��Airline��6%    66   �� *	AirLine+5      5      5      5      