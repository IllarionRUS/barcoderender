//-----------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Zen Design">
//     Copyright (c) Zen Design 2008. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Zen.SampleSite
{
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
    using Zen.Barcode;
    using System.Collections.Generic;

    /// <summary>
    /// Provides functionality for the default site page.
    /// </summary>
    public partial class DefaultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Setup data-source for symbology dropdown
                List<string> symbologyDataSource = new List<string>(
                    Enum.GetNames(typeof(BarcodeSymbology)));
                symbologyDataSource.Remove("Unknown");
                barcodeSymbology.DataSource = symbologyDataSource;
                barcodeSymbology.DataBind();
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            BarcodeSymbology symbology = BarcodeSymbology.Unknown;
            if (barcodeSymbology.SelectedIndex != -1)
            {
                symbology = (BarcodeSymbology) barcodeSymbology.SelectedIndex + 1;
            }
            string text = barcodeText.Text.Trim();

            if (!string.IsNullOrEmpty(text) && symbology != BarcodeSymbology.Unknown)
            {
                barcodeRender.BarcodeEncoding = symbology;
                barcodeRender.Text = text;
            }
        }
    }
}
