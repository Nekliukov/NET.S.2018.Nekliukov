## Задачи 
1. **(deadline - 26.07.2018, 24.00)** Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:
  - System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор); 
  - System.String (использовать сравнение по умолчанию и подключаемый компаратор); 
  - пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор); 
  
  - пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).
2. **(deadline - 27.07.2018, 24.00)** Предложить различные способы (2-3 способа) описания класса TrafficLight (Светофор) для системы управления различными светофорами, соответствующий принципам ООП.

- State pattern: [Realisation](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.16/TrafficLight/StatePattern/StatePatternSolution). [Testing](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.16/TrafficLight/StatePattern/StatePatternSolutionTest).
- Multicast delegate (Not really flexible solution, just to train this mechanism): [Realisation](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.16/TrafficLight/ChainDelegate/ChainDelegateSolution/TrafficLight.cs). [Testing](https://github.com/Nekliukov/NET.S.2018.Nekliukov/blob/master/NET.S.2018.Nekliukov.16/TrafficLight/ChainDelegate/ChainDelegateTest).