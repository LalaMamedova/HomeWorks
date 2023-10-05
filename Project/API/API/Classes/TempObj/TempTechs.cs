namespace API.Classes.TempObj
{
    public class TempTechs
    {
        public List<Technology> Technologies = new List<Technology>
        {
            new Technology
            {id = 1,
            name = "Commodore 64",
            year = 1960,
            description = "Commodore 64, также известный как C64, был одним из самых популярных домашних компьютеров 1980-х годов. Он имел 8-битный процессор MOS " +
            "Technology 6510, 64 КБ оперативной памяти и характерный SID звуковой чип, который делал его популярным среди музыкантов.",
            type = "Computer",
            images = new List<string> { "data:image/jpeg;base64,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","https://assets1.ignimgs.com/2020/01/14/thec64-thumb-1578962621460_160w.jpg?width=1280" },
            charname = new List<string> { "Год релиза" },
            charvalue = new List<string> { "1982" },
            interestingfacts = new List<string> { "Одна из самых продаваемых моделей" }
            },

            new Technology
            {id = 2,
            name = "Atari 2600",
            year = 1970,
            description = "Atari 2600, также известный как Atari VCS (Video Computer System), был первой игровой консолью, которая дала возможность играть в разнообразные видеоигры дома. Он был популярен в 1970-х и начале 1980-х годов.",
            type = "Consoles",
            images = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/b/b9/Atari-2600-Wood-4Sw-Set.jpg" },
            charname = new List<string> { "Год релиза" },
            charvalue = new List<string> { "1977" },
            interestingfacts = new List<string> { "Первая игровая консоль с поддержкой сменных картриджей" }
            },

            new Technology
            {id = 3,
            name= "Floppy Disk",
            description= "A data storage medium that was widely used in the past. Floppy disks store digital data which can be read and written when the disk is inserted into a floppy disk drive (FDD) connected to or inside a computer or other device.Floppy disks became commonplace during the 1980s and 1990s in their use with personal computers to distribute software, transfer data, and create backups. Before hard disks became affordable to the general population,{nb 1} floppy disks were often used to store a computer's operating system (OS). Most home computers from that time have an elementary OS and BASIC stored in read-only memory (ROM), with the option of loading a more advanced OS from a floppy disk.",
            year = 1971,
            type= "Other",
            images= new List<string> {@"https://cdn.retrostylemedia.co.uk/media/img_609bee39f1b57.jpg", @"https://cdn.pixabay.com/photo/2013/07/13/12/52/disk-160525_1280.png", @"https//i.cbc.ca/1.4397749.1510343754!/fileImage/httpImage/floppy-disks.jpg"},
            interestingfacts=  new List<string> {
                "The first floppy disks had a storage capacity of only 80 kilobytes.",
                "Floppy disks were often used to distribute software in the 1980s and 1990s."
            },
            charname=  new List<string> {"Storage Capacity", "Year of Invention"},
            charvalue= new List<string> {"80 KB","1971"}
            },

            new Technology
            {id = 4,
            name= "CRT Monitor",
            description= "A type of computer monitor that used cathode-ray tube technology.",
            year=1922,
            type= "Other",
            images=new List<string>  { @"https://www.online-tech-tips.com/wp-content/uploads/2019/09/cropped-crt-monitor.jpeg", @"https://www.slashgear.com/img/gallery/10-best-uses-for-old-crt-monitors/l-intro-1652987930.jpg"},
            interestingfacts= new List<string> {"CRT monitors were commonly used as computer displays before the advent of LCD monitors."},
            charname=new List<string>  {"Screen Size","Year of Invention"},
            charvalue= new List<string> {"17 inches", "1971" }
            },

            new Technology
            {id = 5,
            name= "Vinyl Record",
            description= "An analog audio storage medium that plays music using a stylus.",
            year=1877,
            type= "Other",
            images= new List<string> { "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/12in-Vinyl-LP-Record-Angle.jpg/800px-12in-Vinyl-LP-Record-Angle.jpg", "https://globalnews.ca/wp-content/uploads/2019/05/turntable.jpg?quality=85&strip=all"},
            interestingfacts= new List<string> {
              "Vinyl records were the primary format for music distribution before CDs and digital downloads.",
              "They come in various sizes, including 7-inch, 10-inch, and 12-inch records."},
            charname= new List<string> {"Playback Speed","Year of Invention"},
            charvalue= new List < string > { "33 1/3 RPM", "1877" }
            },

            new Technology
             {id = 6,
             name= "Typewriter",
             description= "A mechanical device used for typing text on paper.",
             year=1868,
             type= "Other",
             images= new List < string > { "https://m.media-amazon.com/images/I/71oU+4RiX9L._AC_UF894,1000_QL80_.jpg" },
             interestingfacts= new List<string> {
               "Typewriters were widely used for office work and professional writing in the past.",
               "They were gradually replaced by computer keyboards in the late 20th century."
             },
             charname=new List<string>  {"Number of Keys", "Year of Invention"},
             charvalue= new List<string> {"QWERTY keyboard layout", "1868" }
            },
            new Technology
            {
               id=7,
               name= "Steam Engine",
               description= "An early heat engine that converted steam into mechanical work",
               year= 1705,
               type= "Other",
               images=new List<string> { "https://t0.gstatic.com/licensed-image?q=tbn:ANd9GcQ4ehMxFq4ZtKdHNPTcN-BOQ4NW25g5bQWE6YvYa7T-ksaPJU90SQaDgMVTBGeeOAbs", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Steam_lokomobile_2_%28aka%29.jpg/800px-Steam_lokomobile_2_%28aka%29.jpg" },
               interestingfacts =new List<string>  {
                "The steam engine played a pivotal role in the Industrial Revolution.",
                 "It powered trains, ships, and various industrial machinery."
               },
               charname= new List<string>{ "Power Source", "Year of Invention"},
               charvalue = new List<string>{ "Year of Invention", "Late  17th century" },
            },
             new Technology
            {
               id=8,
               name= "IMac G3",
               description= "Первая ревизия iMac G3 включала 15-дюймовый (13,8-дюймовый видимый) ЭЛТ-дисплей, процессор 233 МГц, графику ATI Rage IIc, жесткий диск объемом 4 ГБ, дисковод CD-ROM с загрузкой в лоток, два порта USB, модем 56 Кбит/с, встроенный Ethernet",
               year= 1998,
               type= "Computer",
               images=new List<string> { "https://www.iphones.ru/wp-content/uploads/2012/12/01-iMac-G3.jpeg", "https://upload.wikimedia.org/wikipedia/commons/d/db/IMac_G3_Bondi_Blue%2C_three-quarters_view.png" },
               interestingfacts =new List<string>  {"Создателем был Стив Джобс"},
               charname= new List<string>{ "Processor", "RAM"},
               charvalue = new List<string>{ "IBM PowerPC G3", "128 MB" },
            },
              new Technology
            {
               id=9,
               name= "Sega Mega Drive",
               description= " игровая приставка четвёртого поколения, разработанная и выпускавшаяся компанией Sega. Приставка была выпущена в 1988 году в Японии как Mega Drive, в 1989 году в США как Genesis и в 1990 году в Европе (Virgin Mastertronic), Австралии (Ozisoft) и Бразилии (Tec Toy) — вновь под названием Mega Drive. Причиной изменения названия при запуске приставки на рынке США явилась невозможность официальной регистрации торговой марки Mega Drive. Sega Mega Drive — это третья аппаратная платформа от Sega после Sega Master System. В Южной Корее распространением приставки занималась компания Samsung; приставка имела название Super Gam*Boy, позднее изменённое на Super Aladdin Boy.",
               year= 1988,
               type= "Console",
               images=new List<string> { "https://www.videogameschronicle.com/files/2022/06/mega-drive-mini-2-1.jpg", "https://images-eu.ssl-images-amazon.com/images/G/02/uk-videogames/2014/ConsoleComp/aplus/MD_ConsoleI_lg._V344383332_.jpg" },
               interestingfacts =new List<string>  {
                "Беспеллером в этой консоли был Song the hedgehog",
                 "Всего было продано 39 миллионов штук."
               },
               charname= new List<string>{ "Processor","Additional Processor", "Memory"},
               charvalue = new List<string>{ "Motorola 68000", "Zilog Z80","72 kb" },
            },
        };
    }
}
