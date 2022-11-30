using DH8G3K_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Repository.Database
{
    public class VideogameDbContext : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public VideogameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("videogame");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>(franchise => franchise
                    .HasOne(franchise => franchise.Developer)
                    .WithMany(Developer => Developer.Franchises)
                    .HasForeignKey(franchise => franchise.DeveloperId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Videogame>(videogame => videogame
                    .HasOne(videogame => videogame.Franchise)
                    .WithMany(Franchise => Franchise.Videogames)
                    .HasForeignKey(videogame => videogame.FranchiseId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Videogame>().HasData(new Videogame[]
            {
                new Videogame("1#1#Dark Souls: Prepare To Die Edition#2011*09*22#9"),
                new Videogame("2#1#Dark Souls: REMASTERED#2018*05*24#9,5"),
                new Videogame("3#1#Dark Souls II#2014*03*11#9"),
                new Videogame("4#1#Dark Souls II: Scholar of the First Sin#2015*04*01#9"),
                new Videogame("5#1#Dark Souls III#2016*03*24#9,5"),

                new Videogame("6#2#Elden Ring#2022*02*25#9,7"),

                new Videogame("7#3#Overwatch#2015*05*24#10"),
                new Videogame("8#3#Overwatch 2#2022*10*04#8"),

                new Videogame("9#4#World of Warcraft#2004*11*23#9,1"),
                new Videogame("10#4#Hearthstone: Heroes of Warcraft#2014*03*11#9"),

                new Videogame("11#5#Sonic the Hedgehog#1991*06*23#8"),
                new Videogame("12#5#Sonic Adventure#1998*12*23#3,5"),
                new Videogame("13#5#Sonic Adventure 2#2001*06*19#9,4"),
                new Videogame("14#5#Sonic the Hedgehog (2006)#2006*11*14#4,8"),
                new Videogame("15#5#Sonic Unleashed#2008*11*18#4,5"),
                new Videogame("16#5#Sonic & SEGA All-Stars Racing#2010*02*23#8"),
                new Videogame("17#5#Sonic Generations#2011*11*1#8,5"),
                new Videogame("18#5#Sonic Forces#2017*11*7#6,9"),
                new Videogame("19#5#Sonic Frontiers#2022*11*8#7"),

                new Videogame("20#6#Yakuza#2005*12*8#8,2"),
                new Videogame("21#6#Yakuza 2#2006*12*7#8,5"),
                new Videogame("22#6#Yakuza 3#2009*02*26#8,5"),
                new Videogame("23#6#Yakuza 4#2010*03*18#6,5"),
                new Videogame("24#6#Yakuza 5#2012*12*5#8"),
                new Videogame("25#6#Yakuza 0#2015*03*12#8,5"),

                new Videogame("26#7#Super Mario Bros.#1985*09*13#9"),
                new Videogame("27#7#Super Mario World#1990*11*21#8,5"),
                new Videogame("28#7#Super Mario 64#1996*06*23#9,8"),
                new Videogame("29#7#Super Mario Sunshine#2002*07*19#9,4"),
                new Videogame("30#7#Super Mario Galaxy#2007*11*1#9,7"),
                new Videogame("31#7#Super Mario Maker#2015*09*10#9"),
                new Videogame("32#7#Mario Kart 8 Deluxe#2017*04*27#9,3"),
                new Videogame("33#7#Super Mario Odyssey#2017*10*27#10"),

                new Videogame("34#8#The Legend of Zelda#1986*02*21#9"),
                new Videogame("35#8#The Legend of Zelda: A Link to the Past#1991*11*21#9,5"),
                new Videogame("36#8#The Legend of Zelda: Ocarina of Time#1998*11*21#10"),
                new Videogame("37#8#The Legend of Zelda: Majora's Mask#2000*04*27#9,9"),
                new Videogame("38#8#The Legend of Zelda: The Wind Waker#2002*12*13#9,6"),
                new Videogame("39#8#The Legend of Zelda: Skyward Sword#2011*11*18#10"),
                new Videogame("40#8#The Legend of Zelda: A Link Between Worlds#2013*11*22#9,4"),
                new Videogame("41#8#The Legend of Zelda: Breath of the Wild#2017*03*03#10"),

                new Videogame("42#9#Pokémon Red & Green#1996*02*27#10"),
                new Videogame("43#9#Pokémon Gold & Silver#1999*11*21#10"),
                new Videogame("44#9#Pokémon Ruby & Sapphire#2002*11*21#9,5"),
                new Videogame("45#9#Pokémon Diamond & Pearl#2006*09*28#8,5"),
                new Videogame("46#9#Pokémon Black & White#2010*09*18#9"),
                new Videogame("47#9#Pokémon X & Y#2013*10*12#9"),
                new Videogame("48#9#Pokémon Sun & Moon#2016*11*18#9"),
                new Videogame("49#9#Pokémon Sword & Shield#2019*11*15#9,3"),
                new Videogame("50#9#Pokémon Scarlet & Violet#2022*11*18#6"),

                new Videogame("51#10#The Witcher#2007*10*26#8,5"),
                new Videogame("52#10#The Witcher: Assassins of Kings#2011*05*17#8,8"),
                new Videogame("53#10#The Witcher: The Wild Hunt#2015*05*18#9,3"),

                new Videogame("54#11#Cyberpunk 2077#2020*12*10#9"),

                new Videogame("55#12#Grand Theft Auto#1997*10*21#6"),
                new Videogame("56#12#Grand Theft Auto: Vice City#2002*10*29#9,7"),
                new Videogame("57#12#Grand Theft Auto: San Andreas#2004*10*29#9,6"),
                new Videogame("58#12#Grand Theft Auto V#2013*09*17#10"),

                new Videogame("59#13#Red Dead Revolver#2004*05*04#7"),
                new Videogame("60#13#Red Dead Redemption#2010*05*18#9,7"),
                new Videogame("61#13#Red Dead Redemption 2#2018*10*26#10")
            });

            modelBuilder.Entity<Developer>().HasData(new Developer[]
            {
                new Developer("1#FromSoftware"),
                new Developer("2#Blizzard Entertainment"),
                new Developer("3#SEGA"),
                new Developer("4#Nintendo"),
                new Developer("5#Game Freak"),
                new Developer("6#CD Projekt RED"),
                new Developer("7#Rockstar Games")
            });

            modelBuilder.Entity<Franchise>().HasData(new Franchise[]
            {
                new Franchise("1#1#Dark Souls Franchise#5"),
                new Franchise("2#1#Elden Ring Franchise#1"),
                new Franchise("3#2#Overwatch Franchise#2"),
                new Franchise("4#2#Warcraft Franchise#2"),
                new Franchise("5#3#Sonic the Hedgehog Franchise#9"),
                new Franchise("6#3#Yakuza Franchise#6"),
                new Franchise("7#4#Super Mario Franchise#8"),
                new Franchise("8#4#The Legend of Zelda Franchise#8"),
                new Franchise("9#5#Pokémon Franchise#9"),
                new Franchise("10#6#The Witcher Franchise#3"),
                new Franchise("11#6#Cyberpunk Franchise#1"),
                new Franchise("12#7#Grand Theft Auto Franchise#4"),
                new Franchise("13#7#Red Dead Franchise#3")
            });
        }
    }
}
