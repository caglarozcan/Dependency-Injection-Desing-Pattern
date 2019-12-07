## Dependency Injection Tasarım Deseni
Dependency Injection temel olarak bağımlılıkların kontrolü ve yönetimi için kullanılan bir tasarım desenidir. OOP dillerde yazılım geliştirilirken, kullanılan nesneler birbiri ile iletişim halindedir. Bu da bağımlılıkları oluşturur. Nesneye yönelik programlama dillerinde bu oldukça büyük bir sorundur. Geliştirilen projenin, esnek ve enişletilebilir olması için bağımlılıklar oldukça azaltılmalıdır. Bu amaçla bağımlılıkların parçalara ayrılarak dışarıdan verilmesi ile sistem içindeki bağımlılık en aza indirilmiş olur.

Yazılım geliştirirken bir sınıf içerisinde başka bir sınıf kullanmak gerektiğinde yeni sınıfın nesnesi `new` anahtar kelimesi ile oluşturulmamalıdır. İhtiyaç duyulan nesnenin constructor içerisinden ya da getter/setter metodları ile  alınmasını sağlayan ve bu sayede iki sınıfı birbirinden izole hale getiren yaklaşımdır.

Nesneler arasındaki ilişkiyi gevşek tutmak (`Loosely Coupled`) projeye yeni özelliklerine eklenmesini ve çıkartılmasını kolay hale getirecektir. 


![Image of Class](https://raw.githubusercontent.com/caglarozcan/Desing-Patterns/master/DependencyInjection/DependencyInjection/Component/DependencyInjectionClassDiagram.png)

Yukarıda verilen class diyagramında, değişik ortamlarda log tutan bir mekanizma tasarlanmıştır. Veritabanı, metin dosyası, XML dosyası ve mail gönderme olmak üzere dört farklı ortamda log tutma işlemi yapılmaktadır.  Her ortamda log almayı sağlayacak sınıflar tasarlanmıştır, çünkü her ortamda log kaydedilmesi farklı işlemlerin yerine getirilmesini gerektirir. LogManager sınıfı tasarlanırken log nesnesini constructor ile alan Dependency Injection yaklaşımı kullanılmıştır. Constructor içerisine verilen nesneye göre ILogger arayüzünden beslenerek ilgili log sınıfının çağrılmasını sağlar.

```csharp
public LogManager(ILogger logger)
{
	_ilogger = logger;
}
```
LogManager Constructor parametresi `_ilogger` değişkeninde tutulur. Gelen nesne içerisinden `SaveLog()` metodu tetiklenerek log alma işlemi yerine getirilir. 

```csharp
public string Log(string message)
{
	return _ilogger.SaveLog(message);
}
```
Log alma işlemini yerine getiren sınıflar ise ILogger arayüzü ile implemente edilmiştir. Örnek olarak veritabanında log tutma işlemi yapan `DatabaseLogger` sınıfı;

```csharp
public class DatabaseLogger : ILogger
{
	public string SaveLog(string message)
	{
		return "Log bilgisi veritabanına kaydedildi! : [" + DateTime.Now.ToString() + " | " + message + "]";
	}
}
```
Log alma işlemi için, hangi ortamda kayıt yapılacaksa o ortama iat `..Logger` sınıfı nesnesi LogManager sınıfının constructor metoduna paramete olarak verilir.
```csharp
LogManager logManager = null;
			
string logType = "database";

switch (logType)
{
	case "database":
		logManager = new LogManager(new DatabaseLogger());
		break;
	case "txt":
		logManager = new LogManager(new TextLogger());
		break;
	case "mail":
		logManager = new LogManager(new MailLogger());
		break;
	case "xml":
		logManager = new LogManager(new XMLLogger());
		break;
	default:
		Console.WriteLine("Geçersiz Log Türü!");
		break;
}

if(logManager != null)
{
	Console.WriteLine(logManager.Log("Hata Mesajı!"));
}
```
Yukarıdaki örnek kodda görüldüğü gibi, bağımlılıklar LogManager sınıfı içerisine Dependency Injection yöntemi ile yerine getirilmiştir. Yeni bir ortamda log tutulmak istendiğinde `..Logger` sınıfı yazılmalı ve LogManager içerisine enjekte edilmelidir. Böylece `Loosely Coupled` prensibi yerine getirilmiş olacaktır.
