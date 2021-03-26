# Tubes2_13519009

## Penjelasan singkat algoritma yang diimplementasikan
Program ini dibuat dengan beberapa langkah. Pertama, saat file .txt dimasukkan ke program, program akan membaca file tersebut, dan mengonversinya menjadi graf, sesuai dengan edge  yang ada di file. Setelah program mengubah file menjadi graf, akan muncul simpul-simpul dari graf tersebut. Kemudian pengguna dapat menjalankan fitur explore friend, friends recommendation sesuai dengan algoritma yang diinginkan, yaitu breadth first search dan depth first search.
### Explore Friends Breadth First Search
Pada algoritma explore friends dengan pendekatan BFS, simpul yang menjadi asal akan mencari simpul yang menjadi tujuan. Simpul asal akan maju secara rekursif ke simpul yang bertetangga denganya. Simpul-simpul yang bertetangga ini akan dianggap tidak bisa dikunjungi saat pengunjungan simpul selanjutnya jika bukan simpul-simpul tersebut yang dikunjungi. Jika ketemu simpul tujuan, pencarian akan berhenti. Namun jika tidak, pencarian akan terus dilakukan sampai suatu simpul tidak bisa mengunjungi simpul yang bertetangga dengannya, karena simpul-simpul tetangga tersebut sudah dikunjungi. Namun,pengunjungan simpul dapat mundur jika memang tidak ada simpul setelahnya.
### Explore Friends Depth First Search
Pada algoritma explore friends dengan pendekatan DFS, simpul yang menjadi asal akan mencari simpul yang menjadi tujuan. Simpul asal akan maju secara rekursif ke simpul yang bertetangga denganya. Jika ketemu simpul tujuan, pencarian akan berhenti. Namun jika tidak, pencarian akan terus dilakukan sampai suatu simpul tidak bisa mengunjungi simpul yang bertetangga dengannya, karena simpul-simpul tetangga tersebut sudah dikunjungi. Namun, pengunjungan simpul dapat mundur jika memang tidak ada simpul setelahnya.
### Friend Recommendation
Pada friend recommendation, yang dicari adalah friend recommendation dari simpul awal yang dipilih di explore friend. Algoritma ini mulanya akan mencari simpul-simpul tetangga dari simpul awal. Kemudian, simpul-simpul tetangga tersebut akan mencari simpul-simpul tetangga mereka sebagai friend recommendation untuk simpul awal. Kemudian simpul-simpul yang dijadikan friend recommendation tadi akan diurutkan berdasarkan mutual friend dengan simpul awal atau jumlah simpul tetangga yang sama dengan simpul awal.
## Requirement program dan instalasi
- C#
- .NET application framework => 4.0 version
### Khusus Linux (Ubuntu distros and derived)
- Install mono-mcs package
```bash
sudo apt-get install -y mono-mcs
```
## Cara menggunakan program
### Windows
- Download/clone https://github.com/mochfatchur/Tubes2_13519009.git
```bash
git clone https://github.com/mochfatchur/Tubes2_13519009.git
```
- Pergi ke direktori bin.
- Run **People_May_You_Know.exe**
### Linux
- Download/clone https://github.com/mochfatchur/Tubes2_13519009.git
```bash
git clone https://github.com/mochfatchur/Tubes2_13519009.git
```
- Pergi ke direktori bin.
- Jalankan **People_May_You_Know.exe** 
```bash
mono People_May_You_Know.exe
```
## Author / identitas pembuat
- [Mochammd Fatchur Rochman (13519009)](https://github.com/mochfatchur)
- [Yudi Alfayat (13519051)](https://github.com/yudialfayat)
- [Mgs. Tabrani (13519122)](https://github.com/mgstabrani)
