## Задачи
1. Для объектов [класса Customer](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.07-08/CustomerLib/Customer.cs), у которого есть строковые свойства Name, ContactPhone и свойство Revenue типа decimal реализовать возможность строкового представления различного вида. Например, для объекта со значениями Name = "Jeffrey Richter", Revenue = 1000000, ContactPhone = "+1 (425) 555-0100", могут быть следующие варианты:
 - Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100
 - Customer record: +1 (425) 555-0100
 - Customer record: Jeffrey Richter, 1,000,000.00
 - Customer record: Jeffrey Richter
 - Customer record: 1000000 и т.д.
[Разработать модульные тесты.](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.07-08/CustomerLibTest/CustomerTests.cs)

2.Не изменяя класс Customer, добавить для объектов данного класса дополнительную [возможность форматирования](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.07-08/CustomerLibExtension/CustomerExtension.cs), не предусмотренную классом. [Разработать модульные тесты.](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.07-08/CustomerLibTest/CustomerTests.cs)