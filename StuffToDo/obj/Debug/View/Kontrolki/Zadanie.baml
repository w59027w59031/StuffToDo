   M S B A M L   `   `   `  ����D  @StuffToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:StuffToDo.ViewStuffToDo.View  5      &     StuffToDo.View.Kontrolki.Zadanie   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:StuffToDo.View     5      $��50��5      $	��700��6   .��5	      �� $	��1pxq�6
   
���   �._�5
      �   � RowDefinitions  5      �� 5      $
��50px �6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�6(   .+�5      �� -   5        $��Center=�5      $��Center=�5      $��Center=�5      $��Center=�5      $��50q�5      $��25,0,0,0q�5      $
��40px(�5      $
��50px��5       d� 	IsChecked 5      �� *TakNie+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5      �� *KolorCzcionki+$ TwoWay=�$ PropertyChanged=���5      �� *
KolorTla+$ TwoWay=�$ PropertyChanged=��� 5      .+�5      �� -   5         ��Name$ x_NazwaZadania��5      $
��15px(�5       $
��Left=�5!      $��Center=�5"      $
��30px��5#      ��5      �� *NazwaZadania+$ TwoWay=�$ PropertyChanged=���5$      �� *KolorCzcionki+$ TwoWay=�$ PropertyChanged=���5%      �� *
KolorTla+$ TwoWay=�$ PropertyChanged=��� 5&      $��2��6   $ 
Horizontal=�6   $��Right=�67   .+�5'      �� -   5         ��Name$ 	x_Data_od��5(      $��200px��6   ��5'      �� *	Data_od+ �� StringFormat$ 
dd/MM/yyyy��$ TwoWay=�$ PropertyChanged=���5)      �� *KolorCzcionki+$ TwoWay=�$ PropertyChanged=���5*      �� *
KolorTla+$ TwoWay=�$ PropertyChanged=��� 5+      -   5        $ 	x_Data_do��5,      $��200px��6   ��5+      �� *	Data_do+$ 
dd/MM/yyyy��$ TwoWay=�$ PropertyChanged=���5-      �� *KolorCzcionki+$ TwoWay=�$ PropertyChanged=���5.      �� *
KolorTla+$ TwoWay=�$ PropertyChanged=�5/      50      �� 51      -   5        $
 x_ID��51   d   $	��5px(�6U   ��6   �� *Id+$ TwoWay=�$ PropertyChanged=���52      �� *KolorCzcionki+$ TwoWay=�$ PropertyChanged=���53      �� *
KolorTla+$ TwoWay=�$ PropertyChanged=�54      55      56      57      