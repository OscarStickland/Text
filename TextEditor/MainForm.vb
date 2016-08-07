Imports System
Imports System.IO
Imports System.Windows


Public Class Form1
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK AndAlso ofd.FileName <> "" Then


        End If
        Dim TextLine As String

        Dim FILE_NAME As String = ofd.FileName()

        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            Do While objReader.Peek() <> -1

                TextLine = TextLine & objReader.ReadLine() & vbNewLine

            Loop

            mainTextBox.Text = TextLine

        Else

            MessageBox.Show("File Does Not Exist")

        End If

    End Sub


    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        mainTextBox.Undo()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        mainTextBox.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        mainTextBox.Paste()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        MessageBox.Show("We have not finished the Redo Button")
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Dim ofd As New SaveFileDialog
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK AndAlso ofd.FileName <> "" Then


        End If
        Dim FILE_NAME As String = ofd.FileName()
        Dim NewFile As String = ofd.FileName()


        ''If System.IO.File.Exists(FILE_NAME) = True Then

        ''Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        ''objWriter.Write(mainTextBox.Text)
        ''objWriter.Close()
        ''MessageBox.Show("Text written to file")

        ''Else
        ''System.IO.File.Create(NewFile + ".txt")

        Try
            Dim objWriter As New System.IO.StreamWriter(NewFile)

            objWriter.Write(mainTextBox.Text)
            objWriter.Close()
            MessageBox.Show("Text written to file")
        Catch
            MessageBox.Show("Problem: ")
        End Try
        ''End If

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If mainTextBox.Text = "" Then
            mainTextBox.Clear()
        Else
            Me.SaveToolStripMenuItem.PerformClick()

        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub
End Class
