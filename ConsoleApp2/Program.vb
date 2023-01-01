Module Program
    Sub Main(args As String())
        Console.Title = "VB.NET Algorithm Task 2"
        Dim taskList As New List(Of String)

        For i = 1 To 10
            taskList.Add(i & " - Task " & i)
        Next

        taskList.Add("0 - Exit")

        Dim continueTaskLoop As Boolean

        Do
            Console.Clear()
            writeToConsole(New String() {"VB.NET Algorithm Task 2"})
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

    Function generateNumberList(listType As String, listCount As Integer, Optional randomLimit As Integer = 50, Optional startWithZero As Boolean = False)
        Dim element As New List(Of Integer)

        If startWithZero Then
            element.Add(0)
        Else
            listCount += 1
        End If

        Dim i As Integer = 1

        Select Case listType.ToLower
            Case "linear"
                While i < listCount
                    element.Add(i)
                    i += 1
                End While

            Case "random"
                While i < listCount
                    Dim randomNumber As Integer = Rnd() * randomLimit + 1
                    element.Add(randomNumber)

                    i += 1
                End While
        End Select

        Return element
    End Function

    Sub task1()
        Dim element As New List(Of Integer)
        element = generateNumberList("random", 10)

        writeToConsole(New String() {"List: " & String.Join(", ", element), "Largest value in List: " & task1_func(element)})
    End Sub

    Function task1_func(element As List(Of Integer)) As Integer
        Return element.Max
    End Function

    Sub task2()
        Dim element As New List(Of Integer)
        element = generateNumberList("linear", 10)

        writeToConsole(New String() {"List: " & String.Join(", ", element)})

        task2_func(element)

        writeToConsole(New String() {"Reversed List: " & String.Join(", ", element)})
    End Sub

    Sub task2_func(ByRef element As List(Of Integer))
        element.Reverse()
    End Sub

    Sub task3()
        Dim element As New List(Of Integer)
        Dim randomNumber As Integer = Rnd() * 15 + 1
        element = generateNumberList("linear", 10)

        writeToConsole(New String() {"List: " & String.Join(", ", element), "Random Number: " & randomNumber, IIf(task3_func(element, randomNumber), "Number occurred in List", "Number did not occur in List")})
    End Sub

    Function task3_func(element As List(Of Integer), randomNumber As Integer) As Boolean
        Dim numberOccurred As Boolean = False
        numberOccurred = element.Contains(randomNumber)

        Return numberOccurred
    End Function

    Sub task4()
        Dim element As New List(Of Integer)
        element = generateNumberList("random", 10)

        writeToConsole(New String() {"List: " & String.Join(", ", element), "Element in Odd Positions: " & String.Join(", ", task4_func(element))})
    End Sub

    Function task4_func(element As List(Of Integer)) As List(Of Integer)
        Dim oddElement As New List(Of Integer)

        For i As Integer = 0 To element.Count - 1
            If Not i Mod 2 = 0 Then
                oddElement.Add(element(i))
            End If
        Next

        Return oddElement
    End Function

    Sub task5()
        Dim element As New List(Of Integer)
        element = generateNumberList("random", 10)

        writeToConsole(New String() {"List: " & String.Join(", ", element), "Sum: " & String.Join(", ", task5_func(element))})
    End Sub
    Function task5_func(element As List(Of Integer)) As Integer
        Dim sum As New Integer
        sum = element.Sum()

        Return sum
    End Function

    Sub task6()
        Dim stringList As New List(Of String)({"Visual Basic", "Racecar", "Task", "Civic", "People", "Noon", "Algorithm", "Pop", "List", "Rotator", "Level"})
        Dim randomNumber As Integer = Rnd() * (stringList.Count - 1)

        writeToConsole(New String() {"String: " & stringList(randomNumber), IIf(task6_func(stringList, randomNumber), "String is Palindrome", "String is not Palindrome")})
    End Sub

    Function task6_func(stringList As List(Of String), randomNumber As Integer) As Boolean
        Dim isPalindrome As Boolean = False

        If stringList(randomNumber).ToLower = StrReverse(stringList(randomNumber).ToLower) Then
            isPalindrome = True
        End If

        Return isPalindrome
    End Function

    Sub task7()
        Dim element As New List(Of Integer)
        element = generateNumberList("random", 10)

        writeToConsole(New String() {"List: " & String.Join(", ", element), "Sum using for-loop: " & task7_ForLoop(element), "Sum using while-loop: " & task7_WhileLoop(element), "Sum using recursion: " & task7_Recursion(element, 0)})
    End Sub

    Function task7_ForLoop(element As List(Of Integer)) As Integer
        Dim sumFor As New Integer

        For Each num As Integer In element
            sumFor += num
        Next

        Return sumFor
    End Function

    Function task7_WhileLoop(element As List(Of Integer)) As Integer
        Dim sumWhile As New Integer

        Dim hasNext As Boolean = True
        Dim i As Integer = 0

        While hasNext
            sumWhile += element(i)
            i += 1

            If element.Count = i Then
                hasNext = False
            End If
        End While

        Return sumWhile
    End Function

    Function task7_Recursion(element As List(Of Integer), index As Integer) As Integer
        If index = element.Count - 1 Then
            Return element(index)
        Else
            Return element(index) + task7_Recursion(element, index + 1)
        End If
    End Function

    Sub task8()
        Dim perfectSquares As New List(Of Integer)

        Dim square As Func(Of Integer, Integer) = Function(x) x * x
        perfectSquares = on_all(square)

        writeToConsole(New String() {"Perfect Squares: " & String.Join(", ", perfectSquares)})
    End Sub

    Function on_all(func As Func(Of Integer, Integer)) As List(Of Integer)
        Dim resultList As New List(Of Integer)

        For i As Integer = 1 To 20
            resultList.Add(func(i))
        Next

        Return resultList
    End Function

    Sub task9()
        Dim element As New List(Of Integer)
        Dim element2 As New List(Of String)
        Dim resultList As New List(Of String)

        element = generateNumberList("linear", 5)
        element2 = New List(Of String)({"A", "B", "C", "D", "E"})
        resultList = task9_func(element.ToArray(), element2.ToArray())

        writeToConsole(New String() {"List1: " & String.Join(", ", element), "List2: " & String.Join(", ", element2), "Combined List: " & String.Join(", ", resultList)})
    End Sub

    Function task9_func(list1 As Array, list2 As Array)
        Dim resultList As New List(Of String)

        For Each item In list1
            resultList.Add(item.ToString())
        Next

        For Each item In list2
            resultList.Add(item.ToString())
        Next

        Return resultList
    End Function

    Sub task10()
        Dim element As New List(Of Integer)
        Dim element2 As New List(Of String)
        Dim resultList As New List(Of String)

        element = generateNumberList("linear", 5)
        element2 = New List(Of String)({"A", "B", "C", "D", "E"})
        resultList = task10_func(element.ToArray(), element2.ToArray())

        writeToConsole(New String() {"List1: " & String.Join(", ", element), "List2: " & String.Join(", ", element2), "Combined List: " & String.Join(", ", resultList)})
    End Sub

    Function task10_func(list1 As Array, list2 As Array)
        Dim resultList As New List(Of String)

        Dim i As Integer = list1.Length - 1
        Dim j As Integer = list2.Length - 1
        Dim loopLimit = IIf(i >= j, i, j)
        Dim loopIterator As Integer = 0

        While loopIterator <= loopLimit
            If loopIterator <= i Then
                resultList.Add(list1(loopIterator).ToString())
            End If

            If loopIterator <= j Then
                resultList.Add(list2(loopIterator).ToString())
            End If

            loopIterator += 1
        End While

        Return resultList
    End Function

End Module
