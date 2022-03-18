﻿Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub RemoveConstraint _
    (constraints As ConstraintCollection, constraint As Constraint)

    If constraints.Contains(constraint.ConstraintName) Then
        If constraints.CanRemove(constraint) Then
            constraints.Remove(constraint.ConstraintName)
        End If
    End If
End Sub
' </Snippet1>
End Class
