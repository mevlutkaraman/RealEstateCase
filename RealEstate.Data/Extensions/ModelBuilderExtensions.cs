using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RealEstate.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void HasData(this ModelBuilder modelBuilder)
        {
            int itemAttribute1Id = 1, itemAttribute2Id = 2, itemAttribute3Id = 3, itemAttribute4Id = 4, itemAttribute5Id = 5;
            var itemAttribute1 = new ItemAttribute
            {
                Id = 1,
                Name = "Emlak Tipi",
            };
            var itemAttribute2 = new ItemAttribute
            {
                Id = 2,
                Name = "Eşya Durumu",
            };

            var itemAttribute3 = new ItemAttribute
            {
                Id = 3,
                Name = "Oda Sayısı"
            };

            var itemAttribute4 = new ItemAttribute
            {
                Id = 4,
                Name = "Bulunduğu Kat",
            };

            var itemAttribute5 = new ItemAttribute
            {
                Id = 5,
                Name = "Bina Yaşı"
            };

            var itemAttributeValues = new List<ItemAttributeValue>
            {
                 new ItemAttributeValue { Id =1, ItemAttributeId = itemAttribute1Id, Name ="Satılık" },
                 new ItemAttributeValue {Id=2, ItemAttributeId = itemAttribute1Id, Name ="Kiralık" },
                 new ItemAttributeValue { Id =3, ItemAttributeId = itemAttribute2Id,Name =" Eşyalı" },
                 new ItemAttributeValue {Id=4, ItemAttributeId = itemAttribute2Id, Name =" Eşyasız" },
                 new ItemAttributeValue { Id=5,ItemAttributeId = itemAttribute3Id, Name ="1+0" },
                 new ItemAttributeValue { Id=6, ItemAttributeId = itemAttribute3Id, Name ="1+1" },
                 new ItemAttributeValue {Id=7, ItemAttributeId = itemAttribute3Id, Name ="2+1" },
                 new ItemAttributeValue {Id=8, ItemAttributeId = itemAttribute3Id, Name = "3+1" },
                 new ItemAttributeValue {Id=9,ItemAttributeId = itemAttribute4Id, Name = "Girş Katı" },
                 new ItemAttributeValue {Id=10,ItemAttributeId = itemAttribute4Id, Name = "Bahçe Katı" },
                 new ItemAttributeValue {Id=11, ItemAttributeId = itemAttribute4Id,Name ="Girş Katı" },
                 new ItemAttributeValue {Id=12, ItemAttributeId = itemAttribute4Id,Name ="1. Kat" },
                 new ItemAttributeValue {Id=13, ItemAttributeId = itemAttribute4Id,Name ="2. Kat" },
                 new ItemAttributeValue {Id=14, ItemAttributeId = itemAttribute4Id, Name ="3. Kat" },
                 new ItemAttributeValue {Id=15, ItemAttributeId = itemAttribute5Id, Name = "0" },
                 new ItemAttributeValue {Id=16, ItemAttributeId = itemAttribute5Id, Name = "1" },
                 new ItemAttributeValue {Id=17, ItemAttributeId = itemAttribute5Id, Name = "2" },
                 new ItemAttributeValue {Id=18, ItemAttributeId = itemAttribute5Id, Name = "3" },
                 new ItemAttributeValue {Id=19, ItemAttributeId = itemAttribute5Id, Name = "5" },
                 new ItemAttributeValue {Id=20, ItemAttributeId = itemAttribute5Id,Name = "5" },
                 new ItemAttributeValue {Id=21, ItemAttributeId = itemAttribute5Id,Name = "6" }
            };

            var items = new List<Item>();
            for (int i = 1; i <= 500; i++)
            {
                var random = new Random();
                var item = new Item
                {
                    Id = i,
                    Price = random.Next(1, 5000),
                    Title = GetItemTitle(),
                    Description = GetItemDescription(),
                    ShortDescription = GetItemShortDescription(),
                };
                items.Add(item);
            }

            var itemImages= new List<ItemImage>();
            for (int i = 1; i<=500; i++)
            {
                for (int j = 1; j<=2; j++)
                {
                    var itemImage = new ItemImage()
                    {
                        Id = j + ((i - 1) * 2),
                        ItemId = i,
                        Url = GetItemImageUrl(),
                        IsDefault=j == 1,
                    };
                    itemImages.Add(itemImage);
                }
            }

            var itemAttributeMappings = new List<ItemAttributeMapping>();
            for (int i = 1; i<=500; i++)
            {
                for(int j = 1; j<=5; j++)
                {
                    var values = itemAttributeValues.Where(x => x.ItemAttributeId == j).ToList();
                    var random = new Random();
                    var index = random.Next(values.Count);
                    var value = values[index];

                    var itemAttributeMapping = new ItemAttributeMapping 
                    {
                        Id = j + ((i - 1) * 5),
                        ItemId = i,
                        ItemAttributeValueId=value.Id,
                    };

                    itemAttributeMappings.Add(itemAttributeMapping);
                }
            }

            modelBuilder.Entity<ItemAttribute>().HasData(itemAttribute1, itemAttribute2, itemAttribute3, itemAttribute4, itemAttribute5);
            modelBuilder.Entity<ItemAttributeValue>().HasData(itemAttributeValues);
            modelBuilder.Entity<Item>().HasData(items);
            modelBuilder.Entity<ItemImage>().HasData(itemImages);
            modelBuilder.Entity<ItemAttributeMapping>().HasData(itemAttributeMappings);

        }

        private static string GetItemTitle()
        {
            var titles = new List<string>
            {
                "Sahibinden Emsalsiz meşhur yuvarlakçayda villa",
                "YOZGAT BULVARI PARALELİ KÖŞEBAŞI *ASANSÖRLÜ MANZARALI GENİŞ 5+1*",
                "ARN'DE GÜVENLİKLİ SİTE İÇİ ÇOCUK PARKI VE OTOPARKLI GENİŞ DAİRE.",
                "DEMİRELLER - DENİZE YAKIN MÜSTAKİL BAHÇELİ EMSALSİZ YAZLIK VİLLA",
                "MERKEZİ KONUMDA KREDİYE UYGUN 3+1 150 M2 SATILIK DAİRE",
                "DİDİM DE SATILIK VİLLA",
                "KOCAALİ PLAJ MERKEZ'DE ÇİFT BAHÇELİ MUTFAK AYRI YAŞAM ALANI",
                "ŞOK FIRSAT ACİL TAM MÜSTAKİL DAHA UCUZU YOK TAKASLI OKYANUS TA",
                "KARASUDA BİZE SORMADAN YAZLIK ALMAYIN EMRE FİLİZFİDANOĞLU İNŞAAT",
                "FIRSAT HAVUZLU SİTEDE HAVUZ BAŞI ÜST KAT TAKAS İMKANI OKYANUS TA",
                "KARASU DA ARAÇ TAKAS İMKANI RÜYA GİBİ YAŞAM ALANI OKYANUS TA",
                "KARASU DA FIRSAT YEŞİL VADİDE 5 YILDIZLI OTEL KONFORU OKYANUS TA",
                "FIRSAT AVM VE HASTANEYE KOMŞU ARAKAT OTOPARKLI OKYANUS TA",
                "ŞEHİR MERKEZİ ÇATI KATI SÜPER EV",
                "yeşi̇lli̇kler i̇çi̇nde huzurlu ev",
                "BEYLİKDÜZÜ ISIS RESİDENCEDE 3+1 GENİŞ TERASLI LÜX FIRSAT DAİRE",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA KONYA",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA AYDIN",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA İZMİR",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA MUĞLA",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA ANTALYA",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA MERSİN",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA İZMİT",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA BALIKESİR",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA BURSA",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA BODRUM",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA KUŞADASI",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA DİDİM",
                "İNŞAAT FİRMASINDAN %50 PEŞİNAT İLE SİTE İÇİ LÜX MÜSTAKİL VİLLA BURHANİYE"
            };

            var random = new Random();
            var index = random.Next(titles.Count);
            return titles[index];
        }

        private static string GetItemDescription()
        {
            var descriptions = new List<string>
             {
                "Harika manzaralı muhteşem bir gayrimenkul. Eşsiz doğa ve deniz manzarasına sahip olan bu mülk, lüks ve konforu bir araya getiriyor.",
                "Geniş ve iyi tasarlanmış daire satılık. Ferah iç mekanları ve modern tasarımı ile bu daire aileler için mükemmel bir seçenek.",
                "Huzurlu bir mahallede şirin bir ev. Sessiz ve sakin çevresiyle bu ev, huzurlu bir yaşam tarzını arayanlar için ideal bir tercih.",
                "Zarif penthouse, üstün olanaklarla dolu. Modern ve lüks tasarımıyla bu penthouse yaşam tarzınızı yükseltiyor.",
                "Şehrin kalbinde modern bir loft. Merkezi konumu ve şık tasarımıyla bu loft, şehir hayatının tadını çıkarmak isteyenler için mükemmel bir seçenek.",
                "Deniz kenarında keyifli bir tatil evi. Kumlu plajlara yakın olan bu ev, yaz aylarında huzur dolu bir tatil imkanı sunuyor.",
                "Doğayla iç içe havuzlu bir villa. Muhteşem bahçesi ve özel havuzuyla bu villa, doğal güzelliklerle çevrili lüks bir yaşam sunuyor.",
                "Gölet manzaralı modern bir daire. Doğal güzellikleri iç mekanlara taşıyan bu daire, huzurlu ve sakin bir yaşam sunuyor.",
                "Köy yaşamının keyfini çıkarın. Yeşillikler arasında yer alan bu köy evi, geleneksel ve huzurlu bir yaşam tarzı sunuyor.",
                "Ulaşımı kolay merkezi konum. Şehir merkezine yakın olan bu ev, iş ve sosyal aktivitelere ulaşımı kolaylaştırıyor.",
                "Havuzlu lüks sitede daire. Sosyal olanaklarla donatılmış bu site, lüks ve rahat bir yaşam sunuyor.",
                "Doğa ile iç içe huzurlu bir yaşam. Yeşillikler arasında yer alan bu ev, doğanın tadını çıkarmak isteyenler için mükemmel bir seçenek.",
                "Şık ve modern çatı katı. Şehir manzarası eşliğinde bu çatı katında şık bir yaşamın keyfini çıkarın.",
                "Yeşillikler arasında huzurlu bir ev. Doğanın kucağında yer alan bu ev, stres ve karmaşadan uzak sakin bir yaşam sunuyor.",
                "Lüks rezidans daireleriyle rahat yaşam. Yüksek kaliteli olanaklarla donatılmış bu rezidans, lüks ve konforu bir araya getiriyor.",
                "Sosyal tesislere sahip site içi daire. Havuz, spor alanları ve daha fazlasıyla bu site, sosyal bir yaşam sunuyor.",
                "Doğal taş evinde huzur bulun. Geleneksel mimari ve doğal dokusuyla bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Merkezi konumda teraslı daire. Şehir merkezine yakın olan bu daire, modern yaşamın konforunu şehir manzarasıyla birleştiriyor.",
                "Kuş cıvıltı arasında eşsiz bir villa. Doğanın içinde yer alan bu villa, huzur dolu bir yaşamın kapılarını açıyor.",
                "Sahile yürüme mesafesinde daire. Plajlara yakın olan bu daire, deniz ve kumun keyfini çıkarmak isteyenlere hitap ediyor.",
                "Yeşillikler içinde sakin bir yaşam. Huzurlu çevresiyle bu ev, doğayla iç içe bir yaşam tarzı sunuyor.",
                "Lüks yaşamın keyfini çıkarın. Yüksek standartlara sahip olan bu ev, lüks ve konforlu bir yaşam sunuyor.",
                "Orman manzaralı muhteşem villa. Doğanın güzellikleri içinde yer alan bu villa, doğal bir yaşamın tadını çıkarmanızı sağlıyor.",
                "Ulaşımı kolay şehir merkezi daire. Şehrin merkezi konumunda olan bu daire, tüm olanaklara kolay erişim sağlıyor.",
                "Marina manzaralı lüks daire. Deniz manzarasıyla bu daire, lüks bir yaşamın anahtarını sunuyor.",
                "Tarihi yarımadada eşsiz bir konak. Tarih ve modern yaşamın buluştuğu bu konak, benzersiz bir deneyim sunuyor.",
                "Dağ manzaralı şirin bir dağ evi. Doğa ile iç içe olan bu ev, huzurlu bir dağ yaşamının kapılarını açıyor.",
                "Göl kenarında romantik bir yazlık. Göle sıfır konumuyla bu yazlık, romantik ve dinlendirici bir tatil sunuyor.",
                "Modern mimarinin örnekleri arasında öne çıkan villa. Yenilikçi tasarımı ve özel özellikleriyle bu villa, şıklık ve lüksü bir araya getiriyor.",
                "Tarihi dokusuyla büyüleyen antika ev. Geçmişin izlerini taşıyan bu ev, nostaljik bir atmosfer sunuyor.",
                "Golf sahasına yakın şık bir konut. Spor ve lüks yaşamı bir araya getiren bu konut, keyif dolu bir yaşam sunuyor.",
                "Deniz manzaralı müstakil bahçeli villa. Özel bahçesi ve muhteşem deniz manzarasıyla bu villa, lüks ve özgürlüğü bir araya getiriyor.",
                "Kültürel mirasa sahip tarihi ev. Geçmişin hikayelerini barındıran bu ev, tarih severler için eşsiz bir seçenek.",
                "Dağların arasında huzurlu bir yaşam. Doğal güzelliklerle çevrili olan bu ev, sakinlik ve huzur arayanlara hitap ediyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor.",
                "Marina manzaralı şık bir konut. Deniz ve yat limanı manzarasıyla bu konut, deniz severlere hitap ediyor.",
                "Modern mimarinin şaheseri villa. Estetik ve şıklığın buluştuğu bu villa, lüks bir yaşam sunuyor.",
                "Sessiz ve huzurlu dağ evi. Doğanın kucakladığı bu ev, doğal güzellikler içinde sakin bir yaşam sunuyor.",
                "Havuzlu bahçeli villa. Özel havuzu ve geniş bahçesiyle bu villa, keyifli bir yaşam sunuyor.",
                "Göl manzaralı ahşap kır evi. Geleneksel dokuya sahip bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Modern ve rahat bir daire. Şehir yaşamının tüm olanaklarına yakın olan bu daire, konforlu bir yaşam sunuyor.",
                "Göl kenarında tatil köyünde villa. Göle sıfır konumuyla bu villa, göl manzarasının tadını çıkarmanızı sağlıyor.",
                "Yenilenmiş tarihi konak. Tarihi detayları modern olanaklarla birleştiren bu konak, benzersiz bir yaşam sunuyor.",
                "Sahile yakın modern daire. Plajlara yakın olan bu daire, deniz severlere hitap ediyor.",
                "Huzurlu ve doğal bir yaşam. Doğal güzellikler arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor.",
                "Marina manzaralı şık bir konut. Deniz ve yat limanı manzarasıyla bu konut, deniz severlere hitap ediyor.",
                "Modern mimarinin şaheseri villa. Estetik ve şıklığın buluştuğu bu villa, lüks bir yaşam sunuyor.",
                "Sessiz ve huzurlu dağ evi. Doğanın kucakladığı bu ev, doğal güzellikler içinde sakin bir yaşam sunuyor.",
                "Havuzlu bahçeli villa. Özel havuzu ve geniş bahçesiyle bu villa, keyifli bir yaşam sunuyor.",
                "Göl manzaralı ahşap kır evi. Geleneksel dokuya sahip bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Modern ve rahat bir daire. Şehir yaşamının tüm olanaklarına yakın olan bu daire, konforlu bir yaşam sunuyor.",
                "Göl kenarında tatil köyünde villa. Göle sıfır konumuyla bu villa, göl manzarasının tadını çıkarmanızı sağlıyor.",
                "Yenilenmiş tarihi konak. Tarihi detayları modern olanaklarla birleştiren bu konak, benzersiz bir yaşam sunuyor.",
                "Sahile yakın modern daire. Plajlara yakın olan bu daire, deniz severlere hitap ediyor.",
                "Huzurlu ve doğal bir yaşam. Doğal güzellikler arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Göl manzaralı lüks daire. Göle yakın konumu ve lüks tasarımıyla bu daire, göl manzarasının keyfini çıkarıyor.",
                "Modern şehir merkezi daire. Şehir yaşamının tüm imkanlarına yakın olan bu daire, hareketli bir şehir yaşamı sunuyor.",
                "Kırsal alanda sessiz bir çiftlik evi. Doğanın içinde yer alan bu ev, huzurlu bir kırsal yaşam deneyimi sunuyor.",
                "Deniz manzaralı villa. Eşsiz deniz manzarası eşliğinde bu villa, lüks ve doğal güzellikleri bir araya getiriyor.",
                "Lüks tatil köyünde havuzlu villa. Tatil köyünün imkanları ve özel havuzuyla bu villa, keyifli bir tatil sunuyor.",
                "Dağların arasında huzurlu bir yaşam. Doğal güzelliklerle çevrili olan bu ev, sakinlik ve huzur arayanlara hitap ediyor.",
                "Sahile yakın şehir evi. Plajlara ve şehir merkezine yakın olan bu ev, konforlu bir yaşam sunuyor.",
                "Modern tasarımıyla öne çıkan daire. Yenilikçi mimarisi ve şık iç mekanlarıyla bu daire, modern bir yaşam sunuyor.",
                "Göl kenarında romantik bir yazlık. Göle sıfır konumuyla bu yazlık, romantik ve dinlendirici bir tatil sunuyor.",
                "Doğayla iç içe olan ev. Doğal güzelliklerin arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor."
             };

            var random = new Random();
            var index = random.Next(descriptions.Count);
            return descriptions[index];
        }

        private static string GetItemShortDescription()
        {
            var shortDescriptions = new List<string>
             {
                "Harika manzaralı muhteşem bir gayrimenkul. Eşsiz doğa ve deniz manzarasına sahip olan bu mülk, lüks ve konforu bir araya getiriyor.",
                "Geniş ve iyi tasarlanmış daire satılık. Ferah iç mekanları ve modern tasarımı ile bu daire aileler için mükemmel bir seçenek.",
                "Huzurlu bir mahallede şirin bir ev. Sessiz ve sakin çevresiyle bu ev, huzurlu bir yaşam tarzını arayanlar için ideal bir tercih.",
                "Zarif penthouse, üstün olanaklarla dolu. Modern ve lüks tasarımıyla bu penthouse yaşam tarzınızı yükseltiyor.",
                "Şehrin kalbinde modern bir loft. Merkezi konumu ve şık tasarımıyla bu loft, şehir hayatının tadını çıkarmak isteyenler için mükemmel bir seçenek.",
                "Deniz kenarında keyifli bir tatil evi. Kumlu plajlara yakın olan bu ev, yaz aylarında huzur dolu bir tatil imkanı sunuyor.",
                "Doğayla iç içe havuzlu bir villa. Muhteşem bahçesi ve özel havuzuyla bu villa, doğal güzelliklerle çevrili lüks bir yaşam sunuyor.",
                "Gölet manzaralı modern bir daire. Doğal güzellikleri iç mekanlara taşıyan bu daire, huzurlu ve sakin bir yaşam sunuyor.",
                "Köy yaşamının keyfini çıkarın. Yeşillikler arasında yer alan bu köy evi, geleneksel ve huzurlu bir yaşam tarzı sunuyor.",
                "Ulaşımı kolay merkezi konum. Şehir merkezine yakın olan bu ev, iş ve sosyal aktivitelere ulaşımı kolaylaştırıyor.",
                "Havuzlu lüks sitede daire. Sosyal olanaklarla donatılmış bu site, lüks ve rahat bir yaşam sunuyor.",
                "Doğa ile iç içe huzurlu bir yaşam. Yeşillikler arasında yer alan bu ev, doğanın tadını çıkarmak isteyenler için mükemmel bir seçenek.",
                "Şık ve modern çatı katı. Şehir manzarası eşliğinde bu çatı katında şık bir yaşamın keyfini çıkarın.",
                "Yeşillikler arasında huzurlu bir ev. Doğanın kucağında yer alan bu ev, stres ve karmaşadan uzak sakin bir yaşam sunuyor.",
                "Lüks rezidans daireleriyle rahat yaşam. Yüksek kaliteli olanaklarla donatılmış bu rezidans, lüks ve konforu bir araya getiriyor.",
                "Sosyal tesislere sahip site içi daire. Havuz, spor alanları ve daha fazlasıyla bu site, sosyal bir yaşam sunuyor.",
                "Doğal taş evinde huzur bulun. Geleneksel mimari ve doğal dokusuyla bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Merkezi konumda teraslı daire. Şehir merkezine yakın olan bu daire, modern yaşamın konforunu şehir manzarasıyla birleştiriyor.",
                "Kuş cıvıltı arasında eşsiz bir villa. Doğanın içinde yer alan bu villa, huzur dolu bir yaşamın kapılarını açıyor.",
                "Sahile yürüme mesafesinde daire. Plajlara yakın olan bu daire, deniz ve kumun keyfini çıkarmak isteyenlere hitap ediyor.",
                "Yeşillikler içinde sakin bir yaşam. Huzurlu çevresiyle bu ev, doğayla iç içe bir yaşam tarzı sunuyor.",
                "Lüks yaşamın keyfini çıkarın. Yüksek standartlara sahip olan bu ev, lüks ve konforlu bir yaşam sunuyor.",
                "Orman manzaralı muhteşem villa. Doğanın güzellikleri içinde yer alan bu villa, doğal bir yaşamın tadını çıkarmanızı sağlıyor.",
                "Ulaşımı kolay şehir merkezi daire. Şehrin merkezi konumunda olan bu daire, tüm olanaklara kolay erişim sağlıyor.",
                "Marina manzaralı lüks daire. Deniz manzarasıyla bu daire, lüks bir yaşamın anahtarını sunuyor.",
                "Tarihi yarımadada eşsiz bir konak. Tarih ve modern yaşamın buluştuğu bu konak, benzersiz bir deneyim sunuyor.",
                "Dağ manzaralı şirin bir dağ evi. Doğa ile iç içe olan bu ev, huzurlu bir dağ yaşamının kapılarını açıyor.",
                "Göl kenarında romantik bir yazlık. Göle sıfır konumuyla bu yazlık, romantik ve dinlendirici bir tatil sunuyor.",
                "Modern mimarinin örnekleri arasında öne çıkan villa. Yenilikçi tasarımı ve özel özellikleriyle bu villa, şıklık ve lüksü bir araya getiriyor.",
                "Tarihi dokusuyla büyüleyen antika ev. Geçmişin izlerini taşıyan bu ev, nostaljik bir atmosfer sunuyor.",
                "Golf sahasına yakın şık bir konut. Spor ve lüks yaşamı bir araya getiren bu konut, keyif dolu bir yaşam sunuyor.",
                "Deniz manzaralı müstakil bahçeli villa. Özel bahçesi ve muhteşem deniz manzarasıyla bu villa, lüks ve özgürlüğü bir araya getiriyor.",
                "Kültürel mirasa sahip tarihi ev. Geçmişin hikayelerini barındıran bu ev, tarih severler için eşsiz bir seçenek.",
                "Dağların arasında huzurlu bir yaşam. Doğal güzelliklerle çevrili olan bu ev, sakinlik ve huzur arayanlara hitap ediyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor.",
                "Marina manzaralı şık bir konut. Deniz ve yat limanı manzarasıyla bu konut, deniz severlere hitap ediyor.",
                "Modern mimarinin şaheseri villa. Estetik ve şıklığın buluştuğu bu villa, lüks bir yaşam sunuyor.",
                "Sessiz ve huzurlu dağ evi. Doğanın kucakladığı bu ev, doğal güzellikler içinde sakin bir yaşam sunuyor.",
                "Havuzlu bahçeli villa. Özel havuzu ve geniş bahçesiyle bu villa, keyifli bir yaşam sunuyor.",
                "Göl manzaralı ahşap kır evi. Geleneksel dokuya sahip bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Modern ve rahat bir daire. Şehir yaşamının tüm olanaklarına yakın olan bu daire, konforlu bir yaşam sunuyor.",
                "Göl kenarında tatil köyünde villa. Göle sıfır konumuyla bu villa, göl manzarasının tadını çıkarmanızı sağlıyor.",
                "Yenilenmiş tarihi konak. Tarihi detayları modern olanaklarla birleştiren bu konak, benzersiz bir yaşam sunuyor.",
                "Sahile yakın modern daire. Plajlara yakın olan bu daire, deniz severlere hitap ediyor.",
                "Huzurlu ve doğal bir yaşam. Doğal güzellikler arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor.",
                "Marina manzaralı şık bir konut. Deniz ve yat limanı manzarasıyla bu konut, deniz severlere hitap ediyor.",
                "Modern mimarinin şaheseri villa. Estetik ve şıklığın buluştuğu bu villa, lüks bir yaşam sunuyor.",
                "Sessiz ve huzurlu dağ evi. Doğanın kucakladığı bu ev, doğal güzellikler içinde sakin bir yaşam sunuyor.",
                "Havuzlu bahçeli villa. Özel havuzu ve geniş bahçesiyle bu villa, keyifli bir yaşam sunuyor.",
                "Göl manzaralı ahşap kır evi. Geleneksel dokuya sahip bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Modern ve rahat bir daire. Şehir yaşamının tüm olanaklarına yakın olan bu daire, konforlu bir yaşam sunuyor.",
                "Göl kenarında tatil köyünde villa. Göle sıfır konumuyla bu villa, göl manzarasının tadını çıkarmanızı sağlıyor.",
                "Yenilenmiş tarihi konak. Tarihi detayları modern olanaklarla birleştiren bu konak, benzersiz bir yaşam sunuyor.",
                "Sahile yakın modern daire. Plajlara yakın olan bu daire, deniz severlere hitap ediyor.",
                "Huzurlu ve doğal bir yaşam. Doğal güzellikler arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Göl manzaralı lüks daire. Göle yakın konumu ve lüks tasarımıyla bu daire, göl manzarasının keyfini çıkarıyor.",
                "Modern şehir merkezi daire. Şehir yaşamının tüm imkanlarına yakın olan bu daire, hareketli bir şehir yaşamı sunuyor.",
                "Kırsal alanda sessiz bir çiftlik evi. Doğanın içinde yer alan bu ev, huzurlu bir kırsal yaşam deneyimi sunuyor.",
                "Deniz manzaralı villa. Eşsiz deniz manzarası eşliğinde bu villa, lüks ve doğal güzellikleri bir araya getiriyor.",
                "Lüks tatil köyünde havuzlu villa. Tatil köyünün imkanları ve özel havuzuyla bu villa, keyifli bir tatil sunuyor.",
                "Dağların arasında huzurlu bir yaşam. Doğal güzelliklerle çevrili olan bu ev, sakinlik ve huzur arayanlara hitap ediyor.",
                "Sahile yakın şehir evi. Plajlara ve şehir merkezine yakın olan bu ev, konforlu bir yaşam sunuyor.",
                "Modern tasarımıyla öne çıkan daire. Yenilikçi mimarisi ve şık iç mekanlarıyla bu daire, modern bir yaşam sunuyor.",
                "Göl kenarında romantik bir yazlık. Göle sıfır konumuyla bu yazlık, romantik ve dinlendirici bir tatil sunuyor.",
                "Doğayla iç içe olan ev. Doğal güzelliklerin arasında yer alan bu ev, huzurlu bir yaşam tarzı sunuyor.",
                "Modern şehir evidir. Şehir hayatının tüm olanaklarına yakın olan bu ev, şehir yaşamını kolaylaştırıyor.",
                "Lüks ve stilin buluştuğu özel bir rezidans. Yüksek kaliteli malzemelerle inşa edilen bu rezidans, zengin yaşamın kapılarını açıyor.",
                "Bahçeli taş ev. Geleneksel mimariyle tasarlanan bu ev, doğal ve sıcak bir atmosfer sunuyor.",
                "Sanat ve kültürün merkezinde ferah bir daire. Sanat galerileri ve kültürel etkinliklere yakın olan bu daire, sanatseverler için ideal.",
                "Sahile yakın bir tatil köyünde villa. Plajlara yakın olan bu villa, deniz ve güneşin keyfini çıkarmak isteyenlere hitap ediyor.",
                "Modern ve şık bir şehir evi. Şehir merkezine yakın olan bu ev, şehir hayatının konforunu sunuyor.",
                "Göl manzaralı sessiz bir yazlık. Doğal güzelliklerin arasında yer alan bu yazlık, huzurlu bir tatil deneyimi sunuyor.",
                "Güvenli ve nezih bir site içi daire. Sosyal olanaklarla dolu olan bu site, aileler için güvenli ve keyifli bir yaşam sunuyor.",
                "Dağ manzaralı ahşap bir ev. Doğanın kucağında yer alan bu ev, sıcak ve doğal bir yaşam tarzı sunuyor.",
                "Geleneksel köy evi. Köy yaşamının samimi atmosferini hissedeceğiniz bu ev, gerçek bir köy deneyimi sunuyor.",
                "Golf sahasına sıfır modern villa. Spor ve lüksü bir araya getiren bu villa, keyifli bir yaşam sunuyor.",
                "Denize sıfır lüks daire. Plajlara yakın olan bu daire, deniz manzarasının tadını çıkarmanızı sağlıyor."
             };

            var random = new Random();
            var index = random.Next(shortDescriptions.Count);
            return shortDescriptions[index];
        }

        private static string GetItemImageUrl()
        {
            var titles = new List<string>
            {
                "https://i0.shbdn.com/photos/18/28/39/x5_1034182839gnj.jpg",
                "https://i0.shbdn.com/photos/62/61/14/x5_1135626114gh1.jpg",
                "https://i0.shbdn.com/photos/00/28/61/x5_1165002861gd4.jpg",
                "https://i0.shbdn.com/photos/90/34/02/x5_11139034025hk.jpg",
                "https://i0.shbdn.com/photos/90/69/16/x5_116190691667z.jpg",
                "https://i0.shbdn.com/photos/96/92/51/x5_1099969251buf.jpg",
                "https://i0.shbdn.com/photos/61/55/14/x5_1162615514f0t.jpg",
                "https://i0.shbdn.com/photos/96/92/51/x5_10999692518nu.jpg",
                "https://i0.shbdn.com/photos/45/95/37/x5_11594595373cm.jpg",
                "https://i0.shbdn.com/photos/40/33/48/x5_1162403348d0t.jpg"
            };

            var random = new Random();
            return titles[random.Next(titles.Count)];
        }
    }
}
