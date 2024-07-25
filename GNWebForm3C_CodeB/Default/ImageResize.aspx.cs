using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GNForm3C;

public partial class ImageResize : System.Web.UI.Page
{

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateThumnail();
    }
    #endregion Page Load

    private Boolean ThumbnailCallback()
    {
        return false;
    }

    private void CreateThumnail()
    {
        //'Read in the image filename to create a thumbnail of

        String imageUrl = "~/Images/NoPhotoAvailable.jpg";

        if (Request.QueryString["imageUrl"] != null)
            imageUrl = CommonFunctions.DecryptBase64(Request.QueryString["imageUrl"]);

        //if (imageUrl == String.Empty)
        //{
        //    imageUrl = "~/Images/NoPhotoAvailable.jpg";
        //}
        imageUrl = Server.UrlDecode(imageUrl);

        //'Read in the width and height
        Int32 imageHeight = 50;
        Int32 imageWidth = 50;

        if (Request.QueryString["imageWidth"] != null)
            imageWidth = CommonFunctions.DecryptBase64Int32(Request.QueryString["imageWidth"]).Value;

        if (Request.QueryString["imageHeight"] != null)
            imageHeight = CommonFunctions.DecryptBase64Int32(Request.QueryString["imageHeight"]).Value;

        //'Make sure that the image URL doesn't contain any /'s or \'s
        //if (imageUrl.IndexOf("/") >= 0 || imageUrl.IndexOf("\"") >= 0)
        //{
        //    //'We found a / or \
        //    Response.End();
        //}

        System.Drawing.Image fullSizeImg;
        fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imageUrl));

        if (fullSizeImg == null)
            return;

        Decimal Ratio = 1;
        if (Convert.ToDecimal(fullSizeImg.Width / imageWidth) > Convert.ToDecimal(fullSizeImg.Height / imageHeight))
        {
            Ratio = Convert.ToDecimal(fullSizeImg.Width) / Convert.ToDecimal(imageWidth);
        }
        else
        {
            Ratio = Convert.ToDecimal(fullSizeImg.Height) / Convert.ToDecimal(imageHeight);
        }

        if (Ratio <= 0)
        {
            Ratio = 1;
        }

        imageHeight = Convert.ToInt32(fullSizeImg.Height / Ratio);
        imageWidth = Convert.ToInt32(fullSizeImg.Width / Ratio);

        //'Do we need to create a thumbnail?
        Response.ContentType = "image/Png";
        //imageHeight = 250;
        //imageWidth = 250;


        if (imageHeight > 0 && imageWidth > 0)
        {
            System.Drawing.Image.GetThumbnailImageAbort dumyCallback;
            dumyCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

            System.Drawing.Image thumbNailImg;

            thumbNailImg = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dumyCallback, IntPtr.Zero);
            thumbNailImg.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
        }
        else
        {
            fullSizeImg.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
        }
        fullSizeImg.Dispose();
    }
}
