Imports System
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Namespace Check_BR
    Public Class [Get]
        Public Shared Function EnderecoMAC1() As String
            Try
                Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
                Dim enderecoMAC As String = String.Empty

                For Each adapter As NetworkInterface In nics

                    If enderecoMAC = String.Empty Then
                        Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
                        enderecoMAC = adapter.GetPhysicalAddress().ToString()
                    End If
                Next

                Return enderecoMAC
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function EnderecoMAC2() As PhysicalAddress
            Try

                For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()

                    If nic.NetworkInterfaceType = NetworkInterfaceType.Ethernet AndAlso nic.OperationalStatus = OperationalStatus.Up Then
                        Return nic.GetPhysicalAddress()
                    End If
                Next

                Return Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function EnderecoMAC3() As PhysicalAddress
            For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()

                If nic.OperationalStatus = OperationalStatus.Up AndAlso (Not nic.Description.Contains("Virtual") AndAlso Not nic.Description.Contains("Pseudo")) Then
                    If nic.GetPhysicalAddress().ToString() <> "" Then Return nic.GetPhysicalAddress()
                End If
            Next

            Return Nothing
        End Function

        'Public Shared Function FileChecksum(ByVal file As String, ByVal algorithm As HashAlgorithm) As String
        '    Try
        '        Dim result As String = String.Empty

        '        Using fs As FileStream = file.OpenRead(file)
        '            result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "")
        '        End Using

        '        Return result
        '    Catch
        '    End Try

        '    Return Nothing
        'End Function
    End Class
End Namespace
