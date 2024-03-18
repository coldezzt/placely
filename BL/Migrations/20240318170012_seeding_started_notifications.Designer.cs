﻿// <auto-generated />
using System;
using BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240318170012_seeding_started_notifications")]
    partial class seeding_started_notifications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BL.Entities.Chat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("DirectoryPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("directory_path");

                    b.Property<long>("LandlordId")
                        .HasColumnType("bigint")
                        .HasColumnName("landlord_id");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_chats");

                    b.HasIndex("LandlordId")
                        .HasDatabaseName("ix_chats_landlord_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_chats_tenant_id");

                    b.ToTable("chats", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Contract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("LandlordId")
                        .HasColumnType("bigint")
                        .HasColumnName("landlord_id");

                    b.Property<DateTime>("LeaseEndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lease_end_date");

                    b.Property<DateTime>("LeaseStartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lease_start_date");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint")
                        .HasColumnName("property_id");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("tenant_id");

                    b.Property<string>("TenantPaidUtilies")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tenant_paid_utilies");

                    b.HasKey("Id")
                        .HasName("pk_contracts");

                    b.HasIndex("LandlordId")
                        .HasDatabaseName("ix_contracts_landlord_id");

                    b.HasIndex("PropertyId")
                        .HasDatabaseName("ix_contracts_property_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_contracts_tenant_id");

                    b.ToTable("contracts", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Landlord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contact_address");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_landlords");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_landlords_tenant_id");

                    b.ToTable("landlords", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.HasKey("Id")
                        .HasName("pk_messages");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_messages_author_id");

                    b.HasIndex("ChatId")
                        .HasDatabaseName("ix_messages_chat_id");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<long>("ReceiverId")
                        .HasColumnType("bigint")
                        .HasColumnName("receiver_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_notifications");

                    b.HasIndex("ReceiverId")
                        .HasDatabaseName("ix_notifications_receiver_id");

                    b.ToTable("notifications", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Content = "This is some helpful information",
                            Date = new DateOnly(2024, 3, 18),
                            IsDeleted = false,
                            ReceiverId = 2L,
                            Title = "Info"
                        },
                        new
                        {
                            Id = 2L,
                            Content = "This is some helpful information",
                            Date = new DateOnly(2024, 3, 18),
                            IsDeleted = false,
                            ReceiverId = 2L,
                            Title = "Info"
                        },
                        new
                        {
                            Id = 3L,
                            Content = "This is already readed some helpful information",
                            Date = new DateOnly(2024, 3, 18),
                            IsDeleted = false,
                            ReceiverId = 3L,
                            Title = "Info"
                        },
                        new
                        {
                            Id = 4L,
                            Content = "This is already readed some helpful information",
                            Date = new DateOnly(2024, 3, 18),
                            IsDeleted = true,
                            ReceiverId = 3L,
                            Title = "Info"
                        },
                        new
                        {
                            Id = 5L,
                            Content = "This is request on reservation",
                            Date = new DateOnly(2024, 3, 18),
                            IsDeleted = false,
                            ReceiverId = 4L,
                            Title = "Request"
                        },
                        new
                        {
                            Id = 6L,
                            Content = "This is readed request on reservation",
                            Date = new DateOnly(2024, 3, 18),
                            IsDeleted = true,
                            ReceiverId = 5L,
                            Title = "Request"
                        });
                });

            modelBuilder.Entity("BL.Entities.PriceList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("PeriodLong")
                        .HasColumnType("integer")
                        .HasColumnName("period_long");

                    b.Property<int>("PeriodMedium")
                        .HasColumnType("integer")
                        .HasColumnName("period_medium");

                    b.Property<int>("PeriodShort")
                        .HasColumnType("integer")
                        .HasColumnName("period_short");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint")
                        .HasColumnName("property_id");

                    b.HasKey("Id")
                        .HasName("pk_prices");

                    b.ToTable("prices", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Property", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("owner_id");

                    b.Property<long>("PriceListId")
                        .HasColumnType("bigint")
                        .HasColumnName("price_list_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<byte>("TypeId")
                        .HasColumnType("smallint")
                        .HasColumnName("type_id");

                    b.HasKey("Id")
                        .HasName("pk_properties");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_properties_owner_id");

                    b.ToTable("properties", (string)null);
                });

            modelBuilder.Entity("BL.Entities.PropertyOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_property_options");

                    b.ToTable("property_options", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval")
                        .HasColumnName("duration");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("entry_date");

                    b.Property<byte>("GuestsAmount")
                        .HasColumnType("smallint")
                        .HasColumnName("guests_amount");

                    b.Property<long>("LandlordId")
                        .HasColumnType("bigint")
                        .HasColumnName("landlord_id");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint")
                        .HasColumnName("property_id");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("integer")
                        .HasColumnName("reservation_status");

                    b.Property<byte>("ReservationStatusId")
                        .HasColumnType("smallint")
                        .HasColumnName("reservation_status_id");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_reservations");

                    b.HasIndex("LandlordId")
                        .HasDatabaseName("ix_reservations_landlord_id");

                    b.HasIndex("PropertyId")
                        .HasDatabaseName("ix_reservations_property_id");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_reservations_tenant_id");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint")
                        .HasColumnName("property_id");

                    b.Property<long>("Rating")
                        .HasColumnType("bigint")
                        .HasColumnName("rating");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_reviews_author_id");

                    b.HasIndex("PropertyId")
                        .HasDatabaseName("ix_reviews_property_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Tenant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("about");

                    b.Property<string>("AvatarPath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("avatar_path");

                    b.Property<long>("CreationYear")
                        .HasColumnType("bigint")
                        .HasColumnName("creation_year");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Work")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("work");

                    b.HasKey("Id")
                        .HasName("pk_tenants");

                    b.ToTable("tenants", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            About = "I'm test tenant 1",
                            AvatarPath = "",
                            CreationYear = 2024L,
                            Email = "test.tenant.1@email.domen",
                            Name = "Test tenant 1",
                            Password = "test.tenant.1@email.domen",
                            PhoneNumber = "111 1111 11 11",
                            Work = "I'm working nowhere"
                        },
                        new
                        {
                            Id = 2L,
                            About = "I'm test tenant 2",
                            AvatarPath = "",
                            CreationYear = 2024L,
                            Email = "test.tenant.2@email.domen",
                            Name = "Test tenant 2",
                            Password = "test.tenant.2@email.domen",
                            PhoneNumber = "222 2222 22 22",
                            Work = "I'm working nowhere"
                        },
                        new
                        {
                            Id = 3L,
                            About = "I'm test tenant 3",
                            AvatarPath = "",
                            CreationYear = 2024L,
                            Email = "test.tenant.3@email.domen",
                            Name = "Test tenant 3",
                            Password = "test.tenant.3@email.domen",
                            PhoneNumber = "333 3333 33 33",
                            Work = "I'm working nowhere"
                        },
                        new
                        {
                            Id = 4L,
                            About = "I'm test landlord 1",
                            AvatarPath = "",
                            CreationYear = 2024L,
                            Email = "test.landlord.1@email.domen",
                            Name = "Test landlord 1",
                            Password = "test.landlord.1@email.domen",
                            PhoneNumber = "111 1111 11 11",
                            Work = "I'm working here"
                        },
                        new
                        {
                            Id = 5L,
                            About = "I'm test landlord 2",
                            AvatarPath = "",
                            CreationYear = 2024L,
                            Email = "test.landlord.2@email.domen",
                            Name = "Test landlord 2",
                            Password = "test.landlord.2@email.domen",
                            PhoneNumber = "222 2222 22 22",
                            Work = "I'm working here"
                        },
                        new
                        {
                            Id = 6L,
                            About = "I'm test landlord 3",
                            AvatarPath = "",
                            CreationYear = 2024L,
                            Email = "test.landlord.3@email.domen",
                            Name = "Test landlord 3",
                            Password = "test.landlord.3@email.domen",
                            PhoneNumber = "333 3333 33 33",
                            Work = "I'm working here"
                        });
                });

            modelBuilder.Entity("PropertyPropertyOption", b =>
                {
                    b.Property<long>("OptionsId")
                        .HasColumnType("bigint")
                        .HasColumnName("options_id");

                    b.Property<long>("PropertiesId")
                        .HasColumnType("bigint")
                        .HasColumnName("properties_id");

                    b.HasKey("OptionsId", "PropertiesId")
                        .HasName("pk_property_property_option");

                    b.HasIndex("PropertiesId")
                        .HasDatabaseName("ix_property_property_option_properties_id");

                    b.ToTable("property_property_option", (string)null);
                });

            modelBuilder.Entity("PropertyTenant", b =>
                {
                    b.Property<long>("FavouriteId")
                        .HasColumnType("bigint")
                        .HasColumnName("favourite_id");

                    b.Property<long>("InFavouritesId")
                        .HasColumnType("bigint")
                        .HasColumnName("in_favourites_id");

                    b.HasKey("FavouriteId", "InFavouritesId")
                        .HasName("pk_property_tenant");

                    b.HasIndex("InFavouritesId")
                        .HasDatabaseName("ix_property_tenant_in_favourites_id");

                    b.ToTable("property_tenant", (string)null);
                });

            modelBuilder.Entity("BL.Entities.Chat", b =>
                {
                    b.HasOne("BL.Entities.Landlord", "Landlord")
                        .WithMany("Chats")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chats_landlords_landlord_id");

                    b.HasOne("BL.Entities.Tenant", "Tenant")
                        .WithMany("Chats")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_chats_tenants_tenant_id");

                    b.Navigation("Landlord");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BL.Entities.Contract", b =>
                {
                    b.HasOne("BL.Entities.Landlord", "Landlord")
                        .WithMany("Contracts")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contracts_landlords_landlord_id");

                    b.HasOne("BL.Entities.Property", "Property")
                        .WithMany("Contracts")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contracts_properties_property_id");

                    b.HasOne("BL.Entities.Tenant", "Tenant")
                        .WithMany("Contracts")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contracts_tenants_tenant_id");

                    b.Navigation("Landlord");

                    b.Navigation("Property");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BL.Entities.Landlord", b =>
                {
                    b.HasOne("BL.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_landlords_tenants_tenant_id");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BL.Entities.Message", b =>
                {
                    b.HasOne("BL.Entities.Tenant", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_messages_tenants_author_id");

                    b.HasOne("BL.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_messages_chats_chat_id");

                    b.Navigation("Author");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("BL.Entities.Notification", b =>
                {
                    b.HasOne("BL.Entities.Tenant", "Receiver")
                        .WithMany("Notifications")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_notifications_tenants_receiver_id");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("BL.Entities.Property", b =>
                {
                    b.HasOne("BL.Entities.PriceList", "PriceList")
                        .WithOne("Property")
                        .HasForeignKey("BL.Entities.Property", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_properties_prices_id");

                    b.HasOne("BL.Entities.Landlord", "Owner")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_properties_landlords_owner_id");

                    b.Navigation("Owner");

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("BL.Entities.Reservation", b =>
                {
                    b.HasOne("BL.Entities.Landlord", "Landlord")
                        .WithMany("Reservations")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reservations_landlords_landlord_id");

                    b.HasOne("BL.Entities.Property", "Property")
                        .WithMany("Reservations")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reservations_properties_property_id");

                    b.HasOne("BL.Entities.Tenant", "Tenant")
                        .WithMany("Reservations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reservations_tenants_tenant_id");

                    b.Navigation("Landlord");

                    b.Navigation("Property");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BL.Entities.Review", b =>
                {
                    b.HasOne("BL.Entities.Tenant", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_tenants_author_id");

                    b.HasOne("BL.Entities.Property", "Property")
                        .WithMany("Reviews")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_properties_property_id");

                    b.Navigation("Author");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropertyPropertyOption", b =>
                {
                    b.HasOne("BL.Entities.PropertyOption", null)
                        .WithMany()
                        .HasForeignKey("OptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_property_property_option_property_options_options_id");

                    b.HasOne("BL.Entities.Property", null)
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_property_property_option_properties_properties_id");
                });

            modelBuilder.Entity("PropertyTenant", b =>
                {
                    b.HasOne("BL.Entities.Property", null)
                        .WithMany()
                        .HasForeignKey("FavouriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_property_tenant_properties_favourite_id");

                    b.HasOne("BL.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("InFavouritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_property_tenant_tenants_in_favourites_id");
                });

            modelBuilder.Entity("BL.Entities.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("BL.Entities.Landlord", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Contracts");

                    b.Navigation("Properties");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("BL.Entities.PriceList", b =>
                {
                    b.Navigation("Property")
                        .IsRequired();
                });

            modelBuilder.Entity("BL.Entities.Property", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BL.Entities.Tenant", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Contracts");

                    b.Navigation("Notifications");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
