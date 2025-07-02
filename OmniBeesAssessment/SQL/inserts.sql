USE [Omnibees]
GO
INSERT [dbo].[Produto] ([FK_Key], [Description], [BaseValue], [Limit], [Minimum]) VALUES (1, N'Vida Starter', CAST(10.00 AS Decimal(10, 2)), CAST(10000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Produto] ([FK_Key], [Description], [BaseValue], [Limit], [Minimum]) VALUES (2, N'Vida AP+', CAST(12.50 AS Decimal(10, 2)), CAST(20000.00 AS Decimal(10, 2)), CAST(10001.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Produto] ([FK_Key], [Description], [BaseValue], [Limit], [Minimum]) VALUES (3, N'Vida Plus Master', CAST(20.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)), CAST(20001.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Produto] ([FK_Key], [Description], [BaseValue], [Limit], [Minimum]) VALUES (4, N'Vida Galaxy Membership', CAST(4500.00 AS Decimal(10, 2)), CAST(10000000.00 AS Decimal(10, 2)), CAST(100001.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Parceiro] ([FK_Key], [Description], [User], [Password], [Secret]) VALUES (1, N'Lojas Jackelino', N'lojas.jackelino', N'708306B2A2C20CE88108C5999CA8E17F', N'XPTO2')
GO
INSERT [dbo].[Parceiro] ([FK_Key], [Description], [User], [Password], [Secret]) VALUES (2, N'Rede Cusco de La Rocha', N'rede.cusco', N'BDB64F04D5D650D83B31D52C35A8C0DA', N'IDKFA')
GO
INSERT [dbo].[Parceiro] ([FK_Key], [Description], [User], [Password], [Secret]) VALUES (3, N'Irmãos Global Membership Traders', N'irmaos.global', N'E0B6F54A3C438D52E4E4C006D0DE6B02', N'IDDQD')
GO
SET IDENTITY_INSERT [dbo].[Cotacao] ON 
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (2, 1, CAST(N'2025-07-02T09:38:51.710' AS DateTime), CAST(N'2025-07-02T09:38:51.710' AS DateTime), 1, N'paulo', 11, 994856086, N'r teresina', N'012345', N'doc123', CAST(N'1981-01-24' AS Date), CAST(123.00 AS Decimal(10, 2)), CAST(456.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (3, 1, CAST(N'2025-07-02T09:39:45.490' AS DateTime), CAST(N'2025-07-02T09:39:45.490' AS DateTime), 1, N'paulo', 11, 994856086, N'r teresina', N'012345', N'doc123', CAST(N'1981-01-24' AS Date), CAST(123.00 AS Decimal(10, 2)), CAST(456.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (4, 1, CAST(N'2025-07-02T09:49:12.073' AS DateTime), CAST(N'2025-07-02T09:49:12.073' AS DateTime), 1, N'paulo', 11, 994856086, N'r teresina', N'012345', N'doc123', CAST(N'1981-01-24' AS Date), CAST(123.00 AS Decimal(10, 2)), CAST(456.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (5, 1, CAST(N'2025-07-02T11:06:38.050' AS DateTime), CAST(N'2025-07-02T11:06:38.050' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (6, 1, CAST(N'2025-07-02T11:07:40.747' AS DateTime), CAST(N'2025-07-02T11:07:40.747' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (7, 1, CAST(N'2025-07-02T11:09:16.430' AS DateTime), CAST(N'2025-07-02T11:09:16.430' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (8, 1, CAST(N'2025-07-02T11:10:41.127' AS DateTime), CAST(N'2025-07-02T11:10:41.127' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (9, 1, CAST(N'2025-07-02T11:12:50.470' AS DateTime), CAST(N'2025-07-02T11:12:50.470' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (10, 1, CAST(N'2025-07-02T11:31:53.507' AS DateTime), CAST(N'2025-07-02T11:31:53.507' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (11, 1, CAST(N'2025-07-02T11:34:58.890' AS DateTime), CAST(N'2025-07-02T11:34:58.890' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (12, 1, CAST(N'2025-07-02T11:37:46.087' AS DateTime), CAST(N'2025-07-02T11:37:46.087' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (13, 1, CAST(N'2025-07-02T11:39:35.933' AS DateTime), CAST(N'2025-07-02T11:39:35.933' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (14, 1, CAST(N'2025-07-02T11:42:35.080' AS DateTime), CAST(N'2025-07-02T11:42:35.080' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cotacao] ([Id], [IdProduto], [DataCriacao], [DataAtualizacao], [IdParceiro], [NomeSegurado], [DDD], [Telefone], [Endereco], [CEP], [Documento], [Nascimento], [Premio], [ImportanciaSegurada]) VALUES (15, 1, CAST(N'2025-07-02T12:27:03.540' AS DateTime), CAST(N'2025-07-02T12:27:03.540' AS DateTime), 1, N'string', 0, 0, N'string', N'string', N'string', CAST(N'2015-06-30' AS Date), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[Cotacao] OFF
GO
INSERT [dbo].[TipoParentesco] ([FK_Key], [Description]) VALUES (1, N'Mae')
GO
INSERT [dbo].[TipoParentesco] ([FK_Key], [Description]) VALUES (2, N'Pai')
GO
INSERT [dbo].[TipoParentesco] ([FK_Key], [Description]) VALUES (3, N'Conjuge')
GO
INSERT [dbo].[TipoParentesco] ([FK_Key], [Description]) VALUES (4, N'Filho(a)')
GO
INSERT [dbo].[TipoParentesco] ([FK_Key], [Description]) VALUES (5, N'Outros')
GO
INSERT [dbo].[Cobertura] ([FK_Key], [Description], [Type], [Value]) VALUES (1, N'Morte Acidental', N'Basica', CAST(40.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cobertura] ([FK_Key], [Description], [Type], [Value]) VALUES (2, N'Morte Qualquer Coisa', N'Basica', CAST(36.50 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cobertura] ([FK_Key], [Description], [Type], [Value]) VALUES (3, N'Invalidez Parcial ou Total', N'Basica', CAST(28.95 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cobertura] ([FK_Key], [Description], [Type], [Value]) VALUES (4, N'Assistencia Funeral', N'Adicional', CAST(18.96 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cobertura] ([FK_Key], [Description], [Type], [Value]) VALUES (5, N'Assistencia Odontologica', N'Adicional', CAST(12.55 AS Decimal(10, 2)))
GO
INSERT [dbo].[Cobertura] ([FK_Key], [Description], [Type], [Value]) VALUES (6, N'Assistencia PET', N'Adicional', CAST(15.33 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[CotacaoCobertura] ON 
GO
INSERT [dbo].[CotacaoCobertura] ([Id], [IdCotacao], [IdCobertura], [ValorDesconto], [ValorAgravo], [ValorTotal]) VALUES (2, 14, 1, CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(40.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[CotacaoCobertura] ([Id], [IdCotacao], [IdCobertura], [ValorDesconto], [ValorAgravo], [ValorTotal]) VALUES (3, 14, 4, CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(18.96 AS Decimal(10, 2)))
GO
INSERT [dbo].[CotacaoCobertura] ([Id], [IdCotacao], [IdCobertura], [ValorDesconto], [ValorAgravo], [ValorTotal]) VALUES (4, 15, 1, CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(40.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[CotacaoCobertura] ([Id], [IdCotacao], [IdCobertura], [ValorDesconto], [ValorAgravo], [ValorTotal]) VALUES (5, 15, 4, CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(18.96 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[CotacaoCobertura] OFF
GO
INSERT [dbo].[FaixaIdade] ([Key], [Description], [Desconto], [Agravo], [BaseValue], [Limit]) VALUES (1, N'6 a 18 anos', CAST(20.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 6, 18)
GO
INSERT [dbo].[FaixaIdade] ([Key], [Description], [Desconto], [Agravo], [BaseValue], [Limit]) VALUES (2, N'19 a 25 anos', CAST(10.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 19, 25)
GO
INSERT [dbo].[FaixaIdade] ([Key], [Description], [Desconto], [Agravo], [BaseValue], [Limit]) VALUES (3, N'26 a 35 anos', CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 26, 35)
GO
INSERT [dbo].[FaixaIdade] ([Key], [Description], [Desconto], [Agravo], [BaseValue], [Limit]) VALUES (4, N'36 a 42 anos', CAST(0.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), 36, 42)
GO
INSERT [dbo].[FaixaIdade] ([Key], [Description], [Desconto], [Agravo], [BaseValue], [Limit]) VALUES (5, N'43 a 65 anos', CAST(0.00 AS Decimal(10, 2)), CAST(40.00 AS Decimal(10, 2)), 43, 65)
GO
