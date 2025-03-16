using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Database.Migrations;

[Migration(1, "Initial")]
public class Table : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table bank
    (
        number text not null,
        pin text not null,
        money decimal not null,
        
        primary key (number)
    );
    create table history
    (
        number text not null,
        MoneyBefore decimal not null,
        MoneyAfter decimal not null
    );
    create table passwords
    (
        password text not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table bank;
    drop table history;
    drop table passwords;
    """;
}