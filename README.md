Overview <br>
DataToUI is a WPF-based desktop application developed using C# for real-time communication with Battery Management Systems (BMS) and CAN diagnostic tools via Serial (COM) ports. <br>
The application enables developers and engineers to monitor incoming device data, send command byte arrays, and perform industrial-level hardware communication testing.

Features ✅<br> Automatic COM Port Detection<br> ✅ Serial Port Connection Management<br> ✅ Continuous Real-Time Data Reception<br> ✅ Byte Array Command Transmission to BMS <br>✅ Thread-Safe UI Updates using Dispatcher <br>✅ Industrial Monitoring Friendly Interface <br> ✅ Supports Simultaneous Send & Receive Communication

Tech Stack Language:<br> C# Framework:   .NET WPF Communication:   Serial Port (UART / CAN Tool Interface) Architecture: Event-Driven UI + Dispatcher Thread Handling

Hardware Compatibility Battery Management Systems (BMS) CAN Tools USB to UART Converters Industrial Serial Communication Devices

Functional Workflow Detect available COM Ports Select target communication port Establish serial connection Receive live data stream from BMS Send byte-array command packets Display processed data on UI
