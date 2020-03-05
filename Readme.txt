
CSE 0559 Yazılım Mimarisi ve Entegrasyonu - CQRS ve Event Sourcing

* Her proje için docker file hazırlandı ardından Proje nin oldu dizinde docker compose up yapıldığında tüm projeler ayağa kalkacak şekilde yaml dosyası düzenlendi.
* API Gateway (Ocelot) -> localhost:6543
* UI -> localhost:3461 
* RabbitMQ -> default portundan hizmet vermekte ve kullanıcı adı : test , şifre : test
* Proje DB olacak Microsoft Sql Server Linux kullanılmaktadır. Kullanıcı adı : sa , Şifre : Pass@word ve Port : 5553
* UI projesinde validasyonlar yapılmadığında ilgili alanlar boş geçildiğinde hata verebilir.


Image ları indirmesi için internet bağlantısı olan bir bilgisayar üzerinde proje dizininde docker compose up denildiğinde tüm projeler çalışır hale gelir.

