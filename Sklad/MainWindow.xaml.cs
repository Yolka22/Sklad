using Skald;
using System.Windows;
using System.Windows.Controls;


namespace Sklad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB db = null;

        //This code clears all the children of the Stack_Grocery object. 
        public void Refresh()
        {
            //Clear all the children of the Stack_Grocery object
            Stack_Products.Children.Clear();
            db.connection.Close();
            db.connection.Open();
        }

        public MainWindow()
        {
            db = new DB(@"localhost\SQLEXPRESS01", @"storage");
            InitializeComponent();
        }

        private void Show_All_Click(object sender, RoutedEventArgs e)
        {
            //Refresh the page
            Refresh();

            //Set the query to select all from the Products table
            db.Set_Quary("SELECT Products.*, Suppliers.SupplierName" +
                " FROM Products JOIN Suppliers ON" +
                " Products.SupplierID = Suppliers.SupplierID;");


            ListBox ProductID = new ListBox();
            ProductID.Width = 100;
            ListBox ProductName = new ListBox();
            ProductName.Width = 100;
            ListBox SupplierID = new ListBox();
            SupplierID.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;
            ListBox Cost = new ListBox();
            Cost.Width = 100;
            ListBox DeliveryDate = new ListBox();
            DeliveryDate.Width = 100;
            ListBox SupplierName = new ListBox();
            SupplierName.Width = 100;


            Stack_Products.Children.Add(ProductID);
            Stack_Products.Children.Add(ProductName);
            Stack_Products.Children.Add(SupplierID);
            Stack_Products.Children.Add(Quantity);
            Stack_Products.Children.Add(Cost);
            Stack_Products.Children.Add(DeliveryDate);
            Stack_Products.Children.Add(SupplierName);

            //Read the results from the query
            while (db.reader.Read())
            {

                ProductID.Items.Add(db.reader.GetInt32(0));
                ProductName.Items.Add(db.reader.GetString(1));
                SupplierID.Items.Add(db.reader.GetInt32(2));
                Quantity.Items.Add(db.reader.GetInt32(3));
                Cost.Items.Add(db.reader.GetDecimal(4));
                DeliveryDate.Items.Add(db.reader.GetDateTime(5));
                SupplierName.Items.Add(db.reader.GetString(6));


            }

                //Close the reader
                db.reader.Close();
        }

        private void Show_All_Types_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT DISTINCT ProductName FROM Products");

            ListBox ProductType = new ListBox();
            ProductType.Width = 100;

            Stack_Products.Children.Add(ProductType);

            while (db.reader.Read())
            {
                ProductType.Items.Add(db.reader.GetString(0));
            }

            //Close the reader
            db.reader.Close();
        }

        private void Show_All_Sup_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT DISTINCT SupplierName FROM Suppliers");

            ListBox SupplierName = new ListBox();
            SupplierName.Width = 100;

            Stack_Products.Children.Add(SupplierName);

            while (db.reader.Read())
            {
                SupplierName.Items.Add(db.reader.GetString(0));
            }

            //Close the reader
            db.reader.Close();
        }

        private void Show_MaxCount_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT TOP 1 ProductName, Quantity FROM Products ORDER BY Quantity DESC");

            ListBox Name = new ListBox();
            Name.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;

            Stack_Products.Children.Add(Name);
            Stack_Products.Children.Add(Quantity);

            while (db.reader.Read())
            {
                Name.Items.Add(db.reader.GetString(0));
                Quantity.Items.Add(db.reader.GetInt32(1));
            }

            //Close the reader
            db.reader.Close();
            
        }

        private void Show_MinCount_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT TOP 1 ProductName, Quantity FROM Products ORDER BY Quantity ASC");

            ListBox Name = new ListBox();
            Name.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;

            Stack_Products.Children.Add(Name);
            Stack_Products.Children.Add(Quantity);

            while (db.reader.Read())
            {
                Name.Items.Add(db.reader.GetString(0));
                Quantity.Items.Add(db.reader.GetInt32(1));
            }

            //Close the reader
            db.reader.Close();
        }

        private void Show_MinCost_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT TOP 1 ProductName, Cost FROM Products ORDER BY Cost ASC");

            ListBox Name = new ListBox();
            Name.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;

            Stack_Products.Children.Add(Name);
            Stack_Products.Children.Add(Quantity);

            while (db.reader.Read())
            {
                Name.Items.Add(db.reader.GetString(0));
                Quantity.Items.Add(db.reader.GetDecimal(1));
            }

            //Close the reader
            db.reader.Close();
        }

        private void Show_MaxCost_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT TOP 1 ProductName, Cost FROM Products ORDER BY Cost DESC");

            ListBox Name = new ListBox();
            Name.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;

            Stack_Products.Children.Add(Name);
            Stack_Products.Children.Add(Quantity);

            while (db.reader.Read())
            {
                Name.Items.Add(db.reader.GetString(0));
                Quantity.Items.Add(db.reader.GetDecimal(1));
            }

            //Close the reader
            db.reader.Close();
        }

        private void Confirm_Type_Click(object sender, RoutedEventArgs e)
        {
            Refresh();

            db.Set_Quary($"SELECT * FROM Products WHERE  (ProductName='{Type_TextBlock.Text}')");

            ListBox ProductID = new ListBox();
            ProductID.Width = 100;
            ListBox ProductName = new ListBox();
            ProductName.Width = 100;
            ListBox SupplierID = new ListBox();
            SupplierID.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;
            ListBox Cost = new ListBox();
            Cost.Width = 100;
            ListBox DeliveryDate = new ListBox();
            DeliveryDate.Width = 100;
            ListBox SupplierName = new ListBox();
            SupplierName.Width = 100;


            Stack_Products.Children.Add(ProductID);
            Stack_Products.Children.Add(ProductName);
            Stack_Products.Children.Add(SupplierID);
            Stack_Products.Children.Add(Quantity);
            Stack_Products.Children.Add(Cost);
            Stack_Products.Children.Add(DeliveryDate);

            //Read the results from the query
            while (db.reader.Read())
            {

                ProductID.Items.Add(db.reader.GetInt32(0));
                ProductName.Items.Add(db.reader.GetString(1));
                SupplierID.Items.Add(db.reader.GetInt32(2));
                Quantity.Items.Add(db.reader.GetInt32(3));
                Cost.Items.Add(db.reader.GetDecimal(4));
                DeliveryDate.Items.Add(db.reader.GetDateTime(5));


            }

            //Close the reader
            db.reader.Close();
        }

        private void Confirm_Supplier_Click(object sender, RoutedEventArgs e)
        {
            Refresh();

            db.Set_Quary($"SELECT Products.ProductName, Products.Quantity, Suppliers.SupplierName" +
                $" FROM Products JOIN Suppliers ON Products.SupplierID" +
                $" = Suppliers.SupplierID WHERE (Suppliers.SupplierName = '{Supplier_TextBlock.Text}')");

            ListBox ProductName = new ListBox();
            ProductName.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;
            ListBox SupplierName = new ListBox();
            SupplierName.Width = 100;





            Stack_Products.Children.Add(ProductName);
            Stack_Products.Children.Add(Quantity);
            Stack_Products.Children.Add(SupplierName);


            //Read the results from the query
            while (db.reader.Read())
            {
                ProductName.Items.Add(db.reader.GetString(0));
                Quantity.Items.Add(db.reader.GetInt32(1));
                SupplierName.Items.Add(db.reader.GetString(2));

            }

            //Close the reader
            db.reader.Close();
        }

        private void Old_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT TOP 1 ProductName, MIN(DeliveryDate) AS OldestDate FROM Products" +
                " GROUP BY ProductName ORDER BY OldestDate ASC");

            ListBox Name = new ListBox();
            Name.Width = 100;
            ListBox Date = new ListBox();
            Date.Width = 100;

            Stack_Products.Children.Add(Name);
            Stack_Products.Children.Add(Date);

            while (db.reader.Read())
            {
                Name.Items.Add(db.reader.GetString(0));
                Date.Items.Add(db.reader.GetDateTime(1));
            }

            //Close the reader
            db.reader.Close();
        }

        private void GroupType_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            db.Set_Quary("SELECT ProductName, AVG(Quantity) AS AverageQuantity FROM Products GROUP BY ProductName");

            ListBox Name = new ListBox();
            Name.Width = 100;
            ListBox Quantity = new ListBox();
            Quantity.Width = 100;

            Stack_Products.Children.Add(Name);
            Stack_Products.Children.Add(Quantity);

            while (db.reader.Read())
            {
                Name.Items.Add(db.reader.GetString(0));
                Quantity.Items.Add(db.reader.GetInt32(1));
            }

            //Close the reader
            db.reader.Close();
        }
    }
}
