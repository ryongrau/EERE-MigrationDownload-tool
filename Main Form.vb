Imports System.IO
Imports System.Windows.Forms
Imports Spire.Pdf

Public Class Form1
    '############################ FILE >   ##############################################################
    Dim Errnum As Double = 0
    Dim ErrMsg As String = ""
    Dim myFileHeader As String = "SourcePage" & vbTab & "FileURL" & vbTab & "NodeID" & vbTab & "Add Download Node" & vbTab & "LocalFilePath" _
                                  & vbTab & "FileSize" & vbTab & "DateDownloaded" & vbTab & "DateCreated" & vbTab & "Title" & vbTab & "Subject" & vbTab & "OfficeSpecificTopics"

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
                    Dim myCount As Integer = 1
                    For Each line As String In System.IO.File.ReadAllLines(openFileDialog1.FileName)
                        ToolStripProgressBar1.Value = 100 * (myCount / System.IO.File.ReadAllLines(openFileDialog1.FileName).Length)
                        myCount += 1
                        Try
                            addLinks(line)
                        Catch
                        End Try
                    Next
                End If
                ToolStripProgressBar1.Value = 0
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
                myReplacementRow(6) = Date.Now().ToString("yyyy-MM-dd hh:mm:ss")
                myReplacementRow(7) = myMetaData(0)
                myReplacementRow(8) = myMetaData(1)
                myReplacementRow(9) = myMetaData(2)

                Me.DataGridView1.Rows(iRowIndex).SetValues(myReplacementRow)

                'testStr &= "Row index " & iRowIndex & vbCrLf
                ToolStripProgressBar1.Value = 100 * (i / Me.DataGridView1.SelectedCells.Count)
            Next
            ToolStripProgressBar1.Value = 0
            'MsgBox(testStr)
        Catch ex As Exception
            MsgBox("ExtractSingleFile: " & ex.Message)
        End Try
            
    End Sub

    Private Sub ToolStripMenuItemEditNodes_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEditNodes.Click
        Dim iRowIndex As Integer
        Dim myURLstring As String
        For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
            Errnum = 1
            iRowIndex = Me.DataGridView1.SelectedCells.Item(i).RowIndex
            ToolStripStatusLabel1.Text() = "Opening " & DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString()
            Try
                Errnum = 2
                If DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString() <> "" Then
                    Errnum = 2.1
                    myURLstring = "https://cms.doe.gov/" & DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString() & "/edit"
                    ErrMsg = (myURLstring)
                    Process.Start("Chrome.exe", myURLstring)
                    DataGridView1.Rows(iRowIndex).Cells("AddNode").Value = "edit clicked"
                    DataGridView1.Rows(iRowIndex).Cells(6).Value = Date.Now().ToString("yyyy-MM-dd hh:mm:ss")
                End If
            Catch ex As Exception
                MessageBox.Show("Error " & Errnum & vbCrLf & ErrMsg & vbCrLf & ex.Message)
            End Try
            ToolStripProgressBar1.Value = 100 * (i / Me.DataGridView1.SelectedCells.Count)
        Next i
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text() = "Ready"
    End Sub

    Private Sub UpdateSelectedNodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSelectedNodesToolStripMenuItem.Click
        Dim iRowIndex As Integer
        Dim myURLstring As String
        Dim myChromeThreads()
        Dim doLoop As Integer
        For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
            Errnum = 1
            iRowIndex = Me.DataGridView1.SelectedCells.Item(i).RowIndex
            ToolStripStatusLabel1.Text() = "Sending update for " & DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString()
            Dim arrColQuer As String(,) = {{"DateCreated", "dnkfffDate"}, {"Title", "dnkfftitle"}, {"Subject", "dnkffsubject"}, {"OfficeSpecificTopics", "dnkffofficespecific"}, {"LocalFilePath", "dnkffURL"}}
            Try
                Errnum = 2
                If DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString() <> "" Then
                    Errnum = 2.1
                    myURLstring = "https://cms.doe.gov/" & DataGridView1.Rows(iRowIndex).Cells("NodeID").Value.ToString() & "/edit?"
                    ErrMsg = (myURLstring)

                    For querNum As Integer = 0 To arrColQuer.GetUpperBound(0)
                        Errnum = 2.21
                        ErrMsg &= vbCrLf & (querNum & ". " & arrColQuer(querNum, 0) & " : " & DataGridView1.Rows(iRowIndex).Cells(arrColQuer(querNum, 0)).Value)
                        Errnum = 2.22
                        If DataGridView1.Rows(iRowIndex).Cells(arrColQuer(querNum, 0)).Value.ToString() <> "" Then
                            Errnum = 2.3
                            myURLstring &= arrColQuer(querNum, 1) & "=" & System.Net.WebUtility.UrlEncode(DataGridView1.Rows(iRowIndex).Cells(arrColQuer(querNum, 0)).Value.ToString.Trim("""").Replace("%", "%25").Replace("""""", """")) & "&"
                        End If
                    Next querNum
                    Errnum = 2.4

                    If ImmediatePublish = True Then
                        myURLstring &= "dnkffautopublish=true"
                    End If
                    myURLstring = myURLstring.Trim("&")
                    'MessageBox.Show(myURLstring)
                    '>> FIRE IT TO CHROME   <<<
                    myChromeThreads = System.Diagnostics.Process.GetProcessesByName("Chrome")
                    'MsgBox("number of chrome threads:" & myChromeThreads.Count)
                    If Me.ImmediatePublish = True Then
                        doLoop = 0
                        Do Until myChromeThreads.Count < 20
                            doLoop += 1
                            System.Threading.Thread.Sleep(1000)
                            myChromeThreads = System.Diagnostics.Process.GetProcessesByName("Chrome")
                            If doLoop > 300 Then
                                Exit Do
                            End If
                        Loop
                    End If
                    Process.Start("Chrome.exe", myURLstring)
                    DataGridView1.Rows(iRowIndex).Cells("AddNode").Value = "update sent"
                    DataGridView1.Rows(iRowIndex).Cells(6).Value = Date.Now().ToString("yyyy-MM-dd hh:mm:ss")
                End If
            Catch ex As Exception
                MessageBox.Show("Error " & Errnum & vbCrLf & ErrMsg & vbCrLf & ex.Message)
            End Try
            ToolStripProgressBar1.Value = 100 * (i / Me.DataGridView1.SelectedCells.Count)

        Next i
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text() = "Ready"

    End Sub

    Private Sub OpenExtract_Click(sender As Object, e As EventArgs) Handles OpenExtract.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        ' Dim TotalRowCount As Integer = 1

        openFileDialog1.InitialDirectory = LocalFolder
        openFileDialog1.Filter = "tab delineated txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'TotalRowCount = DataGridView1.RowCount
                My.Settings.MyMostRecentFile = openFileDialog1.FileName
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here. 
                    For Each line As String In System.IO.File.ReadAllLines(openFileDialog1.FileName)
                        If line <> myFileHeader Then
                            DataGridView1.Rows.Add(line.Split(vbTab))
                            'DataGridView1.Rows(TotalRowCount - 1).HeaderCell.Value = TotalRowCount.ToString()
                            DataGridView1.Rows(DataGridView1.Rows.Count - 2).HeaderCell.Value = DataGridView1.Rows.Count.ToString()
                            ' TotalRowCount += 1
                        End If
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
                objWriter.WriteLine(myFileHeader)
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
    Private Sub SaveAsExtract_Click(sender As Object, e As EventArgs) Handles SaveAsExtract.Click
        'Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.InitialDirectory = LocalFolder
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            'myStream = saveFileDialog1.OpenFile()
            'If (myStream IsNot Nothing) Then
            Dim myLine As String = ""
            Dim StreamWriter As New System.IO.StreamWriter(saveFileDialog1.FileName)
            StreamWriter.WriteLine(myFileHeader)
            For Each myRow As DataGridViewRow In DataGridView1.Rows
                myLine = ""
                For Each myCell As DataGridViewCell In myRow.Cells
                    If Not myCell.Value Is Nothing Then
                        myLine &= myCell.Value.ToString & vbTab
                    Else
                        myLine &= vbTab
                    End If
                Next
                StreamWriter.WriteLine(myLine)
            Next
            StreamWriter.Close()
            MsgBox("Text written to file")
            'End If
        End If
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
                myURLstring &= "&dnkfftitle=" & System.Net.WebUtility.UrlEncode(DataGridView1.Rows(e.RowIndex).Cells("Title").Value.ToString.Trim("""").Replace("%", "%25").Replace("""""", """"))
                myURLstring &= "&dnkffsubject=" & System.Net.WebUtility.UrlEncode(DataGridView1.Rows(e.RowIndex).Cells("Subject").Value.ToString.Trim("""").Replace("%", "%25").Replace("""""", """"))


                '>> FIRE IT TO CHROME   <<<
                Errnum = 2
                localFileString = Me.DataGridView1.Rows(e.RowIndex).Cells("LocalFilePath").Value
                Clipboard.SetText(localFileString, TextDataFormat.UnicodeText)
                myURLstring &= "&dnkffURL=" & System.Net.WebUtility.UrlEncode(localFileString)

                '>>>>> THE ONE KEY THING <<<<
                Errnum = 2.41
                Process.Start("Chrome.exe", myURLstring)
                DataGridView1.Rows(e.RowIndex).Cells(3).Value = Date.Now().ToString("yyyy-MM-dd hh:mm:ss")

            End If
        Catch ex As Exception
            MessageBox.Show("Error " & Errnum & vbCrLf & ex.Message)
        End Try

    End Sub

    '####################   OPTIONS #####################################################################################################3
    Private Sub StructureToggle_Click(sender As Object, e As EventArgs) Handles StructureToggle.Click
        If StructureToggle.Checked = True Then
            CopyStructure = True
        Else
            CopyStructure = False
        End If
    End Sub

    Private Sub ImmediatePublish_Click(sender As Object, e As EventArgs) Handles ImmediatePublishToggle.Click
        If ImmediatePublishToggle.Checked = True Then
            ImmediatePublish = True
        Else
            ImmediatePublish = False
        End If
    End Sub

    Private Sub NodeCreationPage_Change(sender As Object, e As EventArgs) Handles NodeCreationPage.LostFocus
        CreateDownloadURL = NodeCreationPage.Text
    End Sub


    Private Sub LocalPathTextBox_Change(sender As Object, e As EventArgs) Handles LocalPathTextBox.LostFocus
        LocalFolder = LocalPathTextBox.Text
    End Sub


    '################ Public Props ######################################################################################################

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

    Private _ImmediatePublish As Boolean = My.Settings.ImmediatePublish
    Public Property ImmediatePublish As Boolean
        Get
            Return _ImmediatePublish
        End Get
        Set(ByVal value As Boolean)
            _ImmediatePublish = value
            My.Settings.ImmediatePublish = value
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
        Dim links As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(html, "href=""([^<>]*?)\.(pdf|xls|xlsx|doc|docx|ppt|pptx)")

        'MsgBox("Add Link : " & url & vbCrLf & "links found..?" & links.Count())
        For Each match As System.Text.RegularExpressions.Match In links
            Try
                'Dim dr As DataRow = DataGridView1
                matchUrl = match.Value.ToString().Replace("href=""", "")

                If matchUrl.StartsWith("/") Then
                    matchUrl = MapUrl("http://www1.eere.energy.gov", matchUrl)
                End If
                If System.Text.RegularExpressions.Regex.Match(matchUrl, "eere.energy.gov").Success = True Then
                    DataGridView1.Rows.Add({url, matchUrl, "", "- found -", "", "", "", "", "", ""})
                    DataGridView1.Rows(DataGridView1.Rows.Count() - 2).HeaderCell.Value = DataGridView1.Rows.Count().ToString()
                End If

            Catch ex As Exception
                MsgBox("Add Link Error from " & matchUrl & vbCrLf & ex.Message)
                'DataGridView1.Rows.Add({url, matchUrl, "", "- error -", "", "", "", "", "", ex.Message})
                'DataGridView1.Rows(DataGridView1.Rows.Count() - 2).HeaderCell.Value = DataGridView1.Rows.Count().ToString()
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


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub


End Class
