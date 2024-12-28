namespace Trial.Project.Permissions;

public static class ProjectPermissions
{
    public const string GroupName = "Project";
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";


    public static class Books 
    {
        public const string Default = GroupName + ".Books";
        public const string Create = GroupName + ".Create";
        public const string Edit = GroupName + ".Edit";
        public const string Delete = GroupName + ".Delete";
    }

    /*public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = GroupName + ".Create";
        public const string Edit = GroupName + ".Edit";
        public const string Delete = GroupName + ".Delete";
    }*/
}
