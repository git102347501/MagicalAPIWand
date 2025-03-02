# MagicalAPIWand
用于批量调用指定API接口的windows桌面应用程序

Windows desktop application for batch calling specified API interfaces

<img width="825" alt="1740904274870" src="https://github.com/user-attachments/assets/13000822-632e-4074-ae83-99754d2a0b01" />

必要的运行环境
- windows7-windows11
- net8 [下载](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0)

Necessary operating environment
- windows7-windows11
- net8 [download](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0)
 
Relases
v 1.0.0
- 支持自定义接口请求方式 
- 支持自定义Task启动数量
- 支持Task批量中止
- 支持导入Excel数据
- 支持模板化批量参数嵌入

v1.0.0
- Support custom interface request methods
- Support custom task initiation quantity
- Support batch termination of tasks
- Support importing Excel data
- Support template based batch parameter embedding

-使用方式
1. 添加自定义接口域名和路径
2. 添加接口参数，如需导入excel嵌入到参数，请使用 {{excel列名}} 作为参数占位符
3. 点击[Import], 导入excel作为参数数据源，点击[Save]，返回首页
4. 点击 [Add Task] 添加处理线程 (您的数据将被线程同时均匀消费，不会产生重复消费)
5. 等待任务执行完成，您可以点击打开 [OpenLog] 访问本次执行的日志文件，每次请求将产生唯一的目录，目录内为每个task任务的执行日志

-Usage method
1. Add custom interface domain name and path
2. Add interface parameters. If you need to import Excel and embed it into the parameters, please use {{Excel column name}} as a parameter placeholder
Click on [Import], Import Excel as the parameter data source, click [Save], return to the homepage
Click on [Add Task] to add a processing thread (your data will be evenly consumed by the thread at the same time, without duplicate consumption)
5. Wait for the task execution to complete. You can click on [OpenLog] to access the log file of this execution. Each request will generate a unique directory containing the execution log of each task
