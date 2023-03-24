# Tugas Besar 2 IF2211 Strategi Algoritma
``Pengaplikasian Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt``


## Tentang Program

  Tuan Krabs menemukan sebuah labirin distorsi terletak tepat di bawah Krusty Krab bernama
El Doremi yang Ia yakini mempunyai sejumlah harta karun di dalamnya dan tentu saja Ia ingin
mengambil harta karunnya. Dikarenakan labirinnya dapat mengalami distorsi, Tuan Krabs harus terus
mengukur ukuran dari labirin tersebut. Oleh karena itu, Tuan Krabs banyak menghabiskan tenaga
untuk melakukan hal tersebut sehingga Ia perlu memikirkan bagaimana caranya agar Ia dapat
menelusuri labirin ini lalu memperoleh seluruh harta karun dengan mudah.

  Setelah berpikir cukup lama, Tuan Krabs tiba-tiba mengingat bahwa ketika Ia berada pada
kelas Strategi Algoritma-nya dulu, Ia ingat bahwa Ia dulu mempelajari algoritma BFS dan DFS
sehingga Tuan Krabs menjadi yakin bahwa persoalan ini dapat diselesaikan menggunakan kedua
algoritma tersebut. Akan tetapi, dikarenakan sudah lama tidak menyentuh algoritma, Tuan Krabs
telah lupa bagaimana cara untuk menyelesaikan persoalan ini dan Tuan Krabs pun kebingungan.
Tidak butuh waktu lama, Ia terpikirkan sebuah solusi yang brilian. Solusi tersebut adalah meminta
mahasiswa yang saat ini sedang berada pada kelas Strategi Algoritma untuk menyelesaikan
permasalahan ini.


## Strategi BFS dan DFS

Graf DFS (Depth-First Search) adalah metode pencarian jalur pada graf yang dilakukan dengan mengunjungi simpul-simpul graf secara berurutan mulai dari simpul awal hingga simpul terakhir. Metode pencarian ini dilakukan dengan mengeksplorasi setiap simpul secara mendalam terlebih dahulu sebelum bergerak ke simpul yang belum dieksplorasi sebelumnya. Hal ini dilakukan dengan menggunakan teknik rekursi, di mana simpul-simpul graf akan ditelusuri secara terus-menerus hingga tidak ada simpul yang belum dieksplorasi. Metode DFS sangat berguna dalam menemukan jalur terpendek antara simpul-simpul pada graf, serta dalam memeriksa keterhubungan antara simpul-simpul pada graf yang memiliki banyak cabang dan relasi yang kompleks. Selain itu, metode DFS juga sering digunakan dalam pengembangan perangkat lunak dan analisis data untuk memecahkan masalah yang melibatkan graf dan struktur data.

Graf BFS (Breadth-First Search) adalah metode pencarian jalur pada graf yang dilakukan dengan mengunjungi simpul-simpul graf secara berurutan mulai dari simpul awal hingga simpul terakhir, dengan cara mengeksplorasi semua simpul yang terhubung dengan simpul awal terlebih dahulu sebelum bergerak ke simpul yang lebih jauh. Metode pencarian ini dilakukan dengan menggunakan teknik antrian, di mana simpul-simpul yang dieksplorasi akan ditambahkan ke dalam antrian dan diambil satu per satu sesuai dengan urutan kedatangan. Dengan metode BFS, simpul-simpul graf akan ditelusuri secara lebar dan teratur, sehingga metode ini sangat berguna dalam menemukan jalur terpendek antara simpul-simpul pada graf dan memeriksa keterhubungan antara simpul-simpul pada graf dengan banyak cabang dan relasi yang kompleks. Selain itu, metode BFS juga sering digunakan dalam pengembangan perangkat lunak dan analisis data untuk memecahkan masalah yang melibatkan graf dan struktur data.

