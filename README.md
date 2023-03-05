# learn-csharp
A learn project of c#


## C#

### 介绍
1. 面向对象、面向组件的编程语言
2. 类型安全

### 术语
- 继承
- 派生
- 实现

### 六种类型
- 六种 C# 类型：类类型、结构类型、接口类型、枚举类型、委托类型和元组值类型。 还可以声明 record 类型（record struct 或 record class）。


# [C# 10新功能]（https://learn.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-10）
- 记录结构
- 结构类型的改进
- 内插字符串处理程序
- global using 指令
- 文件范围的命名空间声明
- 扩展属性模式
- 对 Lambda 表达式的改进
- 可使用 const 内插字符串
- 记录类型可密封 ToString()
- 改进型明确赋值
- 在同一析构中可同时进行赋值和声明
- 可在方法上使用 AsyncMethodBuilder 属性
- CallerArgumentExpression 属性
- 增强的 #line pragma
- 警告波 6


## .NET

### 术语
- CLR: Common Language Runtimes，公共语言运行时
- CLI：Common Language Infrastructure，公共语言基础结构
- CTS: Common Type System，公共类型系统
- CLS：Common Language Specification，公共语言规范
- IL: Intermediate Language，中间语言
- CIL: Common Intermediate Language，公共中间语言
- MSIL：Microsoft Intermediate Language，Microsoft中间语言
- Metadata: 元数据
- PGO：按配置优化 (PGO) 是指JIT编译器根据最常使用的类型和代码路径生成优化后的代码
- 热重载：热更新。使用热重载功能，可以修改应用源代码，并立即将这些更改应用到正在运行的应用。 此功能的目的是避免在编辑之间重新启动应用程序，从而提高工作效率
- JIT: 实时 (JIT) 编译器
- Ngen.exe: 本机映像生成器
- 分层编译：分层编译将方法转换到两个层级：
  - 第一层可以更快速地生成代码（快速 JIT）或加载预编译的代码 (ReadyToRun)。
  - 第二层在后台生成优化的代码（“优化 JIT”）。
