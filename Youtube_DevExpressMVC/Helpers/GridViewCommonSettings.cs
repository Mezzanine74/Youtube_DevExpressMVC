using DevExpress.Web;
using DevExpress.Web.Mvc;
using System.Web.UI.WebControls;

namespace YoutubeDevExpressMVC.Web.Helpers
{
    public class GridViewCommonSettings
    {
        public static void SetSettings(GridViewSettings settings)
        {
            settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow;
            settings.SettingsBehavior.ConfirmDelete = true;

            settings.CommandColumn.Visible = true;
            settings.CommandColumn.ShowNewButton = false;
            settings.CommandColumn.ShowDeleteButton = true;
            settings.CommandColumn.ShowEditButton = true;
            settings.CommandColumn.ShowNewButtonInHeader = true;

            settings.KeyFieldName = "Id";

            settings.Width = Unit.Pixel(800);
            settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.Control;
            settings.SettingsBehavior.AllowEllipsisInText = true;

            settings.SettingsPager.Visible = true;
            settings.Settings.ShowGroupPanel = false;
            settings.Settings.ShowFilterRow = false;
            settings.SettingsBehavior.AllowSelectByRowClick = false;

            settings.Settings.ShowHeaderFilterButton = true;
            settings.SettingsPopup.HeaderFilter.Height = 300;
            settings.SettingsPopup.HeaderFilter.SettingsAdaptivity.MinHeight = 300;


            settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.Off;
            settings.SettingsAdaptivity.AdaptiveColumnPosition = GridViewAdaptiveColumnPosition.Right;
            settings.SettingsAdaptivity.AdaptiveDetailColumnCount = 1;
            settings.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = false;
            settings.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 0;

        }
    }
}