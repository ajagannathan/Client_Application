using SwissRanks.Orion.API;
using System;
using System.Collections.Generic;
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

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ULTMConnection connection = new ULTMConnection();

        public MainWindow()
        {
            InitializeComponent();
            connection.ServerConnected += OnConnection;
            connection.ServerDisconnected += OnDisconnection;
            connection.MessageReceived += OnMessageReceived;
            connection.ServerErrorEvent += OnServerErrorEvent;
            ToolConfiguration.ModuleConnected += OnModuleConnected;
            RobotModule.RobotPositionChanged += OnRobotPositionChanged;
            RobotModule.RobotStateChanged += OnRobotStateChanged2;
            RobotModule.RobotErrorOccured += OnRobotErrorOccured;
            RobotModule.RobotOperatingStationChanged += OnRobotOperatingStationChanged;
            //StationModule.StationStateChanged += OnStationStateChanged2;
            //StationModule.StationErrorOccured += OnStationErrorOccured;

            FoupLoadPort.FoupStateChanged += OnFoupStateChanged;
            CassetteLoadPort.CassetteStateChanged += OnCassetteStateChanged;

            
          
        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.ServerConnected -= OnConnection;
            connection.ServerDisconnected -= OnDisconnection;
            connection.MessageReceived -= OnMessageReceived;
            connection.ServerErrorEvent -= OnServerErrorEvent;
            ToolConfiguration.ModuleConnected -= OnModuleConnected;
            RobotModule.RobotPositionChanged -= OnRobotPositionChanged;
            RobotModule.RobotStateChanged -= OnRobotStateChanged2;
            RobotModule.RobotErrorOccured -= OnRobotErrorOccured;
            RobotModule.RobotOperatingStationChanged -= OnRobotOperatingStationChanged;
            //StationModule.StationStateChanged -= OnStationStateChanged2;
            //StationModule.StationErrorOccured -= OnStationErrorOccured;

            FoupLoadPort.FoupStateChanged -= OnFoupStateChanged;
            CassetteLoadPort.CassetteStateChanged -= OnCassetteStateChanged;
        }

        private void OnCassetteStateChanged(string moduleID, CassetteLoadPortState state)
        {
            try
            {
                if(moduleID == "P2")
                {
                    Dispatcher.Invoke(() =>
                    {
                        C1_Placed_TextBox.Text = state.Placed.ToString();
                        C1_Present_TextBox.Text = state.Present.ToString();
                        C1_Clamp_TextBox.Text = state.ClampStatus.ToString();
                        C1_Dock_TextBox.Text = state.DockPosition.ToString();
                        C1_Open_TextBox.Text = state.Open.ToString();
                        C1_CDA_TextBox.Text = state.CDA.ToString();
                        C1_Vaccum_TextBox.Text = state.Vaccum.ToString();
                        C1_PDORaised_TextBox.Text = state.PDORaised.ToString();
                        C1_PDODocked_TextBox.Text = state.PDODocked.ToString();
                        C1_DoorLatch_TextBox.Text = state.DoorLatch.ToString();
                        C1_DoorChucked_TextBox.Text = state.DoorChucked.ToString();
                        C1_HomingRequired_TextBox.Text = state.HomingRequired.ToString();


                    });
                }
                else if (moduleID == "P3")
                {
                    Dispatcher.Invoke(() =>
                    {
                        C2_Placed_TextBox.Text = state.Placed.ToString();
                        C2_Present_TextBox.Text = state.Present.ToString();
                        C2_Clamp_TextBox.Text = state.ClampStatus.ToString();
                        C2_Dock_TextBox.Text = state.DockPosition.ToString();
                        C2_Open_TextBox.Text = state.Open.ToString();
                        C2_CDA_TextBox.Text = state.CDA.ToString();
                        C2_Vaccum_TextBox.Text = state.Vaccum.ToString();
                        C2_PDORaised_TextBox.Text = state.PDORaised.ToString();
                        C2_PDODocked_TextBox.Text = state.PDODocked.ToString();
                        C2_DoorLatch_TextBox.Text = state.DoorLatch.ToString();
                        C2_DoorChucked_TextBox.Text = state.DoorChucked.ToString();
                        C2_HomingRequired_TextBox.Text = state.HomingRequired.ToString();


                    });
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Cassette status could not be updated", "Cassette Status Error!!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void OnFoupStateChanged(string moduleID, FoupLoadPortState state)
        {
            try
            {
                if (moduleID == "P1")
                {
                    Dispatcher.Invoke(() =>
                    {
                        F1_EquipmentStatus_TextBox.Text = state.EquipmentStatus.ToString();
                        F1_Mode_TextBox.Text = state.Mode.ToString();
                        F1_OperationStatus_TextBox.Text = state.OperationStatus.ToString();
                        F1_CassettePresence_TextBox.Text = state.CassettePresence.ToString();
                        F1_ClampStatus_TextBox.Text = state.FOUPClampStatus.ToString();
                        F1_LatchStatus_TextBox.Text = state.LatchkeyStatus.ToString();
                        F1_DoorPosition_TextBox.Text = state.DoorPosition.ToString();
                        F1_ZAxisPosition_TextBox.Text = state.ZAxisPostion.ToString();
                        F1_YAxisPosition_TextBox.Text = state.YAxisPosition.ToString();
                        F1_MapperZAxis_TextBox.Text = state.MapperZAxis.ToString();
                        F1_MappingStatus_TextBox.Text = state.MappingStatus.ToString();
                        F1_InfoPad_TextBox.Text = state.InfoPad.ToString();

                    });
                }
                else if (moduleID == "P4")
                {
                    Dispatcher.Invoke(() =>
                    {
                        F2_EquipmentStatus_TextBox.Text = state.EquipmentStatus.ToString();
                        F2_Mode_TextBox.Text = state.Mode.ToString();
                        F2_OperationStatus_TextBox.Text = state.OperationStatus.ToString();
                        F2_CassettePresence_TextBox.Text = state.CassettePresence.ToString();
                        F2_ClampStatus_TextBox.Text = state.FOUPClampStatus.ToString();
                        F2_LatchStatus_TextBox.Text = state.LatchkeyStatus.ToString();
                        F2_DoorPosition_TextBox.Text = state.DoorPosition.ToString();
                        F2_ZAxisPosition_TextBox.Text = state.ZAxisPostion.ToString();
                        F2_YAxisPosition_TextBox.Text = state.YAxisPosition.ToString();
                        F2_MapperZAxis_TextBox.Text = state.MapperZAxis.ToString();
                        F2_MappingStatus_TextBox.Text = state.MappingStatus.ToString();
                        F2_InfoPad_TextBox.Text = state.InfoPad.ToString();

                    });
                }

            }
            catch (Exception)
            {

                MessageBox.Show("FOUP status could not be updated", "FOUP Status Error!!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void OnStationErrorOccured(object sender, int error)
        {
            //throw new NotImplementedException();
        }

        private void OnRobotErrorOccured(object sender, int error)
        {
            MessageBox.Show(ErrorDictionary.RobotErrorDictionary[error], "Robot Error!!", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void OnRobotOperatingStationChanged(object sender, string station)
        {

            //Dispatcher.Invoke(() =>
            //{

            //    OperatingStationtextBox.Text = station;
            //});
            
        }

        private IEnumerable<Enum> GetStates(Enum states)
        {
            foreach (Enum flag in Enum.GetValues(states.GetType()))
            {
                if (!flag.Equals(RobotState.Unknown) && states.HasFlag(flag))
                    yield return flag;

            }
        }
        private void OnRobotStateChanged2(string moduleID, RobotState state)
        {
            RobotModule rb= ToolConfiguration.ConfiguredDevices[ToolConfiguration.ROBOT_ID] as RobotModule;
            
            Dispatcher.Invoke(() =>
            {
                //IEnumerable<CheckBox> chkBoxCollection = RobotStatus_Grid.Children.OfType<CheckBox>();
                //Parallel.ForEach(RobotStatus_Grid.Children.OfType<CheckBox>(), (checkBox) =>
                //{
                //    checkBox.IsChecked = false;
                //    checkBox.Foreground = Brushes.White;
                //});
                OperatingStationtextBox.Text = rb.RobotOperatingStation;
                foreach (var chkbox in RobotStatus_Grid.Children.OfType<CheckBox>())
                {
                    chkbox.IsChecked = false;
                    chkbox.Foreground = Brushes.White;
                }
                if((state & RobotState.ServoOFF) == RobotState.ServoOFF)
                {
                    ServoOn_Button.Visibility = Visibility.Visible;
                    ServoOff_Button.Visibility = Visibility.Hidden;
                }
                else if((state & RobotState.ServoOFF) != RobotState.ServoOFF)
                {
                    ServoOn_Button.Visibility = Visibility.Hidden;
                    ServoOff_Button.Visibility = Visibility.Visible;
                }

            });

            Parallel.ForEach(GetStates(state), (val) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var myCheckBox = (CheckBox)this.FindName(val.ToString());
                    myCheckBox.IsChecked = true;
                    myCheckBox.Foreground = Brushes.Red;
                });

            });


            //RobotStatus_TextBlock.Text = state.ToString();
            //if (state == RobotState.ServoOn)
            //{
            //    ServoOn_Button.Visibility = Visibility.Hidden;
            //    ServoOff_Button.Visibility = Visibility.Visible;
            //}
            //if (state == RobotState.ServoOff)
            //{
            //    ServoOn_Button.Visibility = Visibility.Visible;
            //    ServoOff_Button.Visibility = Visibility.Hidden;
            //}

        }

        //private void OnStationStateChanged2(string moduleID, StationState state)
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        switch (moduleID)
        //        {
        //            case "P1":
        //                P1Status_TextBlock.Text = state.ToString();
        //                break;
        //            case "P2":
        //                P2Status_TextBlock.Text = state.ToString();
        //                break;
        //            case "P3":
        //                P3Status_TextBlock.Text = state.ToString();
        //                break;
        //            case "P4":
        //                P4Status_TextBlock.Text = state.ToString();
        //                break;
        //        }
        //    });
        //}

        private void OnRobotPositionChanged(string moduleID, Position position)
        {
            Dispatcher.Invoke(() =>
            {
                TAxis_textBox.Text = position.T.ToString();
                R1Axis_textBox.Text = position.R1.ToString();
                R2Axis_textBox.Text = position.R2.ToString();
                ZAxis_textBox.Text = position.Z.ToString();
                KAxis_textBox.Text = position.K.ToString();
            });
        }

        private void OnServerErrorEvent(object sender, ServerErrorCode error)
        {
            MessageBox.Show($"{error.ToString()} Occurred!!!", error.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //private void OnStationStateChanged(string id, ModuleState state)
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        switch (id)
        //        {
        //            case "P1":
        //                P1Status_TextBlock.Text = state.ToString();
        //                break;
        //            case "P2":
        //                P2Status_TextBlock.Text = state.ToString();
        //                break;
        //            case "P3":
        //                P3Status_TextBlock.Text = state.ToString();
        //                break;
        //            case "P4":
        //                P4Status_TextBlock.Text = state.ToString();
        //                break;
        //        }
        //    });
        //}

        //private void OnRobotStateChanged(string id, ModuleState state)
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        RobotStatus_TextBlock.Text = state.ToString();
        //        if(state == ModuleState.ServoOn)
        //        {
        //            ServoOn_Button.Visibility = Visibility.Hidden;
        //            ServoOff_Button.Visibility = Visibility.Visible;
        //        }
        //        if(state == ModuleState.ServoOff)
        //        {
        //            ServoOn_Button.Visibility = Visibility.Visible;
        //            ServoOff_Button.Visibility = Visibility.Hidden;
        //        }
        //    });
        //}

        private void OnModuleConnected(string moduleID, ModuleConnection connection)
        {
            Dispatcher.Invoke(() =>
            {

                switch (moduleID)
                {
                    case "R1":
                        if (connection == ModuleConnection.Online)
                        {
                            //if(ToolConfiguration.ConfiguredDevices.ContainsKey("R1"))
                            //    rb = ToolConfiguration.ConfiguredDevices["R1"] as RobotModule;
                            RobotConnection_TextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF02FF02");
                            Robot_ComboBox.Items.Add("R1");
                            Robot_ComboBox.SelectedIndex = 0;
                            RobotStatus_TextBlock.Text = "Unknown";
                        }
                        else if (connection == ModuleConnection.Offline)
                        {
                            RobotConnection_TextBlock.Foreground = Brushes.Red;
                        }
                        RobotConnection_TextBlock.Text = connection.ToString();
                        break;
                    case "P1":
                        if (connection == ModuleConnection.Online)
                        {
                            P1Connection_TextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF02FF02");
                            SrcStation_ComboBox.Items.Add("P1");
                            DstStation_ComboBox.Items.Add("P1");
                            P1Status_TextBlock.Text = "Unknown";
                        }
                        else if (connection == ModuleConnection.Offline)
                        {
                            P1Connection_TextBlock.Foreground = Brushes.Red;
                        }
                        P1Connection_TextBlock.Text = connection.ToString();
                        break;
                    case "P2":
                        if (connection == ModuleConnection.Online)
                        {
                            P2Connection_TextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF02FF02");
                            SrcStation_ComboBox.Items.Add("P2");
                            DstStation_ComboBox.Items.Add("P2");
                            P2Status_TextBlock.Text = "Unknown";
                        }
                        else if (connection == ModuleConnection.Offline)
                        {
                            P2Connection_TextBlock.Foreground = Brushes.Red;
                        }
                        P2Connection_TextBlock.Text = connection.ToString();
                        break;
                    case "P3":
                        if (connection == ModuleConnection.Online)
                        {
                            P3Connection_TextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF02FF02");
                            SrcStation_ComboBox.Items.Add("P3");
                            DstStation_ComboBox.Items.Add("P3");
                            P3Status_TextBlock.Text = "Unknown";
                        }
                        else if (connection == ModuleConnection.Offline)
                        {
                            P3Connection_TextBlock.Foreground = Brushes.Red;
                        }
                        P3Connection_TextBlock.Text = connection.ToString();
                        break;
                    case "P4":
                        if (connection == ModuleConnection.Online)
                        {
                            P4Connection_TextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF02FF02");
                            SrcStation_ComboBox.Items.Add("P4");
                            DstStation_ComboBox.Items.Add("P4");
                            P4Status_TextBlock.Text = "Unknown";
                        }
                        else if (connection == ModuleConnection.Offline)
                        {
                            P4Connection_TextBlock.Foreground = Brushes.Red;
                        }
                        P4Connection_TextBlock.Text = connection.ToString();
                        break;
                    default:
                        break;
                }
            });
        }

        private void OnMessageReceived(string message)
        {
            Dispatcher.Invoke(() => TerminalTextBox.AppendText($"{message}\r\n"));
        }

        private void OnDisconnection(object sender, EventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                TerminalTextBox.AppendText("Disconnected from Server\r\n");
                Initialize_Button.IsEnabled = false;
                RobotControls_GroupBox.IsEnabled = false;
                StationControls_GroupBox.IsEnabled = false;
                Position_GroupBox.IsEnabled = false;
                Disconnect_Button.Visibility = Visibility.Hidden;
                RobotConnection_TextBlock.Foreground = Brushes.White;
                RobotConnection_TextBlock.Text = "--";
                RobotStatus_TextBlock.Text = "--";
                P1Connection_TextBlock.Foreground = Brushes.White;
                P1Connection_TextBlock.Text = "--";
                P1Status_TextBlock.Text = "--";
                P2Connection_TextBlock.Foreground = Brushes.White;
                P2Connection_TextBlock.Text = "--";
                P2Status_TextBlock.Text = "--";
                P3Connection_TextBlock.Foreground = Brushes.White;
                P3Connection_TextBlock.Text = "--";
                P3Status_TextBlock.Text = "--";
                P4Connection_TextBlock.Foreground = Brushes.White;
                P4Connection_TextBlock.Text = "--";
                P4Status_TextBlock.Text = "--";
                Robot_ComboBox.Items.Clear();
                SrcStation_ComboBox.Items.Clear();
                SrcSlot_ComboBox.Items.Clear();
                DstStation_ComboBox.Items.Clear();
                DstSlot_ComboBox.Items.Clear();
                Blade_ComboBox.Items.Clear();
            });
        }

        private void OnConnection(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                TerminalTextBox.AppendText("Connected to Server\r\n");
                Initialize_Button.IsEnabled = true;
                RobotControls_GroupBox.IsEnabled = true;
                StationControls_GroupBox.IsEnabled = true;
                Position_GroupBox.IsEnabled = true;
                Disconnect_Button.Visibility = Visibility.Visible;

                /*******Manually fill combobox to test*******/
                Blade_ComboBox.Items.Add("0");
                Blade_ComboBox.Items.Add("1");
                Blade_ComboBox.SelectedIndex = 0;
                SrcStation_ComboBox.Items.Add("P1");
                SrcStation_ComboBox.Items.Add("P2");
                SrcStation_ComboBox.SelectedIndex = 0;
                DstStation_ComboBox.Items.Add("P1");
                DstStation_ComboBox.Items.Add("P2");
                DstStation_ComboBox.SelectedIndex = 0;

                for (int i = 1; i < 14; i++)
                {
                    SrcSlot_ComboBox.Items.Add(i.ToString());
                    DstSlot_ComboBox.Items.Add(i.ToString());
                }

                SrcSlot_ComboBox.SelectedIndex = 0;
                DstSlot_ComboBox.SelectedIndex = 0;

                P1_RadioButton.IsChecked = true;


               



                /**************************************/
            });
        }

        private async void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var code = await connection.ConnectToServer(HostIP_TextBox.Text, Convert.ToInt32(Port_TextBox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to server!", "Connection Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Disconnect_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Disconnect();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not properly disconnect from server!!!", "Disconnection Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Initialize_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToolConfiguration.ToolInitialize();
            }
            catch (Exception)
            {
                MessageBox.Show("Initialization Failed!!!", "Message Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Move_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                
                rb.Move((RobotArm)Convert.ToInt32(Blade_ComboBox.SelectedItem), (StationModule)ToolConfiguration.ConfiguredDevices[DstStation_ComboBox.SelectedItem.ToString()],
                    (LoadPortSlot)Convert.ToInt32(DstSlot_ComboBox.SelectedItem), LocationCode.gbx);
            }
            catch (Exception)
            {
                MessageBox.Show("Move Command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetWafer_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                rb.GetWafer((RobotArm)Convert.ToInt32(Blade_ComboBox.SelectedItem), (StationModule)ToolConfiguration.ConfiguredDevices[SrcStation_ComboBox.SelectedItem.ToString()],
                    (LoadPortSlot)Convert.ToInt32(SrcSlot_ComboBox.SelectedItem));
            }
            catch (Exception)
            {
                MessageBox.Show("Move Command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PutWafer_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                rb.PutWafer((RobotArm)Convert.ToInt32(Blade_ComboBox.SelectedItem), (StationModule)ToolConfiguration.ConfiguredDevices[DstStation_ComboBox.SelectedItem.ToString()],
                    (LoadPortSlot)Convert.ToInt32(DstSlot_ComboBox.SelectedItem));
            }
            catch (Exception)
            {
                MessageBox.Show("Move Command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TransferWafer_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                rb.Tranfer((RobotArm)Convert.ToInt32(Blade_ComboBox.SelectedItem), (StationModule)ToolConfiguration.ConfiguredDevices[SrcStation_ComboBox.SelectedItem.ToString()],
                    (LoadPortSlot)Convert.ToInt32(SrcSlot_ComboBox.SelectedItem),
                    (StationModule)ToolConfiguration.ConfiguredDevices[DstStation_ComboBox.SelectedItem.ToString()],
                    (LoadPortSlot)Convert.ToInt32(DstSlot_ComboBox.SelectedItem));
            }
            catch (Exception)
            {
                MessageBox.Show("Move Command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Scan_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                rb.Map(ToolConfiguration.ConfiguredDevices[DstStation_ComboBox.SelectedItem.ToString()].ModuleID);
            }
            catch (Exception)
            {

                MessageBox.Show("Scan Command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        private void Map_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                rb.FetchMap();
            }
            catch (Exception)
            {

                MessageBox.Show("Map Command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ServoOn_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                await Task.Run(() => rb.RobotON());
            }
            catch (Exception)
            {
                ServoOn_Button.Visibility = Visibility.Visible;
                ServoOff_Button.Visibility = Visibility.Hidden;
                MessageBox.Show("Robot command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ServoOff_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                await Task.Run(() => rb.RobotOFF());
            }
            catch (Exception)
            {
                ServoOn_Button.Visibility = Visibility.Hidden;
                ServoOff_Button.Visibility = Visibility.Visible;
                MessageBox.Show("Robot command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RobotAxisPosition_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = (RobotModule)ToolConfiguration.ConfiguredDevices[Robot_ComboBox.SelectedItem.ToString()];
                rb.GetPosition();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void HomeAxis_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            RobotAxis axis = RobotAxis.All;
            switch (b.Name)
            {
                case "HomeTAxis_Button":
                    axis = RobotAxis.T;
                    break;
                case "HomeR1Axis_Button":
                    axis = RobotAxis.R1;
                    break;
                case "HomeR2Axis_Button":
                    axis = RobotAxis.R2;
                    break;
                case "HomeZAxis_Button":
                    axis = RobotAxis.Z;
                    break;
                case "HomeKAxis_Button":
                    axis = RobotAxis.K;
                    break;
                default:
                    axis = RobotAxis.All;
                    break;
            }

            try
            {
                RobotModule rb = ToolConfiguration.ConfiguredDevices["R1"] as RobotModule;
                rb.HomeAxis(axis);
            }
            catch (Exception)
            {
                MessageBox.Show("Robot Home command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = ToolConfiguration.ConfiguredDevices["R1"] as RobotModule;
                rb.Stop();
            }
            catch (Exception)
            {
                MessageBox.Show("Robot Stop command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetAxisSpeed_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            RobotAxis axis = RobotAxis.All;
            switch (b.Name)
            {
                case "SerTAxisSpeed_Button":
                    axis = RobotAxis.T;
                    break;
                case "SetR1AxisSpeed_Button":
                    axis = RobotAxis.R1;
                    break;
                case "SetR2AxisSpeed_Button":
                    axis = RobotAxis.R2;
                    break;
                case "SetZAxisSpeed_Button":
                    axis = RobotAxis.Z;
                    break;
                case "SetKAxisSpeed_Button":
                    axis = RobotAxis.K;
                    break;
                default:
                    axis = RobotAxis.All;
                    break;
            }

            try
            {
                RobotModule rb = ToolConfiguration.ConfiguredDevices["R1"] as RobotModule;
                rb.SetFIAttribute(FIAttribute.Speed, AllAxisSpeed_textBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Robot Set command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        private void ErrorReset_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RobotModule rb = ToolConfiguration.ConfiguredDevices["R1"] as RobotModule;
                rb.ErrorReset();
            }
            catch (Exception)
            {
                MessageBox.Show("Robot Set command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Load();
                }
                else if((bool)P2_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P2"] as CassetteLoadPort;
                    cassette.Load();
                }
                else if ((bool)P3_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P3"] as CassetteLoadPort;
                    cassette.Load();
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P4"] as FoupLoadPort;
                    foup.Load();
                }                  

                //else if ((bool)P3_RadioButton.IsChecked)
                //    return (StationModule)ToolConfiguration.ConfiguredDevices["P3"];

                //else if ((bool)P4_RadioButton.IsChecked)
                //    return (StationModule)ToolConfiguration.ConfiguredDevices["P4"];

                //else
                //    return (StationModule)ToolConfiguration.ConfiguredDevices["P1"];
                //StationModule station = GetSelectedStation();
                //station.Load();

            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Unload_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Unload();
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Unload();
                }
                else if ((bool)P2_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P2"] as CassetteLoadPort;
                    cassette.Unload();
                }
                else if ((bool)P3_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P3"] as CassetteLoadPort;
                    cassette.Unload();
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P4"] as FoupLoadPort;
                    foup.Unload();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Latch_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.Latch);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Pop(PopCmd.Latch);
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P2"] as FoupLoadPort;
                    foup.Pop(PopCmd.Latch);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Unlatch_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.Unlatch);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Pop(PopCmd.Unlatch);
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P2"] as FoupLoadPort;
                    foup.Pop(PopCmd.Unlatch);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Dock_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.Dock);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Pop(PopCmd.Dock);
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P2"] as FoupLoadPort;
                    foup.Pop(PopCmd.Dock);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Undock_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.Undock);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Pop(PopCmd.Undock);
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P2"] as FoupLoadPort;
                    foup.Pop(PopCmd.Undock);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenDoor_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.OpenDoor);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Pop(PopCmd.OpenDoor);
                }
                else if ((bool)P2_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P2"] as CassetteLoadPort;
                    cassette.Pop(PopCmd.OpenDoor);
                }
                else if ((bool)P3_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P3"] as CassetteLoadPort;
                    cassette.Pop(PopCmd.OpenDoor);
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P4"] as FoupLoadPort;
                    foup.Pop(PopCmd.OpenDoor);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseDoor_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.CloseDoor);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Pop(PopCmd.CloseDoor);
                }
                else if ((bool)P2_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P2"] as CassetteLoadPort;
                    cassette.Pop(PopCmd.CloseDoor);
                }
                else if ((bool)P3_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P3"] as CassetteLoadPort;
                    cassette.Pop(PopCmd.CloseDoor);
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P4"] as FoupLoadPort;
                    foup.Pop(PopCmd.CloseDoor);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LPMap_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Map();
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.Map();
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P2"] as FoupLoadPort;
                    foup.Map();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FetchMap_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.FetchMap();
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.FetchMap();
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P2"] as FoupLoadPort;
                    foup.FetchMap();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStatus_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StationModule station = GetSelectedStation();
                //station.Pop(PopCmd.CloseDoor);
                if ((bool)P1_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P1"] as FoupLoadPort;
                    foup.UpdateStatus();
                }
                else if ((bool)P2_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P2"] as CassetteLoadPort;
                    cassette.UpdateStatus();
                }
                else if ((bool)P3_RadioButton.IsChecked)
                {
                    CassetteLoadPort cassette = ToolConfiguration.ConfiguredDevices["P3"] as CassetteLoadPort;
                    cassette.UpdateStatus();
                }
                else if ((bool)P4_RadioButton.IsChecked)
                {
                    FoupLoadPort foup = ToolConfiguration.ConfiguredDevices["P4"] as FoupLoadPort;
                    foup.UpdateStatus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LoadPort command Failed!!!", "Command Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearTerminal_Button_Click(object sender, RoutedEventArgs e)
        {
            TerminalTextBox.Clear();
        }

        private void ToolStatusTab_Button_Click(object sender, RoutedEventArgs e)
        {
            ToolStatus_GroupBox.Visibility = Visibility.Visible;
            RobotStatus_GroupBox.Visibility = Visibility.Hidden;
            Foup_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_2_Status_GroupBox.Visibility = Visibility.Hidden;
            Foup_2_Status_GroupBox.Visibility = Visibility.Hidden;

        }

        private void RobotStatusTab_Button_Click(object sender, RoutedEventArgs e)
        {
            ToolStatus_GroupBox.Visibility = Visibility.Hidden;
            RobotStatus_GroupBox.Visibility = Visibility.Visible;
            Foup_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_2_Status_GroupBox.Visibility = Visibility.Hidden;
            Foup_2_Status_GroupBox.Visibility = Visibility.Hidden;
        }

        private void Foup_1_StatusTab_Button_Click(object sender, RoutedEventArgs e)
        {
            ToolStatus_GroupBox.Visibility = Visibility.Hidden;
            RobotStatus_GroupBox.Visibility = Visibility.Hidden;
            Foup_1_Status_GroupBox.Visibility = Visibility.Visible;
            Cassette_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_2_Status_GroupBox.Visibility = Visibility.Hidden;
            Foup_2_Status_GroupBox.Visibility = Visibility.Hidden;
        }

        private void Cassette_1_StatusTab_Button_Click(object sender, RoutedEventArgs e)
        {
            ToolStatus_GroupBox.Visibility = Visibility.Hidden;
            RobotStatus_GroupBox.Visibility = Visibility.Hidden;
            Foup_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_1_Status_GroupBox.Visibility = Visibility.Visible;
            Cassette_2_Status_GroupBox.Visibility = Visibility.Hidden;
            Foup_2_Status_GroupBox.Visibility = Visibility.Hidden;
        }

        private void Cassette_2_StatusTab_Button_Click(object sender, RoutedEventArgs e)
        {
            ToolStatus_GroupBox.Visibility = Visibility.Hidden;
            RobotStatus_GroupBox.Visibility = Visibility.Hidden;
            Foup_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_2_Status_GroupBox.Visibility = Visibility.Visible;
            Foup_2_Status_GroupBox.Visibility = Visibility.Hidden;
        }

        private void Foup_2_StatusTab_Button_Click(object sender, RoutedEventArgs e)
        {
            ToolStatus_GroupBox.Visibility = Visibility.Hidden;
            RobotStatus_GroupBox.Visibility = Visibility.Hidden;
            Foup_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_1_Status_GroupBox.Visibility = Visibility.Hidden;
            Cassette_2_Status_GroupBox.Visibility = Visibility.Hidden;
            Foup_2_Status_GroupBox.Visibility = Visibility.Visible;
        }
        private void TerminalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TerminalTextBox.ScrollToEnd();
        }

        #region SubRoutine

        private StationModule GetSelectedStation()
        {
            if ((bool)P2_RadioButton.IsChecked)
                return (StationModule)ToolConfiguration.ConfiguredDevices["P2"];

            else if ((bool)P3_RadioButton.IsChecked)
                return (StationModule)ToolConfiguration.ConfiguredDevices["P3"];

            else if ((bool)P4_RadioButton.IsChecked)
                return (StationModule)ToolConfiguration.ConfiguredDevices["P4"];

            else
                return (StationModule)ToolConfiguration.ConfiguredDevices["P1"];
        }



        #endregion

        private void TowerLampStatus_Click(object sender, RoutedEventArgs e)
        {
            TowerLampModule TowerLamp= ToolConfiguration.ConfiguredDevices["TL"] as TowerLampModule;
            TowerLamp.GetStatus();
        }
    }
}
