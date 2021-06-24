Public Class LinkedList
    Public Structure Points
        Dim hor As Double
        Dim ver As Double

        Public Sub SetPoint(ByVal px As Double, ByVal py As Double)
            hor = px
            ver = py
        End Sub
    End Structure

    Public Class NPoint
        Private data As Points
        Private ref As NPoint

        Property infoData() As Points
            Get
                Return data
            End Get
            Set(ByVal value As Points)
                data = value
            End Set
        End Property

        Property infoRef() As NPoint
            Get
                Return ref
            End Get
            Set(ByVal value As NPoint)
                ref = value
            End Set
        End Property

        Property infoX() As Double
            Get
                Return data.hor
            End Get
            Set(ByVal value As Double)
                data.hor = value
            End Set
        End Property

        Property infoY() As Double
            Get
                Return data.ver
            End Get
            Set(ByVal value As Double)
                data.ver = value
            End Set
        End Property
    End Class

    Public Class LLPolygon
        Private head As NPoint

        Public Sub init()
            head = Nothing
        End Sub

        Property infoHead() As NPoint
            Get
                Return head
            End Get
            Set(ByVal value As NPoint)
                head = value
            End Set
        End Property

        Public Sub addFirstPoint(ByVal P As Points)
            Dim gon As NPoint


            gon = New NPoint
            gon.infoData = P
            gon.infoRef = Nothing

            addFirstEdge(gon)
        End Sub

        Public Sub addFirstEdge(ByVal N As NPoint)
            N.infoRef = head
            head = N
        End Sub

        Public Sub addLastPoint(ByVal P As Points)
            Dim gon As NPoint

            gon = New NPoint
            gon.infoData = P

            addLastEdge(gon)
        End Sub

        Public Sub addLastEdge(ByVal N As NPoint)
            Dim currNode As NPoint
            currNode = head

            If currNode Is Nothing Then
                head = N
                N.infoRef = Nothing
            Else
                While Not (currNode.infoRef Is Nothing)
                    currNode = currNode.infoRef
                End While
                currNode.infoRef = N
                N.infoRef = Nothing
            End If
        End Sub

        Private Function find(ByVal item As Points) As NPoint
            Dim currNode As New NPoint
            currNode = head
            While Not (currNode.infoData.Equals(item))
                currNode = currNode.infoRef
            End While
            Return currNode
        End Function

        Public Overloads Sub addNodeAfter(ByVal P As Points, ByVal Pnew As Points)
            Dim currNode As NPoint = find(P)
            Dim newNode As New NPoint

            newNode.infoData = Pnew
            newNode.infoRef = currNode.infoRef
            currNode.infoRef = newNode
        End Sub

        Public Sub editNode(ByVal P As Points, ByVal newPoint As Points)
            Dim tempNode As NPoint = find(P)
            tempNode.infoData = newPoint
        End Sub

        Private Function findPrev(ByVal x As Points) As NPoint
            Dim currNode As NPoint = head
            While (Not (currNode.infoRef Is Nothing) And Not (currNode.infoRef.infoData.Equals(x)))
                    currNode = currNode.infoRef
            End While

            Return currNode
        End Function

        Public Sub deleteNode(ByVal P As Points)
            If head.infoData.Equals(P) Then
                head = head.infoRef
            Else
                Dim tempNode As NPoint = findPrev(P)
                If (Not (tempNode.infoRef Is Nothing)) Then
                    tempNode.infoRef = tempNode.infoRef.infoRef
                End If
            End If
        End Sub
    End Class
    Public Class LLPolygons
        Private polyHead As NPolygon

        Public Sub init()
            polyHead = Nothing
        End Sub

        Property infoPolyHead() As NPolygon
            Get
                Return polyHead
            End Get
            Set(ByVal value As NPolygon)
                polyHead = value
            End Set
        End Property

        Public Sub addPolyFirstComp(ByVal namePoly As String, ByVal llPoly As LLPolygon)
            Dim polygon As NPolygon

            polygon = New NPolygon
            polygon.infoPolyName = namePoly
            polygon.infoPolyData = llPoly
            polygon.infoPolyRef = Nothing

            addPolyFirst(polygon)
        End Sub

        Public Sub addPolyFirst(ByVal Poly As NPolygon)
            Poly.infoPolyRef = polyHead
            polyHead = Poly
        End Sub

        Public Sub addPolyLastComp(ByVal namePoly As String, ByVal llPoly As LLPolygon)
            Dim polygon As NPolygon

            polygon = New NPolygon
            polygon.infoPolyName = namePoly
            polygon.infoPolyData = llPoly

            addPolyLast(polygon)
        End Sub

        Public Sub addPolyLast(ByVal Poly As NPolygon)
            Dim currNode As NPolygon
            currNode = polyHead

            If currNode Is Nothing Then
                polyHead = Poly
                Poly.infoPolyRef = Nothing
            Else
                While Not (currNode.infoPolyRef Is Nothing)
                    currNode = currNode.infoPolyRef
                End While
                currNode.infoPolyRef = Poly
                Poly.infoPolyRef = Nothing
            End If
        End Sub

        Public Function Find(ByVal itemPoly As LLPolygon) As NPolygon
            Dim currPoly As New NPolygon
            currPoly = polyHead
            While Not (currPoly.infoPolyData.Equals(itemPoly))
                currPoly = currPoly.infoPolyRef
            End While
            Return currPoly
        End Function

        Public Sub addPolyAfter(ByVal newPoly As LLPolygon, ByVal afterPoly As LLPolygon)
            Dim currPoly As New NPolygon
            Dim newNodePoly As New NPolygon
            newNodePoly.infoPolyData = newPoly

            currPoly = Find(afterPoly)
            newNodePoly.infoPolyRef = currPoly.infoPolyRef
            currPoly.infoPolyRef = newNodePoly
        End Sub

        Public Sub editPolyNode(ByVal P As LLPolygon, ByVal newLL As LLPolygon)
            Dim tempNode As NPolygon = Find(P)
            tempNode.infoPolyData = newLL
        End Sub

        Private Function findPrev(ByVal Poly As LLPolygon) As NPolygon
            Dim currNode As NPolygon = polyHead
            While (Not (currNode.infoPolyRef Is Nothing) And Not (currNode.infoPolyRef.infoPolyData.Equals(Poly)))
                currNode = currNode.infoPolyRef
            End While
            Return currNode
        End Function

        Public Sub detelePolyNode(ByVal Poly As LLPolygon)
            If polyHead.infoPolyData.Equals(Poly) Then
                polyHead = polyHead.infoPolyRef
            Else
                Dim tempNode As NPolygon = findPrev(Poly)
                If (Not (tempNode.infoPolyRef Is Nothing)) Then
                    tempNode.infoPolyRef = tempNode.infoPolyRef.infoPolyRef
                End If
            End If
        End Sub
    End Class

    Public Class NPolygon
        Private polyName As String
        Private polyData As LLPolygon
        Private polyRef As NPolygon

        Property infoPolyName() As String
            Get
                Return polyName
            End Get
            Set(ByVal value As String)
                polyName = value
            End Set
        End Property

        Property infoPolyData() As LLPolygon
            Get
                Return polyData
            End Get
            Set(ByVal value As LLPolygon)
                polyData = value
            End Set
        End Property

        Property infoPolyRef() As NPolygon
            Get
                Return polyRef
            End Get
            Set(ByVal value As NPolygon)
                polyRef = value
            End Set
        End Property
    End Class
End Class