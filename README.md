# Лабораторная работа №1

## Вариант 9,22

<b>Выполнил: Бондаренко Данила Александрович Р34112 \
<b>Преподаватель: Пенской Александр Владимирович

## Цель работы:
<b>Освоить базовые приемы и абстракции функционального программирования: функции, поток управления и поток данных, сопоставление с образцом, рекурсия, свертка, отображение, работа с функциями как с данными, списки.

## Задача 9:
### Условие:
<b>Найти пифагорейский триплет 1000 и произведение abc
### Описание решения:
Первая функция pythagorean_tripletsиспользует формулу Евклида для перечисления всех возможных питагоровых троек до заданного порога. Формулу можно резюмировать следующим образом:
а =m^2−n^2, б = 2 m*n , с =m^2+n^2. multiply_listэто просто удобная функция для умножения всех элементов списка вместе. find_triplet_with_sumвыполняет тяжелую работу по созданию фактических троек, выбирая первую, где сумма равна заданному значению.
```F#
     let pythagorean_triplets top =
    [ for m in 1..top do
          for n in 1 .. m - 1 do
              let a = m * m - n * n
              let b = 2 * m * n
              let c = m * m + n * n
              yield [ a; b; c ] ]

let multiply_list list =
    List.fold (fun acc elem -> acc * elem) 1 list

let find_triplet_with_sum sum =
    pythagorean_triplets sum
    |> List.find (fun [ a; b; c ] -> a + b + c = sum)
    |> multiply_list
```
### Ответ: 31875000
<b>Реализация с помощью рекурсии:
  ```F#
  let rec_find (sum: int) =
        let rec find_a (a: int, sum: int) =
                let rec find_b (b: int, sum: int) =
                        let c: int = sum - a - b
                        if (float(a) ** 2.0 + float(b) ** 2.0) = float(c) ** 2.0 then (a*b*c)
                        else
                                if (b<0) then 0
                                else find_b(b-1, sum)
                let result_b = find_b(sum-a, sum)
                if (result_b > 0) then (result_b)
                else
                        if (a<0) then 0
                        else find_a(a-1, sum)
        (find_a(sum-1, sum))
  ```
### Ответ: 31875000

### Реализация на Python:

```python
    def find_product(sum):
    for a in range(1, sum):
      for b in range(1, sum - a):
          c = sum - a - b
          if a ** 2 + b ** 2 == c ** 2:
              print(a, b, c)
              print(a * b * c)
              return a * b * c
    print('has no result')
```
### Ответ: 31875000

## Задача 22:
### Условие:
<b>НВ файле есть список имен, его надо отсортировать и посчитать name score, name score вычисляется позиция*вес символов, вес символов это положение каждой буквы в алфавите, а потом их сумма, выходит вес всего слова, нам нужно найти name score сумму для всех.
### Описание решения:
<b>Для начала надо было считать из файла все имена и преобразовать их в массив дабы удобнее было работать с ними, для этого сначала я считал из файла все имена в виде строки и далее с помощью разделителя я их преобразовал в массив string
```F#
  let readArray =
        let text = IO.File.ReadAllText "/Users/aleksandr/Downloads/names.txt"
        let words = text.Split(',')
        (words)
```
<b>Далее я составил функцию для возвращения веса символа
```F#
  let private getAsciiValue (chr: char) =
        if chr = 'A' then 1
        elif chr = 'B' then 2
        elif chr = 'C' then 3
        elif chr = 'D' then 4
        elif chr = 'E' then 5
        elif chr = 'F' then 6
        elif chr = 'G' then 7
        elif chr = 'H' then 8
        elif chr = 'I' then 9
        elif chr = 'J' then 10
        elif chr = 'K' then 11
        elif chr = 'L' then 12
        elif chr = 'M' then 13
        elif chr = 'N' then 14
        elif chr = 'O' then 15
        elif chr = 'P' then 16
        elif chr = 'Q' then 17
        elif chr = 'R' then 18
        elif chr = 'S' then 19
        elif chr = 'T' then 20
        elif chr = 'U' then 21
        elif chr = 'V' then 22
        elif chr = 'W' then 23
        elif chr = 'X' then 24
        elif chr = 'Y' then 25
        elif chr = 'Z' then 26
        else 0
```
<b>Потом я воспользовался встроенной сортировкой дабы массив был в алфавитном порядке и объявил общий каунтер для суммы всех name scores
```F#
  let public counterNames =
        let mutable allCounter = 0
        let rArray = readArray
        let sortArr = Array.sort rArray
```
<b>Теперь для подсчета name score, я пошел по массиву внутри цикла я объявил каунтер для выбранного имени, использовал UPPERCASE, чтобы не было казусов с типом букв и далее разбил имя на chars и каждый char закидывал в функцию выше, потом суммировал все возвращенные значения и далее этот результат умножал на позицию имени, которую можно узнать просто по аргументу цикла i, впоследствии суммировал с allCounter наш name score
```F#
  for i = 0 to sortArr.Length-1 do
            let mutable charValueCounter = 0
            let chooseStr = sortArr.[i].ToUpper()
            chooseStr |> Seq.iter (fun x-> charValueCounter <- charValueCounter + getAsciiValue(x))
            charValueCounter <- charValueCounter*i
            allCounter <- charValueCounter + allCounter
        printfn "%i" allCounter
```
### Ответ: 870873746
<b>Реализация с помощью рекурсии:
  ```F#
  let public recursionCounter =
    let arr = readArray

    let stringReader (str: String, n: int) =
        let rec score i =
            if (i < 0) then
                0
            else
                getAsciiValue (str[i]) + score (i - 1)

        score (n)

    let rec valueRec len =
        if (len < 0) then
            0
        else
            len * stringReader (arr[ len ].ToUpper(), arr[len].Length - 1)
            + valueRec (len - 1)

    valueRec (arr.Length - 1)
  ```
