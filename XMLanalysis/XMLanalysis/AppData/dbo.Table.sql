CREATE TABLE [dbo].[FarmTran] (
    [Id]   INT            NOT NULL,
    [交易日期] NVARCHAR (MAX) NULL,
    [作物代號] NVARCHAR (MAX) NULL,
    [作物名稱] NVARCHAR (MAX) NULL,
    [市場代號] NVARCHAR (MAX) NULL,
    [市場名稱] NVARCHAR (MAX) NULL,
    [上價]   FLOAT (53)     NULL,
    [中價]   FLOAT (53)     NULL,
    [下價]   FLOAT (53)     NULL,
    [平均價]  FLOAT (53)     NULL,
    [交易量]  FLOAT (53)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

