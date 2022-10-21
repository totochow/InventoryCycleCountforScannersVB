Imports System.Data.Entity
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin


Public Class CompanyDbContext
    'Inherits IdentityDbContext(Of ApplicationUser)
    Inherits DbContext
    Public Sub New()
        MyBase.New("CompanyDBContext")
    End Sub

    Public Shared Function Create() As CompanyDbContext
        Return New CompanyDbContext()
    End Function
    Public Overridable Property MIUSERs As DbSet(Of MIUSER)
    Public Overridable Property MIMOHs As DbSet(Of MIMOH)
    Public Overridable Property MIPIBHs As DbSet(Of MIPIBH)
    Public Overridable Property MIPIBDs As DbSet(Of MIPIBD)
End Class

