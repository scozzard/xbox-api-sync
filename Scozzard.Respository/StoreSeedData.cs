using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scozzard.Model;

namespace Scozzard.Respository
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetGadgets().ForEach(g => context.Gadgets.Add(g));
            GetUsers().ForEach(x => context.Users.Add(x));

            context.Commit();
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Tablets"
                },
                new Category {
                    Name = "Laptops"
                },
                new Category {
                    Name = "Mobiles"
                }
            };
        }

        private static List<Gadget> GetGadgets()
        {
            return new List<Gadget>
            {
                new Gadget {
                    Name = "ProntoTec 7",
                    Description = "Android 4.4 KitKat Tablet PC, Cortex A8 1.2 GHz Dual Core Processor,512MB / 4GB,Dual Camera,G-Sensor (Black)",
                    CategoryID = 1,
                    Price = 46.99m,
                    Image = "prontotec.jpg"
                },
                new Gadget {
                    Name = "Samsung Galaxy",
                    Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
                    CategoryID = 1,
                    Price = 120.95m,
                    Image= "samsung-galaxy.jpg"
                },
                new Gadget {
                    Name = "NeuTab® N7 Pro 7",
                    Description = "NeuTab N7 Pro tablet features the amazing powerful, Quad Core processor performs approximately Double multitasking running speed, and is more reliable than ever",
                    CategoryID = 1,
                    Price = 59.99m,
                    Image= "neutab.jpg"
                },
                new Gadget {
                    Name = "Dragon Touch® Y88X 7",
                    Description = "Dragon Touch Y88X tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 54.99m,
                    Image= "dragon-touch.jpg"
                },
                new Gadget {
                    Name = "Alldaymall A88X 7",
                    Description = "This Alldaymall tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 47.99m,
                    Image= "Alldaymall.jpg"
                },
                new Gadget {
                    Name = "ASUS MeMO",
                    Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
                    CategoryID = 1,
                    Price = 94.99m,
                    Image= "asus-memo.jpg"
                },
                // Code ommitted 
            };
        }

        private static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    XboxUserID = 2533274858439687,
                    Name = "Scott Walker",
                    Password = "1234",
                    Email = "scot.walker@gmail.com",
                    XboxUser = new XboxUser
                    {
                        XboxUserID = 2533274858439687,
                        GamerTag = "scozzard",
                        GameDisplayName = "scozzard",
                        Gamerscore = 22230,
                        GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/scozzard/avatarpic-l.png",
                        AccountTier = "Gold",
                        XboxOneRep = "GoodPlayer",
                        TenureLevel = 5,
                        ProfileLastSyncedAt = DateTime.UtcNow.AddDays(-2),
                        ActivitiesLastSyncedAtt = DateTime.UtcNow.AddDays(-2),
                        GameClips = new List<GameClip>()
                        {
                            new GameClip()
                            {
                                XblID = "174b7bb5-eaac-4c99-9469-8af1ffa5a7ae",
                                State = "Published",
                                DateRecorded = new DateTime(2015, 12, 31, 10, 0, 0),
                                DatePublished = new DateTime(2015, 12, 31, 10, 1, 20),
                                ClipUris = new List<GameClipUri>()
                                {
                                    new GameClipUri()
                                    {
                                        Uri = "http://gameclipscontent-d2016.xboxlive.com/00090000040e4407-174b7bb5-eaac-4c99-9469-8af1ffa5a7ae/GameClip-Original.MP4?sv=2014-02-14&sr=c&sig=R1BeqwlzwB%2FIcNXUX4B%2FuWakfUIwMvNepaSecdVYrdI%3D&st=2016-03-13T18%3A06%3A39Z&se=2016-03-13T19%3A11%3A39Z&sp=r&__gda__=1457896299_edca4c12388343ba809466b469e2e445",
                                        FileSize = 28553786,
                                        UriType = "Download",
                                        Expiration = new DateTime(2016, 3, 13)
                                    }
                                },
                                Thumbnails =new List<GameClipThumbnail>()
                                {
                                    new GameClipThumbnail()
                                    {
                                        Uri = "http://gameclipscontent-t2016.xboxlive.com/00090000040e4407-174b7bb5-eaac-4c99-9469-8af1ffa5a7ae-public/Thumbnail_Small.PNG",
                                        FileSize = 117439,
                                        ThumbnailType = "Small"
                                    },
                                    new GameClipThumbnail()
                                    {
                                        Uri = "http://gameclipscontent-t2016.xboxlive.com/00090000040e4407-174b7bb5-eaac-4c99-9469-8af1ffa5a7ae-public/Thumbnail_Large.PNG",
                                        FileSize = 388443,
                                        ThumbnailType = "Large"
                                    },
                                },
                                TitleName = "FIFA 15",
                                DeviceType = "XboxOne"
                            }
                        },
                        Screenshots = new List<Screenshot>()
                        {
                            new Screenshot()
                            {
                                XblID = "4229575f-157c-46f4-b3bf-6fd3016fe5c4",
                                State = "Published",
                                DateTaken = new DateTime(2016, 3, 13, 10, 0, 0),
                                DatePublished = new DateTime(2016, 3, 13, 11, 1, 20),
                                ScreenshotUris = new List<ScreenshotUri>()
                                {
                                    new ScreenshotUri()
                                    {
                                        Uri = "http://screenshotscontent-t5002.xboxlive.com/00090000040e4407-4229575f-157c-46f4-b3bf-6fd3016fe5c3/Screenshot-Original.png?sv=2014-02-14&sr=c&sig=ns5imB8HmjJ5UwhNwXL%2FSUxy%2BORPDDbCTFk%2BakaKANM%3D&st=2016-03-14T10%3A22%3A28Z&se=2016-03-14T11%3A27%3A28Z&sp=r&__gda__=1457954848_d5bc47b95ca2c48eec757f55918016e6",
                                        FileSize = 2316697,
                                        UriType = "Download",
                                        Expiration = new DateTime(2016, 3, 14, 11, 30, 0)
                                    }
                                },
                                Thumbnails =new List<ScreenshotThumbnail>()
                                {
                                    new ScreenshotThumbnail()
                                    {
                                        Uri = "http://screenshotscontent-t5002.xboxlive.com/00090000040e4407-4229575f-157c-46f4-b3bf-6fd3016fe5c3/Thumbnail_Small.PNG",
                                        FileSize = 104995,
                                        ThumbnailType = "Small"
                                    },
                                    new ScreenshotThumbnail()
                                    {
                                        Uri = "http://screenshotscontent-t5002.xboxlive.com/00090000040e4407-4229575f-157c-46f4-b3bf-6fd3016fe5c3/Thumbnail_Large.PNG",
                                        FileSize = 381121,
                                        ThumbnailType = "Large"
                                    },
                                },
                                TitleName = "Call of Duty: Black Ops III",
                                DeviceType = "XboxOne"
                            }
                        },
                        Friends = new List<XboxUser>()
                        {
                            new XboxUser()
                                {
                                    XboxUserID = 2533274966272821,
                                    GamerTag = "sannestorm",
                                    GameDisplayName = "sannestorm",
                                    Gamerscore = 1123,
                                    GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/sannestorm/avatarpic-l.png",
                                    AccountTier = "Gold",
                                    XboxOneRep = "GoodPlayer",
                                    TenureLevel = 5,
                                    ProfileLastSyncedAt = DateTime.UtcNow.AddDays(-2),
                                    ActivitiesLastSyncedAtt = DateTime.UtcNow.AddDays(-2),
                                    Activities = new List<Activity>()
                                    {
                                        new Activity()
                                        {
                                            StartTime = new DateTime(2015, 1, 29, 16, 30, 0),
                                            EndTime = new DateTime(2015, 1, 29, 16, 30, 0).AddMinutes(56),
                                            SessionDurationInMinutes = 56,
                                            Description = "started playing Neverwinter",
                                            ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcRWAO9fIEHfP2JgHNXxYKbL8hw8SsHT9BpeqdxYuutDM.EoYH7IQq1qDPTpzHAZtivANzoXLx5a8kcLvzbnHHy0hnidQFsq1ZlahDpE8Cx5NWMtHBrK00CU1jnfw.fwq5htGKcIUj3_hvBtAS0IDUl2UjviT6xdk3hti9Dga.TxY-",
                                            ContentType = "Game",
                                            Platform = "XboxOne"
                                        },
                                        new Activity()
                                        {
                                            StartTime = new DateTime(2015, 1, 29, 16, 03, 0),
                                            EndTime = new DateTime(2015, 1, 29, 16, 03, 0).AddMinutes(67),
                                            SessionDurationInMinutes = 67,
                                            Description = "started played Call of Duty : Black Ops III",
                                            ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcjH7Y0zrFAw6OK32H4ByBTK3XKBmgscHXo2gFp5bhlVNjbzVQEZL_0RqOgZ0YLcPZrbZ3onMk4HYyw9FWFp6DRGcN0PEglZNbhwPW5Z4mcXnjLDzS_0GuWKRUgiHfGTzcB_Eugs4WrQhdhOwoSFl4im3rKBja28bj_4Y0wyKNPcg-",
                                            ContentType = "Game",
                                            Platform = "XboxOne"
                                        }
                                    }
                                },
                            new XboxUser()
                                {
                                    XboxUserID = 2533274903999153,
                                    GamerTag = "TopsidePlague18",
                                    GameDisplayName = "TopsidePlague18",
                                    Gamerscore = 15200,
                                    GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/dustwolf83/avatarpic-l.png",
                                    AccountTier = "Gold",
                                    XboxOneRep = "GoodPlayer",
                                    TenureLevel = 5,
                                    ProfileLastSyncedAt = DateTime.UtcNow.AddDays(-2),
                                    ActivitiesLastSyncedAtt = DateTime.UtcNow.AddDays(-2),
                                    Activities = new List<Activity>()
                                    {
                                        new Activity()
                                        {
                                            StartTime = new DateTime(2014, 1, 29, 16, 32, 0),
                                            EndTime = new DateTime(2014, 1, 29, 16, 32, 0).AddMinutes(43),
                                            SessionDurationInMinutes = 43,
                                            Description = "started played Call of Duty : Black Ops III",
                                            ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcjH7Y0zrFAw6OK32H4ByBTK3XKBmgscHXo2gFp5bhlVNjbzVQEZL_0RqOgZ0YLcPZrbZ3onMk4HYyw9FWFp6DRGcN0PEglZNbhwPW5Z4mcXnjLDzS_0GuWKRUgiHfGTzcB_Eugs4WrQhdhOwoSFl4im3rKBja28bj_4Y0wyKNPcg-",
                                            ContentType = "Game",
                                            Platform = "XboxOne"
                                        }
                                    }
                                }
                        },
                        Activities = new List<Activity>()
                        {
                            new Activity()
                            {
                                StartTime = new DateTime(2015, 12, 29, 11, 15, 0),
                                EndTime = new DateTime(2015, 12, 29, 11, 15, 0).AddMinutes(234),
                                SessionDurationInMinutes = 234,
                                Description = "started played Call of Duty : Black Ops III",
                                ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcjH7Y0zrFAw6OK32H4ByBTK3XKBmgscHXo2gFp5bhlVNjbzVQEZL_0RqOgZ0YLcPZrbZ3onMk4HYyw9FWFp6DRGcN0PEglZNbhwPW5Z4mcXnjLDzS_0GuWKRUgiHfGTzcB_Eugs4WrQhdhOwoSFl4im3rKBja28bj_4Y0wyKNPcg-",
                                ContentType = "Game",
                                            Platform = "XboxOne"
                            },
                            new Activity()
                            {
                                StartTime = new DateTime(2015, 12, 28, 16, 30, 0),
                                EndTime = new DateTime(2015, 12, 28, 16, 30, 0).AddMinutes(89),
                                SessionDurationInMinutes = 89,
                                Description = "started using YouTube",
                                ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcfmT6K0_URanUCgqFXgCAXyvPNg_c6BfJukM52FJMY5ppQAAM3TEWK7go0kUeRWBw7oIqU5QGr1Yk5DkumcGhQir.7c2euMCsdmH6k7gZEv_LUNcUpobVfd2OdnYyrj5PO7lVBfP1C9P_R0dyKLWR.rbShckTGC5IJ0tWIeckCQU-",
                                ContentType = "Game",
                                            Platform = "XboxOne"
                            },
                            new Activity()
                            {
                                StartTime = new DateTime(2015, 12, 27, 15, 41, 0),
                                EndTime = new DateTime(2015, 12, 27, 15, 41, 0).AddMinutes(45),
                                SessionDurationInMinutes = 45,
                                Description = "started using Halo 4",
                                ImageUrl = "http://images-eds.xboxlive.com/image?url=S35PkG.Po6AuYMOCXUZRrEOttKZnyhla8BAvz_.mFVKA4u8jVObzUIIr.IPhFRiAXDCYYehBCXOsKscjqVzwuCYSJBwccmeJnSsz4h1UmIXz5lLzqSV0sGlxrlDgbRSAU0qGZX0lXGmyh3_0sD0pXQ--",
                                ContentType = "Game",
                                Platform = "XboxOne"
                            }
                        }
                    }
                }
            };
        }

        private static List<XboxUser> GetXboxUsers()
        {
            return new List<XboxUser>()
            {
                new XboxUser
                {
                    GamerTag = "scozzard",
                    GameDisplayName = "scozzard",
                    Gamerscore = 22230,
                    GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/scozzard/avatarpic-l.png",
                    AccountTier = "Gold",
                    XboxOneRep = "GoodPlayer",
                    ProfileLastSyncedAt = DateTime.UtcNow,
                    Friends = new List<XboxUser>()
                    {
                        new XboxUser()
                            {
                                GamerTag = "sannestorm",
                                GameDisplayName = "sannestorm",
                                Gamerscore = 1123,
                                GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/sannestorm/avatarpic-l.png",
                                AccountTier = "Gold",
                                XboxOneRep = "GoodPlayer",
                                ProfileLastSyncedAt = DateTime.UtcNow,
                                Activities = new List<Activity>()
                                {
                                    new Activity()
                                    {
                                        StartTime = new DateTime(2015, 1, 29, 16, 30, 0),
                                        Description = "started playing Neverwinter",
                                        ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcRWAO9fIEHfP2JgHNXxYKbL8hw8SsHT9BpeqdxYuutDM.EoYH7IQq1qDPTpzHAZtivANzoXLx5a8kcLvzbnHHy0hnidQFsq1ZlahDpE8Cx5NWMtHBrK00CU1jnfw.fwq5htGKcIUj3_hvBtAS0IDUl2UjviT6xdk3hti9Dga.TxY-"
                                    },
                                    new Activity()
                                    {
                                        StartTime = new DateTime(2015, 1, 29, 16, 03, 0),
                                        Description = "started played Call of Duty : Black Ops III",
                                        ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcjH7Y0zrFAw6OK32H4ByBTK3XKBmgscHXo2gFp5bhlVNjbzVQEZL_0RqOgZ0YLcPZrbZ3onMk4HYyw9FWFp6DRGcN0PEglZNbhwPW5Z4mcXnjLDzS_0GuWKRUgiHfGTzcB_Eugs4WrQhdhOwoSFl4im3rKBja28bj_4Y0wyKNPcg-"
                                    }
                                }
                            },
                        new XboxUser()
                            {
                                GamerTag = "dustwolf83",
                                GameDisplayName = "dustwolf83",
                                Gamerscore = 15200,
                                GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/dustwolf83/avatarpic-l.png",
                                AccountTier = "Gold",
                                XboxOneRep = "GoodPlayer",
                                ProfileLastSyncedAt = DateTime.UtcNow,
                                Activities = new List<Activity>()
                                {
                                    new Activity()
                                    {
                                        StartTime = new DateTime(2014, 1, 29, 16, 32, 0),
                                        Description = "started played Call of Duty : Black Ops III",
                                        ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcjH7Y0zrFAw6OK32H4ByBTK3XKBmgscHXo2gFp5bhlVNjbzVQEZL_0RqOgZ0YLcPZrbZ3onMk4HYyw9FWFp6DRGcN0PEglZNbhwPW5Z4mcXnjLDzS_0GuWKRUgiHfGTzcB_Eugs4WrQhdhOwoSFl4im3rKBja28bj_4Y0wyKNPcg-"
                                    }
                                }
                            }
                    },
                    Activities = new List<Activity>()
                    {
                        new Activity()
                        {
                            StartTime = new DateTime(2015, 12, 29, 11, 15, 0),
                            Description = "started played Call of Duty : Black Ops III",
                            ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcjH7Y0zrFAw6OK32H4ByBTK3XKBmgscHXo2gFp5bhlVNjbzVQEZL_0RqOgZ0YLcPZrbZ3onMk4HYyw9FWFp6DRGcN0PEglZNbhwPW5Z4mcXnjLDzS_0GuWKRUgiHfGTzcB_Eugs4WrQhdhOwoSFl4im3rKBja28bj_4Y0wyKNPcg-"
                        },
                        new Activity()
                        {
                            StartTime = new DateTime(2015, 12, 28, 16, 30, 0),
                            Description = "started using YouTube",
                            ImageUrl = "http://images-eds.xboxlive.com/image?url=8Oaj9Ryq1G1_p3lLnXlsaZgGzAie6Mnu24_PawYuDYIoH77pJ.X5Z.MqQPibUVTcfmT6K0_URanUCgqFXgCAXyvPNg_c6BfJukM52FJMY5ppQAAM3TEWK7go0kUeRWBw7oIqU5QGr1Yk5DkumcGhQir.7c2euMCsdmH6k7gZEv_LUNcUpobVfd2OdnYyrj5PO7lVBfP1C9P_R0dyKLWR.rbShckTGC5IJ0tWIeckCQU-"
                        },
                        new Activity()
                        {
                            StartTime = new DateTime(2015, 12, 27, 15, 41, 0),
                            Description = "started using Halo 4",
                            ImageUrl = "http://images-eds.xboxlive.com/image?url=S35PkG.Po6AuYMOCXUZRrEOttKZnyhla8BAvz_.mFVKA4u8jVObzUIIr.IPhFRiAXDCYYehBCXOsKscjqVzwuCYSJBwccmeJnSsz4h1UmIXz5lLzqSV0sGlxrlDgbRSAU0qGZX0lXGmyh3_0sD0pXQ--"
                        }
                    }
                }
            };
        }
    }
}
