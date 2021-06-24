<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.canvas = New System.Windows.Forms.PictureBox()
        Me.AreaPanel = New System.Windows.Forms.Panel()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.rbConvexity = New System.Windows.Forms.RadioButton()
        Me.rbArea = New System.Windows.Forms.RadioButton()
        Me.rbPerimeter = New System.Windows.Forms.RadioButton()
        Me.cmbPolyList = New System.Windows.Forms.ComboBox()
        Me.btnPenColor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsbPoint = New System.Windows.Forms.ListBox()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnDeleteObject = New System.Windows.Forms.Button()
        Me.btnDeleteVertex = New System.Windows.Forms.Button()
        Me.btnEditVertex = New System.Windows.Forms.Button()
        Me.btnAddVertex = New System.Windows.Forms.Button()
        Me.btnPolyline = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPolygon = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblArea = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuBar = New System.Windows.Forms.ToolStrip()
        Me.btnOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveFile = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblInfo = New System.Windows.Forms.ToolStripLabel()
        Me.dialogOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.dialogSaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.dialogColor = New System.Windows.Forms.ColorDialog()
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AreaPanel.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.MenuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'canvas
        '
        Me.canvas.BackColor = System.Drawing.Color.White
        Me.canvas.Cursor = System.Windows.Forms.Cursors.Cross
        Me.canvas.Location = New System.Drawing.Point(-1, 28)
        Me.canvas.Name = "canvas"
        Me.canvas.Size = New System.Drawing.Size(1065, 519)
        Me.canvas.TabIndex = 0
        Me.canvas.TabStop = False
        '
        'AreaPanel
        '
        Me.AreaPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.AreaPanel.Controls.Add(Me.btnCalculate)
        Me.AreaPanel.Controls.Add(Me.rbConvexity)
        Me.AreaPanel.Controls.Add(Me.rbArea)
        Me.AreaPanel.Controls.Add(Me.rbPerimeter)
        Me.AreaPanel.Controls.Add(Me.cmbPolyList)
        Me.AreaPanel.Controls.Add(Me.btnPenColor)
        Me.AreaPanel.Controls.Add(Me.Label1)
        Me.AreaPanel.Controls.Add(Me.lsbPoint)
        Me.AreaPanel.Controls.Add(Me.btnColor)
        Me.AreaPanel.Controls.Add(Me.btnDeleteObject)
        Me.AreaPanel.Controls.Add(Me.btnDeleteVertex)
        Me.AreaPanel.Controls.Add(Me.btnEditVertex)
        Me.AreaPanel.Controls.Add(Me.btnAddVertex)
        Me.AreaPanel.Controls.Add(Me.btnPolyline)
        Me.AreaPanel.Controls.Add(Me.btnClear)
        Me.AreaPanel.Controls.Add(Me.btnPolygon)
        Me.AreaPanel.Controls.Add(Me.StatusStrip)
        Me.AreaPanel.Location = New System.Drawing.Point(-1, 545)
        Me.AreaPanel.Name = "AreaPanel"
        Me.AreaPanel.Size = New System.Drawing.Size(1065, 114)
        Me.AreaPanel.TabIndex = 1
        '
        'btnCalculate
        '
        Me.btnCalculate.BackColor = System.Drawing.SystemColors.Control
        Me.btnCalculate.Enabled = False
        Me.btnCalculate.FlatAppearance.BorderSize = 0
        Me.btnCalculate.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalculate.Location = New System.Drawing.Point(586, 57)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(130, 24)
        Me.btnCalculate.TabIndex = 16
        Me.btnCalculate.Text = "Find"
        Me.btnCalculate.UseVisualStyleBackColor = False
        '
        'rbConvexity
        '
        Me.rbConvexity.AutoSize = True
        Me.rbConvexity.Enabled = False
        Me.rbConvexity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbConvexity.Location = New System.Drawing.Point(586, 32)
        Me.rbConvexity.Name = "rbConvexity"
        Me.rbConvexity.Size = New System.Drawing.Size(77, 19)
        Me.rbConvexity.TabIndex = 15
        Me.rbConvexity.TabStop = True
        Me.rbConvexity.Text = "Convexity"
        Me.rbConvexity.UseVisualStyleBackColor = True
        '
        'rbArea
        '
        Me.rbArea.AutoSize = True
        Me.rbArea.Enabled = False
        Me.rbArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbArea.Location = New System.Drawing.Point(668, 10)
        Me.rbArea.Name = "rbArea"
        Me.rbArea.Size = New System.Drawing.Size(48, 19)
        Me.rbArea.TabIndex = 14
        Me.rbArea.TabStop = True
        Me.rbArea.Text = "Area"
        Me.rbArea.UseVisualStyleBackColor = True
        '
        'rbPerimeter
        '
        Me.rbPerimeter.AutoSize = True
        Me.rbPerimeter.Enabled = False
        Me.rbPerimeter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbPerimeter.Location = New System.Drawing.Point(586, 11)
        Me.rbPerimeter.Name = "rbPerimeter"
        Me.rbPerimeter.Size = New System.Drawing.Size(75, 19)
        Me.rbPerimeter.TabIndex = 13
        Me.rbPerimeter.TabStop = True
        Me.rbPerimeter.Text = "Perimeter"
        Me.rbPerimeter.UseVisualStyleBackColor = True
        '
        'cmbPolyList
        '
        Me.cmbPolyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPolyList.Enabled = False
        Me.cmbPolyList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPolyList.FormattingEnabled = True
        Me.cmbPolyList.Location = New System.Drawing.Point(743, 35)
        Me.cmbPolyList.Name = "cmbPolyList"
        Me.cmbPolyList.Size = New System.Drawing.Size(145, 23)
        Me.cmbPolyList.TabIndex = 12
        '
        'btnPenColor
        '
        Me.btnPenColor.BackColor = System.Drawing.SystemColors.Control
        Me.btnPenColor.FlatAppearance.BorderSize = 0
        Me.btnPenColor.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPenColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPenColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPenColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPenColor.Location = New System.Drawing.Point(354, 11)
        Me.btnPenColor.Name = "btnPenColor"
        Me.btnPenColor.Size = New System.Drawing.Size(87, 32)
        Me.btnPenColor.TabIndex = 9
        Me.btnPenColor.Text = "Pen Color"
        Me.btnPenColor.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(814, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Vertices List"
        '
        'lsbPoint
        '
        Me.lsbPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsbPoint.FormattingEnabled = True
        Me.lsbPoint.ItemHeight = 15
        Me.lsbPoint.Location = New System.Drawing.Point(893, 7)
        Me.lsbPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.lsbPoint.Name = "lsbPoint"
        Me.lsbPoint.Size = New System.Drawing.Size(161, 75)
        Me.lsbPoint.TabIndex = 10
        '
        'btnColor
        '
        Me.btnColor.BackColor = System.Drawing.SystemColors.Control
        Me.btnColor.Enabled = False
        Me.btnColor.FlatAppearance.BorderSize = 0
        Me.btnColor.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColor.Location = New System.Drawing.Point(354, 49)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(87, 32)
        Me.btnColor.TabIndex = 9
        Me.btnColor.Text = "Color"
        Me.btnColor.UseVisualStyleBackColor = False
        '
        'btnDeleteObject
        '
        Me.btnDeleteObject.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteObject.Enabled = False
        Me.btnDeleteObject.FlatAppearance.BorderSize = 0
        Me.btnDeleteObject.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDeleteObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDeleteObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteObject.Location = New System.Drawing.Point(229, 49)
        Me.btnDeleteObject.Name = "btnDeleteObject"
        Me.btnDeleteObject.Size = New System.Drawing.Size(87, 32)
        Me.btnDeleteObject.TabIndex = 8
        Me.btnDeleteObject.Text = "Delete Object"
        Me.btnDeleteObject.UseVisualStyleBackColor = False
        '
        'btnDeleteVertex
        '
        Me.btnDeleteVertex.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteVertex.Enabled = False
        Me.btnDeleteVertex.FlatAppearance.BorderSize = 0
        Me.btnDeleteVertex.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteVertex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDeleteVertex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDeleteVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteVertex.Location = New System.Drawing.Point(136, 49)
        Me.btnDeleteVertex.Name = "btnDeleteVertex"
        Me.btnDeleteVertex.Size = New System.Drawing.Size(87, 32)
        Me.btnDeleteVertex.TabIndex = 7
        Me.btnDeleteVertex.Text = "Delete Vertex"
        Me.btnDeleteVertex.UseVisualStyleBackColor = False
        '
        'btnEditVertex
        '
        Me.btnEditVertex.BackColor = System.Drawing.SystemColors.Control
        Me.btnEditVertex.Enabled = False
        Me.btnEditVertex.FlatAppearance.BorderSize = 0
        Me.btnEditVertex.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnEditVertex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEditVertex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEditVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditVertex.Location = New System.Drawing.Point(229, 11)
        Me.btnEditVertex.Name = "btnEditVertex"
        Me.btnEditVertex.Size = New System.Drawing.Size(87, 32)
        Me.btnEditVertex.TabIndex = 6
        Me.btnEditVertex.Text = "Edit Vertex"
        Me.btnEditVertex.UseVisualStyleBackColor = False
        '
        'btnAddVertex
        '
        Me.btnAddVertex.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddVertex.Enabled = False
        Me.btnAddVertex.FlatAppearance.BorderSize = 0
        Me.btnAddVertex.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnAddVertex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddVertex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddVertex.Location = New System.Drawing.Point(136, 11)
        Me.btnAddVertex.Name = "btnAddVertex"
        Me.btnAddVertex.Size = New System.Drawing.Size(87, 32)
        Me.btnAddVertex.TabIndex = 5
        Me.btnAddVertex.Text = "Add Vertex"
        Me.btnAddVertex.UseVisualStyleBackColor = False
        '
        'btnPolyline
        '
        Me.btnPolyline.BackColor = System.Drawing.SystemColors.Control
        Me.btnPolyline.FlatAppearance.BorderSize = 0
        Me.btnPolyline.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPolyline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPolyline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPolyline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPolyline.Location = New System.Drawing.Point(13, 49)
        Me.btnPolyline.Name = "btnPolyline"
        Me.btnPolyline.Size = New System.Drawing.Size(87, 32)
        Me.btnPolyline.TabIndex = 4
        Me.btnPolyline.Text = "Polyline"
        Me.btnPolyline.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(470, 49)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(87, 32)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnPolygon
        '
        Me.btnPolygon.BackColor = System.Drawing.SystemColors.Control
        Me.btnPolygon.FlatAppearance.BorderSize = 0
        Me.btnPolygon.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnPolygon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPolygon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPolygon.Location = New System.Drawing.Point(13, 11)
        Me.btnPolygon.Name = "btnPolygon"
        Me.btnPolygon.Size = New System.Drawing.Size(87, 32)
        Me.btnPolygon.TabIndex = 2
        Me.btnPolygon.Text = "Polygon"
        Me.btnPolygon.UseVisualStyleBackColor = False
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblArea})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 92)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1065, 22)
        Me.StatusStrip.Stretch = False
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblArea
        '
        Me.lblArea.BackColor = System.Drawing.SystemColors.Control
        Me.lblArea.Name = "lblArea"
        Me.lblArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblArea.Size = New System.Drawing.Size(31, 17)
        Me.lblArea.Text = "(-, -)"
        '
        'MenuBar
        '
        Me.MenuBar.BackColor = System.Drawing.SystemColors.Control
        Me.MenuBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenFile, Me.btnSaveFile, Me.toolStripSeparator1, Me.lblInfo})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(1064, 27)
        Me.MenuBar.TabIndex = 2
        Me.MenuBar.Text = "ToolStrip1"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpenFile.Image = CType(resources.GetObject("btnOpenFile.Image"), System.Drawing.Image)
        Me.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(24, 24)
        Me.btnOpenFile.Text = "&Open"
        '
        'btnSaveFile
        '
        Me.btnSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveFile.Image = CType(resources.GetObject("btnSaveFile.Image"), System.Drawing.Image)
        Me.btnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(24, 24)
        Me.btnSaveFile.Text = "&Save"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(0, 24)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 659)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.AreaPanel)
        Me.Controls.Add(Me.canvas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "illusDragonNRS"
        CType(Me.canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AreaPanel.ResumeLayout(False)
        Me.AreaPanel.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents canvas As PictureBox
    Friend WithEvents AreaPanel As Panel
    Friend WithEvents MenuBar As ToolStrip
    Friend WithEvents btnOpenFile As ToolStripButton
    Friend WithEvents btnSaveFile As ToolStripButton
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents lblArea As ToolStripStatusLabel
    Friend WithEvents btnPolygon As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDeleteObject As Button
    Friend WithEvents btnDeleteVertex As Button
    Friend WithEvents btnEditVertex As Button
    Friend WithEvents btnAddVertex As Button
    Friend WithEvents btnPolyline As Button
    Friend WithEvents btnColor As Button
    Friend WithEvents dialogOpenFile As OpenFileDialog
    Friend WithEvents dialogSaveFile As SaveFileDialog
    Friend WithEvents lsbPoint As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dialogColor As ColorDialog
    Friend WithEvents btnPenColor As Button
    Friend WithEvents cmbPolyList As ComboBox
    Friend WithEvents lblInfo As ToolStripLabel
    Friend WithEvents rbConvexity As RadioButton
    Friend WithEvents rbArea As RadioButton
    Friend WithEvents rbPerimeter As RadioButton
    Friend WithEvents btnCalculate As Button
End Class
