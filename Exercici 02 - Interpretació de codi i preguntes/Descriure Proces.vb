    Private Sub ButtonXMLCreation_Click(sender As Object, e As EventArgs) Handles ButtonXMLCreation.Click
        Dim FitxerPlantilla As String = "D:\BitBucket\Clients\flowFactory\Aigues\samples\SiDureo_Parte_ESP.Template.txt"
        '
        If System.IO.File.Exists(FitxerPlantilla) Then
            Dim strDocumentXML As String = System.IO.File.ReadAllText(FitxerPlantilla)
            '
            Dim dir As System.IO.DirectoryInfo
            Dim file As System.IO.FileInfo

            dir = New System.IO.DirectoryInfo(TextBoxRutaTreball.Text)

            For Each file In dir.GetFiles
                If file.FullName.ToUpper.EndsWith(".CSV") Then
                    Dim arrDocumentXMLGenerat As New System.Collections.ArrayList
                    '
                    Dim arrDadesCSV() As String = System.IO.File.ReadAllLines(file.FullName)
                    '
                    Dim strTemp As String = ""
                    '
                    For intRegistre As Integer = 1 To arrDadesCSV.Count - 1
                        If arrDadesCSV(intRegistre).Split(";")(0) <> "" Then
                            strTemp = "<TIPOSERVIZIO>" & arrDadesCSV(intRegistre).Split(";")(1) & "</TIPOSERVIZIO>" & Microsoft.VisualBasic.vbNewLine
                            strTemp = strTemp & "<CODICE_PE>" & arrDadesCSV(intRegistre).Split(";")(2) & "</CODICE_PE>" & Microsoft.VisualBasic.vbNewLine
                            strTemp = strTemp & "<CODICE_FORN>" & arrDadesCSV(intRegistre).Split(";")(3) & "</CODICE_FORN>" & Microsoft.VisualBasic.vbNewLine
                            strTemp = strTemp & "<NOMINATIVO_CLIENTE>" & arrDadesCSV(intRegistre).Split(";")(4) & "</NOMINATIVO_CLIENTE>" & Microsoft.VisualBasic.vbNewLine

                            System.IO.File.WriteAllText(Me.TextBoxRutaTreball.Text & "\" & getyyyymmddhhmmss() & "_" & intRegistre & ".xml", strDocumentXML.Replace("@Metadades@", strTemp))

                        End If
                    Next
                    '
                    System.IO.File.Move(file.FullName, file.FullName & "_old")
                    '
                End If
            Next
        End If
    End Sub