## Struktur Folder
```
.
├── README.md
├── Tubes2_Ckptw.csproj
├── Tubes2_Ckptw.csproj.user
├── Tubes2_Ckptw.sln
├── app.manifest
├── bin
│   ├── Avalonia.Animation.dll
│   ├── Avalonia.Base.dll
│   ├── Avalonia.Controls.dll
│   ├── Avalonia.DesignerSupport.dll
│   ├── Avalonia.Desktop.dll
│   ├── Avalonia.DesktopRuntime.dll
│   ├── Avalonia.Dialogs.dll
│   ├── Avalonia.FreeDesktop.dll
│   ├── Avalonia.Input.dll
│   ├── Avalonia.Interactivity.dll
│   ├── Avalonia.Layout.dll
│   ├── Avalonia.Markup.Xaml.dll
│   ├── Avalonia.Markup.dll
│   ├── Avalonia.MicroCom.dll
│   ├── Avalonia.Native.dll
│   ├── Avalonia.OpenGL.dll
│   ├── Avalonia.ReactiveUI.dll
│   ├── Avalonia.Remote.Protocol.dll
│   ├── Avalonia.Skia.dll
│   ├── Avalonia.Styling.dll
│   ├── Avalonia.Themes.Default.dll
│   ├── Avalonia.Themes.Fluent.dll
│   ├── Avalonia.Visuals.dll
│   ├── Avalonia.Win32.dll
│   ├── Avalonia.X11.dll
│   ├── Avalonia.dll
│   ├── Debug
│   │   ├── net6.0
│   │   │   ├── Avalonia.Animation.dll
│   │   │   ├── Avalonia.Base.dll
│   │   │   ├── Avalonia.Controls.DataGrid.dll
│   │   │   ├── Avalonia.Controls.dll
│   │   │   ├── Avalonia.DesignerSupport.dll
│   │   │   ├── Avalonia.Desktop.dll
│   │   │   ├── Avalonia.DesktopRuntime.dll
│   │   │   ├── Avalonia.Diagnostics.dll
│   │   │   ├── Avalonia.Dialogs.dll
│   │   │   ├── Avalonia.FreeDesktop.dll
│   │   │   ├── Avalonia.Input.dll
│   │   │   ├── Avalonia.Interactivity.dll
│   │   │   ├── Avalonia.Layout.dll
│   │   │   ├── Avalonia.Markup.Xaml.dll
│   │   │   ├── Avalonia.Markup.dll
│   │   │   ├── Avalonia.MicroCom.dll
│   │   │   ├── Avalonia.Native.dll
│   │   │   ├── Avalonia.OpenGL.dll
│   │   │   ├── Avalonia.ReactiveUI.dll
│   │   │   ├── Avalonia.Remote.Protocol.dll
│   │   │   ├── Avalonia.Skia.dll
│   │   │   ├── Avalonia.Styling.dll
│   │   │   ├── Avalonia.Themes.Default.dll
│   │   │   ├── Avalonia.Themes.Fluent.dll
│   │   │   ├── Avalonia.Visuals.dll
│   │   │   ├── Avalonia.Win32.dll
│   │   │   ├── Avalonia.X11.dll
│   │   │   ├── Avalonia.dll
│   │   │   ├── DynamicData.dll
│   │   │   ├── HarfBuzzSharp.dll
│   │   │   ├── JetBrains.Annotations.dll
│   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.dll
│   │   │   ├── Microsoft.CodeAnalysis.CSharp.dll
│   │   │   ├── Microsoft.CodeAnalysis.Scripting.dll
│   │   │   ├── Microsoft.CodeAnalysis.dll
│   │   │   ├── Microsoft.Win32.SystemEvents.dll
│   │   │   ├── ReactiveUI.dll
│   │   │   ├── SkiaSharp.dll
│   │   │   ├── Splat.dll
│   │   │   ├── System.Drawing.Common.dll
│   │   │   ├── System.Reactive.dll
│   │   │   ├── Tmds.DBus.dll
│   │   │   ├── Tubes2_Ckptw.deps.json
│   │   │   ├── Tubes2_Ckptw.dll
│   │   │   ├── Tubes2_Ckptw.exe
│   │   │   ├── Tubes2_Ckptw.pdb
│   │   │   ├── Tubes2_Ckptw.runtimeconfig.json
│   │   │   ├── cs
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── de
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── es
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── fr
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── it
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── ja
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── ko
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── pl
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── pt-BR
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── ru
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── runtimes
│   │   │   │   ├── linux-arm
│   │   │   │   │   └── native
│   │   │   │   │       ├── libHarfBuzzSharp.so
│   │   │   │   │       └── libSkiaSharp.so
│   │   │   │   ├── linux-arm64
│   │   │   │   │   └── native
│   │   │   │   │       ├── libHarfBuzzSharp.so
│   │   │   │   │       └── libSkiaSharp.so
│   │   │   │   ├── linux-musl-x64
│   │   │   │   │   └── native
│   │   │   │   │       ├── libHarfBuzzSharp.so
│   │   │   │   │       └── libSkiaSharp.so
│   │   │   │   ├── linux-x64
│   │   │   │   │   └── native
│   │   │   │   │       ├── libHarfBuzzSharp.so
│   │   │   │   │       └── libSkiaSharp.so
│   │   │   │   ├── osx
│   │   │   │   │   └── native
│   │   │   │   │       ├── libAvaloniaNative.dylib
│   │   │   │   │       ├── libHarfBuzzSharp.dylib
│   │   │   │   │       └── libSkiaSharp.dylib
│   │   │   │   ├── unix
│   │   │   │   │   └── lib
│   │   │   │   │       └── netcoreapp2.0
│   │   │   │   │           └── System.Drawing.Common.dll
│   │   │   │   ├── win
│   │   │   │   │   └── lib
│   │   │   │   │       └── netcoreapp2.0
│   │   │   │   │           ├── Microsoft.Win32.SystemEvents.dll
│   │   │   │   │           └── System.Drawing.Common.dll
│   │   │   │   ├── win-arm64
│   │   │   │   │   └── native
│   │   │   │   │       ├── av_libglesv2.dll
│   │   │   │   │       ├── libHarfBuzzSharp.dll
│   │   │   │   │       └── libSkiaSharp.dll
│   │   │   │   ├── win-x64
│   │   │   │   │   └── native
│   │   │   │   │       ├── libHarfBuzzSharp.dll
│   │   │   │   │       └── libSkiaSharp.dll
│   │   │   │   ├── win-x86
│   │   │   │   │   └── native
│   │   │   │   │       ├── libHarfBuzzSharp.dll
│   │   │   │   │       └── libSkiaSharp.dll
│   │   │   │   ├── win7-x64
│   │   │   │   │   └── native
│   │   │   │   │       └── av_libglesv2.dll
│   │   │   │   └── win7-x86
│   │   │   │       └── native
│   │   │   │           └── av_libglesv2.dll
│   │   │   ├── tr
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   ├── zh-Hans
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │   │   ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │   │   └── Microsoft.CodeAnalysis.resources.dll
│   │   │   └── zh-Hant
│   │   │       ├── Microsoft.CodeAnalysis.CSharp.Scripting.resources.dll
│   │   │       ├── Microsoft.CodeAnalysis.CSharp.resources.dll
│   │   │       ├── Microsoft.CodeAnalysis.Scripting.resources.dll
│   │   │       └── Microsoft.CodeAnalysis.resources.dll
│   │   └── net6.0-windows
│   │       ├── Tubes2_Ckptw.deps.json
│   │       ├── Tubes2_Ckptw.dll
│   │       ├── Tubes2_Ckptw.exe
│   │       ├── Tubes2_Ckptw.pdb
│   │       └── Tubes2_Ckptw.runtimeconfig.json
│   ├── DynamicData.dll
│   ├── HarfBuzzSharp.dll
│   ├── JetBrains.Annotations.dll
│   ├── Microsoft.Win32.SystemEvents.dll
│   ├── ReactiveUI.dll
│   ├── Release
│   │   └── net6.0-windows
│   ├── SkiaSharp.dll
│   ├── Splat.dll
│   ├── System.Drawing.Common.dll
│   ├── System.Reactive.dll
│   ├── Tmds.DBus.dll
│   ├── Tubes2_Ckptw.deps.json
│   ├── Tubes2_Ckptw.dll
│   ├── Tubes2_Ckptw.exe
│   ├── Tubes2_Ckptw.runtimeconfig.json
│   └── runtimes
│       ├── linux-arm
│       │   └── native
│       │       ├── libHarfBuzzSharp.so
│       │       └── libSkiaSharp.so
│       ├── linux-arm64
│       │   └── native
│       │       ├── libHarfBuzzSharp.so
│       │       └── libSkiaSharp.so
│       ├── linux-musl-x64
│       │   └── native
│       │       ├── libHarfBuzzSharp.so
│       │       └── libSkiaSharp.so
│       ├── linux-x64
│       │   └── native
│       │       ├── libHarfBuzzSharp.so
│       │       └── libSkiaSharp.so
│       ├── osx
│       │   └── native
│       │       ├── libAvaloniaNative.dylib
│       │       ├── libHarfBuzzSharp.dylib
│       │       └── libSkiaSharp.dylib
│       ├── unix
│       │   └── lib
│       │       └── netcoreapp2.0
│       │           └── System.Drawing.Common.dll
│       ├── win
│       │   └── lib
│       │       └── netcoreapp2.0
│       │           ├── Microsoft.Win32.SystemEvents.dll
│       │           └── System.Drawing.Common.dll
│       ├── win-arm64
│       │   └── native
│       │       ├── av_libglesv2.dll
│       │       ├── libHarfBuzzSharp.dll
│       │       └── libSkiaSharp.dll
│       ├── win-x64
│       │   └── native
│       │       ├── libHarfBuzzSharp.dll
│       │       └── libSkiaSharp.dll
│       ├── win-x86
│       │   └── native
│       │       ├── libHarfBuzzSharp.dll
│       │       └── libSkiaSharp.dll
│       ├── win7-x64
│       │   └── native
│       │       └── av_libglesv2.dll
│       └── win7-x86
│           └── native
│               └── av_libglesv2.dll
├── doc
│   └── Ckptw.pdf
├── obj
│   ├── Debug
│   │   ├── net6.0
│   │   │   ├── Avalonia
│   │   │   │   ├── Resources.Inputs.cache
│   │   │   │   ├── original.dll
│   │   │   │   ├── original.pdb
│   │   │   │   ├── references
│   │   │   │   └── resources
│   │   │   ├── Tubes2_Ckptw.AssemblyInfo.cs
│   │   │   ├── Tubes2_Ckptw.AssemblyInfoInputs.cache
│   │   │   ├── Tubes2_Ckptw.GeneratedMSBuildEditorConfig.editorconfig
│   │   │   ├── Tubes2_Ckptw.assets.cache
│   │   │   ├── Tubes2_Ckptw.csproj.AssemblyReference.cache
│   │   │   ├── Tubes2_Ckptw.csproj.BuildWithSkipAnalyzers
│   │   │   ├── Tubes2_Ckptw.csproj.CopyComplete
│   │   │   ├── Tubes2_Ckptw.csproj.CoreCompileInputs.cache
│   │   │   ├── Tubes2_Ckptw.csproj.FileListAbsolute.txt
│   │   │   ├── Tubes2_Ckptw.dll
│   │   │   ├── Tubes2_Ckptw.genruntimeconfig.cache
│   │   │   ├── Tubes2_Ckptw.pdb
│   │   │   ├── apphost.exe
│   │   │   ├── ref
│   │   │   │   └── Tubes2_Ckptw.dll
│   │   │   └── refint
│   │   │       └── Tubes2_Ckptw.dll
│   │   └── net6.0-windows
│   │       ├── Tubes2_Ckptw.AssemblyInfo.cs
│   │       ├── Tubes2_Ckptw.AssemblyInfoInputs.cache
│   │       ├── Tubes2_Ckptw.Form1.resources
│   │       ├── Tubes2_Ckptw.GeneratedMSBuildEditorConfig.editorconfig
│   │       ├── Tubes2_Ckptw.GlobalUsings.g.cs
│   │       ├── Tubes2_Ckptw.assets.cache
│   │       ├── Tubes2_Ckptw.csproj.AssemblyReference.cache
│   │       ├── Tubes2_Ckptw.csproj.BuildWithSkipAnalyzers
│   │       ├── Tubes2_Ckptw.csproj.CoreCompileInputs.cache
│   │       ├── Tubes2_Ckptw.csproj.FileListAbsolute.txt
│   │       ├── Tubes2_Ckptw.csproj.GenerateResource.cache
│   │       ├── Tubes2_Ckptw.designer.deps.json
│   │       ├── Tubes2_Ckptw.designer.runtimeconfig.json
│   │       ├── Tubes2_Ckptw.dll
│   │       ├── Tubes2_Ckptw.genruntimeconfig.cache
│   │       ├── Tubes2_Ckptw.pdb
│   │       ├── apphost.exe
│   │       ├── ref
│   │       │   └── Tubes2_Ckptw.dll
│   │       └── refint
│   │           └── Tubes2_Ckptw.dll
│   ├── Release
│   │   └── net6.0-windows
│   │       ├── Tubes2_Ckptw.AssemblyInfo.cs
│   │       ├── Tubes2_Ckptw.AssemblyInfoInputs.cache
│   │       ├── Tubes2_Ckptw.GeneratedMSBuildEditorConfig.editorconfig
│   │       ├── Tubes2_Ckptw.GlobalUsings.g.cs
│   │       ├── Tubes2_Ckptw.assets.cache
│   │       ├── Tubes2_Ckptw.csproj.AssemblyReference.cache
│   │       ├── ref
│   │       └── refint
│   ├── Tubes2_Ckptw.csproj.nuget.dgspec.json
│   ├── Tubes2_Ckptw.csproj.nuget.g.props
│   ├── Tubes2_Ckptw.csproj.nuget.g.targets
│   ├── project.assets.json
│   └── project.nuget.cache
├── src
│   ├── App.axaml
│   ├── App.axaml.cs
│   ├── Assets
│   │   ├── avalonia-logo.ico
│   │   └── icon.ico
│   ├── BFS
│   │   └── BFS.cs
│   ├── DFS
│   │   └── DFS.cs
│   ├── FileReader
│   │   └── FileReader.cs
│   ├── Models
│   │   ├── Maze.cs
│   │   └── MazePath.cs
│   ├── Program.cs
│   ├── Roots.xml
│   ├── ViewLocator.cs
│   ├── ViewModels
│   │   ├── MainWindowViewModel.cs
│   │   ├── MazeViewModel.cs
│   │   └── ViewModelBase.cs
│   └── Views
│       ├── MainWindow.axaml
│       ├── MainWindow.axaml.cs
│       ├── MazeView.axaml
│       └── MazeView.axaml.cs
└── test
    ├── 1x5.txt
    ├── 4x5.txt
    ├── check.txt
    ├── check1.txt
    ├── map1.txt
    ├── map2.txt
    ├── map3.txt
    ├── map3_aman.txt
    ├── ngaco.txt
    ├── sampel-1.txt
    ├── sampel-2.txt
    ├── sampel-3.txt
    ├── sampel-4.txt
    ├── sampel-5.txt
    └── text.txt
```


