using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;


namespace DataToUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private SerialPort SerialObject;
        private String? CanToolData;

        public MainWindow()
        {

            InitializeComponent();
            DataContext = this;
            // Baud Rate Here Required
            SerialObject = new SerialPort
            {
                BaudRate = 460800,
                DataBits = 8,
                DtrEnable=true,
                RtsEnable=false, 
                Parity = Parity.None,
                StopBits = StopBits.One,
                ReadBufferSize=4096,
                WriteBufferSize=4096,
                Handshake=Handshake.None,
                ReadTimeout = 10000
            };



        }

        private void ConnectPort(object sender, RoutedEventArgs e)
        {

            if (ComboBoxShow.SelectedItem == null)
            {
                MessageBox.Show("Port Must be Select ");
                return;

            }

            try
            {
                /*   if (SerialObject.IsOpen)
                       SerialObject.Close();*/

                SerialObject.PortName = ComboBoxShow.SelectedItem.ToString();
                SerialObject.Open();

                MessageBox.Show("Connected");

                SerialObject.DataReceived += SerialObject_DataReceived;
            }
            catch (Exception)
            {
                MessageBox.Show("Connect Properly");
            }
             


        }

        private void ComboBoxItemAdd(Object Sender, RoutedEventArgs e)
        {

            string[] ports = SerialPort.GetPortNames();


            foreach (var iteam in ports)
            {
                ComboBoxShow.Items.Add(iteam);
            }




        }
        //Add Changes on here
        


        public event PropertyChangedEventHandler? PropertyChanged;

        public String? MyProperty
        {
            get => CanToolData;
            set
            {
                CanToolData = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(nameof(MyProperty)));
            }
        }

        private void SerialObject_DataReceived(Object sender, SerialDataReceivedEventArgs a)
        {
            try
            {

                int bytes = SerialObject.BytesToRead;
                byte[] buffer = new byte[bytes];

                SerialObject.Read(buffer, 0, bytes);

                // Convert byte array to HEX string
                string hexData = BitConverter.ToString(buffer);

                Dispatcher.Invoke(() =>
                {
                    MyProperty += hexData;
                });
                //Console.Write(BitConverter.GetBytes(data));

            }
            catch (Exception e)
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(e.Message);
                });
            }
        }

         private async void DataSendToBMS(Object send, RoutedEventArgs e) {

            if (!SerialObject.IsOpen)
            { MessageBox.Show("Port Is Disconnect"); }

           
            try
            {

                byte SelctedIteam = (Byte)(SelectDataType.SelectedIndex);
                               byte[] BMS = {
            60 ,46 ,69 ,3, 1,24 ,14, 2, 0 ,0 ,1 ,0 ,0 ,0 ,13, 10
            };

                BMS[7] = SelctedIteam;

                /*for (int i = 0; i < BMS.Length; i++)
                {
                    Console.Write(BMS[i]);
                }*/
                

                await SerialObject.BaseStream.WriteAsync(BMS, 0, BMS.Length);
                //await SerialObject.BaseStream.FlushAsync();
                MessageBox.Show("Data Transmission Done");
            }
            catch (Exception ){
                MessageBox.Show("Connection Check");
            }
        }

       /* private byte[] CovertToBit(String  arr[])
        {
           byte data[] = BitConverter.(arr);

            return new data;
        }*/
    }


}

 