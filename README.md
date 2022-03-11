# ContactRise - Telefon rehberi uygulaması oluşturulması


## Teknolojiler ##

- .Net Core 5.0
- MongoDB
- Swagger
- AutoMapper
- MediatR
- CQRS
- RabbitMQ

# Açıklama

Uygulama API üzerinde çalışmaktadır.
MongoDB , RabbitMQ bağlantılarını ilgili API'da bulunan appsettings.json içerisinden ayarlanabilir.
RabbitMQ ilgili projelerde kullanmak için bir proje olusturulmuş ve mikroservislere implement edilebilir.
Mesaj kuyrugu için constants adı oluşturulmuştur.
Core Projesi altında Enum,BaseCOntext,ApiResponse,Entity,Repo vb. classlar oluşturulmustur.
2 mikroservisi APIGateway altında Report.aggregator üzerinden HTTP protokolu haberleştirilmiştir.

# Eksiklikler 

- RabbitMQ mesaj kuyruğu consume ve subscriber edilmesi
- İlgili raporun hazırlanması.
