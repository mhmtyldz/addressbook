# AddressBook
## Projeyi çalıştırmak için gereksinimler.


- rabbitmq ayağa kaldırılır local üzerinden(docker) 
- mongodb ayaka kaldırılır local üzerinden(docker)
- Mongo db deki dataları görmek için mongo compass uygulaması indirilir ve local üzerinden bağlanılır.
- ms sql server kurulur ve dataları görebilmek için management studio kurulur.
- .net core 5.0 sdk kurulur ve visual studio 2019 bilgisayara kurulur.
- Proje locale github üzerinden clone edilir.
- 

## Proje Nasıl Çalıştırılır.

Microservis mantığı olduğu için, Solution'a sağ tıklayı set startup project denir. Multiple startup project dedikten sonra orada bulunan AddressBook.Contacts, AddressBook.Report, Adressbook.Ocelot.Gateways ve AddressBook.UI çalıştırılır. Projeleri application şeklinde çalıştırıyoruz. iis üzerinden değil. Her projenin içerisinde bulunan launchSettings.json dosyası üzerinden portlarını değiştirebiliriz.

Projede bulunan tüm gereksinimler tamamlanmış ise. UI Ekranı karşımıza gelir. 
Burdaki menüde contact alanından contact ekliyoruz. Report kısmında da locationlara göre kişiler ve telefon numaraları sayılarının basit bir dökümünü görüyoruz.

>
