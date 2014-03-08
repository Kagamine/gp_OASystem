using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace OASystem.UI.Ajax
{
    public partial class FIles_GetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Filename = Request.QueryString["Filename"].ToString();
            var Uploader = Request.QueryString["Uploader"].ToString();
            var Page = Convert.ToInt32(Request.QueryString["Page"]);
            using (Dal.DB db = new Dal.DB())
            {
                var files = (from f in db.Uploads
                             where f.Filename.Contains(Filename)
                             && f.User.Name.Contains(Uploader)
                             orderby f.Time descending
                             select f).ToList();
                if (Session["User"] == null || (Session["User"] as Entity.User).Role < Entity.UserRole.Root)
                {
                    files = files.Where(x => x.Type == Entity.UploadType.Public).ToList();
                }
                List<FileListItem> lst = new List<FileListItem>();
                files = files.Skip(20 * Page).Take(20).ToList();
                foreach (var f in files)
                {
                    lst.Add(new FileListItem() { 
                        ID = f.ID,
                        Filename = f.Filename,
                        Time = f.Time,
                        Size = f.Size,
                        Uploader = f.User.Name
                    });
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Response.Write(jss.Serialize(lst));
            }
        }
    }
    class FileListItem
    {
        public int ID { get; set; }
        public string Uploader { get; set; }
        public string Filename { get; set; }
        public int Size { get; set; }
        public DateTime Time { get; set; }
    }
}