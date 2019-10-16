<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.LButton = New System.Windows.Forms.Button()
        Me.UButton = New System.Windows.Forms.Button()
        Me.CFButton = New System.Windows.Forms.Button()
        Me.PBox = New System.Windows.Forms.TextBox()
        Me.FPBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LButton
        '
        Me.LButton.Location = New System.Drawing.Point(16, 12)
        Me.LButton.Name = "LButton"
        Me.LButton.Size = New System.Drawing.Size(78, 27)
        Me.LButton.TabIndex = 2
        Me.LButton.Text = "Lock"
        Me.LButton.UseVisualStyleBackColor = True
        '
        'UButton
        '
        Me.UButton.Location = New System.Drawing.Point(16, 45)
        Me.UButton.Name = "UButton"
        Me.UButton.Size = New System.Drawing.Size(78, 27)
        Me.UButton.TabIndex = 3
        Me.UButton.Text = "Unlock"
        Me.UButton.UseVisualStyleBackColor = True
        '
        'CFButton
        '
        Me.CFButton.Location = New System.Drawing.Point(16, 78)
        Me.CFButton.Name = "CFButton"
        Me.CFButton.Size = New System.Drawing.Size(78, 27)
        Me.CFButton.TabIndex = 1
        Me.CFButton.Text = "Choose File"
        Me.CFButton.UseVisualStyleBackColor = True
        '
        'PBox
        '
        Me.PBox.Location = New System.Drawing.Point(112, 45)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(93, 20)
        Me.PBox.TabIndex = 0
        '
        'FPBox
        '
        Me.FPBox.Location = New System.Drawing.Point(12, 111)
        Me.FPBox.Name = "FPBox"
        Me.FPBox.Size = New System.Drawing.Size(189, 20)
        Me.FPBox.TabIndex = 99
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(128, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "File Path"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(226, 166)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FPBox)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.CFButton)
        Me.Controls.Add(Me.UButton)
        Me.Controls.Add(Me.LButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LButton As Button
    Friend WithEvents UButton As Button
    Friend WithEvents CFButton As Button
    Friend WithEvents PBox As TextBox
    Friend WithEvents FPBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
