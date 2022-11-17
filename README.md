# SanctionScannerCrawling

                                   #İZLENİLEN ADIMLAR ve Çalışma Aşamaları#  
*  Öncelik olarak "C:\htmldownload"  htmldownload adlı dosya oluşturuyoruz, daha sonra "C:\demo" klasörü altına "demo.txt" adlı dosyayı oluşturuyoruz.
* WebClient ile 1 kere İstek atıyor ve html sayfası indiriliyor. 

* Bilgisayarımızda bulunan HTML sayfası içerisinde İsim ve Fiyat Regex ile aratılıyor.

* Regex ile match ettikten sonra Console ekranına yazdırılıyor.

* Aynı zamanda çok kısa bir süre içerisinde yolu belirlenen txt dosyası içerisine kaydediliyor.

* İşlemler bittiğinde html dosyası siliniyor ve 5 dakika uyku moduna alınıyor.

* While döngüsü her 5 dakika bir çalıştırılıyor, 5 dakika olmasının sebebi yaptığım testlerde her 5 dakikada bir vitrin sayfasına yeni veriler ekleniyor(Bu süreç bazen 20 dakika olabiliyor yaptığım 1 saat test üzerine değişiklik gösterebiliyor.).Hem 5 dakikada bir istek attığımız için ban riski neredeyse yok oluyor, hem verilerimizi 1 saniye içerisinde ekrana ve txt dosyamıza kaydediyor.

*************************************************
                                                 
*Crawling Uygulaması geliştirme aşamasında taskı ilk açtığımda, araştırmalarıma başlamadan önce algoritma tasarlamaya başladım nasıl olabilir. 
En basit şekilde aklıma gelen,  "Thread.Sleep" ufak bir yavaşlatmaydı ama bu her zaman çalışmaz, her geçen gün yeni önlemler alınıyor ve hem istediğim
veriyi hem yavaş alacaktım,hem her 5 10 saniyede bir istek atıyordum sonuçta bu yöntem sonsuza dek çalışmaz.

*Daha farklı bir yapı düşündüm aklıma ilk gelen "Cloud Server" ile bir algoritma tasarladım, bu algoritma üzerinde yapı şu şekildeydi 5 farklı Cloud Server açıyordum, 
Google Cloud, Amazon Cloud vb. Cloud hizmeti veren şirketler üzerinde serverleri kurdum, istek her 2 saniyede bir farklı bir server IP'si üzerinden siteye istek atacaktı ama sonunda düşündüğümde hem maliyetli olacaktı, hem de belli bir noktadan sonra buda anlaşılabilir hale gelecekti.

*Bundan sonra aklıma tasarladığım yapı bir IpList şeklinde dosya oluşturmaktı sunucum üzerinde bir liste oluşturup Headers kısmına ipleri sırasıyla yazdıracak istek her seferinde farklı ip üzerinden atılacaktı onlarca ip olduğundan dolayı ban yemek riski oldukça azalıyordu. Hem çok mantıklı geldi hem WebClient gibi hizmetleri daha önce kullandığım için istek atma işlemlerini biliyordum. Sürekli WebClient isteği atmak istemiyordum bu yöntemde tam mantıklı olmuyordu.Asıl kullancağım algoritmayı tasarladım.

*Sürekli istek atmaktan vazgeçip,olağan HTML sayfasını bilgisayarıma indirmeye karar verdim.Sonuçta diğer türlü  yavaş yazdırılacaktı ve yavaş yazdırmak hiç istenilen
bir olay değildir çünkü yazılımlar işimizi kolaylaştırsın diye yapılır.

*WebClient ile html sayfasını indirdim, kendimi bir tarayıcı gibi gösterdiğim için banlanmıyordum.
*Dosya bilgisayara indirildi, bilgisayardaki dosyayı Regex ile match ettikten sonra isimleri ve fiyatları ve ortalamayı aldım ve console ekranına yazdırdım. Son kalan kısım dosyayı kaydetmekti, 
"StreamWriter" ile dosyayı istediğim yere kaydettim.Bu işlemden sonra html otomatik sildirterek, vitrin sayfası güncellenene kadar uyku moduna aldım, her güncellemede tekrardan çalıştırıp verileri kaydedilmesini sağlıyorum.
