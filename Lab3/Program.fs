open System
open System.IO


let getLastDigits numbers =
    Seq.map (fun x -> 
        let xAsString = string x
        let lastCharacter = xAsString.[xAsString.Length - 1]
        int (string lastCharacter)) numbers

let charsToString characters =
    Seq.fold (fun acc ch -> acc + string ch) "" characters
    
let hasFilesInDirectory directoryPath =
    let files = Directory.EnumerateFiles(directoryPath)  
    let isEmpty = Seq.isEmpty files                     
    not isEmpty                                         


let readFloatSeq () =
    printf "Задание 1. Введите вещественные числа через пробел: "
    let input = Console.ReadLine()
    let elements = input.Split(' ')
    
    seq {
        for s in elements do
            if s <> "" then
                yield float s
    }


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
    

    let numbers = readFloatSeq ()
    let charSeq = readCharSeq ()
    
    printfn "\nРезультаты"
    
    
    printfn "Задание 1: Последние цифры чисел"
    printfn "  Исходная последовательность чисел: %A" (Seq.toList numbers)
    let lastDigits = getLastDigits numbers
    printfn "  Последние цифры: %A" (Seq.toList lastDigits)
    printfn ""

    printfn "Задание 2: Строка из последовательности символов"
    printfn "  Исходная последовательность символов: %A" (Seq.toList charSeq)
    let resultString = charsToString charSeq
    printfn "  Полученная строка: %s" resultString

    printfn "Задание 3: Проверка наличия файлов в каталоге"
    

    printf "Введите путь к каталогу: "
    let directoryPath = Console.ReadLine()
    

    let hasFiles = hasFilesInDirectory directoryPath

    if hasFiles then
        printfn "В каталоге '%s' есть файлы" directoryPath
    else
        printfn "В каталоге '%s' нет файлов" directoryPath
    
    0
