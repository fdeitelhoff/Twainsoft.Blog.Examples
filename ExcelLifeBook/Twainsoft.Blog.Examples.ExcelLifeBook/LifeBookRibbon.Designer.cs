namespace Twainsoft.Blog.Examples.ExcelLifeBook
{
    partial class LifeBookRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public LifeBookRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.LifeBookTab = this.Factory.CreateRibbonTab();
            this.Visualization = this.Factory.CreateRibbonGroup();
            this.CreateLifeBook = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.LifeBookTab.SuspendLayout();
            this.Visualization.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // LifeBookTab
            // 
            this.LifeBookTab.Groups.Add(this.Visualization);
            this.LifeBookTab.Label = "Life Book";
            this.LifeBookTab.Name = "LifeBookTab";
            // 
            // Visualization
            // 
            this.Visualization.Items.Add(this.CreateLifeBook);
            this.Visualization.Label = "Visualization";
            this.Visualization.Name = "Visualization";
            // 
            // CreateLifeBook
            // 
            this.CreateLifeBook.Label = "Create Life Book";
            this.CreateLifeBook.Name = "CreateLifeBook";
            this.CreateLifeBook.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CreateLifeBook_Click);
            // 
            // LifeBookRibbon
            // 
            this.Name = "LifeBookRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.LifeBookTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.LifeBookRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.LifeBookTab.ResumeLayout(false);
            this.LifeBookTab.PerformLayout();
            this.Visualization.ResumeLayout(false);
            this.Visualization.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab LifeBookTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Visualization;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CreateLifeBook;
    }

    partial class ThisRibbonCollection
    {
        internal LifeBookRibbon LifeBookRibbon
        {
            get { return this.GetRibbon<LifeBookRibbon>(); }
        }
    }
}
