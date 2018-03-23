USE [CosmicCakes]
GO
SET IDENTITY_INSERT [dbo].[CommonSweets] ON 

INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (1, N'Ягодный   венок', N'Торт с венком/полумесяцем из несезонных ягод', N'Торт с венком/полумесяцем из несезонных ягод', 1.5, 1, CAST(0.00 AS Decimal(18, 2)), 3, 1800, 1, N'/Content/Images/Backgrounds/crown.jpg', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (2, N'Акварельный   торт', N'Торт с акварельным декором', N'Торт с акварельным декором', 1.5, 1, CAST(0.00 AS Decimal(18, 2)), 3, 1800, 1, N'/Content/Images/Backgrounds/aquarel.jpg', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (3, N'Cosmic   Cake', N'Мерцающий торт в космическом оформлении', N'Мерцающий торт в космическом оформлении', 1.5, 1, CAST(0.00 AS Decimal(18, 2)), 3, 1800, 1, N'/Content/Images/Backgrounds/cosmic.jpg', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (5, N'Цветочный   тортик', N'Торт с живыми цветами в оформлении', N'Торт с живыми цветами в оформлении', 1.5, 1, CAST(0.00 AS Decimal(18, 2)), 3, 1800, 1, N'/Content/Images/Backgrounds/flower.jpg', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (9, N'Двухъярусный   торт', N'Двухъярусный торт с разными бисквитами и начинками в ярусах и ягодным оформлением', N'Двухъярусный торт с разными бисквитами и начинками в ярусах и ягодным оформлением', 3, 1, CAST(0.00 AS Decimal(18, 2)), 6, 1800, 0, N'/Content/Images/Backgrounds/doubleleveled.jpg', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (10, N'Свадебный торт', N'Свадебный торт для вашего торжества', N'Вес рассчитывается 200-250гр. на человека.

К любому свадебному торту мы подойдем с особым вниманием, разработаем план, концепцию и индивидуальный стиль.
Готовы ЛИЧНО встретиться с парой для обсуждения. Ждем ваших идей, и сами подскажем как все сделать наилучшим образом :)

При любом заказе свадебного торта ОТДЕЛЬНО оплачивается доставка до места, где проходит мероприятие.

Также к свадебному торту всегда остается актуальным Candy Bar - капкейки/трафайлы/макаронс и другие сладости, помимо торта , для создания красивого свадебного стола для ваших гостей :) Дополнительно оплачиваются:
 свадебный топпер
 и живые или «стеклянные» цветы (под цвет и декор свадьбы и/или букета невесты)', 3, 1, CAST(0.00 AS Decimal(18, 2)), 12, 1800, 1, N'', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (13, N'Единорог', N'Мифический торт-единорожка со сказочной гривой', N'Обращаем Ваше внимание, вес торта от 2,5 кг, потому, что такой торт меньшего веса эффектно выглядеть не будет ', 2.5, 1, CAST(0.00 AS Decimal(18, 2)), 15, 1800, 1, N'/', 1, 1, 0)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (14, N'Капкейки', N'Бисквитное пирожное с шапочкой из сливочного крема и ягодами', N'Бисквитное пирожное с шапочкой из сливочного крема и ягодами', 0, 6, CAST(200.00 AS Decimal(18, 2)), 0, 0, 0, N'/', 1, 0, 1)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (15, N'Пирожное Павлова', N'Воздушное облако безе со свежими ягодами', N'Воздушное облако безе со свежими ягодами', 0, 6, CAST(200.00 AS Decimal(18, 2)), 0, 0, 0, N'/', 1, 0, 1)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (16, N'Макаронс', N'Французское миндальное печенье', N'Французское миндальное печенье', 0, 6, CAST(80.00 AS Decimal(18, 2)), 0, 0, 0, N'/', 1, 0, 1)
INSERT [dbo].[CommonSweets] ([Id], [Name], [Description], [MainInfo], [MinWeight], [MinOrderItemsCount], [PricePerItem], [MaxWeight], [PricePerKilo], [IsLevelable], [BackgroundImagePath], [IsActive], [IsCake], [IsAdditionalSweet]) VALUES (17, N'Ящик Пандоры', N'4  вкуснейших капкейка и цветы от наших друзей @ELGREENFLOWERS', N'4  вкуснейших капкейка и цветы от наших друзей @ELGREENFLOWERS', 0, 1, CAST(2850.00 AS Decimal(18, 2)), 0, 0, 0, N'/', 1, 0, 1)
SET IDENTITY_INSERT [dbo].[CommonSweets] OFF
SET IDENTITY_INSERT [dbo].[IndividualPriceIncludements] ON 

INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (1, N'Любой бисквит и начинка ', 1)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (2, N'Венок / полумесяц  из ягод (клубника, голубика, ежевика, красная смородина, малина, кумкват)', 1)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (3, N'Шоколадные или карамельные подтеки - на ваш выбор ', 1)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (4, N'Покрытие белым или цветным кремом  - на ваш выбор (укажите цвет крема в комментариях к заказу; белый крем по умолчанию)', 1)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (5, N'Шоколадная надпись (укажите ее текст в комментариях к заказу)', 1)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (6, N'Любой бисквит и начинка ', 2)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (8, N'Покрытие белым (цветным) кремом с цветным узором (любые пожелания по цвету мы с вами обговорим) ', 2)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (9, N'Шоколадная надпись (укажите ее текст в комментариях к заказу)', 2)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (10, N'Венок / полумесяц / горка (горка добавляет к стоимости 500р.)  из ягод (клубника, голубика, ежевика, красная смородина, малина, кумкват) ', 2)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (11, N'Любой бисквит и начинка ', 3)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (12, N'Покрытие кремом в «космическом» стиле', 3)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (13, N'Венок / полумесяц / горка (горка добавляет к стоимости 500р.)  из ягод (клубника, голубика, ежевика, красная смородина, малина, кумкват) ', 3)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (14, N'Съедобные сахарные бусины', 3)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (15, N'Съедобные фиолетовые и серебряный блёстки, создающие магическое мерцание', 3)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (21, N'Любой бисквит и начинка в нижний ярус', 9)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (22, N'Любой бисквит и начинка в верхний ярус', 9)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (23, N'Шоколадные или карамельные подтеки - на ваш выбор ', 9)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (24, N'Покрытие белым или цветным кремом  - на ваш выбор (укажите цвет крема в комментариях к заказу; белый крем по умолчанию)', 9)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (25, N'Венок / полумесяц / горка (горка добавляет к стоимости 500р.)  из ягод (клубника, голубика, ежевика, красная смородина, малина, кумкват) ', 9)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (26, N'При оформлении венком - шоколадная надпись (укажите ее текст в комментариях к заказу)', 9)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (27, N'Любой бисквит и начинка ', 5)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (28, N'Покрытие белым (цветным) кремом с цветным узором (любые пожелания по цвету мы с вами обговорим) ', 5)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (29, N'Шоколадная надпись (укажите ее текст в комментариях к заказу)', 5)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (30, N'Венок / полумесяц / горка (горка добавляет к стоимости 500р.)  из ягод (клубника, голубика, ежевика, красная смородина, малина, кумкват) ', 5)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (31, N'Живые цветы оплачиваются ОТДЕЛЬНО в зависимости от количества и стоимости. Они предают невероятную легкость и красоту каждому торту, особенно на свадебное торжество  (укажите ваши пожелания в комментариях, все согласуем по телефону)', 5)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (45, N'Любой бисквит и начинка в каждый ярус', 10)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (46, N'Шоколадные или карамельные подтеки - на ваш выбор', 10)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (47, N'Покрытие белым или цветным кремом - на ваш выбор (укажите цвет крема в комментариях к заказу; белый крем по умолчанию)', 10)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (48, N'Венок / полумесяц / горка (горка добавляет к стоимости 500р.)  из ягод (клубника, голубика, ежевика, красная смородина, малина, кумкват) ', 10)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (52, N'Любой бисквит и начинка ', 13)
INSERT [dbo].[IndividualPriceIncludements] ([Id], [IncludementInfo], [SweetId]) VALUES (54, N'Оформление "Единорог" (грива любой цветовой гаммы, золотой рог и уши из мастики)', 13)
SET IDENTITY_INSERT [dbo].[IndividualPriceIncludements] OFF
SET IDENTITY_INSERT [dbo].[SweetImages] ON 

INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (1, N'/Content/Images/CrownCake/StartPage/cr_cake_start_1.jpg', 1)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (2, N'/Content/Images/CrownCake/StartPage/cr_cake_start_2.jpg', 1)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (3, N'/Content/Images/CrownCake/StartPage/cr_cake_start_3.jpg', 1)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (4, N'/Content/Images/CrownCake/StartPage/cr_cake_start_4.jpg', 1)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (5, N'/Content/Images/CosmicCake/StartPage/csm_cake_start_1.jpg', 3)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (6, N'/Content/Images/CosmicCake/StartPage/csm_cake_start_2.jpg', 3)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (7, N'/Content/Images/CosmicCake/StartPage/csm_cake_start_3.jpg', 3)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (8, N'/Content/Images/CosmicCake/StartPage/csm_cake_start_4.jpg', 3)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (9, N'/Content/Images/AquarelCake/StartPage/aq_cake_start_1.jpg', 2)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (10, N'/Content/Images/AquarelCake/StartPage/aq_cake_start_2.jpg', 2)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (11, N'/Content/Images/AquarelCake/StartPage/aq_cake_start_3.jpg', 2)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (12, N'/Content/Images/AquarelCake/StartPage/aq_cake_start_4.jpg', 2)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (13, N'/Content/Images/FlowerCake/StartPage/fl_cake_start_1.jpg', 5)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (14, N'/Content/Images/FlowerCake/StartPage/fl_cake_start_2.jpg', 5)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (15, N'/Content/Images/FlowerCake/StartPage/fl_cake_start_3.jpg', 5)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (16, N'/Content/Images/FlowerCake/StartPage/fl_cake_start_4.jpg', 5)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (17, N'/Content/Images/DoubleLeveledCake/StartPage/dl_cake_start_1.jpg', 9)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (18, N'/Content/Images/DoubleLeveledCake/StartPage/dl_cake_start_2.jpg', 9)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (19, N'/Content/Images/DoubleLeveledCake/StartPage/dl_cake_start_3.jpg', 9)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (20, N'/Content/Images/DoubleLeveledCake/StartPage/dl_cake_start_4.jpg', 9)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (21, N'/Content/Images/WeddingCake/StartPage/wed_cake_start_1.jpg', 10)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (22, N'/Content/Images/WeddingCake/StartPage/wed_cake_start_2.jpg', 10)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (23, N'/Content/Images/WeddingCake/StartPage/wed_cake_start_3.jpg', 10)
INSERT [dbo].[SweetImages] ([Id], [Path], [SweetId]) VALUES (24, N'/Content/Images/WeddingCake/StartPage/wed_cake_start_4.jpg', 10)
SET IDENTITY_INSERT [dbo].[SweetImages] OFF
SET IDENTITY_INSERT [dbo].[SweetIndividualRectangleImages] ON 

INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (1, N'/Content/Images/CrownCake/Individual/Rectangle/cr_cake_rect_1.jpg', 1)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (2, N'/Content/Images/CrownCake/Individual/Rectangle/cr_cake_rect_2.jpg', 1)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (3, N'/Content/Images/CrownCake/Individual/Rectangle/cr_cake_rect_3.jpg', 1)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (4, N'/Content/Images/CrownCake/Individual/Rectangle/cr_cake_rect_4.jpg', 1)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (5, N'/Content/Images/CrownCake/Individual/Rectangle/cr_cake_rect_5.jpg', 1)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (6, N'/Content/Images/CrownCake/Individual/Rectangle/cr_cake_rect_6.jpg', 1)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (7, N'/Content/Images/AquarelCake/Individual/Rectangle/aq_cake_rect_1.jpg', 2)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (8, N'/Content/Images/AquarelCake/Individual/Rectangle/aq_cake_rect_2.jpg', 2)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (9, N'/Content/Images/AquarelCake/Individual/Rectangle/aq_cake_rect_3.jpg', 2)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (11, N'/Content/Images/AquarelCake/Individual/Rectangle/aq_cake_rect_4.jpg', 2)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (12, N'/Content/Images/AquarelCake/Individual/Rectangle/aq_cake_rect_5.jpg', 2)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (13, N'/Content/Images/AquarelCake/Individual/Rectangle/aq_cake_rect_6.jpg', 2)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (14, N'/Content/Images/CosmicCake/Individual/Rectangle/csm_cake_rect_1.jpg', 3)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (15, N'/Content/Images/CosmicCake/Individual/Rectangle/csm_cake_rect_2.jpg', 3)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (16, N'/Content/Images/CosmicCake/Individual/Rectangle/csm_cake_rect_3.jpg', 3)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (17, N'/Content/Images/CosmicCake/Individual/Rectangle/csm_cake_rect_4.jpg', 3)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (18, N'/Content/Images/CosmicCake/Individual/Rectangle/csm_cake_rect_5.jpg', 3)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (20, N'/Content/Images/FlowerCake/Individual/Rectangle/fl_cake_rect_1.jpg', 5)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (21, N'/Content/Images/FlowerCake/Individual/Rectangle/fl_cake_rect_2.jpg', 5)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (22, N'/Content/Images/FlowerCake/Individual/Rectangle/fl_cake_rect_3.jpg', 5)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (23, N'/Content/Images/FlowerCake/Individual/Rectangle/fl_cake_rect_4.jpg', 5)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (24, N'/Content/Images/FlowerCake/Individual/Rectangle/fl_cake_rect_5.jpg', 5)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (25, N'/Content/Images/FlowerCake/Individual/Rectangle/fl_cake_rect_6.jpg', 5)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (51, N'/Content/Images/DoubleLeveledCake/Individual/Rectangle/dl_cake_rect_1.jpg', 9)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (52, N'/Content/Images/DoubleLeveledCake/Individual/Rectangle/dl_cake_rect_2.jpg', 9)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (53, N'/Content/Images/DoubleLeveledCake/Individual/Rectangle/dl_cake_rect_3.jpg', 9)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (54, N'/Content/Images/DoubleLeveledCake/Individual/Rectangle/dl_cake_rect_4.jpg', 9)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (55, N'/Content/Images/DoubleLeveledCake/Individual/Rectangle/dl_cake_rect_5.jpg', 9)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (56, N'/Content/Images/DoubleLeveledCake/Individual/Rectangle/dl_cake_rect_6.jpg', 9)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (57, N'/Content/Images/WeddingCake/Individual/Rectangle/wed_cake_rect_1.jpg', 10)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (58, N'/Content/Images/WeddingCake/Individual/Rectangle/wed_cake_rect_2.jpg', 10)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (59, N'/Content/Images/WeddingCake/Individual/Rectangle/wed_cake_rect_3.jpg', 10)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (60, N'/Content/Images/WeddingCake/Individual/Rectangle/wed_cake_rect_4.jpg', 10)
INSERT [dbo].[SweetIndividualRectangleImages] ([Id], [Path], [SweetId]) VALUES (61, N'/Content/Images/WeddingCake/Individual/Rectangle/wed_cake_rect_5.jpg', 10)
SET IDENTITY_INSERT [dbo].[SweetIndividualRectangleImages] OFF
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201803231544206_InitialCreateComplete', N'CosmicCakes.DAL.Migrations.Configuration', 0x1F8B0800000000000400ED5C5B6FE3B8157E2FD0FF20E8A92D66E3248329B681B38B8C33698D9D5C1067B67D1B3012631323511E894A6D14FBCBF6A13FA97FA1A46EE655122539B1678C0106312FDF393CE7903C2475CEFF7EFFEFF8E7551838CF304E5084CFDD93A363D781D88B7C84E7E76E4A9E7EF8D1FDF9A73FFE61FCC10F57CEAF65BBB7AC1DED8993737741C8F26C344ABC050C417214222F8E92E8891C795138027E343A3D3EFEDBE8E4640429844BB11C677C9F62824298FDA03F2711F6E092A420B88E7C18244539AD9965A8CE0D0861B2041E3C77275142494CC017981C5D5E7C749D8B0001CAC60C064FAE03308E082094C9B34F099C9138C2F3D9921680E061BD84B4DD13081258307FB669DE761CC7A76C1CA34DC712CA4B1312859680276F0BC18CE4EE9DC4EB5682A3A2FB40454CD66CD499F8CEDDF7308ED7AE23533A9B04316BA588F6284340F4C7143F434CA2787D9461BC71A4966F2ACBA006C4FED1166940D2189E63989218046F9CBBF43140DE2F70FD107D81F81CA741C0B34B19A67542012DBA8BA3258CC9FA1E3E158398FAAE3312FB8DE48E5537AE4F3EC229266F4F5DE78612078F01ACAC8193C68C8E13FE1D62180302FD3B40088C31C380993C15EA122DF67F498D9A1F9D46AE730D561F219E93C5B9FB573A6FAED00AFA6541C1C0278CE8A4A37D489C4291C678B4D164BD7E51F23545A4AF867394838ECDB4189D1A1DBF6BA76385C17AA29730F162B4CCD706236DFA677FE2AD2D6E124310F6B4B70CE3606D9DADEDE4F8BB31B72B14041907BD0CAE4039985C67933B7DF7EE7B31B97FC060790FBFA630E9B6AF72FD0F0667A6F5210428186091EBE59B0D43848E9D1E3AD654D15B275518D6035C9101264CA7F931C53E7A463E3DB9DDC5C88353EC05A90F43AAF54ED3858150FE8FCCB0875954436B23A6297E8A06B60995DEECDF1092E6014A2037E019CDB3F14A7093280C239C81BACE3D0CB236C9022DF3C37D8D517C16BA5EC551781F05B5D6C9F7F83C8BD2D8632B4364D5ED01C47346AF9BEBCC73DC61A670FD0F53C24CAB61C97F554F866E025B71DDAF01C20DF37F6BA411FE2744F345B51F5D46D4CE3AE1DCC63E8CA70486C9244A31B15C64E44D99CDE3BB1CAF620D7A2804D4EBB88BE95FC5FDE78FAE33F300C3B52742E52B0EBE1FAFBFA020DA1AAFD3E4237C86598F92C6FB882E7E005B43BD07DE97794C75E44F433087748A2E5E7EC64D930B8FA0E7DE8399266C15ED8F72E1FB884D7F10144BBC0D60EB4D249B239DB68FAC67FEFF61FB30D39A64928571C336D2F2C6AF1DADBB4584E14D1A3E32D59AE7D1102433FD5F52C954EB0CFDFB0185F6F3EFC36A8962380814B3C3413691E2A2A7E13263185798B963D4A492AD13620F3074026F7F40540B0D563FD0210206D0230C83EE4749BFADF30AC509C980AAB790AD73EF45D87F51920F0B14BF2CC55245B718BE0ADD6BBAFBA017A57C0903EA4CC4EB1B087DE8F775074AB40B3F86C9D053B7B5B3909FD6998BD6ED029DF54C8E362807BFC14CABC109DECBEB978DE64DD72DFA16CAF58AA159AFEB941CB3BAB7B9A7EB06C0F3000E64EF06E0C314F81EA780C118EA67458B4E8689D2A667AFB9F32981F115DDE81EE941BED354E1010E53C24CEB22258BA8EE5037D459041388B7EF24353DDA0D349A1852610F72B2BC2004780BD8EA9E6A4857EC2249220F6526D4F86C26AC22E2683E60DFE9F6AE910FB2FE0D858E9EB9D94B3A11E910CEDDBF28D2B4A65FAE4A1C7D618D14099EB8F20CBFC5D47386043AEC6E8F5D794E40E2015FD53395BB2F96D04501C66C5682804E87842E330813750541D8434B10741A9684D6724562DC5674E59A4BB884982D269DF4DC86A16AC354B9AA884BB26D12E578C4D977BDD91B5C48939935F9931BB3E2CF36EDCDB8C111DD17B3AD1FC60B9869BD9EF6C52CDBB875F59664E5E3C9C66B3CBBD8DAB38DBFB85F266E31B217B37A0B9DEFDA44C89D15E62DD21E30E62E7E330F72A5FB3081BAFAC57920293C20D91819E60C12F9BA7AE31915F656442328C62CF5CF2FFCB400E55D600344F191B2D2BF286FE85D3C22E818A83E476D80E0BE01D4C1089F1836406DCC8DA949760A74E8750E5F03B1CC167598C252D100923D31E9408AB7CB563CE477311A107EDF6F875489A301D3B81C3790E1CFC23A74F1B02D81711355A7F3FACF9EB8CE761F4CC92B4DE77346258B1686AAAC6F9D4F171CD5D262E54D48946B0B999BEE3A5519B771696D9C5A6534A59DD608ACC18FDD9E805ADD84996466ED6FF5F4B854C92A6B41A38C6D7CAB3E622F6F12AACDB9AA1B8FF290C8A2603C32C44E8EAFC172C936AE4DCFA2C4991581943FCCEC830CC31C63E4259A58C38ADB8A1289622A1EA996DD50F9307BABBD04043C0276AD32F143B519E78A1856DD9292E86DA86A2C57E1B23DFBBBBC2D136F3573BF44F5D58A9E5774406C29CAC606391D1BFA392C86150420D6DC3B4EA2200DB1D91935F7CE5FE6F9FE79898A301E498C2B7EA5221CC5831765DD4E13A5DFD64B158587D74119A69EDB5147FE8909DF3F2F698F207C31CA0309153BA3DEDC77EEA35B2D420BCD1AFA1DF43A885EABD34E1FD596E7227BE51A7B1ED43B887A8593681F15F367567B35D7F6DE8EAA8BB72A1EA028DAC6A66B42E063C3781CBEBC3D9A10FEC5C309153B637C4D47C23EF65873CB616F9E3660DBB15625904B80922BDBE356B78B3C9EF1CAF1D52CA5382EF5722FCC87C8364E465DEFD7F6E887DE8B4C789B30221E6C536A81B4890A12A036C556584A649004AAD45B2CD0429C90B0440B3536525C69C7BE29B6E72E8F0CD27197D7582C347C189060BC7C457B3C6D2C108FAB6D60C36F19E623325B96DA20E5813E224E5E66C58F1CE823312657EFCC225B5CCCF75964F32B7CFBE5D5D06F3B0BAB18C2C3E38835F68842A08E0E5868D01E9F8BCAE151B9620BBF978BCB119C5FAEDC62E45C688E3060AEBC3D9A109FC3C3091516DC553138026F55A9C53256BE5A0A4B575968272F8DDD55A5169E9B1425233870529D8D06947819510F4AB50DC76A648CC8B55A6F71745783608473BC5A6D2F6B25DC452774A5913D1D4D788B8E92A6998D732806B488FEA158678F5A06B6E850CBBA9DD9F88467B53EDB1FF7F86CBF07D675DECE46A83A63B6DED75E1D1F95D7BDFEAA367D13D055FBADF10E06D1CB20C46F32FAD881F0F586BDDAEBBB6F47CB65D0018F5096D9F856454C81E85A15852F7B0FCB470408EC70E516F25183020451A9D52F6CD7CAB70072938A7A5152FDAEBE0528DEE1DB2457961EE6F3262CEF4844972AF6283F5B27048647ACC1D1EC6B300950660265836B80D113BB7CCE2279DCD3E393532945F3EEA44B1E25892F041A9972268BCA7A815824C444DA186D6419FE929F397202F819C4DE02C44A72E20DE6009988BF0DB9F10924B4727B773C4486A812FA4F2158FD79D80CBDDF891EB2AC8A3BAA08EDD3F6B7AB8A2CCDD38EAAC2F8FCBCB7EA102231DB4C0DDB6CA94361AAC9518742D6E442351ACF76F29D7E1BA664C8216A214B15538AD247DAE4B054B27075EEFE27EB73E64CFFF5B9E8F6C6C96EBECF9C63E7B7C1B645634CD7BEEAAD71B60EBC226BD249F64C533920B29C85F229880019300965A6C1015250FA5B4F41D987533E01E5E09C6A12503E227B5E6B924F0E360BE4DC925DF814F34A764330E4946C06B3CC27F96D2C88BAD48D2D4E6F3D3335EA8DCE9A829298D1A77F936112337686521333765B573579197BB91772EEC55E60527EC57E8C493914FB3951DA3C895DD6776396C49EFC993221F68235663B1C4498868C8683601BB316F642D76726ECB2A1E8B3126EE3D0647AEBDCDBBD45E7667C2327238B97C983FA764F7DE617C6BDD5969835ADA7A7206446EB85A5BD73EBC69592E1ACB38B66CC7036C0B23E781633214A3C67F34533D1B4C9383058F2B44E696FEAA318DACC5E679874633B97BBA6776EB1DD313E3E8709C7884D4AB37D30AEDAAFE576D398FA6404DB35FB32E6B3514CAE7322B2FDB1C2F61FF2BDAE614A1FFE545E8C9C3D4356BD9A836B6DCEC0957FE2439D8E4776DB9B7B05866FDD4DE9B9EAB27369E1ABAC5E0DF80DB9BB74D85955337295BC4BC1AE6A74E89B74600DF842562F858650ABA323E60C6BA055E79728A4EB1AEB3831B76FA13E7EB15395C8D76A55B969D04CABC827A65029CA75F8656EB206647E2756E0F94A1D8D4D7D5B42C6F5D740DBD8DECC8EA14B338762F6328521B15A475F4A8F2691DBB5FC671AFB55E283D57DA0DDB98283B3C8D1B753A9CCFA8A479D587268C450C37FC54465C308A96151681154D05E9416C9C7D40F8BA9B79362767791FFBA84099A6F20C61413434FF073AA36EC6380D2DF92382A9BC8CFDD90009F3A411731414FC023B4DA834992EDDEBF8220CDAE691EA13FC5B72959A6840E19868F81907694B96D75F4B30C6B22CFE3DBEC9388648821503611BBEEB9C5EF5314F815DF579A4B400304F3078BFB36A64BC2EEDDE6EB0AE926C22D810AF1556EEC030C9701054B6EF10CB0F76F7BDEE87AFF11CE81B72EBF0F3783342B4214FBF81281794C7DBD0263D39FFEA436EC87AB9FFE0F232A44CEE2880000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Berries] ON 

INSERT [dbo].[Berries] ([Id], [Name]) VALUES (1, N'Красные')
INSERT [dbo].[Berries] ([Id], [Name]) VALUES (2, N'Синие')
INSERT [dbo].[Berries] ([Id], [Name]) VALUES (3, N'Микс')
SET IDENTITY_INSERT [dbo].[Berries] OFF
SET IDENTITY_INSERT [dbo].[Bisquits] ON 

INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (1, N'гранд шоколад', N'Сочные бисквиты с какао и кусочками настоящего шоколада. Тяжёлые, влажные, прекрасно сочетаются с домашней карамелью или ягодными начинками (муссы, желе, свежие ягоды)')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (2, N'vanilla
', N'Воздушные бисквиты с добавлением настоящей стручковой ванили. Легкие, нежные, прекрасно сочетаются со свежими начинками (свежие ягоды, желе, чизкейками, муссы, курды)')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (3, N'цитрусовый бум', N'Лимон, лайм или мандарин.
Цитрусовые нотки в легком тающем бисквите. Отлично сочетается с ягодами, чизкейками, курдами, муссами.')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (5, N'миндальный', N'Легкий бисквит с добавлением миндальной муки. Нежный ореховый вкус. Сочетается с крупными орехами, карамелью, карамелизированными орешками, пралине.')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (6, N'lavender lace', N'Неожиданно тонкие оттенки лаванды. Необычный, немного пряный вкус. Тандем нежности и смелости. Сочетается с лавандовым желе, голубикой, черничным муссом.')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (7, N'wonder carrot ', N'Морковные бисквиты с орешками и корицей. Не волнуйтесь, бисквиты не имею запах овощей, а вкус сладкий, насыщенный, пряный. Идеально со свежей малиной и карамелью, карамелизированными орешками, пралине и чизкейками. Бисквиты, которые не оставят вас равнодушными!
')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (8, N'red velvet ', N'Он же красный бархат. Страстный, сочный, всегда вызывает восторг у гостей! Красные бисквиты с насыщенным шоколадным вкусом. Сочетаются со всеми видами начинок, тут можно проявить фантазию!
')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (9, N'biscuits of Queen Victoria', N'Бисквиты Королевы Виктории. Более плотные, но не менее потрясающие ванильные бисквиты с настоящей ванилью. Отлично подходят к любым начинкам.')
INSERT [dbo].[Bisquits] ([Id], [Type], [Description]) VALUES (11, N'черничные облака', N'Ванильные бисквиты с вкраплениями свежей черники. Свежо, сладко, необычно! 
Сочетаются с черничным и шоколадным муссом, свежими ягодами.')
SET IDENTITY_INSERT [dbo].[Bisquits] OFF
SET IDENTITY_INSERT [dbo].[Creams] ON 

INSERT [dbo].[Creams] ([Id], [Type], [Description]) VALUES (1, N'крем-чиз', N'Вкус крема не приторный,  немного солоноватый; придает пикантную нотку в десерт. Если Вы сладкоежка, то напишите в комментариях, сделаем крем слаще (:')
INSERT [dbo].[Creams] ([Id], [Type], [Description]) VALUES (2, N'шоколадный крем', N'Крем на основе настоящего горького шоколада. Очень вкусный и эффектный. Для настоящих шокоголиков.')
INSERT [dbo].[Creams] ([Id], [Type], [Description]) VALUES (3, N'крем на белом шоколаде', N'Крем на основе сливок и белого бельгийскогошоколада. Сладкий, нежный, невероятно вкусный. ')
SET IDENTITY_INSERT [dbo].[Creams] OFF
SET IDENTITY_INSERT [dbo].[Fillings] ON 

INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (16, N'фруктовое желе ', N'Свежее желе на агар-агаре на основе фруктового пюре, варенья или перемолотых фруктов со свежими ягодами. Придаёт десерту легкую кислинку и насыщенность. ')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (17, N'цитрусовый курд ', N'Лимон, апельсин или мандарин - на ваш выбор! Своего рода пропитка бисквита с ярким вкусом для придания сочности.')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (18, N'муссы', N'Ягодные, фруктовые, шоколадные. Пушистые, легкие, придают воздушность любому торту! ')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (19, N'орехи', N'Любые (дроблённые или целые) орехи в прослойке торта.')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (20, N'домашняя карамель', N'Сладкая домашняя карамель. Невероятное сочетания карамели, орешков и солоноватого крем-чиза. По вашему желанию может быть с пряными нотками корицы, имбиря и гвоздики. ')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (21, N'карамелизированные орехи ', N'Дробленые лесные орехи в домашней карамели. Хрустящие, придают пикантность десерту.
')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (22, N'свежие несезонные ягоды и фрукты', N'Свежие ягоды и фрукты придают десерту свежесть и подойдут к любому бисквиту.')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (23, N'печёный чизкейк Нью-Йорк', N'Прослойка печёного чизкейка Нью-Йорк между двумя бисквитами - как торт в торте! Неожиданно вкусная и сытная начинка.')
INSERT [dbo].[Fillings] ([Id], [Type], [Description]) VALUES (24, N'чизкейк без выпечки ', N'Чизкейк без выпечки между двумя бисквитами, своего рода прослойка натурального йогуртового вкуса.')
SET IDENTITY_INSERT [dbo].[Fillings] OFF
