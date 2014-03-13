Imports System.IO
Imports System.Windows.Forms
Imports Spire.Pdf

Public Class Form1
    '############################ FILE >   ##############################################################
    Dim Errnum As Double = 0
    Private Sub DownLoadFromList_Click(sender As Object, e As EventArgs) Handles DownLoadFromList.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = LocalFolder
        openFileDialog1.Filter = "tab delineated txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                My.Settings.MyMostRecentFile = openFileDialog1.FileName
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here. 

                    For Each line As String In System.IO.File.ReadAllLines(openFileDialog1.FileName)
                        addLinks(line)
                    Next
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub ExtractSingleFile_Click(sender As Object, e As EventArgs) Handles ExtractSingleFile.Click
        Try
            Dim iRowIndex As Integer
            'Dim testStr = ""
            For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1

                iRowIndex = Me.DataGridView1.SelectedCells.Item(i).RowIndex

                Dim myFileUrl As String = Me.DataGridView1.Rows(iRowIndex).Cells("FileURL").Value.ToString
                Dim myLocalFile As String = downloadEEREEnergyFile(myFileUrl)
                Dim myMetaData() As String
                Try
                    If myFileUrl.EndsWith(".pdf") Then
                        myMetaData = extractPDFMetaData(myLocalFile)
                    Else
                        myMetaData = extractOtherMetadata(myLocalFile)
                    End If
                Catch
                    MsgBox("problem pulling metadata from " & myLocalFile)
                    myMetaData = {"2014-03-03", myLocalFile.Split("\")(myLocalFile.Split("\").GetUpperBound(0)), ""}
                End Try
                Dim myReplacementRow(9) As String
                myReplacementRow(0) = Me.DataGridView1.Rows(iRowIndex).Cells("SourcePage").Value.ToString
                myReplacementRow(1) = myFileUrl
                myReplacementRow(2) = Me.DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString
                myReplacementRow(3) = ">>> Updated !!!"
                myReplacementRow(4) = myLocalFile
                myReplacementRow(7) = myMetaData(0)
                myReplacementRow(8) = myMetaData(1)
                myReplacementRow(9) = myMetaData(2)

                Me.DataGridView1.Rows(iRowIndex).SetValues(myReplacementRow)

                'testStr &= "Row index " & iRowIndex & vbCrLf
            Next
            'MsgBox(testStr)
        Catch ex As Exception
            MsgBox("ExtractSingleFile: " & ex.Message)
        End Try

    End Sub
    Private Sub OpenExtract_Click(sender As Object, e As EventArgs) Handles OpenExtract.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = LocalFolder
        openFileDialog1.Filter = "tab delineated txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                My.Settings.MyMostRecentFile = openFileDialog1.FileName
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here. 
                    For Each line As String In System.IO.File.ReadAllLines(openFileDialog1.FileName)
                        DataGridView1.Rows.Add(line.Split(vbTab))
                        'For Each myCell As DataGridViewCell In DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells
                        '    myCell.Value = myCell.Value.ToString.Trim("""")
                        'Next
                    Next
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub SaveExtract_Click(sender As Object, e As EventArgs) Handles SaveExtract.Click
        Try
            If System.IO.File.Exists(My.Settings.MyMostRecentFile) = True Then
                Dim myLine As String = ""
                Dim objWriter As New System.IO.StreamWriter(My.Settings.MyMostRecentFile)
                For Each myRow As DataGridViewRow In DataGridView1.Rows
                    myLine = ""
                    For Each myCell As DataGridViewCell In myRow.Cells
                        If Not myCell.Value Is Nothing Then
                            myLine &= myCell.Value.ToString & vbTab
                        Else
                            myLine &= vbTab
                        End If
                    Next
                    objWriter.WriteLine(myLine)
                Next
                objWriter.Close()
                MsgBox("Text written to file")

            Else

                MsgBox("File Does Not Exist")

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CloseExtract_Click(sender As Object, e As EventArgs) Handles CloseExtract.Click
        DataGridView1.Rows.Clear()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub



    '############################## DATAGRIDVIEW #####################################################

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.ColumnIndex = 3 Then
                Errnum = 1
                Dim myFileURL As String
                Dim myURLstring As String
                Dim localFileString As String
                Dim myOutput As String = "This is Output" & vbCrLf
                Dim myOtherOutput As String = "This is Sorted" & vbCrLf
                myFileURL = DataGridView1.Rows(e.RowIndex).Cells("FileURL").Value.ToString
                myURLstring = Me.CreateDownloadURL & "&dnkffdate=" & DataGridView1.Rows(e.RowIndex).Cells("DateCreated").Value.ToString.Trim("""")
                myURLstring &= "&dnkfftitle=" & System.Net.WebUtility.UrlEncode(DataGridView1.Rows(e.RowIndex).Cells("Title").Value.ToString.Trim(""""))
                myURLstring &= "&dnkffsubject=" & System.Net.WebUtility.UrlEncode(DataGridView1.Rows(e.RowIndex).Cells("Subject").Value.ToString.Trim(""""))


                '>> FIRE IT TO CHROME   <<<
                Errnum = 2
                localFileString = Me.DataGridView1.Rows(e.RowIndex).Cells("LocalFilePath").Value
                Clipboard.SetText(localFileString, TextDataFormat.UnicodeText)
                myURLstring &= "&dnkffURL=" & System.Net.WebUtility.UrlEncode(localFileString)

                '>>>>> THE ONE KEY THING <<<<
                Errnum = 2.41
                Process.Start(myURLstring)


                'my plot: START THE PROCESS (check) find the process, then send the commandS to enter the textbox info

                'Dim myProcesses() = Process.GetProcesses
                'Dim myChromeProcess As Process
                'Dim myChromeProcesses = New List(Of Process)()
                'Dim myInitialChromeProcesses = New List(Of Process)()
                'Dim myInitialChromeProcessIDs = New List(Of Integer)()
                'Dim myProcessID As Integer

                'Errnum = 2.3
                'For Each myProcess In myProcesses
                '    If myProcess.ProcessName.ToString = "chrome" Then
                '        myInitialChromeProcessIDs.Add(myProcess.Id)
                '    End If
                'Next
                'Errnum = 2.4
                'Dim startInfo As New ProcessStartInfo(myURLstring)
                'startInfo.UseShellExecute = False
                'startInfo.RedirectStandardOutput = True

                'I was hoping to pass the commands for entereing the text through here to chrome... closing that loop.... 
                'by getting the process of the individual tab and then sending keystroke messege/ commands to chrome.. alas
                'System.Threading.Thread.Sleep(1000)
                'myProcesses = Process.GetProcesses
                'Errnum = 2.42
                'For Each newProcess In myProcesses
                '    If newProcess.ProcessName.ToString = "chrome" And Not myInitialChromeProcessIDs.Contains(newProcess.Id) Then
                '        myOutput &= "NEW >" & newProcess.ProcessName & " " & newProcess.Id & " " & newProcess.StartTime.ToString("hh:mm:ss") & vbCrLf
                '        myChromeProcesses.Add(newProcess)
                '    End If
                'Next
                'Errnum = 2.5
                ''MessageBox.Show(myOutput)
                'Errnum = 2.6
                'myChromeProcess = myChromeProcesses(myChromeProcesses.Count - 1)
                'Errnum = 2.7
                'Dim idleMessage As String = "idling test:" & vbCrLf
                'If Not myChromeProcess Is Nothing Then
                '    For i = 1 To 25
                '        Try
                '            Errnum = 2.82
                '            myChromeProcess.Refresh()
                '            Errnum = 2.83
                '            'idleMessage &= myChromeProcess.Threads.Count().ToString & vbCrLf
                '            idleMessage &= myChromeProcess.StandardOutput.ReadLine() & vbCrLf
                '            System.Threading.Thread.Sleep(500)
                '        Catch ex As Exception
                '            idleMessage &= Errnum & " : " & ex.Message
                '        End Try
                '    Next
                'Else
                '    idleMessage &= "this chrome process is nothing"
                'End If
                'MessageBox.Show(idleMessage)
                'myChromeProcess.Kill()


            End If
        Catch ex As Exception
            MessageBox.Show("Error " & Errnum & vbCrLf & ex.Message)
        End Try

    End Sub

    '####################   OPTIONS ##############################
    Private Sub StructureToggle_Click(sender As Object, e As EventArgs) Handles StructureToggle.Click
        If StructureToggle.Checked = True Then
            CopyStructure = True
        Else
            CopyStructure = False
        End If
    End Sub

    Private Sub NodeCreationPage_Change(sender As Object, e As EventArgs) Handles NodeCreationPage.LostFocus
        CreateDownloadURL = NodeCreationPage.Text
    End Sub


    Private Sub LocalPathTextBox_Change(sender As Object, e As EventArgs) Handles LocalPathTextBox.LostFocus
        LocalFolder = LocalPathTextBox.Text
    End Sub


    '################ Public Props ################################

    Private _CreateDownloadURL As String = My.Settings.CreateDownloadURL
    Public Property CreateDownloadURL As String
        Get
            Return _CreateDownloadURL
        End Get
        Set(ByVal value As String)
            _CreateDownloadURL = value
            My.Settings.CreateDownloadURL = value
        End Set
    End Property

    Private _LocalFolder As String = My.Settings.LocalFolder
    Public Property LocalFolder As String
        Get
            Return _LocalFolder
        End Get
        Set(ByVal value As String)
            _LocalFolder = value
            My.Settings.LocalFolder = value
        End Set
    End Property

    Private _CopyStructure As Boolean = My.Settings.CopyStructure
    Public Property CopyStructure As Boolean
        Get
            Return _CopyStructure
        End Get
        Set(ByVal value As Boolean)
            _CopyStructure = value
            My.Settings.CopyStructure = value

        End Set
    End Property




    '###############################   FUNCTIONS    #########################################################################
    Private Function extractPDFMetaData(filePath As String)
        Dim myMetaData(2) As String

        Dim doc As New PdfDocument(filePath)
        For i = 0 To 2
            Try
                Select Case i
                    Case 0
                        myMetaData(0) = doc.DocumentInformation.CreationDate.ToString("yyyy-MM-dd")
                    Case 1
                        myMetaData(1) = doc.DocumentInformation.Title.ToString.Replace(vbCr, "").Replace(vbLf, "")
                    Case 2
                        myMetaData(2) = doc.DocumentInformation.Subject.ToString.Replace(vbCr, "").Replace(vbLf, "")
                End Select
            Catch ex As Exception
                myMetaData(i) = ex.Message.ToString
                MsgBox("Extract PDF MetaData Error:" & ex.Message)
            End Try
        Next
        doc.Close()
        Return myMetaData
    End Function

    Function extractOtherMetadata(ByVal myFile As String)
        Dim errnum As Double = 10
        Dim myInfo As System.IO.FileInfo
        Dim myMetaData(2) As String
        errnum = 11
        Try

            myInfo = New System.IO.FileInfo(myFile)

            myMetaData(0) = myInfo.CreationTime.ToString("yyyy-MM-dd")
            myMetaData(1) = myFile.Split("\")(myFile.Split("\").GetUpperBound(0))
            myMetaData(2) = ""

        Catch ex As Exception
            MsgBox("Extract other MetaData Error:" & ex.Message)
        End Try
        Return myMetaData
    End Function


    Private Function downloadEEREEnergyFile(fileURL As String)
        Dim localFilePath As String = LocalFolder

        Dim Errnum As Double = 0
        Try
            Dim testMsg As String = "Paths:" & vbCrLf
            Dim testpath As String = ""
            Dim stringSeperator() As String = {".gov/"}
            Dim relativePath As String = fileURL.Split(stringSeperator, StringSplitOptions.None)(1)

            Errnum = 1
            For pathPart = 0 To relativePath.Split("/").GetUpperBound(0)
                testpath = localFilePath
                For i = 0 To pathPart
                    testpath &= "\" & relativePath.Split("/")(i)
                Next
                testMsg &= testpath & vbCrLf
                testpath = testpath.Trim(" ")
                If testpath.EndsWith(".pdf") Or testpath.EndsWith(".doc") Or testpath.EndsWith(".docx") Or testpath.EndsWith(".ppt") _
                    Or testpath.EndsWith(".pptx") Or testpath.EndsWith(".xls") Or testpath.EndsWith(".xlsx") Then
                    If Not System.IO.File.Exists(testpath) Then
                        My.Computer.Network.DownloadFile(fileURL, testpath)
                    Else
                        System.IO.File.Delete(testpath)
                        My.Computer.Network.DownloadFile(fileURL, testpath)
                    End If
                Else
                    If Not System.IO.Directory.Exists(testpath) Then
                        System.IO.Directory.CreateDirectory(testpath)
                    End If
                End If


            Next pathPart
            'MsgBox(testMsg)
            localFilePath = testpath
        Catch ex As Exception
            MsgBox("downloadEEREEnergyFile Error " & Errnum & vbCrLf & ex.Message)
        End Try
        Return localFilePath
    End Function


    Private Sub addLinks(ByVal url As String)

        Dim wc As New System.Net.WebClient
        Dim html As String = wc.DownloadString(url)
        Dim matchUrl As String = ""
        Dim links As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(html, "href=""(.*?)\.(pdf|xls|xlsx|doc|docx|ppt|pptx)")
        'MsgBox("Add Link : " & url & vbCrLf & "links found..?" & links.Count())
        For Each match As System.Text.RegularExpressions.Match In links
            Try
                'Dim dr As DataRow = DataGridView1
                matchUrl = match.Value.ToString()
                If Not matchUrl.StartsWith("http://") And Not matchUrl.StartsWith("https://") Then
                    matchUrl = MapUrl("http://www1.eere.energy.gov", matchUrl)
                End If
                matchUrl = matchUrl.Replace("href=""", "")
                DataGridView1.Rows.Add({url, matchUrl, "", "- found -", "", "", "", "", "", ""})


            Catch ex As Exception
                MsgBox("Add Link Error from " & matchUrl & vbCrLf & ex.Message)
            End Try
        Next

    End Sub

    Public Function MapUrl(ByVal baseAddress As String, ByVal relativePath As String) As String

        Dim u As New System.Uri(baseAddress)

        If relativePath = "./" Then
            relativePath = "/"
        End If

        If relativePath.StartsWith("/") Then
            Return u.Scheme + Uri.SchemeDelimiter + u.Authority + relativePath
        Else
            Dim pathAndQuery As String = u.AbsolutePath
            ' If the baseAddress contains a file name, like ..../Something.aspx
            ' Trim off the file name
            pathAndQuery = pathAndQuery.Split("?")(0).TrimEnd("/")
            If pathAndQuery.Split("/")(pathAndQuery.Split("/").Count - 1).Contains(".") Then
                pathAndQuery = pathAndQuery.Substring(0, pathAndQuery.LastIndexOf("/"))
            End If
            baseAddress = u.Scheme + Uri.SchemeDelimiter + u.Authority + pathAndQuery

            'If the relativePath contains ../ then
            ' adjust the baseAddress accordingly

            While relativePath.StartsWith("../")
                relativePath = relativePath.Substring(3)
                If baseAddress.LastIndexOf("/") > baseAddress.IndexOf("//" + 2) Then
                    baseAddress = baseAddress.Substring(0, baseAddress.LastIndexOf("/")).TrimEnd("/")
                End If
            End While

            Return baseAddress + relativePath
        End If

    End Function


End Class