- PE: PE文件的全称是Portable Executable，意为可移植的可执行的文件，常见的EXE、DLL、OCX、SYS、COM都是PE文件
- IDL: Interface Definition Language，接口定义语言
- Ildasm.exe: MSIL 反汇编程序 (Ildasm.exe)
- AssemblyLoadContext: [AssemblyLoadContext](https://learn.microsoft.com/zh-cn/dotnet/core/dependency-loading/understanding-assemblyloadcontext) API 是 .NET 加载设计的核心
- Assembly: 表示一个程序集，它是一个可重用、无版本冲突并且可自我描述的公共语言运行时应用程序构建基块。
- GUID: 全局唯一标识符（GUID，Globally Unique Identifier）
- RID: Runtimes ID，运行时标识符的缩写
- FlagsAttribute: 特性表示一种特殊的枚举，称为位域。
- 协变：泛型的术语，指能够使用比原始指定的派生类型的派生程度更大（更具体的）的类型。
- 逆变：泛型的术语，指能够使用比原始指定的派生类型的派生程度更小（不太具体的）的类型。
- APM：Async Programing Model，异步编程模型 (APM) 模式
- TAP: 基于任务的异步模式 (TAP) ，该模式使用单一方法表示异步操作的开始和完成
- EAP: 基于事件的异步模式 (EAP), 是提供异步行为的基于事件的旧模型


### 介绍
- .NET 是一个免费的跨平台开放源代码开发人员平台，用于生成多种类型的应用程序。

### 功能
借助 .NET 功能，开发人员可以高效地编写可靠的高性能代码。

- 异步代码
- 属性
- 反射
- 代码分析器
- 委托和 lambda
- 事件
- 异常
- 垃圾回收
- 泛型类型
- LINQ（语言集成查询）。
- 并行编程
- 类型推理 - C#、F#、Visual Basic。
- 类型系统
- 不安全代码

### 二进制分布
- .NET SDK - 用于开发、生成和测试应用的一组工具、库和运行时。
- .NET Runtimes - 用于运行应用的一组运行时和库。

### 运行时
- 公共语言运行时 (CLR) 是生成所有 .NET 应用的基础。 运行时的基本功能包括：
  - 垃圾回收。
  - 内存安全和类型安全。
  - 对编程语言的全面支持。
  - 跨平台设计。

- .NET 有时被称为“托管代码”运行时。 之所以称为“托管”，主要是因为它使用垃圾回收器进行内存管理，还因为它强制执行类型和内存安全。 CLR 虚拟化（或抽象）了各种操作系统和硬件概念，例如内存、线程和异常。
- CLR 从一开始就被设计为一个跨平台运行时。 它已被移植到多个操作系统和体系结构。 通常，跨平台 .NET 代码不需要经过重新编译就能在新环境中运行。 相反，你只需安装一个不同的运行时即可运行应用。


### 查看版本等详细信息
```shell
➜  ~ dotnet --info
.NET SDK:
 Version:   7.0.200
 Commit:    534117727b

运行时环境:
 OS Name:     Mac OS X
 OS Version:  12.2
 OS Platform: Darwin
 RID:         osx.12-x64
 Base Path:   /usr/local/share/dotnet/sdk/7.0.200/

Host:
  Version:      7.0.3
  Architecture: x64
  Commit:       0a2bda10e8

.NET SDKs installed:
  6.0.406 [/usr/local/share/dotnet/sdk]
  7.0.200 [/usr/local/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.14 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 7.0.3 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.14 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
  Microsoft.NETCore.App 7.0.3 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]

Other architectures found:
  None

Environment variables:
  Not set

global.json file:
  Not found

Learn more:
  https://aka.ms/dotnet/info

Download .NET:
  https://aka.ms/dotnet/download
```

### [支持的五种类型](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/common-type-system)
- 类：
  - 定义：类是可以直接从另一个类派生以及从 System.Object 隐式派生的引用类型
  - 特征：
    - sealed：指定不能从此类型派生出另一个类。
    - 实现: 指出该类通过提供接口成员的实现，使用一个或多个接口。
    - abstract：指出无法实例化类。 若要使用它，必须由其派生出另一个类。
    - 继承：指出可以在指定了基类的任何地方使用类的实例。 从基类继承的派生类可以使用基类提供的任何公共成员的实现，派生类也可以用自己的实现重写这些公共成员的实现。
    - exported 或 not exported：指出某个类在定义它的程序集之外是否可见。 此特征仅适用于顶级类，不适用于嵌套类。
  - 单一类继承，多接口实现
- 结构：
  - 定义：结构是隐式从 System.ValueType 派生的值类型，后者则是从 System.Object 派生的
  - 对于表示内存要求较小的值以及将值作为按值参数传递给具有强类型参数的方法，结构很有用。
  - 在 .NET 中，所有基元数据类型（Boolean、Byte、Char、DateTime、Decimal、Double、Int16、Int32、Int64、SByte、Single、UInt16、UInt32 和 UInt64）都定义为结构。
- 枚举
  - 定义：枚举是一种值类型，该值类型直接从 System.Enum 继承并为基础基元类型的值提供替代名称
  - 它们不能定义自己的方法。
  - 它们不能实现接口。
  - 它们不能定义属性或事件。
  - 枚举不能是泛型，除非它嵌套在泛型类型中，才能是泛型。 也就是说，枚举不能有自己的类型参数。
- 接口
  - 定义：接口定义用于指定“可以执行”关系或“具有”关系的协定
  - 接口可以用任何可访问性来声明，但接口成员必须全都具有公共可访问性。
  - 接口不能定义构造函数。
  - 接口不能定义字段。
  - 接口只能定义实例成员。 它们不能定义静态成员。
- 委托
  - 定义：委托是用途类似于 C++ 中的函数指针的引用类型。
  - 它们用于 .NET 中的事件处理程序和回调函数。 与函数指针不同，委托是安全、可验证和类型安全的。
  - 委托类型可以表示任何具有兼容签名的实例方法或静态方法。

### 类型特征
- abstract
- private、family、assembly、public
- final
- initialize-only: 该值只能被初始化，不能在初始化之后写入。
- newslot 或 override：定义成员如何与具有相同签名的继承成员进行交互
  - newslot：隐藏具有相同签名的继承成员。
  - override：替换继承的虚方法的定义。
- virtual：此方法可以由派生类型实现，并且既可静态调用，也可动态调用。


## 术语
1.

顶级语句
2. 


## 参考
- [Visual Studio for Mac 文档](https://learn.microsoft.com/zh-cn/visualstudio/mac/?view=vsmac-2022)
- [C# 文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/)
- [.NET 文档](https://learn.microsoft.com/zh-cn/dotnet/fundamentals/)
