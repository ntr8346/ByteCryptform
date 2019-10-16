Imports System.IO
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    ReadOnly Settings As ParallelOptions = New ParallelOptions With {.MaxDegreeOfParallelism = Environment.ProcessorCount}
    Dim array() As String
    Dim chosen As Boolean = False
    Public Function ByteToBin(ByVal conv() As Byte) As String
        Dim newBin As New System.Text.StringBuilder
        For Each c In conv
            newBin.Append(Convert.ToString(c, 2).PadLeft(8, "0"))
        Next
        Return newBin.ToString
    End Function
    Public Function CreateBinarySeed(ByRef Location As String)
        Dim data() As Byte = ReadBytes(Location)
        Dim binary As String = ByteToBin(data)
        Dim length As Integer = Math.Round(binary.Length / 64)
        ReDim array(length)
        Parallel.For(0, CInt(Math.Round((binary.Length - 1) / 64)), Settings, Sub(i) Loops(i, binary))
        Return (String.Join("", array))
    End Function
    Sub WriteBytes(ByRef binary As String, location As String)

        File.WriteAllBytes(location, BintoBytes(binary))
    End Sub
    Function ReadBytes(ByRef Location As String)
        Dim data() As Byte = File.ReadAllBytes(Location)
        Return data
    End Function
    Sub Loops(ByRef i As Integer, ByRef binary As String)
        'if there isnt 64 chars left, it jumps to the else:
        If (i * 64 + 64) <= binary.Length Then
            array(i) = "~" & CStr(Convert.ToInt64((binary.Substring(i * 64, 64)), 2))
            'Else statement appends the ammount of binary digits read at the end to give the final answer only happens if last set is less than 64.
        Else
            'B signifies when the value states how many bits are read at the end.
            array(i) = "~" & CStr(Convert.ToInt64((binary.Substring(i * 64, binary.Length - i * 64)), 2)) & "B" & binary.Length - i * 64
        End If
        'Console.WriteLine(i)

    End Sub
    Function SeedToBinary(Seed As String)
        Dim last As Boolean = False
        Seed = Seed.Substring(1, Seed.Length - 1)
        Dim arrays() As String = Seed.Split("~")
        'create array of values
        If arrays(arrays.Length - 1).Contains("B") Then
            Dim lastbit As String() = arrays(arrays.Length - 1).Split("B")
            Dim temp(1) As Int64
            temp(0) = Convert.ToInt64(lastbit(0))
            temp(1) = CInt(lastbit(1))
            arrays(arrays.Length - 1) = Convert.ToString(temp(0), 2).PadLeft(temp(1), "0"c)
            last = True
        End If
        If last = True Then
            If arrays.Length - 2 = 0 Then
                IntToBinary(arrays, 0)
            Else
                Parallel.For(0, arrays.Length - 1, Settings, Sub(i) IntToBinary(arrays, i))
            End If
        Else
            Parallel.For(0, arrays.Length, Settings, Sub(i) IntToBinary(arrays, i))
        End If
        Return String.Join("", arrays)
    End Function
    Sub IntToBinary(ByRef arrayi As String(), i As Integer)
        Dim temp As Long = Convert.ToInt64(arrayi(i))
        arrayi(i) = Convert.ToString(temp, 2).PadLeft(64, "0"c)

    End Sub
    Function AugmentSeedUnLock(seed As String, password As String)
        Dim temp(1) As String
        temp(1) = ""
        seed = seed.Substring(1, seed.Length - 1)
        Dim arraya() As String = seed.Split("~")
        If arraya(arraya.Length - 1).Contains("B") Then
            temp = arraya(arraya.Length - 1).Split("B")
            arraya(arraya.Length - 1) = temp(0)
            temp(1) = "B" & temp(1)
        End If
        Dim Pint As Integer = StrToInt(password)
        Parallel.For(0, arraya.Length - 1, Settings, Sub(i) Unlock(i, arraya, Pint))
        Return ("~" & String.Join("~", arraya) & temp(1))
    End Function
    Function AugmentSeedLock(seed As String, password As String)
        Dim temp(1) As String
        temp(1) = ""
        seed = seed.Substring(1, seed.Length - 1)
        Dim arraya() As String = seed.Split("~")
        If arraya(arraya.Length - 1).Contains("B") Then
            temp = arraya(arraya.Length - 1).Split("B")
            arraya(arraya.Length - 1) = temp(0)
            temp(1) = "B" & temp(1)
        End If
        Dim Pint As Integer = StrToInt(password)
        Parallel.For(0, arraya.Length, Settings, Sub(i) Lock(i, arraya, Pint))
        Return ("~" & String.Join("~", arraya) & temp(1))
    End Function
    Sub Lock(i As Integer, ByRef arraya As String(), pint As Integer)
        arraya(i) = (Convert.ToInt64(arraya(i)) + pint)
    End Sub
    Sub Unlock(i As Integer, ByRef arraya As String(), pint As Integer)
        arraya(i) = Convert.ToInt64(arraya(i) - pint)
    End Sub
    Function StrToInt(str As String) As Integer
        Dim Pint As Integer
        For i = 0 To str.Length - 1
            Pint += Asc(str.Substring(i, 1))
        Next
        Return Pint
    End Function
    Private temp As Byte()
    Function BintoBytes(binary As String)
        ReDim temp((binary.Length - 1) / 8)
        Parallel.For(0, CInt(Math.Round((binary.Length - 1) / 8)), Settings, Sub(i) BtB(i, binary.Substring(i * 8, 8)))
        Return temp
    End Function
    Sub BtB(i As Integer, binary As String)
        temp(i) = Convert.ToByte(binary, 2)
    End Sub
    Private Sub CFButton_Click(sender As Object, e As EventArgs) Handles CFButton.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = "Please select a file"
        ofd.InitialDirectory = "C:\"
        ofd.ShowDialog()
        FPBox.Text = ofd.FileName
        chosen = True
    End Sub
    Private Sub LButton_Click(sender As Object, e As EventArgs) Handles LButton.Click
        Dim FilePath As String = FPBox.Text
        Dim Password As String = PBox.Text
        If FilePath = "" Then
            MsgBox("Please choose a file.")
        Else
            If Password = "" Then
                MsgBox("Please enter a password")
            Else
                WriteBytes(SeedToBinary(AugmentSeedLock(CreateBinarySeed(FilePath), Password)), FilePath)
                MsgBox("File Encrypted and Written.")
            End If
        End If
    End Sub
    Private Sub UButton_Click(sender As Object, e As EventArgs) Handles UButton.Click
        Dim FilePath As String = FPBox.Text
        Dim Password As String = PBox.Text
        If FilePath = "" Then
            MsgBox("Please choose a file.")
        Else
            If Password = "" Then
                MsgBox("Please enter a password")
            Else
                WriteBytes(SeedToBinary(AugmentSeedUnLock(CreateBinarySeed(FilePath), Password)), FilePath)
                MsgBox("File Decrypted and Written.")
            End If
        End If
    End Sub
End Class
