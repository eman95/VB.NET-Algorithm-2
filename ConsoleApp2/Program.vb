Module Program
    Sub Main(args As String())
        Dim taskList As New List(Of String)

        For i = 1 To 10
            taskList.Add(i & " - Task " & i)
        Next

        taskList.Add("0 - Exit")

        Dim continueTaskLoop As Boolean

        Do
            Console.Clear()

            writeToConsole(taskList.ToArray())

            Dim taskNumber As Integer
            Dim tmpInput As String
            Dim valid As Boolean

            Do
                writeToConsole(New String() {"Please enter Task Number:"})
                tmpInput = Console.ReadLine()

                If Int32.TryParse(tmpInput, taskNumber) = True Then
                    If taskNumber >= 0 And taskNumber <= taskList.Count Then
                        valid = True
                    Else
                        valid = False
                    End If
                Else
                    valid = False
                End If
            Loop While Not valid

            Select Case taskNumber
                Case 0
                    exitModule()

                Case 1
                    task1()

                Case 2
                    task2()

                Case 3
                    task3()

                Case 4
                    task4()

                Case 5
                    task5()

                Case 6
                    task6()

                Case 7
                    task7()

                Case 8
                    task8()

                Case 9
                    task9()

                Case 10
                    task10()

            End Select

            writeToConsole(New String() {"Do you want to continue?", "Type 'yes' to continue"})
            If Console.ReadLine() = "yes" Then
                continueTaskLoop = True
            Else
                continueTaskLoop = False
            End If

        Loop While continueTaskLoop
    End Sub

    Sub writeToConsole(ByVal texts() As String)
        Console.Write(vbCrLf)

        For Each textItem In texts
            Console.WriteLine(textItem)
        Next
    End Sub

    Sub exitModule()
        writeToConsole(New String() {"Are you sure you want to exit?", "Type 'exit' to continue"})
        If Console.ReadLine() = "exit" Then
            Environment.Exit(0)
        End If
    End Sub

    Sub task1()
        writeToConsole(New String() {"Hello world"})
    End Sub

    Sub task2()
        writeToConsole(New String() {"Please enter your name:"})
        writeToConsole(New String() {"Hello world, " & Console.ReadLine()})
    End Sub

    Sub task3()
        writeToConsole(New String() {"Please enter your name:"})
        Dim name = Console.ReadLine()

        If name.ToLower = "alice" Or name.ToLower = "bob" Then
            writeToConsole(New String() {"Hello world, " & name})
        Else
            task1()
        End If
    End Sub

    Sub task4()
        Dim isValid As Boolean
        Dim n As Integer
        Dim sum As Integer = 0

        Do
            writeToConsole(New String() {"Please input a number more than 1:"})
            Dim input = Console.ReadLine()

            If IsNumeric(input) Then
                If input > 1 Then
                    isValid = True
                    n = CInt(input)
                End If
            End If

        Loop While Not isValid

        For i = 1 To n
            sum += i
        Next

        writeToConsole(New String() {"The sum is", sum})
    End Sub

    Sub task5()
        Dim isValid As Boolean
        Dim n As Integer
        Dim sum As Integer = 0

        Do
            writeToConsole(New String() {"Please input a number more than 1:"})
            Dim input = Console.ReadLine()

            If IsNumeric(input) Then
                If input > 1 Then
                    isValid = True
                    n = CInt(input)
                End If
            End If

        Loop While Not isValid

        For i = 1 To n
            If i Mod 3 = 0 Or i Mod 5 = 0 Then
                sum += i
            End If
        Next

        writeToConsole(New String() {"The sum of numbers that are multiples of 3 and 5 is", sum})
    End Sub

    Sub task6()
        Dim isValid As Boolean
        Dim n As Integer


        Do
            writeToConsole(New String() {"Please input a number more than 1:"})
            Dim input = Console.ReadLine()

            If IsNumeric(input) Then
                If input > 1 Then
                    isValid = True
                    n = CInt(input)
                End If
            End If

        Loop While Not isValid

        Dim calcTask As Integer
        isValid = False

        Do
            writeToConsole(New String() {"Please input calculation method:", "1 - Sum", "2 - Product"})
            Dim input = Console.ReadLine()

            If IsNumeric(input) Then
                If input = 1 Or input = 2 Then
                    isValid = True
                    calcTask = CInt(input)
                End If
            End If

        Loop While Not isValid

        Dim calcResult As Integer = 0

        If calcTask = 1 Then
            For i = 1 To n
                calcResult += i
            Next

            writeToConsole(New String() {"The sum of numbers from 1 to " & n & " is", calcResult})
        Else
            calcResult = 1
            For i = 1 To n
                calcResult *= i
            Next

            writeToConsole(New String() {"The product of numbers from 1 to " & n & " is", calcResult})
        End If
    End Sub

    Sub task7()
        Dim isValid As Boolean
        Dim n As Integer
        Dim calcResultList As New List(Of String)

        Do
            writeToConsole(New String() {"Please input a number:"})
            Dim input = Console.ReadLine()

            If IsNumeric(input) Then
                isValid = True
                n = CInt(input)
            End If

        Loop While Not isValid

        For i = 1 To 12
            calcResultList.Add(i & " x " & n & " = " & i * n)
        Next

        writeToConsole(calcResultList.ToArray())
    End Sub

    Sub task8()
        Dim primeNumberList As New List(Of String)

        For i = 0 To 10000
            Dim checkPrime As Integer = 1
            For j = 2 To i - 1
                If i Mod j = 0 Then
                    checkPrime = 0
                    Exit For
                Else
                    checkPrime = 1
                End If
            Next
            If checkPrime = 1 And Not i < 2 Then
                primeNumberList.Add(i)
            End If
        Next

        writeToConsole(New String() {"The prime numbers from 0 to 1000 are ", Join(primeNumberList.ToArray(), ", ")})
    End Sub

    Sub task9()
        Dim Generator As Random = New Random()
        Dim randomNumber = Generator.Next(1, 100 + 1)
        Dim isCorrect As Boolean = False
        Dim numberTried As New List(Of String)

        Do
            writeToConsole(New String() {"Please enter your guess between 1 - 100"})
            Dim guessInput = Console.ReadLine()

            If IsNumeric(guessInput) Then
                If guessInput = randomNumber Then
                    writeToConsole(New String() {"Your guess is correct!"})
                    isCorrect = True
                Else
                    If Not numberTried.Contains(guessInput) Then
                        numberTried.Add(guessInput)
                    End If

                    If guessInput > randomNumber Then
                        writeToConsole(New String() {"Your guess is higher than the value"})
                    ElseIf guessInput < randomNumber Then
                        writeToConsole(New String() {"Your guess is lower than the value"})
                    End If
                End If
            End If

        Loop While Not isCorrect

        writeToConsole(New String() {"Number of tries needed:", numberTried.Count})
    End Sub

    Sub task10()
        Dim year = Today.Year
        Dim leapYear As New List(Of String)

        Do
            year += 1

            If Date.IsLeapYear(year) Then
                leapYear.Add(year)
            End If

        Loop While leapYear.Count < 20

        writeToConsole(New String() {"The next 20 leap years are", Join(leapYear.ToArray(), ", ")})

    End Sub

End Module
