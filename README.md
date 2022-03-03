# ShopCommerce
E TİCARET PROJE
SHOPCOMMERCE

GENEL BAKIŞ
1. PROJE AÇIKLAMASI

ShopCommerce, Asp.Net Core teklolojisini kullanan ve
katmanlı mimari üzerine kurulan, genişlemeye müsait bir mini
pazaryeri projesidir.

 2. KATMANLAR 
 
    1-) Entity Layer
    - Veritabanı nesnelerinin tutulduğu katman

    2-) Data Access Layer
    - Veritabanı CRUD işlemlerinin yaptırıldığı katmandır.

    3-) Bussiness Layer

    - Projeye ait iş kurallarının yazıldığı katmandır.
    
    4-) UI
    - Projenin Kullanıcı Arayüz katmanıdır.
     - Bu projede arayüz için mvc teknolojisi kullanılmaktadır.
     
3.KULLANICI TÜRLERİ
Sistemde 3 tür kullanıcı vardır.

1-) Normal Kullanıcılar (users)
 - herkes e posta vs gerekli bilgileri sisteme girip, üye olabilir ve alışverişe
başlayabilir.

2-) Satıcılar (sellers)
 - Sistemde mağaza kurup satış yapmak isteyenler, gerekli bilgileri girip formu
gönderdikten sonra onaylanması durumunda sisteme girip, ürün ekleyip, satış
yapmaya başlayabilir.
 - Mağaza kuran satıcılar mağazalarına başka satıcılar da ekleyebilir.
 
3-) Yöneticiler(admins)
 - Sistemde yöneticiler rollerine göre ayrılır ve farklı yetkilere sahiptir. Isteyen
herkes yönetici olamaz. Sistemde bir “Genel Yönetici” vardır ve Yöneticileri
rollerine göre, ekleyip, bloklayabilir.

4-)işleyiş
 - Kullanıcı sisteme üye olmadan girebilir, ve izin verilen sayfalarda dolaşarak
ürünleri inceleyebilir.
- Kullanıcı ürün satın almak için sisteme üye olmalıdır.
- Kullanıcı üye olduktan sonra, kullanıcıya özel bir sepet oluşturulur ve
kullanıcı buraya ürün ekleyip daha sonra satın almaya devam edebilir.
- Kullanıcı ürünlere beğeni atabilir ve daha sonra bunları görüntüleyebilir.
- Kullanıcı’nın sipariş ettiği ürünleri takip edebileceği bir sipariş takip
sayfası projeye eklenmiştir.
- Kullanıcı, ürün sipariş ettikten sonra, kargoya verilmeyen ürünleri iptal
edebilir. Teslim edilen ürünler ise iade için gönderilebilir.
- Kullanıcılar rahat bir şekilde ürün araması yapabilsin diye sayfa
yenilenmeden, seçilen kategori, fiyat aralığı ve – veya marka
filtrelemeleri ile arama yapabilecekleri bir arama sayfası (/magazadaara) eklenmiştir.
- Ürün arama için Ajax teknolojisi kullanılmıştır. bu sayede daha kaliteli bir
kullanıcı deneyimi elde edilir.
- Satıcılar gerekli bilgileri girip sistemde mağaza kurarlar.
 - satıcı kendisine özel yönetim panelinden, ürün ekleyebilir, ürünlerini
düzenleyebilir, ürünlerini silebilir ve kendine özel bilgileri düzenleyebilir.
- Satıcının eklediği ürüne ait görseller /wwwroot/ProductImages/ProductFixed-Name klasörü altına eklenir. Not: Product-Fixed-Name, ürüne özel
seo url’sidir.
- Eklenen ürün yönetici onayından geçtikten sonra kullanıcılara erişilebilir
olacaktır.
- Bir kullanıcının bir mağazada ürün listeleyebilir, ama bir mağazaya
birden fazla satıcı eklenebilmektedir.
- Kullanıcı bir sipariş verdiğinde siparişteki ürünler hangi satıcı tarafından
girilmiş ise o satıcının sipariş sayfasına düşer. (/Seller/Orders)
- Bir siparişe birden fazla ürün eklenebilir
- Bir siparişte birden fazla satıcının ürünleri eklenebilir.
- Bir kullanıcı, bir üründen en fazla stok adedi kadar sipariş edebilir.
- Yöneticiler
 - Yöneticiler rollerine göre eklenebilir.
- Yönetici ekleme yetkisi “Genel Yönetici”ye aittir.
- Sistemin en üst yetkilileridirler.
- Satıcılar sistemde mağaza kurmak istediklerinde, genel yönetici bu
mağaza ve satıcıları onayladıktan sonra bu satıcılar sisteme giriş
yapabilir.
- Genel yönetici, satıcıları ve mağazaları bloklyabilir.

5.VERİTABANI
 - Projede veritabanı yönetim sistemi olarak mssql server 2019 tercih
edilmiştir.
- Veritabanı adı DbShopCommerce’dir.
- Veritabanı, birbirleri ile ilişkili 21 adet tablodan oluşmaktadır. Bu tablolar
şunlardır.
 1-) Tablolar
 Admins, AdminStatus, Adresses,Brands, Cards,CargoFirms, Cards, Orders ,
OrderIcns, OrderProducts, OrderStatus, PaymentTypes, Products,
ProductImages,ProductProperties,Sellers,Ships, ShipStatus, Shops,Users, Wishes
 2-) Diyagram
 
6.KULLANILAN YAZILIM DİLİ

 Bu Projede yazılım dili olarak c# tercih edilmiştir. Not asp.net core 5 sürümü
üzerinde çalışılmaktadır.
7.TASARIM DESENİ
 Bu Projede tasarım deseni olarak Repository Pattern tercih edilmiştir.
Yeni bir entity girmek istersek ne yapmalıyız?
1-)Data access layer altında Abstract klasörü altına ilgili entity için bir interface
oluturun. Bu interface IRepositoryDal interfacesinden kalıtım almalıdır.
2-) Data access layer altında EntityFramework klasörü altına ilgili entity için bir
class oluşturun, bu class EfGenericRepositry classından kalıtım almalı ve daha
önce oluşturduğumuz interface implement edilmelidir.
3-) Bussiness layer altında Abstract klasörü altına ilgili entity için bir interface
oluturun. Bu interface IService interfacesinden kalıtım almalıdır.
4-) Bussiness layer altında Concrete klasörü altına ilgili entity için bir class
oluşturun, bu class Manager classından kalıtım almalı ve 3.adımda
oluşturduğumuz interface implement edilmelidir.
 
