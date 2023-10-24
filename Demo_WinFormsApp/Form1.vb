Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init_ListView()
        Init_ListBox()
    End Sub



    Private Sub Init_ListView()
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("Columns 1", 135)
        ListView1.Columns.Add("Columns 2", 135)
        ListView1.Columns.Add("Columns 3", 135)

    End Sub


    Private Sub Init_ListBox()

        ListBox1.Items.Add("Item A")
        ListBox1.Items.Add("Item B")
        ListBox1.Items.Add("Item C")

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim selectedItemText As String = ListBox1.SelectedItem.ToString()
        ListView1.Items.Clear()

        If selectedItemText = "Item A" Then

            For i = 1 To 4
                ListView1.Items.Add("A-" & i & "-1")
                For j = 2 To 3
                    ListView1.Items(i - 1).SubItems.Add("A-" & i & "-" & j)
                Next
            Next

        ElseIf selectedItemText = "Item B" Then
            For i = 1 To 3
                ListView1.Items.Add("B-" & i & "-1")
                For j = 2 To 3
                    ListView1.Items(i - 1).SubItems.Add("B-" & i & "-" & j)
                Next
            Next

        ElseIf selectedItemText = "Item C" Then
            For i = 1 To 6
                ListView1.Items.Add("C-" & i & "-1")
                For j = 2 To 3
                    ListView1.Items(i - 1).SubItems.Add("C-" & i & "-" & j)
                Next
            Next
        End If


    End Sub

    Private Async Sub Run_Button_Click(sender As Object, e As EventArgs) Handles Run_Button.Click

        Dim Selected_idx = 0
        Dim Max_Listview_item = 0

        While True

            For i = 0 To ListBox1.Items.Count - 1
                ListBox1.SelectedIndex = i
                Await Delay_msec(500)

                ListView1.Focus()

                If ListView1.Items.Count > Max_Listview_item Then
                    Max_Listview_item = ListView1.Items.Count
                End If

                If ListView1.Items.Count > Selected_idx Then
                    ListView1.Items(Selected_idx).Selected = True

                    Your_sub() ' 改成你要的事件
                End If

                Await Delay_msec(500)

            Next

            Selected_idx += 1

            If Selected_idx = Max_Listview_item Then
                Exit While
            End If

        End While

        MsgBox("Done")

    End Sub



    Private Sub Your_sub()
        ' add your code here
        Debug.WriteLine(ListView1.SelectedItems.Item(0).ToString())
    End Sub



    Public Shared Async Function Delay_msec(msec As Integer) As Task
        Await Task.Delay(msec)
    End Function
End Class
