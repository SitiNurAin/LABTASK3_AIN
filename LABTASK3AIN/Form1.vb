

Public Class Form1
    'set the maximum capacity for the array
    Private maxCap As Integer = 10
    Private apps(maxCap - 1) As String
    Private appCount As Integer = 0

    Private Sub clearList()
        ListBoxApps.Items.Clear()
    End Sub
    Private Sub DisplayApps() 'private sub DisplayApps() untuk clearkan list box apps
        'display the current apps in a listApp 
        ListBoxApps.Items.Clear()

        For i As Integer = 0 To appCount - 1
            ListBoxApps.Items.Add(apps(i))
        Next
    End Sub
    Private Sub AddApp(appName As String) 'private sub AddApp() ni adalh untuk button add . Untuk add app yang telah di input 
        If appCount < maxCap Then
            apps(appCount) = appName
            appCount += 1
            MessageBox.Show($"{appName} has been added to the list.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Array is full !, cannot add more apps", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub UpdateApp(index As Integer, newName As String) 'Private sub UpdateApp() ni untuk button update dimana  akan select based on index
        'update the app at the specified index with the new name
        apps(index) = newName
        MessageBox.Show($"The app is successfully updated! New app name: {newName}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub DeleteApp(index As Integer) 'Private sub DeleteApp() ni untuk button delete 
        'remove the app at the specified index
        Dim removedAppName As String = apps(index)
        Dim confirmsg = MessageBox.Show($"Are you sure to deleted {removedAppName}?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirmsg = DialogResult.Yes Then
            'shift the remaining elements to fill the gap
            For i As Integer = index To appCount - 2
                apps(i) = apps(i + 1)
            Next

            'decrement the app count
            appCount -= 1
            MessageBox.Show($"{removedAppName} has been deleted from the list.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Private sub Form1_Load() will appear if we start the sytem , message box will appear before you can even doing CRUD
        MessageBox.Show("Please add the apps fisrt", "IMPORTANT MESSAGE !", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim appName As String = InputBox("Enter the name of the apps")

        If Not String.IsNullOrEmpty(appName) Then
            AddApp(appName)

            DisplayApps()
            clearList()
        Else
            MessageBox.Show("Please enter a valid app name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ButtonView_Click(sender As Object, e As EventArgs) Handles ButtonView.Click
        DisplayApps() 'ni akan display list apps tu

    End Sub


    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        Dim selectedAppIndex As Integer = ListBoxApps.SelectedIndex

        If selectedAppIndex <> -1 Then '<> not equal to 
            Dim newAppName As String = InputBox("Enter the new name for the app:")
            If Not String.IsNullOrEmpty(newAppName) Then
                UpdateApp(selectedAppIndex, newAppName)

                DisplayApps()
            Else
                MessageBox.Show("Please enter a valid new app name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Please select an app to updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        Dim selectedAppIndex As Integer = ListBoxApps.SelectedIndex

        If selectedAppIndex <> -1 Then
            DeleteApp(selectedAppIndex)

            DisplayApps()
        Else
            MessageBox.Show("Please select an app to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

End Class
