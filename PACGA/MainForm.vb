Imports System.ComponentModel
Imports System.IO
Imports PACGA.LinkedList

Public Class MainForm
    Dim bmp As Bitmap
    Dim graphics As Graphics
    Dim startpoint, lastpoint As Point
    Dim draw, polygon,
        colorize, edit, add As Boolean
    Dim listPolygon As New LLPolygons
    Dim node As NPolygon
    Dim Poly As New LLPolygon
    Dim Vertex As NPoint
    Dim p, deletePoint, editPoint, addPoint As Points
    Dim color, polyColor As Color
    Dim numberPolygon As Integer = 1
    Dim numberPolyline As Integer = 1

    Private Sub checkPoint(ByVal bm As Bitmap, ByVal pixels As Stack, ByVal x As Integer, ByVal y As Integer, ByVal oldColor As Color, ByVal newColor As Color)
        Dim check As Color = bm.GetPixel(x, y)
        If check = oldColor Then
            pixels.Push(New Point(x, y))
            bm.SetPixel(x, y, newColor)
        End If
    End Sub

    Public Sub floodFill(ByVal bm As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal newColor As Color)
        Dim oldColor As Color = bm.GetPixel(x, y)

        If oldColor.ToArgb <> newColor.ToArgb Then
            Dim pixels As New Stack(2000)
            pixels.Push(New Point(x, y))
            bm.SetPixel(x, y, newColor)

            Do While pixels.Count > 0
                Dim pt As Point = DirectCast(pixels.Pop(), Point)

                If pt.Y > 0 Then
                    checkPoint(bm, pixels, pt.X, pt.Y - 1, oldColor, newColor)
                End If
                If pt.X > 0 Then
                    checkPoint(bm, pixels, pt.X - 1, pt.Y, oldColor, newColor)
                End If
                If pt.Y < bm.Height - 1 Then
                    checkPoint(bm, pixels, pt.X, pt.Y + 1, oldColor, newColor)
                End If
                If pt.X < bm.Width - 1 Then
                    checkPoint(bm, pixels, pt.X + 1, pt.Y, oldColor, newColor)
                End If
            Loop
        End If
    End Sub

    Function printPoint(ByVal P As Points) As String
        Return CStr(P.hor) + "," + CStr(P.ver)
    End Function

    Private Sub button(ByVal test As Boolean)
        btnAddVertex.Enabled = test
        btnEditVertex.Enabled = test
        btnDeleteVertex.Enabled = test
        btnDeleteObject.Enabled = test
        btnColor.Enabled = test
    End Sub

    Private Sub buttonCalculation(ByVal test As Boolean)
        btnCalculate.Enabled = test
        rbArea.Enabled = test
        rbConvexity.Enabled = test
        rbPerimeter.Enabled = test

        If test = False Then
            rbArea.Checked = False
            rbConvexity.Checked = False
            rbPerimeter.Checked = False
        End If
    End Sub

    Private Sub createGraphic()
        bmp = New Bitmap(canvas.Width, canvas.Height)
        graphics = Graphics.FromImage(bmp)
        graphics.Clear(Color.White)
        canvas.BackgroundImage = bmp
    End Sub

    Private Sub reDraw(ByVal node As NPolygon)
        While Not (node Is Nothing)
            Vertex = node.infoPolyData.infoHead

            If Vertex Is Nothing Then
                node = node.infoPolyRef

            Else
                Dim startX, startY, endX, endY, firstX, firstY As Integer
                firstX = Vertex.infoX
                firstY = Vertex.infoY

                Dim detGon As String = node.infoPolyName
                Dim res As String() = detGon.Split(New String() {" "}, StringSplitOptions.None)

                While Not (Vertex Is Nothing)
                    startX = Vertex.infoX
                    startY = Vertex.infoY

                    Vertex = Vertex.infoRef

                    If Vertex Is Nothing Then
                        Exit While
                    End If

                    endX = Vertex.infoX
                    endY = Vertex.infoY
                    graphics.DrawLine(New Pen(color, 2), startX, startY, endX, endY)
                End While


                If res(0) = "Polygon" Then
                    graphics.DrawLine(New Pen(color, 2), startX, startY, firstX, firstY)
                End If

                node = node.infoPolyRef
            End If
        End While
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        createGraphic()
        listPolygon.init()
        color = Color.Black
    End Sub

    Private Sub canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseDown
        Dim oldPoint As Points
        If draw = True Then
            If e.Button = MouseButtons.Right Then
                If polygon = True Then
                    If lsbPoint.Items.Count = 2 Then
                        MessageBox.Show("Cannot draw polygon, vertices is less than 3", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Else
                        graphics.DrawLine(New Pen(color, 2), lastpoint.X, lastpoint.Y, startpoint.X, startpoint.Y)
                        draw = False
                        btnPolygon.Text = "Add Polygon"
                        lblInfo.Text = ""

                        button(True)
                        buttonCalculation(True)
                        canvas.Refresh()
                    End If
                End If
            Else
                If lastpoint.X <> 0 And lastpoint.Y <> 0 Then
                    p.SetPoint(e.X, e.Y)
                    Poly.addLastPoint(p)
                    graphics.DrawLine(New Pen(color, 2), lastpoint.X, lastpoint.Y, e.X, e.Y)
                    lsbPoint.Items.Add(printPoint(p))
                    lastpoint.X = e.X
                    lastpoint.Y = e.Y
                    canvas.Refresh()

                    If polygon = False Then
                        btnPolyline.Text = "Add Polyline"

                        button(True)
                        buttonCalculation(True)
                    Else
                        lblInfo.Text = "Done drawing polygon? Click right mouse button to finish"
                    End If
                Else
                    p.SetPoint(e.X, e.Y)
                    Poly.addFirstPoint(p)
                    lsbPoint.Items.Add(printPoint(p))
                    startpoint.X = Poly.infoHead.infoX
                    startpoint.Y = Poly.infoHead.infoY
                    lastpoint.X = Poly.infoHead.infoX
                    lastpoint.Y = Poly.infoHead.infoY
                End If
            End If

        ElseIf colorize = True Then
            floodFill(canvas.BackgroundImage, e.X, e.Y, polyColor)
            canvas.Refresh()

        ElseIf edit = True Then
            editPoint.hor = e.X
            editPoint.ver = e.Y
            If lsbPoint.SelectedIndex > -1 Then
                Dim str As String = lsbPoint.SelectedItem.ToString
                Dim res As String() = str.Split(New String() {","}, StringSplitOptions.None)
                Dim newStr As String = CStr(editPoint.hor) + "," + CStr(editPoint.ver)
                oldPoint.SetPoint(res(0), res(1))
                createGraphic()

                Dim name As String = cmbPolyList.SelectedItem.ToString

                node = listPolygon.infoPolyHead

                While Not (node Is Nothing)
                    If node.infoPolyName = name Then
                        Vertex = node.infoPolyData.infoHead
                        While Not (Vertex Is Nothing)
                            If Vertex.infoX = res(0) And Vertex.infoY = res(1) Then
                                lsbPoint.Items(lsbPoint.SelectedIndex) = newStr
                                node.infoPolyData.editNode(oldPoint, editPoint)
                            End If
                            Vertex = Vertex.infoRef
                        End While
                    End If
                    node = node.infoPolyRef
                End While

                node = listPolygon.infoPolyHead
                reDraw(node)

                canvas.Refresh()
            End If
            lblInfo.Text = ""
            edit = False

        ElseIf add = True Then
            addPoint.hor = e.X
            addPoint.ver = e.Y
            If lsbPoint.SelectedIndex > -1 Then
                Dim str As String = lsbPoint.SelectedItem.ToString
                Dim res As String() = str.Split(New String() {","}, StringSplitOptions.None)
                Dim newStr As String = CStr(addPoint.hor) + "," + CStr(addPoint.ver)
                oldPoint.SetPoint(res(0), res(1))
                createGraphic()

                Dim name As String = cmbPolyList.SelectedItem.ToString

                node = listPolygon.infoPolyHead

                While Not (node Is Nothing)
                    If node.infoPolyName = name Then
                        Vertex = node.infoPolyData.infoHead
                        While Not (Vertex Is Nothing)
                            If Vertex.infoX = res(0) And Vertex.infoY = res(1) Then
                                lsbPoint.Items.Insert(lsbPoint.SelectedIndex + 1, newStr)
                                node.infoPolyData.addNodeAfter(oldPoint, addPoint)
                            End If
                            Vertex = Vertex.infoRef
                        End While
                    End If
                    node = node.infoPolyRef
                End While

                node = listPolygon.infoPolyHead
                reDraw(node)

                canvas.Refresh()
            Else
                createGraphic()

                Dim newStr As String = CStr(addPoint.hor) + "," + CStr(addPoint.ver)

                Dim name As String = cmbPolyList.SelectedItem.ToString

                node = listPolygon.infoPolyHead

                While Not (node Is Nothing)
                    If node.infoPolyName = name Then
                        lsbPoint.Items.Insert(0, newStr)

                        p.SetPoint(e.X, e.Y)
                        node.infoPolyData.addFirstPoint(p)
                    End If
                    node = node.infoPolyRef
                End While

                node = listPolygon.infoPolyHead
                reDraw(node)

                canvas.Refresh()
            End If
            lblInfo.Text = ""
            add = False
        End If
    End Sub

    Private Sub canvas_MouseMove(sender As Object, e As MouseEventArgs) Handles canvas.MouseMove
        lblArea.Text = "(" & e.X & ", " & e.Y & ")"
    End Sub

    Private Sub btnPolygon_Click(sender As Object, e As EventArgs) Handles btnPolygon.Click
        draw = True
        polygon = True
        edit = False
        add = False

        cmbPolyList.Enabled = True
        lsbPoint.Items.Clear()

        Dim polygonName As String = "Polygon " + CStr(numberPolygon)
        Dim a As Integer = cmbPolyList.Items.Add(polygonName)

        If cmbPolyList.SelectedIndex = -1 Then
            cmbPolyList.SelectedIndex = 0

            listPolygon.addPolyFirstComp(polygonName, Poly)
            Poly.init()
        Else
            cmbPolyList.SelectedIndex = a

            Dim currentPoly As New LLPolygon
            currentPoly.init()
            Poly = currentPoly
            Poly.init()
            listPolygon.addPolyLastComp(polygonName, Poly)
        End If

        numberPolygon += 1

        lastpoint.X = 0
        lastpoint.Y = 0
    End Sub

    Private Sub btnPolyline_Click(sender As Object, e As EventArgs) Handles btnPolyline.Click
        draw = True
        polygon = False
        edit = False
        add = False

        cmbPolyList.Enabled = True
        lsbPoint.Items.Clear()

        Dim polylineName As String = "Polyline " + CStr(numberPolyline)
        Dim b As Integer = cmbPolyList.Items.Add(polylineName)

        If cmbPolyList.SelectedIndex = -1 Then
            cmbPolyList.SelectedIndex = 0

            listPolygon.addPolyFirstComp(polylineName, Poly)
            Poly.init()

        Else
            cmbPolyList.SelectedIndex = b

            Dim currentPoly As New LLPolygon
            currentPoly.init()
            Poly = currentPoly
            Poly.init()
            listPolygon.addPolyLastComp(polylineName, Poly)

        End If

        numberPolyline += 1

        lastpoint.X = 0
        lastpoint.Y = 0
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        draw = False
        polygon = False
        edit = False
        add = False

        listPolygon.init()
        Poly.init()

        btnPolygon.Text = "Polygon"
        btnPolyline.Text = "Polyline"
        lblInfo.Text = ""

        lastpoint.X = 0
        lastpoint.Y = 0
        numberPolygon = 1
        numberPolyline = 1

        color = Color.Black

        createGraphic()
        button(False)
        buttonCalculation(False)
        cmbPolyList.Enabled = False

        cmbPolyList.Items.Clear()
        cmbPolyList.SelectedIndex = -1
        lsbPoint.Items.Clear()
    End Sub

    Private Sub findArea(ByVal node As NPolygon)
        Dim name As String = cmbPolyList.SelectedItem.ToString
        Dim res As String() = name.Split(New String() {" "}, StringSplitOptions.None)

        If res(0) <> "Polygon" Then
            MessageBox.Show("Not a Polygon, cannot find area", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim area As Double = 0
            Dim deltaX, deltaY As Double
            Dim startX, startY, endX, endY, firstX, firstY As Integer

            While Not (node Is Nothing)
                If node.infoPolyName = name Then
                    Vertex = node.infoPolyData.infoHead

                    If Vertex Is Nothing Then
                        MessageBox.Show("No vertex detected", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    firstX = Vertex.infoX
                    firstY = Vertex.infoY
                    While Not (Vertex Is Nothing)
                        startX = Vertex.infoX
                        startY = Vertex.infoY

                        Vertex = Vertex.infoRef

                        If Vertex Is Nothing Then
                            Exit While
                        End If

                        endX = Vertex.infoX
                        endY = Vertex.infoY

                        deltaX = endX - startX
                        deltaY = endY - startY
                        area += (startX * deltaY) - (startY * deltaX)
                    End While

                    deltaX = firstX - startX
                    deltaY = firstY - startY
                    area += (startX * deltaY) - (startY * deltaX)
                End If
                node = node.infoPolyRef
            End While

            area *= 0.5
            area = Math.Abs(area)

            MessageBox.Show("The area is " + CStr(Math.Round(area, 3)), "Area", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub findPerimeter(ByVal node As NPolygon)
        Dim perimeter As Double = 0
        Dim deltaX, deltaY As Double
        Dim startX, startY, endX, endY, firstX, firstY As Integer
        Dim name As String = cmbPolyList.SelectedItem.ToString
        Dim res As String() = name.Split(New String() {" "}, StringSplitOptions.None)

        While Not (node Is Nothing)
            If node.infoPolyName = name Then
                Vertex = node.infoPolyData.infoHead

                If Vertex Is Nothing Then
                    MessageBox.Show("No vertex detected", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                firstX = Vertex.infoX
                firstY = Vertex.infoY
                While Not (Vertex Is Nothing)
                    startX = Vertex.infoX
                    startY = Vertex.infoY

                    Vertex = Vertex.infoRef

                    If Vertex Is Nothing Then
                        Exit While
                    End If

                    endX = Vertex.infoX
                    endY = Vertex.infoY

                    deltaX = endX - startX
                    deltaY = endY - startY
                    perimeter += (deltaX * deltaX + deltaY * deltaY) ^ 0.5
                End While

                If res(0) = "Polygon" Then
                    deltaX = firstX - startX
                    deltaY = firstY - startY
                    perimeter += (deltaX * deltaX + deltaY * deltaY) ^ 0.5
                End If
            End If
            node = node.infoPolyRef
        End While

        MessageBox.Show("The perimeter is " + CStr(Math.Round(perimeter, 3)), "Perimeter", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function crossProduct(ByVal Ax As Double, ByVal Ay As Double, ByVal Bx As Double, ByVal By As Double, ByVal Cx As Double, ByVal Cy As Double)
        Dim XofBA, YofBA, XofBC, YofBC As Double

        XofBA = Ax - Bx
        YofBA = Ay - By
        XofBC = Cx - Bx
        YofBC = Cy - By

        Dim result As Double = XofBA * YofBC - YofBA * XofBC
        Return result
    End Function

    Private Sub detConvexity(ByVal node As NPolygon)
        Dim resNeg, resPos As Boolean
        Dim resCrossProduct As Double
        Dim name As String = cmbPolyList.SelectedItem.ToString
        Dim res As String() = name.Split(New String() {" "}, StringSplitOptions.None)

        If res(0) <> "Polygon" Then
            MessageBox.Show("Not a Polygon, cannot find convexity", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            resNeg = False
            resPos = False

            While Not (node Is Nothing)
                If node.infoPolyName = name Then
                    Vertex = node.infoPolyData.infoHead

                    If Vertex Is Nothing Then
                        MessageBox.Show("No vertex detected", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Dim start As NPoint = Vertex
                    While Not (Vertex Is Nothing)
                        Dim A As NPoint = Vertex
                        Dim B As NPoint = Vertex.infoRef
                        Dim C As NPoint = B.infoRef

                        If C Is Nothing Then
                            resCrossProduct = crossProduct(A.infoX, A.infoY, B.infoX, B.infoY, start.infoX, start.infoY)
                            If resCrossProduct < 0 Then
                                resNeg = True
                            Else
                                resPos = True
                            End If

                            If resNeg = True And resPos = True Then
                                MessageBox.Show("This Polygon is Concave", "Convexity", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If

                            Exit While
                        End If

                        resCrossProduct = crossProduct(A.infoX, A.infoY, B.infoX, B.infoY, C.infoX, C.infoY)
                        If resCrossProduct > 0 Then
                            resPos = True
                        ElseIf resCrossProduct < 0 Then
                            resNeg = True
                        End If

                        If resNeg = True And resPos = True Then
                            MessageBox.Show("This Polygon is Concave", "Convexity", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        Vertex = Vertex.infoRef
                    End While
                End If
                node = node.infoPolyRef
            End While

            MessageBox.Show("This Polygon is Convex", "Convexity", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        node = listPolygon.infoPolyHead
        If rbArea.Checked Then
            findArea(node)
        ElseIf rbConvexity.Checked Then
            detConvexity(node)
        ElseIf rbPerimeter.Checked Then
            findPerimeter(node)
        Else
            MessageBox.Show("Choose one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAddVertex_Click(sender As Object, e As EventArgs) Handles btnAddVertex.Click
        draw = False
        colorize = False
        edit = False
        add = True

        If lsbPoint.SelectedIndex = -1 Then
            lblInfo.Text = "You are adding a point as a first vertex of " + cmbPolyList.SelectedItem.ToString
        ElseIf lsbPoint.SelectedIndex > -1 Then
            lblInfo.Text = "Hint: Click on the canvas to select a New Point for the vertex to be add"
        End If
    End Sub

    Private Sub btnEditVertex_Click(sender As Object, e As EventArgs) Handles btnEditVertex.Click
        draw = False
        colorize = False
        add = False

        If lsbPoint.SelectedIndex = -1 Then
            edit = False
            MessageBox.Show("Please select a vertex in Vertices Lists to Edit a Vertex", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf lsbPoint.SelectedIndex > -1 Then
            edit = True
            lblInfo.Text = "Hint: Click on the canvas to select a New Point for the vertex to be edit"
        End If
    End Sub

    Private Sub btnDeleteVertex_Click(sender As Object, e As EventArgs) Handles btnDeleteVertex.Click
        draw = False
        colorize = False
        edit = False
        add = False

        If lsbPoint.SelectedIndex = -1 Then
            MessageBox.Show("Please select a vertex in Vertices Lists to Delete a Vertex", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf lsbPoint.SelectedIndex > -1 Then
            If lsbPoint.Items.Count = 1 Then
                btnDeleteObject.PerformClick()
                Exit Sub
            End If
            Dim str As String = lsbPoint.SelectedItem.ToString
            Dim res As String() = str.Split(New String() {","}, StringSplitOptions.None)
            deletePoint.SetPoint(res(0), res(1))
            createGraphic()

            Dim name As String = cmbPolyList.SelectedItem.ToString
            node = listPolygon.infoPolyHead

            While Not (node Is Nothing)
                If node.infoPolyName = name Then
                    Vertex = node.infoPolyData.infoHead
                    While Not (Vertex Is Nothing)
                        If Vertex.infoX = res(0) And Vertex.infoY = res(1) Then
                            lsbPoint.Items.Remove(lsbPoint.SelectedItem)
                            node.infoPolyData.deleteNode(deletePoint)
                            Exit While
                        End If
                        Vertex = Vertex.infoRef
                    End While
                End If
                node = node.infoPolyRef
            End While

            node = listPolygon.infoPolyHead
            reDraw(node)

            canvas.Refresh()
        End If
    End Sub

    Private Sub btnDeleteObject_Click(sender As Object, e As EventArgs) Handles btnDeleteObject.Click
        draw = False
        colorize = False
        edit = False
        add = False
        createGraphic()

        Dim str As String = cmbPolyList.SelectedItem.ToString

        node = listPolygon.infoPolyHead
        While Not (node Is Nothing)
            If node.infoPolyName = str Then
                listPolygon.detelePolyNode(node.infoPolyData)
                cmbPolyList.Items.RemoveAt(cmbPolyList.SelectedIndex)

                If cmbPolyList.Items.Count <> 0 Then
                    cmbPolyList.SelectedIndex = 0

                Else
                    btnClear.PerformClick()
                    Exit Sub

                End If

                Exit While
            End If
            node = node.infoPolyRef
        End While

        node = listPolygon.infoPolyHead
        reDraw(node)
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        draw = False
        colorize = True
        edit = False
        add = False

        If dialogColor.ShowDialog() = DialogResult.OK Then
            polyColor = dialogColor.Color
        End If
    End Sub

    Private Sub btnPenColor_Click(sender As Object, e As EventArgs) Handles btnPenColor.Click
        colorize = False
        edit = False
        add = False

        If dialogColor.ShowDialog() = DialogResult.OK Then
            color = dialogColor.Color
        End If
    End Sub

    Private Sub saveFile()
        dialogSaveFile.Filter = "Text Files (*.txt)|*.txt"
        If dialogSaveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim path As String = dialogSaveFile.FileName
            Dim sb As New System.Text.StringBuilder()

            node = listPolygon.infoPolyHead

            While Not (node Is Nothing)
                Vertex = node.infoPolyData.infoHead

                If Vertex Is Nothing Then
                    node = node.infoPolyRef

                Else
                    sb.AppendLine(node.infoPolyName)
                    While Not (Vertex Is Nothing)
                        Dim str As String = CStr(Vertex.infoX) + "," + CStr(Vertex.infoY)
                        sb.AppendLine(str)
                        Vertex = Vertex.infoRef
                        If Vertex Is Nothing Then
                            sb.AppendLine(" ")
                        End If
                    End While
                    node = node.infoPolyRef

                End If
            End While

            System.IO.File.WriteAllText(path, sb.ToString())
        End If
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        draw = False
        colorize = False
        edit = False
        add = False

        If cmbPolyList.Items.Count = 0 Then
            dialogOpenFile.Title = "Open a Text File"
            dialogOpenFile.Filter = "Text Files (*.txt)|*.txt"
            Dim title As Boolean = False
            Dim inputPoly As New LLPolygon
            If dialogOpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim path As String = dialogOpenFile.FileName

                If File.ReadAllText(path).Length = 0 Then
                    MessageBox.Show("txt file is empty!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim text As String() = File.ReadAllLines(path)
                cmbPolyList.Enabled = True

                For Each line In text
                    Dim res As String() = line.Split(New String() {" "}, StringSplitOptions.None)
                    If res(0) = "Polygon" Then
                        If text(1) Then
                            Dim currentPoly As New LLPolygon
                            currentPoly.init()
                            inputPoly = currentPoly
                            inputPoly.init()
                            listPolygon.addPolyFirstComp(line, inputPoly)
                            title = True
                            cmbPolyList.Items.Add(line)

                            numberPolygon = CInt(res(1)) + 1

                        Else
                            Dim currentPoly As New LLPolygon
                            currentPoly.init()
                            inputPoly = currentPoly
                            inputPoly.init()
                            listPolygon.addPolyLastComp(line, inputPoly)
                            title = True
                            cmbPolyList.Items.Add(line)

                            numberPolygon = CInt(res(1)) + 1

                        End If

                    ElseIf res(0) = "Polyline" Then
                        If text(1) Then
                            Dim currentPoly As New LLPolygon
                            currentPoly.init()
                            inputPoly = currentPoly
                            inputPoly.init()
                            listPolygon.addPolyFirstComp(line, inputPoly)
                            title = True
                            cmbPolyList.Items.Add(line)

                            numberPolyline = CInt(res(1)) + 1

                        Else
                            Dim currentPoly As New LLPolygon
                            currentPoly.init()
                            inputPoly = currentPoly
                            inputPoly.init()
                            listPolygon.addPolyLastComp(line, inputPoly)
                            title = True
                            cmbPolyList.Items.Add(line)

                            numberPolyline = CInt(res(1)) + 1

                        End If

                    ElseIf String.IsNullOrWhiteSpace(line) Then
                        Continue For

                    Else
                        If title = True Then
                            Dim resPoint As String() = line.Split(New String() {","}, StringSplitOptions.None)
                            p.SetPoint(resPoint(0), resPoint(1))
                            inputPoly.addFirstPoint(p)
                            title = False
                            lsbPoint.Items.Add(line)
                        Else
                            Dim resPoint As String() = line.Split(New String() {","}, StringSplitOptions.None)
                            p.SetPoint(resPoint(0), resPoint(1))
                            inputPoly.addLastPoint(p)
                            lsbPoint.Items.Add(line)
                        End If
                    End If
                Next

                cmbPolyList.SelectedIndex = 0
                button(True)
                buttonCalculation(True)
                node = listPolygon.infoPolyHead
                reDraw(node)
                canvas.Refresh()
            End If
        Else

            Dim response As Integer = MessageBox.Show("There is object inside, do you want to save file?", "Save file?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

            If response = vbYes Then
                saveFile()
                btnClear.PerformClick()

            ElseIf response = vbNo Then
                btnClear.PerformClick()
                btnOpenFile.PerformClick()

            End If
        End If
    End Sub

    Private Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
        draw = False
        colorize = False
        edit = False
        add = False

        saveFile()
    End Sub

    Private Sub cmbPolyList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPolyList.SelectedIndexChanged
        lsbPoint.Items.Clear()

        Dim name As String = cmbPolyList.SelectedItem.ToString

        node = listPolygon.infoPolyHead

        While Not (node Is Nothing)
            If node.infoPolyName = name Then
                Vertex = node.infoPolyData.infoHead
                While Not (Vertex Is Nothing)
                    lsbPoint.Items.Add(printPoint(Vertex.infoData))
                    Vertex = Vertex.infoRef
                End While
            End If
            node = node.infoPolyRef
        End While
    End Sub
End Class