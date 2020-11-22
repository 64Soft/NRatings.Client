using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace NRatings.Client.GUI
{
    /// <summary>
    /// (eraghi)
    /// Custom CheckedListBox with binding facilities (Value property)
    /// </summary>
    [ToolboxBitmap(typeof(CheckedListBox))]
    public class cCheckedListBox : CheckedListBox
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public cCheckedListBox()
        {
            this.CheckOnClick = true;

        }



        /// <summary>
        ///    Gets or sets the property to display for this CustomControls.CheckedListBox.
        ///
        /// Returns:
        ///     A System.String specifying the name of an object property that is contained
        ///     in the collection specified by the CustomControls.CheckedListBox.DataSource
        ///     property. The default is an empty string ("").
        /// </summary>
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string DisplayMember
        {
            get
            {
                return base.DisplayMember;
            }
            set
            {
                base.DisplayMember = value;

            }
        }

        /// <summary>
        ///    Gets or sets the property to get the values for this CustomControls.CheckedListBox.
        ///
        /// Returns:
        ///     A System.String specifying the name of an object property that is contained
        ///     in the collection specified by the CustomControls.CheckedListBox.DataSource
        ///     property. The default is an empty string ("").
        /// </summary>
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string ValueMember
        {
            get
            {
                return base.ValueMember;
            }
            set
            {
                base.ValueMember = value;

            }
        }


        /// <summary>
        /// Gets or sets the data source for this CustomControls.CheckedListBox.
        /// Returns:
        ///    An object that implements the System.Collections.IList or System.ComponentModel.IListSource
        ///    interfaces, such as a System.Data.DataSet or an System.Array. The default
        ///    is null.
        ///
        ///Exceptions:
        ///  System.ArgumentException:
        ///    The assigned value does not implement the System.Collections.IList or System.ComponentModel.IListSource
        ///    interfaces.
        /// </summary>
        [DefaultValue("")]
        [AttributeProvider(typeof(IListSource))]
        [RefreshProperties(RefreshProperties.All)]
        [Browsable(true)]
        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;

            }
        }

        ///// <summary>
        ///// Gets and sets an integer array of the values based on checked items values ID
        ///// </summary>
        //[Bindable(true), Browsable(true)]
        //public List<int> ValueList
        //{
        //    get
        //    {
        //        ///Gets checked items id values in a list
        //        List<int> retArray = new List<int>();
        //        PropertyDescriptor prop = null;
        //        PropertyDescriptorCollection  propList = this.DataManager.GetItemProperties();
        //        prop = propList.Find(this.ValueMember, false);
        //        object checkedItem;
        //        if (prop != null)
        //        {
        //            for (int i = 0; i < this.Items.Count; i++)
        //            {
        //                if (this.GetItemChecked(i))
        //                {
        //                    checkedItem = this.DataManager.List[i];
        //                    retArray.Add(Convert.ToInt32(prop.GetValue(checkedItem).ToString()));
        //                }
        //            }
        //        }
        //        return retArray;
        //    }

        //    set
        //    {
        //        ///Sets checked items base on id values in a list
        //        List<int> myList = value;
        //        PropertyDescriptor prop = null;
        //        PropertyDescriptorCollection propList = this.DataManager.GetItemProperties();
        //        prop = propList.Find(this.ValueMember, false);
        //        object checkedItem;
        //        int intValItem;
        //        int found;
        //        if (prop != null)
        //        {
        //            for (int i = 0; i < this.Items.Count; i++)
        //            {
        //                checkedItem = this.DataManager.List[i];
        //                intValItem = Convert.ToInt32( prop.GetValue(checkedItem).ToString() );
        //                found = (from c in myList where c == intValItem  select c).Count();
        //                if ( found==1 )
        //                    this.SetItemCheckState(i, CheckState.Checked);
        //                else
        //                    this.SetItemCheckState(i, CheckState.Unchecked);
        //            }
        //        }
        //    }
        //}
    }
}
