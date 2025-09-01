<%@ Application Language="VB" %>

<script runat="server">

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        'TODO: for test only!!!
        'Zulu.Security.Factory.UserProvider.ForceLogin("naruboworn.pi ")
        ' Code that runs when a new session is started
     
    End Sub
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)      
        'register Zulu file store provider to provider cache for fastest access
         
        
        Zulu.Provider.ProviderCache.RegisterProvider(Of Zulu.Storage.FileStorage)(Zulu.Storage.FileStorage.ProviderID)
    
	    Zulu.Security.Factory.RegisterUserProvider(New Zulu.Security.AdUserProvider("LDAP://10.200.10.11"))
        Zulu.Security.Factory.RegisterRoleProvider(New Zulu.Security.DbRoleProvider())
        
        'start Zulu url routing
        Zulu.Web.Factory.Start()
        
        
        Dim p As System.Reflection.PropertyInfo = GetType(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.[Public] Or System.Reflection.BindingFlags.[Static])

        Dim o As Object = p.GetValue(Nothing, Nothing)

        Dim f As System.Reflection.FieldInfo = o.[GetType]().GetField("_dirMonSubdirs", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.IgnoreCase)

        Dim monitor As Object = f.GetValue(o)

        Dim m As System.Reflection.MethodInfo = monitor.[GetType]().GetMethod("StopMonitoring", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        m.Invoke(monitor, New Object() {})

    End Sub


   
       
</script>