### Ответ: 870873746
<b>Реализация с помощью хвостовой рекурсии:
```F#
let public tailRecursionCounter =
    let arr = readArray

    let rec scoreTail (idx: int, sum: int) =
        if (idx < 0) then
            sum
        else
            scoreTail (idx - 1, sum + scoreGoal (idx, arr[idx]))

    scoreTail (arr.Length - 1, 0)
```
<b>Реализация с помощью map:
  ```F#
  let scoreGoal(index: int, str: String) =
        let usesStr = str |> String.map Char.ToUpper |> Seq.map(fun x -> getAsciiValue(x)) |> Seq.sum
        (usesStr*index)
  let map_counter =
        let arr = readArray
        let summary = Seq.init arr.Length (fun x -> scoreGoal(x, arr[x])) |> Seq.sum
        (summary)
  ```
### Ответ: 870873746
### Реализация на Python:
```python
  def scoreNames(name, pos):
    return countLetters(name) * pos


def countLetters(name):
    score = 0
    for letter in name:
        if letter == "A": score += 1
        elif letter == "B": score += 2
        elif letter == "C": score += 3
        elif letter == "D": score += 4
        elif letter == "E": score += 5
        elif letter == "F": score += 6
        elif letter == "G": score += 7
        elif letter == "H": score += 8
        elif letter == "I": score += 9
        elif letter == "J": score += 10
        elif letter == "K": score += 11
        elif letter == "L": score += 12
        elif letter == "M": score += 13
        elif letter == "N": score += 14
        elif letter == "O": score += 15
        elif letter == "P": score += 16
        elif letter == "Q": score += 17
        elif letter == "R": score += 18
        elif letter == "S": score += 19
        elif letter == "T": score += 20
        elif letter == "U": score += 21
        elif letter == "V": score += 22
        elif letter == "W": score += 23
        elif letter == "X": score += 24
        elif letter == "Y": score += 25
        elif letter == "Z": score += 26
        else: score += 0
    return score


if __name__ == '__main__':
    f = open('names.txt')
    string = f.readlines()
    f.close()

    names = sorted(string[0].split(','))
    tscore = 0

    for i in range(0, len(names)):
        tscore += scoreNames(names[i], i)
    print(tscore)

```
### Ответ:
<b>870873746
## Вывод:
<b>В ходе написания лабораторной работы мне очень понравилось взаимодействовать с F#. До этого я касался функционального программирования вскользь используя замыкания на swift и для меня это можно сказать было новым опытом. Хоть и были небольшие казусы по типу int нельзя возводить в степень, мне было интересно программировать на F#, планирую и дальше углубиться в него, так как это что-то новое для меня и мне интересно.
