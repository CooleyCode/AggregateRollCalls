/// <summary>
/// Main definition of this class will be in auto generatd file. Use this to define 
/// any additional information needed.
/// 
/// XML file format parsing data from http://clerk.house.gov/legislative/legvotes.aspx
/// 
/// </summary>
public partial class rollcallvote
{
    /// <summary>
    /// Property tp use as single comlumn header to describe the roll call.
    /// The year and roll call number should define a unique reference
    /// </summary>
    public string RollCallId
    {
        get
        {
            var date = votemetadata.actiondate.Substring(votemetadata.actiondate.Length - 4);  // length always greater than 4
            return $"{date} {votemetadata.rollcallnum}";
        }
    }
}
