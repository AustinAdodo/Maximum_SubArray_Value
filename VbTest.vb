'Imports System.Collections.Generic
'Imports System.Runtime.CompilerServices
'
'Module Maximum_SubArray_Value
'    Public Class VbTests
'        Public Function Test(a As Integer) As Integer
'            Dim sample As New List(Of String)
'            Dim dic As New Dictionary(Of String, Integer)
'            If a > 6
'                dic.Add("Six", 7)
'            Else
'                dic.Remove("Six", 5)
'            End If
'            Dim result As Integer
'            ' Perform some operation using parameter 'a'
'            Return result
'        End Function
'    End Class
'' Example of Private Protected access modifier
'    Public Class VbTests2
'        Private Protected Sub MyMethod()
'            ' Private Protected method accessible within the same assembly and by derived classes in the same assembly
'        End Sub
'    End Class
'
'    Public Class MyDerivedClass
'        Inherits VbTests2
'
'        Public Sub AccessMyMethod()
'            MyMethod() ' Accessing Private Protected method from the base class
'        End Sub
'
'        Friend Sub MyMethod()
'            ' Internal method accessible only within the same assembly
'        End Sub
'    End Class
'' Example of Protected Friend access modifier
'    Public Class MyBaseClass
'        Protected Friend Sub MyMethod()
'            ' Protected Friend method accessible within the same assembly and by derived classes
'        End Sub
'    End Class
'
'    Public Class MyDerivedClass2
'        Inherits MyBaseClass
'
'        Public Sub AccessMyMethod()
'            MyMethod() ' Accessing Protected Friend method from the base class
'        End Sub
'    End Class
'End Module
'
