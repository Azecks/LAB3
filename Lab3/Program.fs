open System
open System.IO

// Задание 1. Seq.map - последние цифры чисел
let getLastDigits numbers =
    Seq.map (fun x -> 
        let xAsString = string x
        let lastCharacter = xAsString.[xAsString.Length - 1]
        // Проверяем, является ли последний символ цифрой
        int (string lastCharacter)) numbers

// Задание 2. Seq.fold - строка из списка символов
let charsToString characters =
    Seq.fold (fun acc ch -> acc + string ch) "" characters

// Задание 3. Функция для проверки наличия файлов в каталоге
let hasFilesInDirectory directoryPath =
    let files = Directory.EnumerateFiles(directoryPath)  // получаем последовательность файлов
    let isEmpty = Seq.isEmpty files                       // проверяем, пустая ли она
    not isEmpty                                            // инвертируем результат

// Функция для ввода последовательности вещественных чисел
let readFloatSeq () =
    printf "Задание 1. Введите вещественные числа через пробел: "
    let input = Console.ReadLine()
    let elements = input.Split(' ')
    
    seq {
        for s in elements do
            if s <> "" then
                yield float s
    }

// Функция для ввода последовательности символов
let readCharSeq () =
    printf "Задание 2. Введите символы через пробел: "
    let input = Console.ReadLine()
    let elements = input.Split(' ')
    
    seq {
        for s in elements do
            if s <> "" then
                yield s.[0]
    }

[<EntryPoint>]
let main argv =
   
    printfn "Ввод исходных данных"
    
    // Вызов функций для ввода последовательностей
    let numbers = readFloatSeq ()
    let charSeq = readCharSeq ()
    
    printfn "\nРезультаты"
    
    // Задание 1
    printfn "Задание 1: Последние цифры чисел"
    printfn "  Исходная последовательность чисел: %A" (Seq.toList numbers)
    let lastDigits = getLastDigits numbers
    printfn "  Последние цифры: %A" (Seq.toList lastDigits)
    printfn ""
    
    // Задание 2
    printfn "Задание 2: Строка из последовательности символов"
    printfn "  Исходная последовательность символов: %A" (Seq.toList charSeq)
    let resultString = charsToString charSeq
    printfn "  Полученная строка: %s" resultString

    printfn "Задание 3: Проверка наличия файлов в каталоге"
    
    // Ввод пути к каталогу
    printf "Введите путь к каталогу: "
    let directoryPath = Console.ReadLine()
    
    // Проверяем наличие файлов
    let hasFiles = hasFilesInDirectory directoryPath
    
    // Выводим результат
    if hasFiles then
        printfn "В каталоге '%s' есть файлы" directoryPath
    else
        printfn "В каталоге '%s' нет файлов" directoryPath
    
    0