# SanctionScannerCrawling

                                   #İZLENİLEN ADIMLAR ve Çalışma Aşamaları#  
* WebClient ile 1 kere İstek atıyor ve html sayfası indiriliyor.

* Bilgisayarımızda bulunan HTML sayfası içerisinde ki İsim ve Fiyat Regex ile aratılıyor.

* Regex ile match ettikten sonra Console ekranına yazdırılıyor.

* Aynı zamanda çok kısa bir süre içerisinde yolu belirlenen txt dosyası içerisine kaydediliyor.

* İşlemler bittiğinde html dosyası siliniyor ve 5 dakika uyku moduna alınıyor.

* While döngüsü her 5 dakika bir çalıştırılıyor, 5 dakika olmasının sebebi yaptığım testlerde her 5 dakikada bir vitrin sayfasına yeni veriler ekleniyor.Hem 5 dakikada
bir istek attığımız için ban riski neredeyse yok oluyor, hem verilerimizi 1 saniye içerisinde ekrana ve txt dosyamıza kaydediyor.

*************************************************
                                                 
*Crawling Uygulaması geliştirme aşamasında taskı ilk açtığımda, araştırmalarıma başlamadan önce algoritma tasarlamaya nasıl olabilir. 
En basitinden düşündüğümde herkesin ilk aklına gelen "Thread.Sleep" ufak bir yavaşlatmaydı ama bu her zaman çalışmaz, her geçen gün yeni önlemler alınıyor ve hem istediğim
veriyi hem yavaş alacaktım,hem her 5 10 saniyede bir istek atıyordum sonuçta buda bi yerden sonra anlaşılabilir bir haldeydi.

*Daha farklı bir yapı düşündüm aklıma ilk gelen "Cloud Server" ile bir algoritma planladım, bu algoritma üzerinde yapı şu şekildeydi 5 farklı Cloud Server açıyordum, 
Google Cloud, Amazon Cloud vb. Cloud hizmeti veren şirketler üzerinde serverleri kurdum, istek her 2 saniyede bir farklı bir server IP'si üzerinden siteye istek atacaktı
ama sonunda düşündüğümde hem maliyetli olacaktı, hem de belli bir noktadan sonra buda anlaşılabilir hale gelecekti.

*Bundan sonra aklıma gelende bir IpList şeklinde dosya oluşturmaktı sunucum üzerinde bir liste oluşturup Headers kısmına ipleri sırasıyla yazdıracak isteklerimi her
seferinde farklı ip üzerinden atılacaktı onlarca ip olduğundan dolayı ban yemek riski oldukça azalıyordu. Hem çok mantıklı geldi hem WebClient gibi hizmetleri daha önce
kullandığım için istek atma işlemlerini biliyordum. Sürekli WebClient isteği atmak tam kafama oturmamıştı bir türlü, daha sonra vakit kaybetmeden WebClient araştırmasına
başladım.Belirli satırlar nasıl çekilir gibisinden içerisinde ki div gibi html kodlarından olduğunu gördüğümde girdim mantığını anladım testlerime başladım.Gün sonunda
belirli aşama kaydettim daha sonrasında farklı bir yapı kurdum kafamda şuan asıl kullanmakta olduğum yapıya geçiyorum şimdi.

*Sürekli istek atmaktan vazgeçip,Olağan HTML sayfasını bilgisayarıma indirmeye karar verdim.Sonuçta diğer türlü hem yavaş yazdırılacaktı ve yavaş yazdırmak hiç istenilen
bir olay değildir çünkü yazılımları işimizi kolaylaştırsın diye yaparız. 
*WebClient ile html sayfasını indirdim, kendimi bir tarayıcı gibi gösterdiğim için ban yemiyordum.
*Dosya Bilgisayarımda oldu, bilgisayarımda ki dosyayı Regex ile aratıcaktım daha önce kullanmıştım ama html kodları arasından biraz karmaşıktı baştan sona araştırdım ve 
aratacağım metodu buldum. Regex ile match ettikten sonra isimleri ve fiyatları ve ortalamayı aldım ve console ekranına yazdırdım. Son kalan kısım dosyayı kaydetmekti, 
"StreamWriter" ile dosyayı istediğim yere kaydettim. 
