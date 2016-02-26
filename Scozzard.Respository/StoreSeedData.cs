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
                    Name = "Scott Walker",
                    Password = "1234",
                    Email = "scot.walker@gmail.com",
                    LastSynced = DateTime.UtcNow,
                    XboxUser = new XboxUser
                    {
                        GamerTag = "scozzard",
                        GameDisplayName = "scozzard",
                        Gamerscore = 22230,
                        GameDisplayPicRaw = "http://avatar.xboxlive.com/avatar/scozzard/avatarpic-l.png",
                        AccountTier = "Gold",
                        XboxOneRep = "GoodPlayer",
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
