Overview <br>
DataToUI is a WPF-based desktop application developed using C# for real-time communication with Battery Management Systems (BMS) and CAN diagnostic tools via Serial (COM) ports. <br>
The application enables developers and engineers to monitor incoming device data, send command byte arrays, and perform industrial-level hardware communication testing.

Features <br>✅ Automatic COM Port Detection<br> ✅ Serial Port Connection Management<br> ✅ Continuous Real-Time Data Reception<br> ✅ Byte Array Command Transmission to BMS <br>✅ Thread-Safe UI Updates using Dispatcher <br>✅ Industrial Monitoring Friendly Interface <br> ✅ Supports Simultaneous Send & Receive Communication

Tech Stack Language:<br> C# Framework:   .NET WPF  <br> Communication: Serial Port (UART / CAN Tool Interface) <br> Architecture: Event-Driven UI + Dispatcher Thread Handling

Hardware Compatibility : <br>  Battery Management Systems (BMS) <br> CAN Tools USB to UART Converters <br> Industrial Serial Communication Devices

Functional Workflow <br> Detect available COM Ports Select target communication port <br> Establish serial connection Receive live data stream from BMS <br> Send byte-array command packets Display processed data on UI.
