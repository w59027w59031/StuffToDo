   M S B A M L   `   `   `  ����D  @StuffToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:StuffToDo.ViewStuffToDo.View  5      9!clr-namespace:StuffToDo.ViewModelStuffToDo.ViewModel  5      %    StuffToDo.View.DodajZadanieView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:StuffToDo.View     5      7	viewModel!clr-namespace:StuffToDo.ViewModel     5      $	��450��5	      $	��800��6   .��5      � ��6   �� *
KolorTla+  �� Mode$  TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� � RowDefinitions 5      �� 5      $��* �6   �� 5      $��3* �6   �� 5      $
��45px �6   .+�5      �� $��Nowe Zadanie��6
   $
��20px(�5      $��Center=�5      $��Center=�5      ��5      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���5      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=��� 5      $
��15px(�5      $��1��5      ��5      �� *NazwaZadania+$  TwoWay=�$ PropertyChanged=���5      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���5      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=��� 5       �� Orientation$ 
Horizontal=�6   $��2��6(   .+�5      �� $��Data od��6   ��5      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���5      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  5       $
��15px(�5!      $
��30px��5"         SelectedDate 5       �� *	Data_od+$  TwoWay=�$ PropertyChanged=� =� ErrorTemplate 5#      Z� ��5$      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���5%      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=��� 5&      $��Data do��6   ��5'      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���5(      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=�  5)      $
��15px(�5*      $
��30px��5+       5)      �� *	Data_do+$  TwoWay=�$ PropertyChanged=� 5,      Z� ��5-      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���5.      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=�5/      �� 51      $ 
Horizontal=�6   $��3��6(   $��Right=�65   .+�52      �� $��Dodaj zadanie��6   $
��30px��6E   $��5q�6S   ��6$   �� *DodajZadanie+��53      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���54      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=��� 55      $��Wstecz��6   $
��30px��68   $��5q�6F   ��6   �� *Wstecz+��56      �� *KolorCzcionki+$  TwoWay=�$ PropertyChanged=���57      �� *
KolorTla+$  TwoWay=�$ PropertyChanged=�58      59      5:      