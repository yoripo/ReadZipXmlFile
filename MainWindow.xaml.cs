using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Xml.Linq;

namespace ReadZipFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //ZIP書庫を開く
            using (ZipArchive readZip = ZipFile.OpenRead(@"C:\work\test.zip"))
            {
                //「1.txt」のZipArchiveEntryを取得する
                ZipArchiveEntry zipArc = readZip.GetEntry(@"test.xml");
                if (zipArc == null)
                {
                    //見つからなかった時
                    MessageBox.Show("test.xml が見つかりませんでした。");
                    
                }
                else
                {
                    var s = "";
                    //見つかった時は開く
                    using (StreamReader sr = new StreamReader(zipArc.Open()))
                    {
                        //すべて読み込む
                        s = sr.ReadToEnd();
                        //Console.Write(s);
                    }
                    //見つかった時は開く
                    using (TextReader sr = new StreamReader(zipArc.Open()))
                    {
                        //XDocumentオブジェクトを生成
                        XDocument xdx = XDocument.Load(sr);
                        //要素「Tests」を読み込む
                        XElement Tests = xdx.Element("Tests");
                        
                    }
                    ////XMLファイル名
                    //string fileName = zipArc.FullName;

                    ////XDocumentオブジェクトを生成
                    //XDocument xd = XDocument.Load(fileName);

                    ////要素「zaiko」を読み込む
                    //XElement zaiko = xd.Element("zaiko");

                    ////要素「zaiko」から要素「syohin」を読み込みループ処理する
                    //IEnumerable syohin = zaiko.Elements("syohin");
                    //foreach (XElement elm in syohin)
                    //{
                    //    string name = elm.Element("name").Value;          //要素「name」の値
                    //    //string quantity = elm.Element("quantity").Value;  //要素「quantity」の値
                    //    MessageBox.Show(name);
                    //    //Console.WriteLine(name);
                    //    //Console.WriteLine(quantity);
                    //}
                }
            }
        }
    }
}