## Requirements
Untuk dapat menjalankan permainan ini, maka pastikan perangkat sudah dilengkapi oleh aplikasi berikut :

1. .NET 7
2. Visual Studio

## Cara menjalankan program

Untuk membangun dan menjalankan program ini diperlukan proses berikut
1. Clone repository yang berada pada lampiran
2. Install .NET 7 dan Visual Studio
3. Buka Visual Studio
4. Pilih file lalu tekan open
5. Pilih Project/Solution
6. Arahkan pada program yang sudah di clone sebelumnya
7. Lalu pilih Tubes2_Ckptw.csproj atau Tubes2_Ckptw.sln
8. Setelah kembali ke Visual Studio tekan tombol play berwarna hijau di samping tulisan 
   Tubes2_Ckptw
9. Program akan berjalan sesuai dengan semestinya

## Cara menggunakan program

1. buatlah file dengan format txt terlebih dahulu untuk membuat sebuah map seperti berikut

![image](https://user-images.githubusercontent.com/89321009/227572142-e68d2c73-c465-4ef4-858e-6a29952ae527.png)

2. buka program sesuai dengan arahan pada sub ``Cara menjalankan program``

3. tekan tombol ReadFile untuk membuka map yang sudah dibuat
![image](https://user-images.githubusercontent.com/89321009/227572580-3b4c422e-2857-4e14-9873-47a6aae4d1bb.png)

4. pilih file txt yang baru saja dibuat

5. program akan menampilkan map seperti ini
![image](https://user-images.githubusercontent.com/89321009/227572883-86e86c54-a061-44aa-9336-eb48f2c820fe.png)

6. untuk memecahkan maze treasure kita dapat memilih toggle DFS dan BFS dan bisa memilih ingin menggunakan TSP atau tidak
![image](https://user-images.githubusercontent.com/89321009/227573340-b6b1785c-f978-4ae5-b48a-24bf5385d42f.png)

7. jika sudah memilih tekan tombol Visualize

8. Contoh program jika sudah ditekan tombol visualize
![image](https://user-images.githubusercontent.com/89321009/227573521-8677f647-5c7e-413b-a529-0c79c332278e.png)
![image](https://user-images.githubusercontent.com/89321009/227573605-1d17bf64-5a03-4814-bf88-ba5698160c1e.png)


## Author
```
1. 13521031 - Fahrian Afdholi
2. 13521091 - Fakih Anugerah Pratama
3. 13521165 - Reza Pahlevi Ubaidillah
```
